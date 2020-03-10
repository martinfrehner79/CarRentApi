using CarRentApi.Models.Classes;
using CarRentApi.Data;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;


namespace CarRentApi.Repository
{
    public class CarBrandRepository : BaseRepository<CarBrand, CarRentApiContext>, IRepository<CarBrand>
    {

        private readonly CarRentApiContext _dbContext;
        public CarBrandRepository(CarRentApiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
