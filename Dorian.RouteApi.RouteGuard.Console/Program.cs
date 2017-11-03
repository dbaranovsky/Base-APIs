using System;
using System.IO;
using System.Threading.Tasks;
using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Providers.Configuration;
using Dorian.RouteApi.RouteGuard.Core.Models;
using Dorian.RouteApi.RouteGuard.Core.Providers;
using Dorian.RouteApi.RouteGuard.Core.Queries;
using Microsoft.Extensions.Configuration;

namespace Dorian.RouteApi.RouteGuard.Console
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appconfig.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();

            var authProvider = new RouteGuardAuthProvider(
                new RouteGuardAuthDataProvider(
                    new Infrastructure.Providers.Configuration.ConfigurationProvider(configuration)),
                new BaseHttpClient<AuthResponseModel>(new BaseHttpClientFactory(
                    new RouteGuardUrlProvider(
                        new Infrastructure.Providers.Configuration.ConfigurationProvider(configuration)))));
            var handler = new GetVoyages.Handler(authProvider,
                new BaseHttpClient<string>(new BaseHttpClientFactory(
                    new RouteGuardUrlProvider(
                        new Infrastructure.Providers.Configuration.ConfigurationProvider(configuration)))));

            var result = await handler.Handle(new GetVoyages.Query());
            System.Console.WriteLine(result);
            System.Console.ReadKey();
        }
    }
}
