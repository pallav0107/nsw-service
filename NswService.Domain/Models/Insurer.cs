using System;
using System.Collections.Generic;

#nullable disable

namespace NswService.Domain.Models
{
    public partial class Insurer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long? RegistrationId { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
