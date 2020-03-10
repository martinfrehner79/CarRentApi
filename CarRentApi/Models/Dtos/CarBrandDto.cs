using System;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Dtos
{
    public class CarBrandDto : IEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
    }
}
