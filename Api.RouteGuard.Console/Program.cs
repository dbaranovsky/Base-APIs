using System.Threading.Tasks;
using Api.Infrastructure.HttpClient;
using Api.RouteGuard.Models;
using Api.RouteGuard.Providers;
using Api.RouteGuard.Queries;

namespace Api.RouteGuard.Console
{
    class Program
    {
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var handler = new GetVoyages.Handler(
                new RouteGuardAuthProvider(new RouteGuardAuthDataProvider(), new BaseHttpClient<AuthResponseModel>(new BaseHttpClientFactory(new RouteGuardAuthUrlProvider()))),
                new BaseHttpClient<string>(new BaseHttpClientFactory(new RouteGuardUrlProvider())));
            var result = await handler.Handle(new GetVoyages.Query());
            System.Console.WriteLine(result);
            System.Console.ReadKey();
        }
    }
}
