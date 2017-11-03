using Dorian.RouteApi.Infrastructure.Models;

namespace Dorian.RouteApi.Infrastructure.Providers.Auth
{
    public interface IAuthDataProvider<out TAuthData> where TAuthData : AuthData
    {
        TAuthData GetAuthData();
    }
}
