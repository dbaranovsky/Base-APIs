using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Infrastructure.HttpClient;
using Api.Infrastructure.Providers;
using Api.RouteGuard.Constants;
using Api.RouteGuard.RequestHandlers;

namespace Api.RouteGuard.Queries
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
