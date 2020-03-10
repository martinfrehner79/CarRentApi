using System;
using System.ComponentModel.DataAnnotations;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Classes
{
    public class CarClass : IEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }
    }
}
