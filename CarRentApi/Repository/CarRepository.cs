using CarRentApi.Models.Classes;
using CarRentApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;

namespace CarRentApi.Repository
{
    public class CarRepository : BaseRepository<Car,CarRentApiContext>, IRepository<Car>
    {

        private readonly CarRentApiContext _dbContext;
        public CarRepository(CarRentApiContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public new async Task<List<Car>> Search(object key)
        {
            return await _dbContext.Cars.AsNoTracking()
                .AsQueryable()
                .Where(b => b.Name.Contains((string)key))
                .OrderBy(b => b.Name)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
