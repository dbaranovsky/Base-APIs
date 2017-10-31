using Api.Infrastructure.Models;

namespace Api.Infrastructure.Providers
{
    public interface IAuthDataProvider<out TAuthData> where TAuthData : AuthData
    {
        TAuthData GetAuthData();
    }
}
