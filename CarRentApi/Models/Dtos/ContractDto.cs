using System;
using CarRentApi.Models.Interfaces;

namespace CarRentApi.Models.Dtos
{
    public class ContractDto : IEntity
    {
        public Guid Guid { get; set; }   
        public int ContractNo { get; set; }      
        public Guid CustomerGuId { get; set; }
        public Guid CarGuId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DailyFee { get; set; }      
        public decimal TotalCost { get; set; }
        public string CustomerRemark { get; set; }
        public string InternalRemark { get; set; }
    }
}
