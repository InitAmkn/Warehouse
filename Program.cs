using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Warehouse
{
    internal class Program
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["WarehouseDB.mdf"].ConnectionString;
        private SqlConnection connection = null;
        static void Main(string[] args)
        {
            

        }
    }
}
