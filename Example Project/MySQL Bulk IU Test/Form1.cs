using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_Bulk_IU_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "Server=localhost;Database=test;Uid=root;Pwd=1234;";

        private void btnTableCreate_Click(object sender, EventArgs e)
        {
            try
            {
                


                //create table
                string sqlQuery = "CREATE TABLE IF NOT EXISTS test_bulk (ID int primary key, Name nvarchar(100));";

                MySqlConnection mConnection = new MySqlConnection(connectionString);
                mConnection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(sqlQuery, mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                }
                mConnection.Close();

                MessageBox.Show("Table Created.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnBulkInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Name");

                for(int i = 0; i < 100; i++)
                {
                    table.Rows.Add((i+1).ToString(), RandomString(10));
                }

                bool result = MySQLBulkIU.BulkInsert.BulkToMySQL(table, "test_bulk", connectionString);

                if (result)
                    MessageBox.Show("Data Insert Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Name");

                for (int i = 0; i < 100; i++)
                {
                    table.Rows.Add((i + 1).ToString(), "Update data"+(i+1).ToString() );
                }

                bool result = MySQLBulkIU.BulkUpdate.UpdateBulkToMySQL(table, "test_bulk", "Name", "ID", connectionString);

                if (result)
                    MessageBox.Show("Data Update Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
