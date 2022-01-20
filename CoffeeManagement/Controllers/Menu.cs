using CoffeeManagement.Windows;
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

namespace CoffeeManagement.Controllers
{
    public partial class Menu : UserControl
    {
        private static Menu _instance;

        public static Menu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Menu();
                return _instance;
            }
        }


        Controller dt = new();
        String query;
        public static string itemName;
        public static int itemPrice;
        public static string itemCategory;
        public static int itemId;

        public Menu()
        {
            InitializeComponent();
        }


        private void Menu_Load(object sender, EventArgs e)
        {
            GetItem();
        }

        private void btnMenuAdd_Click(object sender, EventArgs e)
        {
            Form formBackground = new();
            try
            {
                using frmAddItem addItem = new();
                formBackground.StartPosition = FormStartPosition.Manual;
                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .70d;
                formBackground.BackColor = Color.Black;
                formBackground.WindowState = FormWindowState.Maximized;
                formBackground.TopMost = true;
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                addItem.Owner = formBackground;
                addItem.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
            
            
        }


        public void GetItem()
        {
            query = "select * from ITEM";
            DataSet ds = dt.GetData(query);
            dtgvItem.AutoGenerateColumns = false;
            dtgvItem.DataSource = ds.Tables[0];
        }

        int indexRow;
        public void dtgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            indexRow = e.RowIndex;
            DataGridViewRow row = dtgvItem.Rows[indexRow];
            itemName = row.Cells[0].Value.ToString();
            itemCategory = row.Cells[1].Value.ToString();
            itemPrice = int.Parse(row.Cells[2].Value.ToString());
            itemId = int.Parse(row.Cells[3].Value.ToString());

        }

        public void btnMenuDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure?", "Wait!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    //int selectedrowindex = dtgvItem.SelectedCells[0].RowIndex;
                    //DataGridViewRow selectedRow = dtgvItem.Rows[selectedrowindex];
                    //string name = Convert.ToString(selectedRow.Cells["ItemName"].Value);

                    dtgvItem.Rows.RemoveAt(this.dtgvItem.SelectedRows[0].Index);
                    query = "delete from ITEM where name='"+itemName+"'";
                    dt.SetData(query);
                    GetItem();
                }
            }
            catch { }
        }

        private void btnMenuUpd_Click(object sender, EventArgs e)
        {
            Form formBg = new();
            try
            {
                using frmUpdateItem updItem = new();
                formBg.StartPosition = FormStartPosition.Manual;
                formBg.FormBorderStyle = FormBorderStyle.None;
                formBg.Opacity = .70d;
                formBg.BackColor = Color.Black;
                formBg.WindowState = FormWindowState.Maximized;
                formBg.TopMost = true;
                formBg.Location = this.Location;
                formBg.ShowInTaskbar = false;
                formBg.Show();

                updItem.Owner = formBg;
                updItem.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBg.Dispose();
            }
        }

        private void btnMenuRefresh_Click(object sender, EventArgs e)
        {
            GetItem();
        }
    }
}
