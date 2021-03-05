using Microsoft.AspNetCore.Mvc;
using NswService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NswService.Controllers
{
    public class VehicleController : Controller
    {
        private IVehicleService vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            this.vehicleService = vehicleService;
        }

        [Route("Registrations/{userId}")]
        public IActionResult GetVehicleData(int userId)
        {
            var registrations = vehicleService.GetRegistrations(userId);

            var registrationsSerialized = Newtonsoft.Json.JsonConvert.SerializeObject(registrations);

            return Ok(registrationsSerialized);
        }
    }
}
