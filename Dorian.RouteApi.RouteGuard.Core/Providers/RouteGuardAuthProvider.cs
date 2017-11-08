using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dorian.RouteApi.Common.Extensions;
using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Models;
using Dorian.RouteApi.Infrastructure.Providers;
using Dorian.RouteApi.Infrastructure.Providers.Auth;
using Dorian.RouteApi.RouteGuard.Core.Constants;
using Dorian.RouteApi.RouteGuard.Core.Models;

namespace Dorian.RouteApi.RouteGuard.Core.Providers
{
    public class RouteGuardAuthProvider : IAuthProvider
    {
        private const string AuthHeader = "Authorization";
        private const string BasicAuthType = "Basic";

        private readonly RouteGuardAuthData authData;
        private readonly IBaseHttpClient<AuthResponseModel> httpClient;
        private AuthResponseModel authResponse;

        public IAccessTokenModel AccessTokenModel => authResponse;

        public bool IsAuthorized => authResponse != null;

        public RouteGuardAuthProvider(IAuthDataProvider<RouteGuardAuthData> authProvider, IBaseHttpClient<AuthResponseModel> httpClient)
        {
            this.httpClient = httpClient;
            authData = authProvider.GetAuthData();
        }

        public async Task Login()
        {
            var headers = new Dictionary<string, string>
            {
                { AuthHeader, $"{BasicAuthType} {$"{authData.ClientId}:{authData.ClientSecret}".ToBase64()}"}
            };

            var content = new StringContent($"grant_type=password&username={authData.Username}&password={authData.Password}&scope=web default rights claims openid",
                Encoding.UTF8, "application/x-www-form-urlencoded");

            authResponse = await httpClient.Post(Routes.Login, content, headers);
        }
    }
}
