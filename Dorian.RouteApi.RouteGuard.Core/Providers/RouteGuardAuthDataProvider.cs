using Dorian.RouteApi.Common.Constants;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.Infrastructure.Providers.Configuration;
using Dorian.RouteApi.RouteGuard.Core.Models;

namespace Dorian.RouteApi.RouteGuard.Core.Providers
{
    public class RouteGuardAuthDataProvider : IAuthDataProvider<RouteGuardAuthData>
    {
        private readonly IConfigurationProvider configurationProvider;

        public RouteGuardAuthDataProvider(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public RouteGuardAuthData GetAuthData()
        {
            return new RouteGuardAuthData
            {
                ClientId = configurationProvider.GetValue(ConfigurationKeys.RouteGuardClientId),
                ClientSecret = configurationProvider.GetValue(ConfigurationKeys.RouteGuardClientSecret),
                Username = configurationProvider.GetValue(ConfigurationKeys.RouteGuardUsername),
                Password = configurationProvider.GetValue(ConfigurationKeys.RouteGuardPassword)
            };
        }
    }
}
