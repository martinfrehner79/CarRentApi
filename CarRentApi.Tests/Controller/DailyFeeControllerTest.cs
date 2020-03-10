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
    public class DailyFeeControllerTest
    {
        #region Delete_DailyFee_ReturnsOk
        [Fact]
        public async Task Delete_Daily_ReturnsOK()
        {
            // Arrange & Act
            var mockRepo = new Mock<IRepository<Customer>>();
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new CarRentApi.Models.Mapping.AutoMapping());
            });
            var mapper = config.CreateMapper();
            var controller = new CustomersController(mockRepo.Object, mapper);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            var badRequestResult = Assert.IsType<OkResult>(result);
        }
        #endregion
    }
}
