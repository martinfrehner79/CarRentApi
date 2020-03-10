using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Classes
{
    public class Contract : IEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractNo { get; set; }        
        public Guid ReservationGuId { get; set; }
        [Required]
        public Guid CustomerGuId { get; set; }
        [Required]
        public Guid CarGuId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NoOfRentalDays { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DailyFee { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        [StringLength(250)]
        public string CustomerRemark { get; set; }

        [StringLength(250)]
        public string InternalRemark { get; set; }

        public Contract(){}        

        public Contract(Reservation reservation, Car car, DailyFee dailyFee)
        { 
            Guid = new Guid();
            ReservationGuId = reservation.Guid;
            CustomerGuId = reservation.CustomerGuId;
            CarGuId = car.Guid;
            StartDate = reservation.StartDate;
            NoOfRentalDays = reservation.NoOfRentalDays;
            CustomerRemark = reservation.CustomerRemark;
            InternalRemark = "";
            DailyFee = dailyFee.DayFee;
            CalcEndDate();
            CalcTotalCost();
            reservation.CloseReservation();
        }

        public void CalcEndDate()
        {
            EndDate = StartDate + new TimeSpan((int)NoOfRentalDays, 0,0,0);
        }

        public void CalcTotalCost()
        {
            TotalCost = NoOfRentalDays * DailyFee;
        }

    }
}
