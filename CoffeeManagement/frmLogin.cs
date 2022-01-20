using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new();
            conn.ConnectionString = "data source = DESKTOP-3108059; database = COFFEECSZ; integrated security = True";

            // string query = "select * from USERS where username = '" + txtUser.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";
            //SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

            SqlCommand cmd = new("role_login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("@uname", txtUser.Text);
            cmd.Parameters.AddWithValue("@upass", txtPassword.Text);

            // DataTable dtbl = new DataTable();
            // adapter.Fill(dtbl);

            SqlDataReader rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                rd.Read();
                if (rd[3].ToString() == "admin")
                {
                    Main main = new("Admin");
                    main.Show();
                    this.Hide();
                }
                else if (rd[3].ToString() == "member")
                {
                    Main main = new("Member");
                    main.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("heckerdog ak","Vo' van?");
            }
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
