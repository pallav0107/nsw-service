using System;
using System.Collections.Generic;

#nullable disable

namespace NswService.Domain.Models
{
    public partial class Registration
    {
        public Registration()
        {
            UserRegistrations = new HashSet<UserRegistration>();
        }

        public long Id { get; set; }
        public string PlateNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string Vin { get; set; }
        public string TareWeight { get; set; }
        public string GrossMass { get; set; }
        public string InsurerName { get; set; }
        public string InsurerCode { get; set; }

        public virtual ICollection<UserRegistration> UserRegistrations { get; set; }
    }
}
