using System;


namespace Warehouse.model
{
    internal class CannotAddException : Exception
    {
        public CannotAddException(string massage) : base(massage) { }

    }
}
