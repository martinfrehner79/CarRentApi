using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentApi.Models.Classes;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Repository.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid guid);
        Task AddAsync(T obj);
        Task DeleteAsync(Guid guid);
        Task UpdateAsync(T obj);
        Task<List<T>> Search(object key);
    }
}
