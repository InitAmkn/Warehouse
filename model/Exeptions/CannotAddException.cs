using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class CannotAddException : Exception
    {
        public CannotAddException(string massage) : base(massage) { }

    }
}
