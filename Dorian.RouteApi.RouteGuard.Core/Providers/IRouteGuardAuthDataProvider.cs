using Dorian.RouteApi.Infrastructure.Providers;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.RouteGuard.Core.Models;

namespace Dorian.RouteApi.RouteGuard.Core.Providers
{
    public interface IRouteGuardAuthDataProvider : IAuthDataProvider<RouteGuardAuthData>
    {

    }
}
