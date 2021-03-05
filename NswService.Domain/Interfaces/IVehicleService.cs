using NswService.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NswService.Domain.Interfaces
{
    public interface IVehicleService
    {
        public UserRegistrationsDto GetRegistrations(int userId);
    }
}
