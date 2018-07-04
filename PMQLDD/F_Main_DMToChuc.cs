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
    public partial class F_Main_DMToChuc : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_DSToChuc;
        private DataColumn co0, co1, co2, co3, co4, co5, co6;

        private XtraForm1 formIn;

        public F_Main_DMToChuc()
        {
            InitializeComponent();
        }

        private void F_Main_DMToChuc_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //Gridcontrol2 DSToChuc

            table_DSToChuc = new DataTable();

            co0 = new DataColumn();
            co0.DataType = System.Type.GetType("System.Int32");
            co0.ColumnName = "STT";
            table_DSToChuc.Columns.Add(co0);


            co1 = new DataColumn();
            co1.DataType = System.Type.GetType("System.String");
            co1.ColumnName = "Mã tổ chức";
            table_DSToChuc.Columns.Add(co1);

            co2 = new DataColumn();
            co2.DataType = System.Type.GetType("System.String");
            co2.ColumnName = "Tên tổ chức";
            table_DSToChuc.Columns.Add(co2);

            co3 = new DataColumn();
            co3.DataType = System.Type.GetType("System.String");
            co3.ColumnName = "Địa chỉ";
            table_DSToChuc.Columns.Add(co3);

            co4 = new DataColumn();
            co4.DataType = System.Type.GetType("System.String");
            co4.ColumnName = "Mã số thuế";
            table_DSToChuc.Columns.Add(co4);

            co5 = new DataColumn();
            co5.DataType = System.Type.GetType("System.String");
            co5.ColumnName = "Giám đốc";
            table_DSToChuc.Columns.Add(co5);

            co6 = new DataColumn();
            co6.DataType = System.Type.GetType("System.String");
            co6.ColumnName = "Ngày thành lập";
            table_DSToChuc.Columns.Add(co6);

            gridControl1.Width = int.MaxValue;
            gridControl1.DataSource = table_DSToChuc;
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.Columns[0].Width = 5;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 300;
            gridView1.Columns[3].Width = 350;
            gridView1.Columns[4].Width = 100;
            gridView1.Columns[5].Width = 100;
            gridView1.Columns[6].Width = 100;

            //Chèn dữ liệu vào gridcontrol

            string s1 = "SELECT COUNT(IDTC) as SoToChuc FROM TenTochuc";
            groupControl1.Text = "Danh sách tổ chức | Tổng số tổ chức : " + sql.GetData(s1, 0);

            DataColumn[] Array_col2 = { co0, co1, co2, co3, co4, co5, co6 };
            s1 = "SELECT ROW_NUMBER() OVER(ORDER BY [TenTochuc] ASC) AS Row#,[MaTochuc],[TenTochuc],[Diachi],[Masothue],[Giamdoc],convert(NVARCHAR, TenTochuc.NgayTL, 103) as NgayTL FROM [GIAODAT].[dbo].[TenTochuc]";
            table_DSToChuc.Clear();
            sql.ViewDataTable(s1, table_DSToChuc, Array_col2);


            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (formIn == null)
                {
                    formIn = new XtraForm1("BÁO CÁO DANH MỤC TỔ CHỨC", table_DSToChuc);
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
                sql.ExportExcel2007(ext, table_DSToChuc);
            }
        }
    }
}