using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLBulkIU
{
    public class BulkInsert
    {
        /*
         * Create date - 12-15-2018
         * Author      - Shalitha senanayaka (https://github.com/ShalithaCell)
         * Comment     - Insert bulk datat to database in one query
         * */
        //saving bulk data to relevent database table
        public static bool BulkToMySQL(DataTable dt, string tableName, string ConnectionString)
        {
            /* -------------------------key note----------------------------
             * 
             * dt               = datatable with values to be updated.
             * tableName        = Table name tobe updated in Database.
             * ConnectionString = MySql Connection String
             * 
             * */

            int result = 0;

            if (dt.Rows.Count == 0 || tableName == string.Empty)
                return false;

            //creating INSERT Query Header accordingf to datatable column headers
            StringBuilder queryHeader = new StringBuilder("INSERT INTO " + tableName + " (");
            List<string> columns = new List<string>();

            foreach (DataColumn column in dt.Columns)
            {
                columns.Add(column.ColumnName);
            }
            queryHeader.Append(string.Join(",", columns));
            queryHeader.Append(")");
            queryHeader.Append(" VALUES ");

            
            StringBuilder sCommand = new StringBuilder(queryHeader.ToString());
            using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
            {
                List<string> Rows = new List<string>();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder rowData = new StringBuilder("(");
                    List<string> Values = new List<string>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        Values.Add("'" + dr[dc.ColumnName].ToString() + "'");
                    }
                    rowData.Append(string.Join(",", Values));
                    rowData.Append(")");

                    Rows.Add(rowData.ToString());
                }


                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");
                //string xx = sCommand.ToString();
                mConnection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    result = myCmd.ExecuteNonQuery();
                }


            }

            if (result > 0)
                return true;
            else
                return false;
            
        }
    }
}
