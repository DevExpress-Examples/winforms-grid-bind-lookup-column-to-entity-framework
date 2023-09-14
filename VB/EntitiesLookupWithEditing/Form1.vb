Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns

Namespace EntitiesLookupWithEditing

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private entities As NorthwindEntities = New NorthwindEntities()

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            gridView1.Columns.AddField("ProductName").Visible = True
            Dim column As GridColumn = gridView1.Columns.AddField("Categories")
            Dim editor As RepositoryItemLookUpEdit = CType(gridControl1.RepositoryItems.Add("LookUpEdit"), RepositoryItemLookUpEdit)
            editor.DataSource = entities.Categories
            editor.DisplayMember = "CategoryName"
            editor.Columns.Add(New DevExpress.XtraEditors.Controls.LookUpColumnInfo("CategoryName"))
            column.ColumnEdit = editor
            column.Visible = True
            gridControl1.DataSource = entities.Products
        End Sub

        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
            entities.SaveChanges()
        End Sub
    End Class
End Namespace
