using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeManagement.Windows;
using CoffeeManagement.Model;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;

namespace CoffeeManagement.Controllers
{
    public partial class PlaceOrder : UserControl
    {
        private static PlaceOrder _instance;

        public static PlaceOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlaceOrder();
                return _instance;
            }
        }

        Controller controller = new();
        String query;
        public static int billTotal;
        

        public PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            String category = comboCategory.Text;
            query = "select name from ITEM where category = '" + category + "'";
            ShowItemList(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            String category = comboCategory.Text;
            query = "select name from ITEM where category = '" + category + "' and name like '"+txtSearch.Text+"%'";
            ShowItemList(query);
        }

        private void ShowItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = controller.GetData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOrderQuantity.ResetText();
            txtTotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtOrderName.Text = text;
            query = "select price from ITEM where name = '" + text + "'";
            DataSet ds = controller.GetData(query);

            try
            {
                txtOrderPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex) 
            { 
            }
        }

        private void txtOrderQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtOrderQuantity.Value.ToString());
            Int64 price = Int64.Parse(txtOrderPrice.Text);
            txtTotal.Text = (quan*price).ToString();
        }

        protected int n;
        protected int total = 0;       
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text != "0" && txtTotal.Text != "")
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtOrderName.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtTotal.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtOrderQuantity.Text;
                dataGridView1.Rows[n].Cells[3].Value = txtOrderPrice.Text;

                total += int.Parse(txtTotal.Text);
                labelTotal.Text = total + " k";
            }
            else
            {
                MessageBox.Show("Mua bao nhieu cai?", "Tu` tu` tu` binh` tinh~ nao`", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtOrderQuantity.Value = 0;
        }

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            catch { }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch { }
            
            total -= amount;
            labelTotal.Text = total + " k";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*DGVPrinter printer = new DGVPrinter();
            printer.Title = "CSZ Coffee";
            printer.SubTitle = String.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payable Amount: " + labelTotal.Text;
            printer.FooterSpacing = 5;
            printer.PrintDataGridView(dataGridView1);
            

            total = 0;
            dataGridView1.Rows.Clear();
            labelTotal.Text = total + " k";*/

            string cusName = Interaction.InputBox("Enter Customer's Name: ", "Customer:", "", 500, 300);
            //DateTime date = DateTime.ParseExact(DateTime.Now.Date.ToString(), "yyyy-MM-dd", null);
            

            if (cusName != "")
            {
                DateTime date = DateTime.Today;
                query = "insert into ORDERS (customer, date, cost) values ('" + cusName + "','" + date.ToString("yyyy-MM-dd") + "'," + (int)total + ")";
                controller.SetData(query);
            }
            

            List<Order> Ord = new();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Ord.Add(new Order
                {
                    Name = (string)row.Cells[0].Value,
                    Quantity = (string)row.Cells[2].Value,
                    Price = (string)row.Cells[1].Value
                });
            }

            billTotal = total;
            frmInvoice bill = new();
            bill.Orders = Ord;
            
            bill.ShowDialog();
            
        }
    }
}
