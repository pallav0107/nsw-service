using Microsoft.EntityFrameworkCore;
using Moq;
using NswService.Domain.Models;
using NswService.Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NswService.Tests
{
    public class VehicleServiceTests
    {
        private Mock<NSWContext> mockContext;
        private IQueryable<UserRegistration> userRegistrations;

        [SetUp]
        public void Setup()
        {
            userRegistrations = new List<UserRegistration>()
            {
                new UserRegistration(){ Id = 1, User = new User(){ Id=1, Name="User1", Address="Address1" },  Registration = new Registration { Id = 1, PlateNumber = "platenumber 1", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" },  RegistrationId = 1, UserId = 1 },
                new UserRegistration(){ Id = 2, User = new User { Id = 1, Name = "Name 2", Address = "Address 2" }, Registration = new Registration { Id = 2, PlateNumber = "platenumber 2", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" }, RegistrationId = 2, UserId = 1 },
                new UserRegistration(){ Id = 3, User = new User { Id = 1, Name = "Name 3", Address = "Address 3" }, Registration = new Registration { Id = 3, PlateNumber = "platenumber 3", Colour = "color 1", ExpiryDate = new DateTime(2030, 1, 1), GrossMass = "100", InsurerCode = "INS Code 1", InsurerName = "INS Name", Make = "Make 1", Model = "Model 1", TareWeight = "122", Type = "Type 1", Vin = "Vin 1" }, RegistrationId = 3, UserId = 1 },
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<UserRegistration>>();
            mockDbSet.As<IQueryable<UserRegistration>>().Setup(m => m.Provider).Returns(userRegistrations.Provider);
            mockDbSet.As<IQueryable<UserRegistration>>().Setup(m => m.Expression).Returns(userRegistrations.Expression);
            mockDbSet.As<IQueryable<UserRegistration>>().Setup(m => m.ElementType).Returns(userRegistrations.ElementType);
            mockDbSet.As<IQueryable<UserRegistration>>().Setup(m => m.GetEnumerator()).Returns(userRegistrations.GetEnumerator());

            mockContext = new Mock<NSWContext>();
            mockContext.Setup(c => c.UserRegistrations).Returns(mockDbSet.Object);
        }

        [Test]
        public void GetRegistrationsByUserId_ValidInput_ReturnsValidData()
        {
            var service = new VehicleService(mockContext.Object);
            var registrations = service.GetRegistrationsByUserId(1);

            Assert.NotNull(registrations);
            Assert.AreEqual(3, registrations.Registrations.Count);
        }

        [Test]
        public void GetRegistrationsByUserId_InValidInput_ReturnsNoData()
        {
            var service = new VehicleService(mockContext.Object);
            var registrations = service.GetRegistrationsByUserId(5);

            Assert.NotNull(registrations);
            Assert.AreEqual(0, registrations.Registrations.Count);
        }
    }
}