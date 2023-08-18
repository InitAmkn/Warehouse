using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal interface IStorage
    {
        int id { get; }
        double length { get; }
        double width { get; }
        double height { get; }

    }
}
