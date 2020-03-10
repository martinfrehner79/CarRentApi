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
    public class CustomerRepository : BaseRepository<Customer, CarRentApiContext>, IRepository<Customer>
    {

        private readonly CarRentApiContext _dbContext;
        public CustomerRepository(CarRentApiContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<List<Customer>> Search(object key)
        {
            if ((key == null) || (key.GetType() != typeof(CustomerSearch)))
                throw new System.ArgumentException("key must be of Type CustomerSearch");
            var customerSearch = (CustomerSearch)key;
            var query = _dbContext.Customers.AsNoTracking().AsQueryable();
            if (customerSearch.CustomerNo != 0)
                query = query.Where(c => c.CustomerNo.Equals(customerSearch.CustomerNo));
            if (!string.IsNullOrWhiteSpace(customerSearch.Name))
                query = query.Where(c => c.Firstname.Contains(customerSearch.Name) || c.Lastname.Contains(customerSearch.Name));
            if (!string.IsNullOrWhiteSpace(customerSearch.City))
                query = query.Where(c => c.City.Contains(customerSearch.City));
            return await query.OrderBy(c => c.Lastname).ToListAsync().ConfigureAwait(false);
        }
    }
}
