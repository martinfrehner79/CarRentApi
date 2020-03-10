using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarRentApi.Models.Classes;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Dtos;
using AutoMapper;
using CarRentApi.Controllers.Base;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : CarRentApiBaseController<Car, CarDto, IRepository<Car>> 
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public CarsController(IRepository<Car> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string carName)
        {
            try
            {
                List<Car> carList = await _repository.Search(carName).ConfigureAwait(false);
                var carDto = carList.Select(x => _mapper.Map<CarDto>(x)).ToList();
                return Ok(carDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}

   
