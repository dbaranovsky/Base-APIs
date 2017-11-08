namespace Dorian.RouteApi.RouteGuard.Core.Constants
{
    public class Routes
    {
        private const string BaseAuthPath = "accounts/identity/connect/token";
        private const string BaseApiPath = "routeguard";

        public const string Login = BaseAuthPath;
        public const string Voyages = BaseApiPath + "/v1/voyages";
    }
}
