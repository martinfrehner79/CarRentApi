using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Classes
{
    public class Reservation : IEntity
    {
        [Key]
        public Guid Guid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationNo { get; set; }
        public State ReservationState { get; set; }
        [Required]
        public Guid CustomerGuId { get; set; }
        [Required]
        public Guid CarClassGuId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "1", "100")]
        public decimal NoOfRentalDays { get; set; }
        [StringLength(250)]
        public string CustomerRemark { get; set; }

        public void CloseReservation()
        {
            ReservationState=State.Closed;
        }
    }
}
