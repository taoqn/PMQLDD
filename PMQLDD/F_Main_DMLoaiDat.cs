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
    public partial class F_Main_DMLoaiDat : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_DSLoaiDat;
        private DataColumn co0, co1, co2;

        private XtraForm1 formIn;

        public F_Main_DMLoaiDat()
        {
            InitializeComponent();
        }

        private void F_Main_DMLoaiDat_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //Gridcontrol2 DSLoaiDat

            table_DSLoaiDat = new DataTable();

            co0 = new DataColumn();
            co0.DataType = System.Type.GetType("System.Int32");
            co0.ColumnName = "STT";
            table_DSLoaiDat.Columns.Add(co0);

            co1 = new DataColumn();
            co1.DataType = System.Type.GetType("System.String");
            co1.ColumnName = "Mã loại đất";
            table_DSLoaiDat.Columns.Add(co1);

            co2 = new DataColumn();
            co2.DataType = System.Type.GetType("System.String");
            co2.ColumnName = "Tên loại đất";
            table_DSLoaiDat.Columns.Add(co2);

            gridControl1.Width = int.MaxValue;
            gridControl1.DataSource = table_DSLoaiDat;
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.Columns[0].Width = 5;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 300;

            //Chèn dữ liệu vào gridcontrol

            string s1 = "SELECT COUNT(ID) as SoLD FROM [GIAODAT].[dbo].[DMLoaidat]";
            groupControl1.Text = "Danh sách loại đất | Tổng số loại đất : " + sql.GetData(s1, 0);

            DataColumn[] Array_col2 = { co0, co1, co2 };
            s1 = "SELECT ROW_NUMBER() OVER(ORDER BY [TenLD] ASC) AS Row#,[MaLD],[TenLD] FROM [GIAODAT].[dbo].[DMLoaidat]";
            table_DSLoaiDat.Clear();
            sql.ViewDataTable(s1, table_DSLoaiDat, Array_col2);


            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (formIn == null)
                {
                    formIn = new XtraForm1("BÁO CÁO DANH MỤC LOẠI ĐẤT", table_DSLoaiDat);
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
                sql.ExportExcel2007(ext, table_DSLoaiDat);
            }
        }
    }
}