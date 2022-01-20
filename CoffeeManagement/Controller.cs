using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManagement
{
    internal class Controller
    {
        protected SqlConnection GetConnection()
        {
            SqlConnection conn = new();
            conn.ConnectionString = "data source = DESKTOP-3108059; database = COFFEECSZ; integrated security = True";
            return conn;
        }

        public DataSet GetData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new();
            cmd.Connection = conn;
            cmd.CommandText = query;
            SqlDataAdapter adapter = new(cmd);
            DataSet ds = new();
            adapter.Fill(ds);
            return ds;
        }

        public void SetData(String query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new();
            cmd.Connection= conn;
            conn.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Successfully", "Noti!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
