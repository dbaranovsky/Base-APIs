using System.Net;
using System.Threading.Tasks;
using Api.Infrastructure.Providers;

namespace Api.Infrastructure.RequestHandlers
{
    public abstract class BaseApiAsyncRequestHandler<TRequest, TResponse>
    {
        private readonly IAuthProvider authProvider;
        protected abstract string ApiBaseUrl { get; set; }
        protected abstract string RelativeUrl { get; set; }
        protected abstract string HttpMethod { get; set; }

        private const string AuthHeader = "Authorization";
        private const string BearerAuthType = "Bearer";

        protected BaseApiAsyncRequestHandler(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        protected abstract Task<TResponse> Execute(TRequest request, HttpWebRequest webRequest);

        public async Task<TResponse> Handle(TRequest request)
        {
            if (!authProvider.IsAuthorized)
            {
                await authProvider.Login();
            }

            var webRequest = BuildRequest();

            return await Execute(request, webRequest);
        }

        private HttpWebRequest BuildRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create($"{ApiBaseUrl}/{RelativeUrl}");
            request.Headers.Add(AuthHeader, $"{BearerAuthType} {authProvider.AccessTokenModel?.AccessToken}");
            request.Method = HttpMethod;

            return request;
        }
    }
}
