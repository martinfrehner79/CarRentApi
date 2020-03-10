using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Classes;
using CarRentApi.Models.Dtos;
using CarRentApi.Controllers;
using AutoMapper;

namespace CarRentApi.Tests.Controller
{
    public class CarControllerTest
    {

        #region Put_ReturnsBadRequest
        [Fact]
        public async Task Put_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange & Act
            var mockRepo = new Mock<IRepository<Car>>();
            var config = new MapperConfiguration(cfg => { 
                    cfg.CreateMap<Car, CarDto>();
                    cfg.CreateMap<CarDto, Car>();
                });
            var mapper = config.CreateMapper();
            var controller = new CarsController(mockRepo.Object,mapper);

            // Act
            var result = await controller.Put(Guid.NewGuid(),new Car());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        #endregion

        #region Post_ReturnsNewlyCreatedCar
        [Fact]
        public async Task Put_ReturnsNewlyCreatedCar()
        {
            // Arrange & Act
            var mockRepo = new Mock<IRepository<Car>>();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new CarRentApi.Models.Mapping.AutoMapping());
            });
            var mapper = config.CreateMapper();
            var controller = new CarsController(mockRepo.Object, mapper);

            // Act
            var car = new Car
            {
                Guid = Guid.NewGuid(),
                CarBrandGuId = Guid.NewGuid(),
                CarClassGuId = Guid.NewGuid(),
                Name = "Test",
                RegistrationPlate = "Test"
            };
            var result = await controller.Post(car);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnObject = Assert.IsType<Car>(okResult.Value);
            Assert.Equal("Test", returnObject.Name);
            Assert.Equal("Test", returnObject.RegistrationPlate);
        }
        #endregion
    }
}

