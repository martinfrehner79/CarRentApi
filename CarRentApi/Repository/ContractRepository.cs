using System;
using CarRentApi.Models.Classes;
using CarRentApi.Data;
using System.Threading.Tasks;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Repository
{
    public class ContractRepository : BaseRepository<Contract, CarRentApiContext>, IRepository<Contract>
    {

        private readonly DailyFeeRepository _dailyFeeRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly CarRepository _carRepository;

        public ContractRepository(CarRentApiContext dbContext) : base(dbContext) {}
        public ContractRepository(CarRentApiContext dbContext, DailyFeeRepository dailyFeeRepository, ReservationRepository reservationRepository, CarRepository carRepository) : base(dbContext)
        {
            _dailyFeeRepository = dailyFeeRepository;
            _reservationRepository = reservationRepository;
            _carRepository = carRepository;
        }       
    }
}
