using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeManagement.Controllers;
using CoffeeManagement.Model;

namespace CoffeeManagement.Windows
{
    public partial class frmInvoice : Form
    {
        public frmInvoice()
        {
            InitializeComponent();
        }

        public List<Order> Orders { get; set; }

        public void AddOrder(List<Order> ord)
        {
            if (ord != null)
            {
                foreach (Order order in ord)
                {
                    int n = dtgvBill.Rows.Add();
                    dtgvBill.Rows[n].Cells[0].Value = order.Name;
                    dtgvBill.Rows[n].Cells[1].Value = order.Quantity;
                    dtgvBill.Rows[n].Cells[2].Value = order.Price;
                }
            }
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            AddOrder(Orders);

            txtTotalBill.Text = PlaceOrder.billTotal + "k";
            lbDate.Text = String.Format("Date: {0}", DateTime.Now.Date);
            
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        Bitmap bmp;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printPreviewDialog1.ShowDialog();
        }
    }
}
