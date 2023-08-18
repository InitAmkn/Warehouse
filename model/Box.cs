using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class Box : IStorage, IHaveWeight
    {

        public int id { get; private set; }

        public double length { get; private set; }
        public double width { get; private set; }
        public double height { get; private set; }
        public double weight { get; private set; }



        public Box(double length, double width, double height, double weight)
        {
            this.length = length;
            this.width = width;
            this.height = height;
            this.weight = weight;
          
        }
    }
}
