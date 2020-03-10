using System;
using System.ComponentModel.DataAnnotations;

namespace CarRentApi.Models.HelperClasses
{
    public class DailyFeeSearch
    {
        [Required]
        public Guid CarClassGuId { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
    }
}
