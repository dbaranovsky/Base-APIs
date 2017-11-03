using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Providers;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.Infrastructure.RequestHandlers;

namespace Dorian.RouteApi.RouteGuard.Core.RequestHandlers
{
    public abstract class BaseRouteGuardRequestHandler<TRequest, TResponse> : BaseApiAsyncRequestHandler<TRequest, TResponse>
    {
        protected BaseRouteGuardRequestHandler(IAuthProvider authProvider, IBaseHttpClient<TResponse> httpClient) : base(authProvider, httpClient)
        {
            
        }
    }
}
