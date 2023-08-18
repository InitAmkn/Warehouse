using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class Pallet : ISorage, IHaveWeight
    {

        public int id { get; }

        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public virtual double weight { get; private set; }



        public Pallet(double length, double width, double height, double weight)
        {
            this.length = length;
            this.width = width;
            this.height = height;
            this.weight = weight;

        }


    }
}
