using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal interface Sorage
    {
        int id { get; }
        double length { set; get; }
        double width { set; get; }
        double height { set; get; }
        double weight { set; get; }

    }
}
