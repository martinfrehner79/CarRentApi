using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Classes;
using CarRentApi.Models.Dtos;
using CarRentApi.Models.Mapping;
using CarRentApi.Controllers;
using AutoMapper;

namespace CarRentApi.Tests.Controller
{
    public class CustomerControllerTest
    {
        #region Search_Customer_ReturnsCustomerDto
        [Fact]
        public async Task Search_Customer_ReturnsCustomerDto()
        {            
            // Arrange & Act
            var mockCustomerListDto = new List<Customer> { new Customer { Guid = Guid.NewGuid(), Firstname="Martin", Lastname="Frehner" } };
            var mockRepo = new Mock<IRepository<Customer>>();

            mockRepo.Setup(repo => repo.Search(It.IsAny<Object>()))
                .ReturnsAsync(mockCustomerListDto)
                .Verifiable();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new AutoMapping());
            });

            var mapper = config.CreateMapper();
            var controller = new CustomersController(mockRepo.Object, mapper);

            //Act
            var result = await controller.Search(0,"Martin","St. Gallen") as OkObjectResult;

            //Assert
            var list = result.Value as List<CustomerDto>;
            Assert.Single(list);
            Assert.Equal("Frehner", list[0].Lastname);
        }
        #endregion
    }
}
