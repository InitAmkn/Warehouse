using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.model;

namespace Warehouse.SqlControllers
{
    internal class ReaderBoxWithContentsSQL
    {


        public List<BoxWithContents> readToSql(SqlConnection sqlConnection)
        {
            List <BoxWithContents> listBoxes = new List<BoxWithContents>();

            SqlDataReader dataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Id, Length, Width, Height, Weight, ProductionDate, ExpirationDate FROM [Box]", sqlConnection);
                dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    listBoxes.Add(
                        new BoxWithContents(
                            Convert.ToDouble(dataReader["Length"]),
                            Convert.ToDouble(dataReader["Width"]),
                            Convert.ToDouble(dataReader["Height"]),
                            Convert.ToDouble(dataReader["Weight"]),
                            Convert.ToDateTime(dataReader["ProductionDate"]),
                            Convert.ToDateTime(dataReader["ExpirationDate"])
                           ));

                            listBoxes[listBoxes.Count-1].SetID(Convert.ToInt32(dataReader["Id"]));
                }
                return listBoxes;
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
