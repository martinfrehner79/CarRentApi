using System;
using System.Collections.Generic;
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
    public class CarClassesControllerTest
    {
        #region Get_ReturnsListOfCarClasses
        [Fact]
        public async Task Get_ReturnsListOfCarClasses()
        {
            // Arrange & Act
            var mockCarClassList = new List<CarClass> { new CarClass { Guid = Guid.NewGuid(), Name = "Test" } };           
            var mockRepo = new Mock<IRepository<CarClass>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(mockCarClassList)
                .Verifiable();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new CarRentApi.Models.Mapping.AutoMapping());
            });
            var mapper = config.CreateMapper();
            var controller = new CarClassesController(mockRepo.Object, mapper);

            //Act
            var result = await controller.GetAll() as OkObjectResult;

            //Assert
            var list = result.Value as List<CarClassDto>;
            Assert.Single(list);
            Assert.Equal("Test",list[0].Name);
        }
        #endregion
    }
}
