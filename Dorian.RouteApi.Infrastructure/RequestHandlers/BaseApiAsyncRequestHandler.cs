using System.Collections.Generic;
using System.Threading.Tasks;
using Dorian.RouteApi.Infrastructure.HttpClient;
using Dorian.RouteApi.Infrastructure.Providers.Auth;

namespace Dorian.RouteApi.Infrastructure.RequestHandlers
{
    public abstract class BaseApiAsyncRequestHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
    {
        private readonly IAuthProvider authProvider;
        protected readonly IBaseHttpClient<TResponse> HttpClient;
       
        private const string AuthHeader = "Authorization";

        protected BaseApiAsyncRequestHandler(IAuthProvider authProvider, IBaseHttpClient<TResponse> httpClient)
        {
            this.authProvider = authProvider;
            HttpClient = httpClient;
        }

        protected abstract Task<TResponse> Execute(TRequest request, Dictionary<string, string> headers);

        public async Task<TResponse> Handle(TRequest request)
        {
            if (!authProvider.IsAuthorized)
            {
                await authProvider.Login();
            }

            var headers = InitializeHeaders();

            return await Execute(request, headers);
        }

        private Dictionary<string, string> InitializeHeaders()
        {
            return new Dictionary<string, string>
            {
                { AuthHeader, $"{authProvider.AccessTokenModel.TokenType} {authProvider.AccessTokenModel.AccessToken}" }
            };
        }
    }
}
