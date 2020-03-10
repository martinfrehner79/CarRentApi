using CarRentApi.Models.Classes;
using CarRentApi.Data;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Repository
{
    public class ReservationRepository: BaseRepository<Reservation, CarRentApiContext>, IRepository<Reservation>
    {

        private readonly CarRentApiContext _dbContext;
        public ReservationRepository(CarRentApiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }        
    }
}
