using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.model;

namespace Warehouse.SqlControllers
{
    internal class FillingPalletsSQL<T> where T : Storage
    {

        public FillingPalletsSQL(PalletsAutoFilling<T> palletsAutoFilling, SqlConnection sqlConnection)
        {
            writeToSql(palletsAutoFilling, sqlConnection);
        }

        private void writeToSql(PalletsAutoFilling<T> palletsAutoFilling, SqlConnection sqlConnection)
        {

            foreach (var item in palletsAutoFilling.getFilledPallets())
            {
                foreach (var contains in item.contains)
                {
                    SqlCommand command = new SqlCommand(
                    "INSERT INTO [PalletWithContents] (IdPallet, IdBox)" +
                    "VALUES (@IdPallet, @IdBox)", sqlConnection);
                    command.Parameters.AddWithValue("IdPallet", item.pallet.Id);
                    command.Parameters.AddWithValue("IdBox", contains.Id);
                    command.ExecuteNonQuery();
                }
            }

        }

    }
}
