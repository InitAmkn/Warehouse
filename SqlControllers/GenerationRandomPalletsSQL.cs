using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.model;

namespace Warehouse.SqlControllers
{
    internal class GenerationRandomPalletsSQL
    {

        Random random = new Random();

        private List<Pallet> randomPallets(int count)
        {
            List<Pallet> listPallets = new List<Pallet>();

            for (int i = 0; i < count; i++)
            {

                listPallets.Add(new Pallet(
                     random.Next(10, 1000),
                     random.Next(10, 1000),
                     random.Next(10, 1000),
                     random.Next(10, 1000)

                    ));
            }
            return listPallets;
        }

        private void writeToSql(int count, SqlConnection sqlConnection)
        {
            List<Pallet> randomPalletsForSQL = randomPallets(count);
            int countAdded = 0;
            foreach (var item in randomPalletsForSQL)
            {
                SqlCommand command = new SqlCommand(
                "INSERT INTO [Pallet] (Length,Width, Height, Weight)" +
                "VALUES (@Length, @Width, @Height, @Weight)", sqlConnection);
                command.Parameters.AddWithValue("Length", item.Length);
                command.Parameters.AddWithValue("Width", item.Width);
                command.Parameters.AddWithValue("Height", item.Height);
                command.Parameters.AddWithValue("Weight", item.Weight);

                countAdded = countAdded + command.ExecuteNonQuery();
            }
            Console.WriteLine($"Added {countAdded} Pallets");


        }

        public GenerationRandomPalletsSQL(int count, SqlConnection sqlConnection)
        {
            writeToSql(count, sqlConnection);
        }
    }
}
