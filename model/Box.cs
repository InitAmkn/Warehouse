
using System.Text;

namespace Warehouse.model
{
    internal abstract class Box : Storage, IHaveWeight
    {
        public virtual double Weight { get; private set; }
        public Box(double length, double width, double height, double Weight) : base(length, width, height)
        {
            this.Weight = Weight;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"box: {Length}х{Width}х{Height}; ");
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
