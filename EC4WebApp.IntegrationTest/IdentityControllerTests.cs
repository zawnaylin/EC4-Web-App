using EC4WebApp.Contracts.V1.Requests;
using FluentAssertions;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Xunit;
using System.Collections.Generic;

namespace EC4WebApp.IntegrationTest
{
    public class IdentityControllerTests : ControllerTest
    {
        [Fact]
        public async Task Login_As_Admin_Successful()
        {
            // Arrange
            var loginForm = new UserRequest
            {
                UserName = "zawnay160399",
                Password = "Zawnaylin@1999"
            };

            // Add
            var response = await Login(loginForm);

            // Assert 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_Password_Is_Case_Sensitive()
        {
            // Arrange
            var loginForm = new UserRequest
            {
                UserName = "zawnay160399",
                Password = "zAwnaylin@1999"
            };

            // Add
            var response = await Login(loginForm);

            // Assert 
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var message = await response.Content.ReadFromJsonAsync<List<string>>();
            message[0].Should().Be("Username or Password is wrong.");
        }

        [Fact]
        public async Task Login_Username_Is_Case_Sensitive()
        {
            // Arrange
            var loginForm = new UserRequest
            {
                UserName = "Zawnay160399",
                Password = "Zawnaylin@1999"
            };

            // Add
            var response = await Login(loginForm);

            // Assert 
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var message = await response.Content.ReadFromJsonAsync<List<string>>();
            message[0].Should().Be("Username does not exists.");
        }
    }
}
