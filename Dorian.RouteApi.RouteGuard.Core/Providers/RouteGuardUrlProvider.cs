using System;
using Dorian.RouteApi.Common.Constants;
using Dorian.RouteApi.Infrastructure.Providers.Configuration;

namespace Dorian.RouteApi.RouteGuard.Core.Providers
{
    public class RouteGuardUrlProvider : IRouteGuardUrlProvider
    {
        private readonly IConfigurationProvider configurationProvider;

        public RouteGuardUrlProvider(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        public Uri GetBaseApiUrl()
        {
            return new Uri(configurationProvider.GetValue(ConfigurationKeys.RouteGuardBaseUrl));
        }
    }
}
