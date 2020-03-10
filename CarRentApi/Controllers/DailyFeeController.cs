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
    public class DailyFeesController : CarRentApiBaseController<DailyFee, DailyFeeDto, IRepository<DailyFee>>
    {
        private readonly IRepository<DailyFee> _repository;
        private readonly IMapper _mapper;
        public DailyFeesController(IRepository<DailyFee> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] Guid carClassGuid, [FromQuery] DateTime validFromDate)
        {
            try
            {
                var dailyFeeSearch = new DailyFeeSearch { CarClassGuId=carClassGuid,ValidFrom=validFromDate};
                var dailyFeeList = await _repository.Search(dailyFeeSearch).ConfigureAwait(false);
                var dailyFeeListDto = dailyFeeList.Select(x => _mapper.Map<DailyFeeDto>(x)).ToList();
                return Ok(dailyFeeListDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
   
}
