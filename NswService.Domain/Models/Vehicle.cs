using System;
using System.Collections.Generic;

#nullable disable

namespace NswService.Domain.Models
{
    public partial class Vehicle
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string Vin { get; set; }
        public string TareWeight { get; set; }
        public string GrossMass { get; set; }
        public long? RegistrationId { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
