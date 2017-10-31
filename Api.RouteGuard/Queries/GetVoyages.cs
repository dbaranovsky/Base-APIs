using System.IO;
using System.Net;
using System.Threading.Tasks;
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
            protected override string RelativeUrl { get; set; } = Routes.Voyages;
            protected override string HttpMethod { get; set; } = WebRequestMethods.Http.Get;
            public Handler(IAuthProvider authProvider) : base(authProvider) { }

            protected override async Task<string> Execute(Query request, HttpWebRequest webRequest)
            {
                using (var response = (HttpWebResponse)await webRequest.GetResponseAsync())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}
