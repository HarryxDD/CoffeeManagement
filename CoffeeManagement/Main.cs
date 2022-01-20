using CoffeeManagement.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        public Main(String user)
        {
            InitializeComponent();

            if (user == "Member")
            {
                btnAdd.Hide();
                btnHis.Hide();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(PlaceOrder.Instance))
            {
                panel2.Controls.Add(PlaceOrder.Instance);
                PlaceOrder.Instance.Dock = DockStyle.Fill;
                PlaceOrder.Instance.BringToFront();
            }
            else PlaceOrder.Instance.BringToFront();

            button1.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin lg = new();
            this.Hide();
            lg.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(Menu.Instance)) {
                panel2.Controls.Add(Menu.Instance);
                Menu.Instance.Dock = DockStyle.Fill;
                Menu.Instance.BringToFront();
            } else Menu.Instance.BringToFront();

            button1.BringToFront();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Menu.Instance.Visible = false;
            PlaceOrder.Instance.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do want to exit?", "Close the Application", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHis_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(History.Instance))
            {
                panel2.Controls.Add(History.Instance);
                History.Instance.Dock = DockStyle.Fill;
                History.Instance.BringToFront();
            }
            else History.Instance.BringToFront();

            button1.BringToFront();
        }
    }
}
