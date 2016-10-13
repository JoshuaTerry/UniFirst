using System.Web.Http;
using UniFirst.Models;
using UniFirst.Services;

namespace UniFirst.Controllers
{
    [RoutePrefix("api/Vehicle")]
    public class VehicleController : ApiController
    {
        private readonly IVehicleService vehicleService;

        public VehicleController()
        {
            vehicleService = new VehicleService(new VehicleRepository());
        }

        [Route("Status")]
        [HttpPost]
        public IHttpActionResult ChangeStatus(IVehicle vehicle, VehicleStatus status)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Model");
            }

            if (!vehicleService.ChangeVehicleStatus(vehicle, status))
                return BadRequest("Status UnChanged");
            else 
                return Ok();
        }

        // If return routes will also include larger collections
        // you could make this an OData Controller instead
        // if only there were more time ... :)
    }
}
