using System.Threading.Tasks;

namespace Dorian.RouteApi.Infrastructure.RequestHandlers
{
    public interface IAsyncRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
