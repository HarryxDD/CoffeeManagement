namespace CoffeeManagement.Controllers
{
    partial class Menu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMenuAdd = new System.Windows.Forms.Button();
            this.btnMenuUpd = new System.Windows.Forms.Button();
            this.btnMenuDel = new System.Windows.Forms.Button();
            this.dtgvItem = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMenuRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenuAdd
            // 
            this.btnMenuAdd.BackColor = System.Drawing.Color.Brown;
            this.btnMenuAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAdd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenuAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMenuAdd.Location = new System.Drawing.Point(651, 103);
            this.btnMenuAdd.Name = "btnMenuAdd";
            this.btnMenuAdd.Size = new System.Drawing.Size(200, 75);
            this.btnMenuAdd.TabIndex = 22;
            this.btnMenuAdd.Text = "Add Item";
            this.btnMenuAdd.UseVisualStyleBackColor = false;
            this.btnMenuAdd.Click += new System.EventHandler(this.btnMenuAdd_Click);
            // 
            // btnMenuUpd
            // 
            this.btnMenuUpd.BackColor = System.Drawing.Color.Brown;
            this.btnMenuUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuUpd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenuUpd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMenuUpd.Location = new System.Drawing.Point(651, 250);
            this.btnMenuUpd.Name = "btnMenuUpd";
            this.btnMenuUpd.Size = new System.Drawing.Size(200, 75);
            this.btnMenuUpd.TabIndex = 23;
            this.btnMenuUpd.Text = "Update Item";
            this.btnMenuUpd.UseVisualStyleBackColor = false;
            this.btnMenuUpd.Click += new System.EventHandler(this.btnMenuUpd_Click);
            // 
            // btnMenuDel
            // 
            this.btnMenuDel.BackColor = System.Drawing.Color.Brown;
            this.btnMenuDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenuDel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMenuDel.Location = new System.Drawing.Point(651, 404);
            this.btnMenuDel.Name = "btnMenuDel";
            this.btnMenuDel.Size = new System.Drawing.Size(200, 75);
            this.btnMenuDel.TabIndex = 24;
            this.btnMenuDel.Text = "Remove Item";
            this.btnMenuDel.UseVisualStyleBackColor = false;
            this.btnMenuDel.Click += new System.EventHandler(this.btnMenuDel_Click);
            // 
            // dtgvItem
            // 
            this.dtgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemCategory,
            this.ItemPrice,
            this.id});
            this.dtgvItem.Location = new System.Drawing.Point(77, 103);
            this.dtgvItem.Name = "dtgvItem";
            this.dtgvItem.RowTemplate.Height = 25;
            this.dtgvItem.Size = new System.Drawing.Size(492, 525);
            this.dtgvItem.TabIndex = 25;
            this.dtgvItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvItem_CellClick);
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "name";
            this.ItemName.HeaderText = "Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 150;
            // 
            // ItemCategory
            // 
            this.ItemCategory.DataPropertyName = "category";
            this.ItemCategory.HeaderText = "Category";
            this.ItemCategory.Name = "ItemCategory";
            this.ItemCategory.Width = 150;
            // 
            // ItemPrice
            // 
            this.ItemPrice.DataPropertyName = "price";
            this.ItemPrice.HeaderText = "Price";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Width = 150;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "ItemID";
            this.id.Name = "id";
            // 
            // btnMenuRefresh
            // 
            this.btnMenuRefresh.BackColor = System.Drawing.Color.Brown;
            this.btnMenuRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuRefresh.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenuRefresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMenuRefresh.Location = new System.Drawing.Point(651, 553);
            this.btnMenuRefresh.Name = "btnMenuRefresh";
            this.btnMenuRefresh.Size = new System.Drawing.Size(200, 75);
            this.btnMenuRefresh.TabIndex = 26;
            this.btnMenuRefresh.Text = "Refresh";
            this.btnMenuRefresh.UseVisualStyleBackColor = false;
            this.btnMenuRefresh.Click += new System.EventHandler(this.btnMenuRefresh_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnMenuRefresh);
            this.Controls.Add(this.dtgvItem);
            this.Controls.Add(this.btnMenuDel);
            this.Controls.Add(this.btnMenuUpd);
            this.Controls.Add(this.btnMenuAdd);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(938, 753);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btnMenuAdd;
        private Button btnMenuUpd;
        private Button btnMenuDel;
        private DataGridView dtgvItem;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn ItemCategory;
        private DataGridViewTextBoxColumn ItemPrice;
        private DataGridViewTextBoxColumn id;
        private Button btnMenuRefresh;
    }
}
