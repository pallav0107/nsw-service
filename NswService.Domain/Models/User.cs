using System;
using System.Collections.Generic;

#nullable disable

namespace NswService.Domain.Models
{
    public partial class User
    {
        public User()
        {
            UserRegistrations = new HashSet<UserRegistration>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<UserRegistration> UserRegistrations { get; set; }
    }
}
