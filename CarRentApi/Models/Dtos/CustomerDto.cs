using System;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Dtos
{
    public class CustomerDto : IEntity
    { 
        public Guid Guid { get; set; }
        public int CustomerNo { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string PhoneNo { get; set; }
    }
}
