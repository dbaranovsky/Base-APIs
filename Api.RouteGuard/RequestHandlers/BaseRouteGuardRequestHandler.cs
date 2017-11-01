using System.Configuration;
using Api.Common.Constants;
using Api.Infrastructure.HttpClient;
using Api.Infrastructure.Providers;
using Api.Infrastructure.RequestHandlers;

namespace Api.RouteGuard.RequestHandlers
{
    public abstract class BaseRouteGuardRequestHandler<TRequest, TResponse> : BaseApiAsyncRequestHandler<TRequest, TResponse>
    {
        protected BaseRouteGuardRequestHandler(IAuthProvider authProvider, IBaseHttpClient<TResponse> httpClient) : base(authProvider, httpClient)
        {
            
        }
    }
}
