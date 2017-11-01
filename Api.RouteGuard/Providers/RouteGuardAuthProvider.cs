using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api.Common.Extensions;
using Api.Infrastructure.HttpClient;
using Api.Infrastructure.Models;
using Api.Infrastructure.Providers;
using Api.RouteGuard.Models;

namespace Api.RouteGuard.Providers
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

        public RouteGuardAuthProvider(IRouteGuardAuthDataProvider authProvider, IBaseHttpClient<AuthResponseModel> httpClient)
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

            authResponse = await httpClient.Post(string.Empty, content, headers);
        }
    }
}
