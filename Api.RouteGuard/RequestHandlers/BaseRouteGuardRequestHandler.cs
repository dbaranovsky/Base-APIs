using System.Configuration;
using Api.Infrastructure.Constants;
using Api.Infrastructure.Providers;
using Api.Infrastructure.RequestHandlers;

namespace Api.RouteGuard.RequestHandlers
{
    public abstract class BaseRouteGuardRequestHandler<TRequest, TResponse> : BaseApiAsyncRequestHandler<TRequest, TResponse>
    {
        protected override string ApiBaseUrl { get; set; } = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardBaseUrl];

        protected BaseRouteGuardRequestHandler(IAuthProvider authProvider) : base(authProvider)
        {
            
        }
    }
}
