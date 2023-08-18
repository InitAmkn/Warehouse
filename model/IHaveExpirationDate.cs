using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal interface IHaveExpirationDate
    {
         DateTime expirationDate { get; set; }
    }
}
