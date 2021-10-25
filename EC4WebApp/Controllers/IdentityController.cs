using EC4WebApp.Contracts.V1;
using EC4WebApp.Contracts.V1.Requests;
using EC4WebApp.Contracts.V1.Responses;
using EC4WebApp.Contracts.V1.Responses.Authentication;
using EC4WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EC4WebApp.Controllers
{
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityServices _identityServices;

        public IdentityController(IIdentityServices identityServices)
        {
            _identityServices = identityServices;
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserRequest userLoginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var result = await _identityServices.LoginAsync(userLoginRequest);

            if(!result.Success)
            {
                return BadRequest(new FailResponse
                {
                    Errors = result.Errors
                });
            }

            return Ok(new SuccessResponse
            {
                DisplayName = result.DisplayName,
                JwtToken = result.Token
            });
        }

        [HttpGet(ApiRoutes.Identity.AllUsers)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _identityServices.GetAllAsync());
        }

        [HttpGet(ApiRoutes.Identity.User)]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var jwt = Request.Cookies["jwt"];
            var result = await _identityServices.GetUserAsync(id, jwt);
            switch (result)
            {
                case UserResponseOwn own: return Ok(new
                {
                    Data = own
                });
                case UserResponsePublic @public: return Ok(new
                {
                    Data = @public
                });
                default: return NotFound(new
                {
                    Errors = new[]
                    {
                        new
                        {
                            Type = "NOTFOUND",
                            Message = "User does not exist."
                        }
                    }
                });
            }
        }



        //public async Task<IActionResult> AddMember([FromBody] UserRequest user)
        //{


        //    var result = _identityServices.AddUserAsync(user);
        //    return result.Success ? Ok(new
        //    {
        //        Data = new
        //        {
        //            Id = result.Id,
        //        }
                
        //    })



        //}
        
        
    }
}
