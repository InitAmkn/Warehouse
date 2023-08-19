using System.Text;

namespace Warehouse.model
{
    internal class Pallet : Storage, IHaveWeight
    {
        public virtual double Weight { get; private set; }
        public Pallet(double length, double width, double height, double Weight) : base(length, width, height)
        {
            this.Weight = Weight;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            sb.Append($"Pallet: Id:{Id}; Dimensions: {Length}х{Width}х{Height};");
            sb.Append("\n");
            return sb.ToString();
        }

    }
}
