using System;
using Dorian.RouteApi.Infrastructure.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Dorian.RouteApi.Infrastructure.Providers.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfiguration configuration;

        public ConfigurationProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public int GetIntValue(string configurationKey)
        {
            var value = GetValue(configurationKey);
            if (!int.TryParse(value, out var result))
            {
                throw new ApiException($"Type of {configurationKey} is not integer value.");
            }

            return result;
        }

        public string GetValue(string configurationKey)
        {
            var value = configuration[configurationKey];
            if (value == null)
            {
                throw new ApiException($"There is no configuration for {configurationKey}.");
            }

            return value;
        }

        public decimal GetDecimalValue(string configurationKey)
        {
            var value = GetValue(configurationKey);
            if (!decimal.TryParse(value, out var result))
            {
                throw new ApiException($"Type of {configurationKey} is not decimal value.");
            }

            return result;
        }
    }
}
