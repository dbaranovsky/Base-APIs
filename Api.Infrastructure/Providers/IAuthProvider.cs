using System.Threading.Tasks;
using Api.Infrastructure.Models;

namespace Api.Infrastructure.Providers
{
    public interface IAuthProvider
    {
        IAccessTokenModel AccessTokenModel { get; }
        bool IsAuthorized { get; }
        Task Login();
    }
}
