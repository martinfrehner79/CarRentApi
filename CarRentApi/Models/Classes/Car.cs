using System;
using System.ComponentModel.DataAnnotations;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Classes
{
    public class Car : IEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [Required]
        [StringLength(60)]
        public string RegistrationPlate { get; set; }

        [Required]
        public Guid CarBrandGuId { get; set; }

        [Required]
        public Guid CarClassGuId { get; set; }    
    }
}
