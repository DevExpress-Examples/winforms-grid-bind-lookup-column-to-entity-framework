using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace EntitiesLookupWithEditing {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        NorthwindEntities entities = new NorthwindEntities();

        private void Form1_Load(object sender, EventArgs e) {
            gridView1.Columns.AddField("ProductName").Visible = true;
            GridColumn column = gridView1.Columns.AddField("Categories");
            RepositoryItemLookUpEdit editor = (RepositoryItemLookUpEdit)gridControl1.RepositoryItems.Add("LookUpEdit");
            editor.DataSource = entities.Categories;
            editor.DisplayMember = "CategoryName";
            editor.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryName"));
            column.ColumnEdit = editor;
            column.Visible = true;
            gridControl1.DataSource = entities.Products;
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            entities.SaveChanges();
        }
    }
}
