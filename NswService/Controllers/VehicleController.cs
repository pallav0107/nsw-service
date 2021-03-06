using Microsoft.AspNetCore.Mvc;
using NswService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NswService.Controllers
{
    [Route("api")]

    public class VehicleController : Controller
    {
        private IVehicleService vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [Route("Registrations/{userId}")]
        [HttpGet]
        public IActionResult GetVehicleData(int userId)
        {
            var registrations = vehicleService.GetRegistrationsByUserId(userId);

            var registrationsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(registrations);

            return Ok(registrationsSerialized);
        }
    }
}
