using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class BoxWithContents : Box, IHaveExpirationDate
    {
        private const int shelfLife = 100;
        public DateTime productionDate { get; }
        public DateTime expirationDate { get; private set; }

        public BoxWithContents(double length, double width, double height, double weight, DateTime productionDate) : base(length, width, height, weight)
        {

            this.productionDate = productionDate;
            this.expirationDate = productionDate.AddDays(shelfLife);
        }

        public void setExpirationDate(DateTime expirationDate)
        {
            this.expirationDate = expirationDate;
        }
    }
}
