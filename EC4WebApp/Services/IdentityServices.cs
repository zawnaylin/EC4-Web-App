using EC4WebApp.Contracts.V1.Requests;
using EC4WebApp.Contracts.V1.Responses;
using EC4WebApp.Data;
using EC4WebApp.Domains;
using EC4WebApp.Extensions;
using EC4WebApp.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EC4WebApp.Services
{
    public class IdentityServices : IIdentityServices
    {
        private readonly DataContext _datacontext;
        private readonly UserManager<User> _userManager;
        private readonly IJwtServices _jwtServices;

        public IdentityServices(DataContext datacontext, UserManager<User> userManager, IJwtServices jwtServices)
        {
            _datacontext = datacontext;
            _userManager = userManager;
            _jwtServices = jwtServices;
        }

        public async Task<AuthenticationResults> LoginAsync(UserRequest userLoginRequest)
        {
            var user = await _userManager.FindByUserNameAsync(userLoginRequest.UserName);
            if (user == null)
            {
                return ReturnAuthError("Username does not exists.");
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, userLoginRequest.Password);

            if (!isPasswordCorrect)
            {
                return ReturnAuthError("Username or Password is wrong.");
            }
            return new AuthenticationResults
            {
                Success = true,
                Token = await _jwtServices.GenerateTokenAsync(user),
                UserId = user.Id,
                DisplayName = user.DisplayName
            };
        }


        private static AuthenticationResults ReturnAuthError(string error)
        {
            return new AuthenticationResults
            {
                Success = false,
                Errors = new string[] { error }
            };
        }

        private static AuthenticationResults ReturnAuthError(IEnumerable<string> errors)
        {
            return new AuthenticationResults
            {
                Success = false,
                Errors = errors
            };
        }

        public async Task<AuthenticationResults> UpdateAsync(UserUpdateRequest userUpdateRequest, string userId)
        {
            var result = _userManager.FindByIdAsync(userId);
            if (result == null)
            {
                return ReturnAuthError("User can't be found.");
            }

            User user = new User
            {
                Id = userId,
                UserName = userUpdateRequest.UserName,
                NormalizedUserName = userUpdateRequest.UserName.ToUpper(),
                PhoneNumber = userUpdateRequest.PhoneNumber,
                PhoneNumberConfirmed = true,
                Email = userUpdateRequest.Email,
                NormalizedEmail = userUpdateRequest.Email.ToUpper(),
                PhotoPath = userUpdateRequest.PhotoPath,
                DateOfBirth = userUpdateRequest.DateOfBirth,
                Description = userUpdateRequest.Description
            };
            var iresult = await _userManager.UpdateAsync(user);
            if (!iresult.Succeeded)
            {
                return ReturnAuthError(iresult.Errors.Select(x => x.Description));
            }

            return new AuthenticationResults
            {
                Success = true
            };
        }

        public async Task<List<UserResponsePublic>> GetAllAsync()
        {
            return await (from user in _datacontext.Users
                          select new UserResponsePublic
                          {
                              DisplayName = user.DisplayName,
                              Email = user.Email,
                              Description = user.Description,
                              PhotoPath = user.PhotoPath
                          }).ToListAsync();

        }

        public async Task<UserResponsePublic> GetUserAsync(string userId, string jwt)
        { 
            if(jwt is not null)
            {
                var token = _jwtServices.VerifyToken(jwt);
                if (token?.Claims.Single(x => x.Type == JwtRegisteredClaimNames.NameId).Value == userId)
                {
                    return await (from user in _datacontext.Users
                                    where user.Id == userId
                                    select new UserResponseOwn
                                    {
                                        DisplayName = user.DisplayName,
                                        DateOfBirth = user.DateOfBirth,
                                        Description = user.Description,
                                        Email = user.Email,
                                        Phone = user.PhoneNumber,
                                        PhotoPath = user.PhotoPath,
                                        StudentId = user.StudentId
                                    }).FirstOrDefaultAsync();
                }
            }

            return await (from user in _datacontext.Users
                          where user.Id == userId
                          select new UserResponsePublic
                          {
                              DisplayName = user.DisplayName,
                              Description = user.Description,
                              Email = user.Email,
                              PhotoPath = user.PhotoPath
                          }).FirstOrDefaultAsync();
        }
    }
}
