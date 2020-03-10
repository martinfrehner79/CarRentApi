using System;
using CarRentApi.Models.Interfaces;


namespace CarRentApi.Models.Dtos
{
    public class CarDto : IEntity
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }      
        public string RegistrationPlate { get; set; }
        public Guid CarBrandGuid { get; set; }       
        public Guid CarClassGuid { get; set; }
    }
}
