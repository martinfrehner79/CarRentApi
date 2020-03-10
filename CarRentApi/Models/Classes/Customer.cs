using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRentApi.Models.Interfaces;


namespace CarRentApi.Models.Classes
{
    public class Customer :IEntity
    {
        [Key]
        public Guid Guid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerNo { get; set; }

        [Required]
        [StringLength(60)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(60)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(60)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string ZIP { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [StringLength(30)]
        public string PhoneNo { get; set; }
    }
}
