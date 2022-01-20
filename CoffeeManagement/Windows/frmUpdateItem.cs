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

namespace CoffeeManagement.Windows
{
    public partial class frmUpdateItem : Form
    {
        Controller dt = new();
        String query;

        public frmUpdateItem()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void frmUpdateItem_Load(object sender, EventArgs e)
        {
            txtUpdItemName.Text = Menu.itemName;
            txtUpdCategory.Text = Menu.itemCategory;
            txtUpdItemPrice.Text = Menu.itemPrice.ToString();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            query = "update ITEM set name ='"+txtUpdItemName.Text+"', category='"+txtUpdCategory.Text+"', price="+txtUpdItemPrice.Text+" where id ="+Menu.itemId+"";
            dt.SetData(query);
            Close();
        }
    }
}
