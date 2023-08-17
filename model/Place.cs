using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal abstract class Place
    {
        protected double length { set; get; }
        protected double width { set; get; }
        protected double height { set; get; }

    }
}
