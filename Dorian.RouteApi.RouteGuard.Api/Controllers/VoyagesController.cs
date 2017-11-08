using System.Threading.Tasks;
using Dorian.RouteApi.RouteGuard.Core.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Dorian.RouteApi.RouteGuard.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Voyages")]
    public class VoyagesController : Controller
    {
        private readonly GetVoyages.Handler getVoyagesHandler;

        public VoyagesController(GetVoyages.Handler getVoyagesHandler)
        {
            this.getVoyagesHandler = getVoyagesHandler;
        }
        
        [HttpGet]
        public async Task<string> Get()
        {
            return await this.getVoyagesHandler.Handle(new GetVoyages.Query());
        }
    }
}