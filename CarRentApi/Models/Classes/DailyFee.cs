using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Classes
{
    public class DailyFee : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        public Guid CarClassGuId { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DayFee { get; set; }
    }
}
