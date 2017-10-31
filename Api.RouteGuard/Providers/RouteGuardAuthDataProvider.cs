using System.Configuration;
using Api.Infrastructure.Constants;
using Api.RouteGuard.Models;

namespace Api.RouteGuard.Providers
{
    public class RouteGuardAuthDataProvider : IRouteGuardAuthDataProvider
    {
        public RouteGuardAuthData GetAuthData()
        {
            return new RouteGuardAuthData
            {
                ClientId = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardClientId],
                ClientSecret = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardClientSecret],
                Username = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardUsername],
                Password = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardPassword],
                AuthUrl = ConfigurationManager.AppSettings[ConfigurationKeys.RouteGuardAuthUrl]
            };
        }
    }
}
