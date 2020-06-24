using System.Collections.Generic;
using System.Threading.Tasks;
using Pitstop.Models;
using Microsoft.AspNetCore.Hosting;
using Refit;
using WebApp.Commands;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace WebApp.RESTClients
{
    public class VehicleManagementAPI : IVehicleManagementAPI
    {
        private IVehicleManagementAPI _restClient;
        private string cachedToken = string.Empty;

        public ControllerBase Parent { get; set; }

        public  VehicleManagementAPI(IConfiguration config, HttpClient httpClient)
        {
            string apiHostAndPort = config.GetSection("APIServiceLocations").GetValue<string>("VehicleManagementAPI");
            httpClient.BaseAddress = new Uri($"http://{apiHostAndPort}/api");
            //_restClient = RestService.For<IVehicleManagementAPI>(httpClient);
            // replaced with
            _restClient = RestService.For<IVehicleManagementAPI>($"http://{apiHostAndPort}/api", new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var accessToken = await Parent.HttpContext.GetTokenAsync("access_token");
            cachedToken = $"Bearer {accessToken}";
            return await _restClient.GetVehicles();
        }
        public async Task<Vehicle> GetVehicleByLicenseNumber([AliasAs("id")] string licenseNumber)
        {
            try
            {
                return await _restClient.GetVehicleByLicenseNumber(licenseNumber);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task RegisterVehicle(RegisterVehicle command)
        {
            await _restClient.RegisterVehicle(command);
        }
    }
}
