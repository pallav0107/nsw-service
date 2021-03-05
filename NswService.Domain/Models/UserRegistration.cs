using System;
using System.Collections.Generic;

#nullable disable

namespace NswService.Domain.Models
{
    public partial class UserRegistration
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long RegistrationId { get; set; }

        public virtual Registration Registration { get; set; }
        public virtual User User { get; set; }
    }
}
