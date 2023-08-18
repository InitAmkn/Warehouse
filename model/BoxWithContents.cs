using System;
using System.Text;

namespace Warehouse.model
{
    internal class BoxWithContents : Box, IHaveExpirationDate, IHaveWeight
    {
        private const int shelfLife = 100;
        public DateTime productionDate { get; private set; }
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($"Production date: {this.productionDate}; ");
            sb.Append($"Expiration date: {this.expirationDate}; ");
            return sb.ToString();
        }
    }
}
