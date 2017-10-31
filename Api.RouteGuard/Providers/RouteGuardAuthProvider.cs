using System.Net;
using System.Text;
using System.Threading.Tasks;
using Api.Infrastructure.Extensions;
using Api.Infrastructure.Models;
using Api.Infrastructure.Providers;
using Api.RouteGuard.Constants;
using Api.RouteGuard.Models;
using Newtonsoft.Json;

namespace Api.RouteGuard.Providers
{
    public class RouteGuardAuthProvider : IAuthProvider
    {
        private const string AuthHeader = "Authorization";
        private const string BasicAuthType = "Basic";

        private readonly RouteGuardAuthData authData;
        private AuthResponseModel authResponse;

        public IAccessTokenModel AccessTokenModel => authResponse;

        public bool IsAuthorized => authResponse != null;

        public RouteGuardAuthProvider(IRouteGuardAuthDataProvider authProvider)
        {
            authData = authProvider.GetAuthData();
        }

        public async Task Login()
        {
            var content = Encoding.ASCII.GetBytes(
                $"grant_type=password&username={authData.Username}&password={authData.Password}&scope=web default rights claims openid");
            var request = BuildLoginRequest(content);

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    var token = reader.ReadToEnd();
                    authResponse = JsonConvert.DeserializeObject<AuthResponseModel>(token);
                }
            }
        }

        private HttpWebRequest BuildLoginRequest(byte[] content)
        {
            var request = (HttpWebRequest)WebRequest.Create(authData.AuthUrl);
            request.Headers.Add(AuthHeader, $"{BasicAuthType} {$"{authData.ClientId}:{authData.ClientSecret}".ToBase64()}");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "String";
            request.ContentLength = content.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(content, 0, content.Length);
            reqStream.Close();

            return request;
        }
    }
}
