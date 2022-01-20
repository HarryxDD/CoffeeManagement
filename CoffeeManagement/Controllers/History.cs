using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using excel = Microsoft.Office.Interop.Excel;

namespace CoffeeManagement.Controllers
{
    public partial class History : UserControl
    {
        private static History _instance;

        public static History Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new History();
                return _instance;
            }
        }

        Controller dt = new Controller();
        String query;

        public History()
        {
            InitializeComponent();
        }

        public void GetItem()
        {
            query = "select * from ORDERS";
            DataSet ds = dt.GetData(query);
            dtgvHis.AutoGenerateColumns = false;
            dtgvHis.DataSource = ds.Tables[0];
        }

        private void History_Load(object sender, EventArgs e)
        {
            GetItem();
        }

        private void comCategory_TextChanged(object sender, EventArgs e)
        {
            if (comCategory.Text == "customer")
            {
                dtpDate.SendToBack();
                pictureBox3.Show();
                GetItem();
            }
            else if (comCategory.Text == "date")
            {
                dtpDate.BringToFront();
                pictureBox3.Hide();
            }
        }

        public void DataFilter(string query)
        {
            try
            {
                DataSet ds = dt.GetData(query);
                dtgvHis.AutoGenerateColumns = false;
                dtgvHis.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong input!!");
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                GetItem();
            }
            else
            {
                query = "select * from ORDERS where " + comCategory.Text + " like '" + txtSearch.Text + "%'";
                DataFilter(query);

            }        
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            query = "select * from ORDERS where cast (datediff (day, 0, " + comCategory.Text + ") as datetime) = '" + dtpDate.Text + "'";
            DataFilter(query);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            excel.Application exApp = new();
            excel.Workbook workbook = exApp.Workbooks.Add();
            excel.Worksheet worksheet = null;

            exApp.Visible = true;
            worksheet = workbook.Sheets["sheet1"];
            worksheet = workbook.ActiveSheet;

            for (int i = 0; i < dtgvHis.Columns.Count; i++)
            {
                worksheet.Cells[1, i+1] = dtgvHis.Columns[i].HeaderText;
            }

            for (int i = 0; i < dtgvHis.Rows.Count-1; i++)
            {
                for (int j = 0; j < dtgvHis.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtgvHis.Rows[i].Cells[j].Value.ToString();
                }
            }

            worksheet.Columns.AutoFit();
        }

        
    }
}
