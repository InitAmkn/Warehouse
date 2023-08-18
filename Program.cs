using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Warehouse.model;

namespace Warehouse
{
    internal class Program
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["WarehouseDB.mdf"].ConnectionString;
        private SqlConnection connection = null;
        static void Main()
        {

            BoxWithContents box = new BoxWithContents(10,10,4,10, DateTime.Now.AddDays(-100));
            Console.WriteLine(box.expirationDate);
            Console.ReadLine();
        }
    }
}
