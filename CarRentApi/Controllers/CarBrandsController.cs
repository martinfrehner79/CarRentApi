using Microsoft.AspNetCore.Mvc;
using CarRentApi.Models.Classes;
using CarRentApi.Repository;
using CarRentApi.Models.Dtos;
using AutoMapper;
using CarRentApi.Controllers.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : CarRentApiBaseController<CarBrand, CarBrandDto, IRepository<CarBrand>>
    {      
        public CarBrandsController(IRepository<CarBrand> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}