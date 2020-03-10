using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRentApi.Models.Classes;
using CarRentApi.Data;
using CarRentApi.Models.HelperClasses;
using CarRentApi.Repository.Base;
using CarRentApi.Repository.Interfaces;
namespace CarRentApi.Repository
{
    public class DailyFeeRepository : BaseRepository<DailyFee, CarRentApiContext>, IRepository<DailyFee>
    {

        private readonly CarRentApiContext _dbContext;
        public DailyFeeRepository(CarRentApiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public new async Task<List<DailyFee>> Search(object key)
        {
            if ((key == null) || (key.GetType() != typeof(DailyFeeSearch)))
                throw new System.ArgumentException("key must be of Type DailyFeeSearch");
            var dailyFeeSearch = (DailyFeeSearch)key;
            var query = _dbContext.DailyFees.AsNoTracking().AsQueryable();
            if (dailyFeeSearch.CarClassGuId  != null)
                query = query.Where(d => d.CarClassGuId.Equals(dailyFeeSearch.CarClassGuId));
            if (dailyFeeSearch.ValidFrom!=null)
                query = query.Where(d => d.ValidFrom >= dailyFeeSearch.ValidFrom);          
            return await query.OrderBy(d => d.ValidFrom).ToListAsync().ConfigureAwait(false);
        }
    }
}
