using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApp.RESTClients;
using Serilog;
using Microsoft.Extensions.HealthChecks;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

namespace PitStop
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            //services
            //    .AddMvc(options => options.EnableEndpointRouting = false)
            //    .AddNewtonsoftJson();
            // replaced with
            services.AddControllersWithViews();


            // add custom services
            services.AddHttpClient<ICustomerManagementAPI, CustomerManagementAPI>();
            services.AddHttpClient<IVehicleManagementAPI, VehicleManagementAPI>();
            services.AddHttpClient<IWorkshopManagementAPI, WorkshopManagementAPI>();

            services.AddHealthChecks(checks =>
            {
                checks.WithDefaultCacheDuration(TimeSpan.FromSeconds(1));
                checks.AddValueTaskCheck("HTTP Endpoint", () => new
                    ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("Ok")));
            });

            #region borrowed from quickstart2nd MvcClient

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            // "web_api is VehicleManagementAPI and mvc is WebApp
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;

                    options.Scope.Add("web_api");
                    options.Scope.Add("offline_access");
                });
            #endregion borrowed from quickstart2nd MvcClient
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(_configuration)
                .Enrich.WithMachineName()
                .CreateLogger();

            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            #region borrowed from quickstart2nd MvcClient
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion borrowed from quickstart2nd MvcClient

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //    //.RequireAuthorization
            //});
            // replaced with 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });

        }
    }
}
