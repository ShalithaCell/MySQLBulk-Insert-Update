using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLBulkIU
{
    public class BulkUpdate
    {
        /*
         * Create date - 01-06-2019
         * Author      - Shalitha senanayaka(https://github.com/ShalithaCell)
         * Comment     - Update bulk data to database in one query
         * */
        //update bulk data to relevent database table
        public static bool UpdateBulkToMySQL(DataTable dt, string tableName, string valueColumn, string conditionColumn, string ConnectionString)
        {
            try
            {
                /* -------------------------key note----------------------------
             * 
             * dt              = datatable with values to be updated.
             * tableName       = Table name to be updated in Database.
             * Value_Column    = column name to be updated.
             * conditionColumn = column name used to write 'WHERE' condition
             * ConnectionString= MySQL connection string
             * */

                int result = 0;

                if (dt.Rows.Count == 0 || tableName == string.Empty)
                    return false;

                //creating UPDATE Query Header accordingf to datatable column headers
                StringBuilder query = new StringBuilder("UPDATE " + tableName + " SET " + valueColumn + " = ( CASE " + conditionColumn + " ");

                List<string> Cases = new List<string>();
                List<string> IDs = new List<string>();

                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    string key = string.Empty;
                    string value = string.Empty;

                    key = dt.Rows[n][conditionColumn].ToString();
                    value = dt.Rows[n][valueColumn].ToString();

                    string CASE = "WHEN " + key + " THEN '" + value + "'";

                    Cases.Add(CASE);

                    IDs.Add(key);
                }

                query.Append(String.Join(" ", Cases));
                query.Append(" END ) WHERE " + conditionColumn + " IN ( ");

                query.Append(String.Join(",", IDs));
                query.Append(" );");

                //Updating

                MySqlConnection mConnection = new MySqlConnection(ConnectionString);
                mConnection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(query.ToString(), mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    result = myCmd.ExecuteNonQuery();
                }
                mConnection.Close();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
