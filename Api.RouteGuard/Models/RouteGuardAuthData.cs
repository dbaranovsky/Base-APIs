using Api.Infrastructure.Models;

namespace Api.RouteGuard.Models
{
    public class RouteGuardAuthData : AuthData
    {
        public string AuthUrl { get; set; }
    }
}
