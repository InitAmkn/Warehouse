using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.model;

namespace Warehouse.SqlControllers
{
    internal class ReaderPalletSQL
    {


        public List<Pallet> readToSql(SqlConnection sqlConnection)
        {
            List <Pallet> listPallet = new List<Pallet>();

            SqlDataReader dataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Id, Length, Width, Height, Weight FROM [Pallet]", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    listPallet.Add(
                        new Pallet(
                            Convert.ToDouble(dataReader["Length"]),
                            Convert.ToDouble(dataReader["Width"]),
                            Convert.ToDouble(dataReader["Height"]),
                            Convert.ToDouble(dataReader["Weight"])
                           ));

                    listPallet[listPallet.Count-1].SetID(Convert.ToInt32(dataReader["Id"]));
                }
                return listPallet;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }


        }

    }
}
