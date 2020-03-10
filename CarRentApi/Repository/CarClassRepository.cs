using CarRentApi.Models.Classes;
using CarRentApi.Data;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Repository
{
    public class CarClassRepository : BaseRepository<CarClass, CarRentApiContext>, IRepository<CarClass>
    {

        private readonly CarRentApiContext _dbContext;
        public CarClassRepository(CarRentApiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
