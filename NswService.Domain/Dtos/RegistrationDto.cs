using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NswService.Domain.Dtos
{
    public class UserRegistrationsDto
    {
        [JsonProperty("registrations")]
        public List<RegistrationsDto> Registrations { get; set; }
    }

    public class RegistrationsDto
    {
        [JsonProperty("plate_number")]
        public string PlateNumber { get; set; }
        [JsonProperty("registration")]
        public RegistrationDto RegistrationDto { get; set; }
        [JsonProperty("vehicle")]
        public VehicleDto VehicleDto { get; set; }
        [JsonProperty("insurer")]
        public InsurerDto InsurerDto { get; set; }
    }

    public class RegistrationDto
    {
        [JsonProperty("expired")]
        public string Expired { get; set; }
        [JsonProperty("expiry_date")]
        public DateTime ExpiryDate { get; set; }        
    }

    public class VehicleDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("colour")]
        public string Colour { get; set; }

        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("tare_weight")]
        public string TareWeight { get; set; }

        [JsonProperty("gross_mass")]
        public string GrossMass { get; set; }
    }

    public class InsurerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
