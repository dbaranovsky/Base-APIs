using System.Collections.Generic;
using System.Threading.Tasks;
using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Providers;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.RouteGuard.Core.Constants;
using Dorian.RouteApi.RouteGuard.Core.RequestHandlers;

namespace Dorian.RouteApi.RouteGuard.Core.Queries
{
    public class GetVoyages
    {
        public class Query { }

        public class Handler : BaseRouteGuardRequestHandler<Query, string>
        {
            public Handler(IAuthProvider authProvider, IBaseHttpClient<string> httpClient) : base(authProvider, httpClient) { }

            protected override async Task<string> Execute(Query request, Dictionary<string, string> headers)
            {
                return await HttpClient.Get(Routes.Voyages, headers);
            }
        }
    }
}
