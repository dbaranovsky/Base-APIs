using System.Threading.Tasks;
using Api.RouteGuard.Providers;
using Api.RouteGuard.Queries;

namespace Api.RouteGuard.Console
{
    class Program
    {
        static void Main()
        {
            MainAsync().Wait();
            // or, if you want to avoid exceptions being wrapped into AggregateException:
            //  MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var handler = new GetVoyages.Handler(new RouteGuardAuthProvider(new RouteGuardAuthDataProvider()));
            var result = await handler.Handle(new GetVoyages.Query());
            System.Console.WriteLine(result);
            System.Console.ReadKey();
        }
    }
}
