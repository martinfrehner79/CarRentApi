using System;
using CarRentApi.Models.Interfaces;
using CarRentApi.Models.Classes;
namespace CarRentApi.Models.Dtos
{
    public class ReservationDto : IEntity
    {
        public Guid Guid { get; set; }
        public int ReservationNo { get; set; }
        public State ReservationState { get; set; }
        public Guid CustomerGuId { get; set; }
        public Guid CarClassGuId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal NoOfRentalDays { get; set; }
        public string CustomerRemark { get; set; }     
    }
}
