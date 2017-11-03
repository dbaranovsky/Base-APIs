namespace Dorian.RouteApi.Infrastructure.Providers.Configuration
{
    public interface IConfigurationProvider
    {
        int GetIntValue(string configurationKey);

        string GetValue(string configurationKey);

        decimal GetDecimalValue(string configurationKey);
    }
}
