using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CarRentApi.Models.Classes;
using CarRentApi.Repository.Interfaces;
using CarRentApi.Models.Dtos;
using CarRentApi.Controllers.Base;
using CarRentApi.Models.HelperClasses;

namespace CarRentApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CarRentApiBaseController<Customer, CustomerDto, IRepository<Customer>>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CustomersController(IRepository<Customer> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int customerNo,[FromQuery] string name, [FromQuery] string city)
        {
            try
            {
                var customerSearch = new CustomerSearch { CustomerNo = customerNo, Name = name, City = city };
                List<Customer> customerList = await _repository.Search(customerSearch).ConfigureAwait(false);
                var customerListDto = customerList.Select(x => _mapper.Map<CustomerDto>(x)).ToList();
                return Ok(customerListDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
