using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Warehouse.model;

namespace Warehouse.SqlControllers
{
    internal class GenerationRandomBoxesSQL
    {

        Random random = new Random();

        private List<BoxWithContents> randomBoxes(int count)
        {
            List<BoxWithContents> listBoxes = new List<BoxWithContents>();

            for (int i = 0; i < count; i++)
            {
               
                listBoxes.Add(new BoxWithContents(
                     random.Next(10, 1000),
                     random.Next(10, 1000),
                     random.Next(10, 1000),
                     random.Next(10, 1000),
                    DateTime.Now,
                    DateTime.Now.AddDays(random.Next(10, 1000))
                    ));
            }
            return listBoxes;
        }

        private void writeToSql(int count, SqlConnection sqlConnection)
        {
            List<BoxWithContents> randomBoxesForSQL = randomBoxes(count);
            int countAdded = 0;
            foreach (var item in randomBoxesForSQL)
            {
                SqlCommand command = new SqlCommand(
                "INSERT INTO [Box] (Length,Width, Height, Weight,ProductionDate,ExpirationDate)" +
                "VALUES (@Length, @Width, @Height, @Weight, @ProductionDate, @ExpirationDate)", sqlConnection);
                command.Parameters.AddWithValue("Length", item.Length);
                command.Parameters.AddWithValue("Width", item.Width);
                command.Parameters.AddWithValue("Height", item.Height);
                command.Parameters.AddWithValue("Weight", item.Weight);
                command.Parameters.AddWithValue("ProductionDate", item.productionDate);
                command.Parameters.AddWithValue("ExpirationDate", item.expirationDate);

                countAdded = countAdded + command.ExecuteNonQuery();
            }
            Console.WriteLine($"Added {countAdded} Boxes");
        }

        public GenerationRandomBoxesSQL(int count, SqlConnection sqlConnection)
        {
            writeToSql(count, sqlConnection);
        }



    }
}
