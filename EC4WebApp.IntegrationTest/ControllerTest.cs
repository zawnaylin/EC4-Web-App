using EC4WebApp.Contracts.V1;
using EC4WebApp.Contracts.V1.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EC4WebApp.IntegrationTest
{
    public class ControllerTest
    {
        private readonly IServiceProvider _serviceProvider;
        protected readonly HttpClient TestClient;
        
        protected ControllerTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _serviceProvider = appFactory.Services;
            TestClient = appFactory.CreateClient();
        }

        protected async Task<HttpResponseMessage> Login(UserRequest userLogin)
        {
            return await TestClient.PostAsJsonAsync(ApiRoutes.Identity.Login, userLogin);
        }

    }
}
