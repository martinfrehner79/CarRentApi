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
    public class ReservationsController : CarRentApiBaseController<Reservation, ReservationDto, IRepository<Reservation>>
    {      
        public ReservationsController(IRepository<Reservation> repository, IMapper mapper) : base(repository, mapper)
        {     
        }
    }
}
