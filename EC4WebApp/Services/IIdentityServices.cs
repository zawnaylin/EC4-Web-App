using EC4WebApp.Contracts.V1.Requests;
using EC4WebApp.Contracts.V1.Responses;
using EC4WebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EC4WebApp.Services
{
    public interface IIdentityServices
    {
        /// <summary>
        /// Log in with Username and Password. 
        /// </summary>
        /// <param name="username">Provided Username</param>
        /// <param name="password">Provided Password</param>
        /// <returns>The <see cref="Task"/> that represent the <see cref="AuthenticationResults"/> which contains login result and JWT Token.</returns>
        Task<AuthenticationResults>LoginAsync(UserRequest userLoginRequest);

        Task<AuthenticationResults> UpdateAsync(UserUpdateRequest userUpdateRequest, string userId);

        Task<List<UserResponsePublic>> GetAllAsync();

        Task<UserResponsePublic> GetUserAsync(string userId, string jwt);
    }
}
