using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PMQLDD
{
    public partial class F_Main_DMHinhThucSuDung : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_DSHinhThucSuDung;
        private DataColumn co0, co1, co2;

        private XtraForm1 formIn;

        public F_Main_DMHinhThucSuDung()
        {
            InitializeComponent();
        }

        private void F_Main_DMHinhThucSuDung_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //Gridcontrol2 DSLoaiDat

            table_DSHinhThucSuDung = new DataTable();

            co0 = new DataColumn();
            co0.DataType = System.Type.GetType("System.Int32");
            co0.ColumnName = "STT";
            table_DSHinhThucSuDung.Columns.Add(co0);

            co1 = new DataColumn();
            co1.DataType = System.Type.GetType("System.String");
            co1.ColumnName = "Mã hình thức";
            table_DSHinhThucSuDung.Columns.Add(co1);

            co2 = new DataColumn();
            co2.DataType = System.Type.GetType("System.String");
            co2.ColumnName = "Tên hình thức";
            table_DSHinhThucSuDung.Columns.Add(co2);

            gridControl1.Width = int.MaxValue;
            gridControl1.DataSource = table_DSHinhThucSuDung;
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.Columns[0].Width = 5;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 400;

            //Chèn dữ liệu vào gridcontrol

            string s1 = "SELECT COUNT(ID) as SoHT FROM [GIAODAT].[dbo].[DMHinhthucsudung]";
            groupControl1.Text = "Danh sách hình thức | Tổng số hình thức : " + sql.GetData(s1, 0);

            DataColumn[] Array_col2 = { co0, co1, co2 };
            s1 = "SELECT ROW_NUMBER() OVER(ORDER BY [TenHinhthuc] ASC) AS Row#,[MaHinhthuc],[TenHinhthuc] FROM [GIAODAT].[dbo].[DMHinhthucsudung]";
            table_DSHinhThucSuDung.Clear();
            sql.ViewDataTable(s1, table_DSHinhThucSuDung, Array_col2);


            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (formIn == null)
                {
                    formIn = new XtraForm1("BÁO CÁO DANH MỤC HÌNH THỨC SỬ DỤNG", table_DSHinhThucSuDung);
                    formIn.FormClosed += new FormClosedEventHandler(formIn_FormClosed);
                    formIn.Show();
                }
                else
                    formIn.Activate();
            }
            catch { }
        }

        void formIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formIn = null;
        }

        private void toolStripMenuItem_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx",
                FileName = "SavedDocument"
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetFullPath(save.FileName);
                sql.ExportExcel2007(ext, table_DSHinhThucSuDung);
            }
        }
    }
}