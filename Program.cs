using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "IdentityServer";

            var host = new WebHostBuilder()
                .UseKestrel(options => {
                    options.UseHttps(@"ic3-idsrv.azurewebsites.net.pfx", "Password");
                })
                .UseUrls("https://*:40443")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
