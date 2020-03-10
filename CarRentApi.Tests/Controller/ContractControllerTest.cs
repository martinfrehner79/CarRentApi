using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Classes;
using CarRentApi.Controllers;
using AutoMapper;

namespace CarRentApi.Tests.Controller
{
    public class ConractControllerTest
    {

        #region Post_ReturnsBadRequest
        [Fact]
        public async Task Post_ReturnsBadRequest()
        {
            // Arrange & Act
            var mockContractRepo = new Mock<IRepository<Contract>>();
            var mockCarRepo = new Mock<IRepository<Car>>();
            var mockReservationRepo = new Mock<IRepository<Reservation>>();
            var mockDailyFeeRepo = new Mock<IRepository<DailyFee>>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CarRentApi.Models.Mapping.AutoMapping());
            });
            var mapper = config.CreateMapper();
            var controller = new ContractController(mockContractRepo.Object, mockCarRepo.Object, mockReservationRepo.Object, mockDailyFeeRepo.Object, mapper);
            
            var reservationGuId = Guid.NewGuid();
            var carGuId = Guid.NewGuid();
            var dailyFeeGuId = Guid.NewGuid();
            var result = await controller.CreateContract(reservationGuId, carGuId, dailyFeeGuId);

            // Assert
            var okResult = Assert.IsType<BadRequestObjectResult>(result);                      
        }
        #endregion
    }
}
