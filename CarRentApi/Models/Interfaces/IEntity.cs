using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentApi.Models.Interfaces
{
    public interface IEntity
    {
        Guid Guid { get; set; }
    }
}
