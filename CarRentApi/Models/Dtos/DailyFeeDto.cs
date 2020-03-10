using System;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Dtos
{
    public class DailyFeeDto :IEntity
    {
        public Guid Guid { get; set; }
        public Guid CarClassGuId { get; set; }
        public DateTime ValidFrom { get; set; }
        public decimal DayFee { get; set; }
    }
}
