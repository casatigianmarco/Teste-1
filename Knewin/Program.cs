using Autofac;
using Autofac.Integration.WebApi;
using KnewinAPI.Infraestruture;
using KnewinAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Web.Http;

namespace Knewin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
