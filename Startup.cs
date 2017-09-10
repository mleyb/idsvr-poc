using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IdentityServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer(options =>
            {
                options.IssuerUri = "http://ic3-idsrv.com";
            })
            .AddTemporarySigningCredential()
            .AddInMemoryApiResources(IdentityConfig.GetApiResources())
            .AddInMemoryClients(IdentityConfig.GetClients())
            .AddTestUsers(IdentityConfig.GetUsers());
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}
