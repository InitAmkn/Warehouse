using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.model
{
    internal class NoBoxesFoundException : Exception
    {
        public NoBoxesFoundException(string message) : base(message) { };
       
    }
}
