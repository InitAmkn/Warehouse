using System;
using System.Collections.Generic;
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
            List<BoxWithContents> boxes = new List<BoxWithContents>();
            boxes.Add(new BoxWithContents(1000, 60, 4, 10, DateTime.Now.AddDays(7)));
            boxes.Add(new BoxWithContents(1000, 350, 40, 100, DateTime.Now.AddDays(10)));
            boxes.Add(new BoxWithContents(200, 400, 400, 1000, DateTime.Now.AddDays(5)));
            var pallet = new Pallet(1000, 300, 20, 30);
            var palletWithBoxes = new PalletWithContents(pallet);
            palletWithBoxes.addContains(boxes[0]);
            palletWithBoxes.addContains(boxes[1]);
            palletWithBoxes.addContains(boxes[2]);
            palletWithBoxes.addContains(new Pallet(10,10,10,10));
           
            Console.WriteLine(palletWithBoxes);

            Console.ReadLine();
        }
    }
}
