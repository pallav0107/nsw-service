using Microsoft.EntityFrameworkCore;
using NswService.Domain.Dtos;
using NswService.Domain.Interfaces;
using NswService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NswService.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private NSWContext VechileContext;

        public VehicleService(NSWContext vehicleContext)
        {
            this.VechileContext = vehicleContext;
        }

        public UserRegistrationsDto GetRegistrations(int userId)
        {
            var registrations = VechileContext.UserRegistrations.Include(a => a.Registration).Include(a => a.User).Where(a => a.UserId == userId).ToList();

            var userRegistrationsDto = new UserRegistrationsDto();

            userRegistrationsDto.Registrations = new List<RegistrationsDto>();

            foreach (var registration in registrations)
            {
                userRegistrationsDto.Registrations.Add(new RegistrationsDto()
                {
                    PlateNumber = registration.Registration.PlateNumber,
                    RegistrationDto = new RegistrationDto()
                    {
                        Expired = (registration.Registration.ExpiryDate < DateTime.Now).ToString(),
                        ExpiryDate = registration.Registration.ExpiryDate ?? DateTime.MinValue
                    },
                    VehicleDto = new VehicleDto()
                    {
                        Colour = registration.Registration.Colour,
                        GrossMass = registration.Registration.GrossMass,
                        Make = registration.Registration.Make,
                        Model = registration.Registration.Model,
                        TareWeight = registration.Registration.TareWeight,
                        Type = registration.Registration.Type,
                        Vin = registration.Registration.Vin
                    },
                    InsurerDto = new InsurerDto()
                    {
                        Code = registration.Registration.InsurerCode,
                        Name = registration.Registration.InsurerName
                    }
                });
            }

            return userRegistrationsDto;
        }
    }
}
