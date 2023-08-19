namespace Warehouse.model
{
    internal abstract class Storage : IHaveVolume
    {
        public int Id { get; protected set; }
        public double Length { get; protected set; }
        public double Width { get; protected set; }
        public double Height { get; protected set; }

        public double Volume { get; protected set; }

        public Storage(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
            setVolume();
        }
        protected void setVolume()
        {
            Volume = Length * Width * Height;
        }

    }
}
