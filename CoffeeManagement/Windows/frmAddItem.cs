using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManagement.Windows
{
    public partial class frmAddItem : Form
    {

        Controller controller = new();
        String query;

        public frmAddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void ClearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItemName.Clear();
            txtItemPrice.Clear();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "insert into ITEM (name, category, price) values ('" + txtItemName.Text + "','" + txtCategory.Text + "'," + txtItemPrice.Text + ")";
            controller.SetData(query);
            ClearAll();
        }
    }
}
