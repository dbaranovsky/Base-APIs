using System.Threading.Tasks;
using Dorian.RouteApi.Infrastructure.Models;

namespace Dorian.RouteApi.Infrastructure.Providers.Auth
{
    public interface IAuthProvider
    {
        IAccessTokenModel AccessTokenModel { get; }
        bool IsAuthorized { get; }
        Task Login();
    }
}
