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
    public class CarBrandsControllerTest
    {
        #region Get_CarBrandById
        [Fact]
        public async Task Get_CarBrandById()
        {
            // Arrange & Act
            var id = Guid.NewGuid();
            var mockCarbrand = new CarBrand { Guid = id, Name="Test" };
            var mockRepo = new Mock<IRepository<CarBrand>>();

            mockRepo.Setup(repo => repo.GetAsync(It.IsAny<Guid>()))
                .ReturnsAsync(mockCarbrand)
                .Verifiable();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new CarRentApi.Models.Mapping.AutoMapping());
            });
            var mapper = config.CreateMapper();
            var controller = new CarBrandsController(mockRepo.Object, mapper);

            //Act
            var result = await controller.Get(id) as OkObjectResult;

            //Assert
            var carBrand=result.Value as CarBrandDto;
            Assert.Equal("Test", carBrand.Name);
        }
        #endregion
    }
}
