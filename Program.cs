using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Warehouse.model;
using Warehouse.SqlControllers;

namespace Warehouse
{
    internal class Program
    {
  

        static void Main()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["WarehouseDB"].ConnectionString);
            sqlConnection.Open();
           // new GenerationRandomPalletsSQL(3, sqlConnection);
           // new GenerationRandomBoxesSQL(10, sqlConnection);
           
            ReaderBoxWithContentsSQL readerBoxWithContentsSQL = new ReaderBoxWithContentsSQL();
            ReaderPalletSQL readerPalletSQL = new ReaderPalletSQL();

            List<BoxWithContents> boxWithContents = readerBoxWithContentsSQL.readToSql(sqlConnection);
            List<Pallet> pallets = readerPalletSQL.readToSql(sqlConnection);

            PalletsAutoFilling<BoxWithContents> palletsAutoFilling = new PalletsAutoFilling<BoxWithContents>(boxWithContents, pallets);
            FillingPalletsSQL<BoxWithContents> fillingPalletsSQL = 
                new FillingPalletsSQL<BoxWithContents>( palletsAutoFilling, sqlConnection);

            
            Console.WriteLine(palletsAutoFilling);

            //PalletWithContents pallet = new PalletWithContents(new Pallet(10,525,46,8));
            //Console.WriteLine(pallet);
            Console.ReadLine();
        }
    }
}
