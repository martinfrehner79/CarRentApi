using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRentApi.Models.Classes;
using CarRentApi.Models.Dtos;
using AutoMapper;
using CarRentApi.Controllers.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : CarRentApiBaseController<Contract, ContractDto, IRepository<Contract>>
    {
        private readonly IRepository<Contract> _contractRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<DailyFee> _dailyFeeRepository;
        private readonly IMapper _mapper;

        public ContractController(IRepository<Contract> contractRepository, IRepository<Car> carRepository, IRepository<Reservation> reservationRepository, IRepository<DailyFee> dailyFeeRepository, IMapper mapper) : base(contractRepository, mapper)
        {
            _contractRepository = contractRepository;
            _carRepository = carRepository;
            _reservationRepository = reservationRepository;
            _dailyFeeRepository = dailyFeeRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("createcontract")]
        public async Task<ActionResult> CreateContract([FromQuery] Guid reservationGuId, [FromQuery] Guid carGuId, [FromQuery] Guid dailyFeeGuId)
        {
            try
            {
                var reservation = await _reservationRepository.GetAsync(reservationGuId).ConfigureAwait(false);
                var car = await _carRepository.GetAsync(carGuId).ConfigureAwait(false);
                var dailyFee = await _dailyFeeRepository.GetAsync(dailyFeeGuId).ConfigureAwait(false);
                
                var contract = new Contract(reservation, car, dailyFee);

                await _contractRepository.AddAsync(contract).ConfigureAwait(false);
                return Ok(contract);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
