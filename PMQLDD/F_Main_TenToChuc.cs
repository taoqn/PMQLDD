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
    public partial class F_Main_TenToChuc : DevExpress.XtraEditors.XtraForm
    {

        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_XemDuAn formXemDuAn;

        private DataTable table_DSTenToChuc;
        private DataColumn col0, col1, col2, col3;

        private DataTable table_DSDuAn;
        private DataColumn c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11;

        public F_Main_TenToChuc()
        {
            InitializeComponent();
        }

        private void F_Main_TenToChuc_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;


            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl DSTenToChuc
            table_DSTenToChuc = new DataTable();

            col0 = new DataColumn();
            col0.DataType = System.Type.GetType("System.Int32");
            col0.ColumnName = "STT";
            table_DSTenToChuc.Columns.Add(col0);

            col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Mã TC";
            table_DSTenToChuc.Columns.Add(col1);

            col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Tên tổ chức";
            table_DSTenToChuc.Columns.Add(col2);

            col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.Int32");
            col3.ColumnName = "Số dự án";
            table_DSTenToChuc.Columns.Add(col3);

            gridControl1.DataSource = table_DSTenToChuc;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.Columns[0].Width = 5;
            gridView1.Columns[1].Width = 20;
            gridView1.Columns[2].Width = 70;
            gridView1.Columns[3].Width = 20;

            DataColumn[] Array_col1 = { col0, col1, col2, col3 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY t1.TenTochuc asc) AS Row#,t1.MaTochuc,t1.TenTochuc,ISNULL(t2.soduan, 0 ) as SoDuAn FROM (Select MaTochuc,TenTochuc from TenTochuc) t1  LEFT JOIN  (Select MaTochuc, COUNT(MaTochuc) as soduan from Giaodat group by MaTochuc) t2 ON t1.MaTochuc = t2.MaTochuc WHERE t2.soduan IS NULL OR t2.soduan >= 0";
            sql.ViewDataTable(s, table_DSTenToChuc, Array_col1);


            //GridControl DSDuAn
            table_DSDuAn = new DataTable();

            c0 = new DataColumn();
            c0.DataType = System.Type.GetType("System.Int32");
            c0.ColumnName = "STT";
            table_DSDuAn.Columns.Add(c0);

            c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.String");
            c1.ColumnName = "Tên dự án";
            table_DSDuAn.Columns.Add(c1);

            c2 = new DataColumn();
            c2.DataType = System.Type.GetType("System.String");
            c2.ColumnName = "Địa điểm";
            table_DSDuAn.Columns.Add(c2);

            c3 = new DataColumn();
            c3.DataType = System.Type.GetType("System.String");
            c3.ColumnName = "Huyện";
            table_DSDuAn.Columns.Add(c3);

            c4 = new DataColumn();
            c4.DataType = System.Type.GetType("System.Double");
            c4.ColumnName = "Diện tích trước giao (m2)";
            table_DSDuAn.Columns.Add(c4);

            c5 = new DataColumn();
            c5.DataType = System.Type.GetType("System.Double");
            c5.ColumnName = "Diện tích sau giao (m2)";
            table_DSDuAn.Columns.Add(c5);

            c6 = new DataColumn();
            c6.DataType = System.Type.GetType("System.String");
            c6.ColumnName = "Số quyết định";
            table_DSDuAn.Columns.Add(c6);

            c7 = new DataColumn();
            c7.DataType = System.Type.GetType("System.String");
            c7.ColumnName = "Ngày quyết định";
            table_DSDuAn.Columns.Add(c7);

            c8 = new DataColumn();
            c8.DataType = System.Type.GetType("System.String");
            c8.ColumnName = "Ngày giao";
            table_DSDuAn.Columns.Add(c8);

            c9 = new DataColumn();
            c9.DataType = System.Type.GetType("System.String");
            c9.ColumnName = "Thời hạn";
            table_DSDuAn.Columns.Add(c9);

            c10 = new DataColumn();
            c10.DataType = System.Type.GetType("System.String");
            c10.ColumnName = "Hình thức sử dụng";
            table_DSDuAn.Columns.Add(c10);

            c11 = new DataColumn();
            c11.DataType = System.Type.GetType("System.String");
            c11.ColumnName = "Tình trạng pháp lý";
            table_DSDuAn.Columns.Add(c11);

            gridControl2.Width = int.MaxValue;
            gridControl2.DataSource = table_DSDuAn;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView2.Columns[0].Width = 25;
            gridView2.Columns[1].Width = 300;
            gridView2.Columns[2].Width = 250;
            gridView2.Columns[3].Width = 110;
            gridView2.Columns[4].Width = 130;
            gridView2.Columns[5].Width = 120;
            gridView2.Columns[6].Width = 90;
            gridView2.Columns[7].Width = 90;
            gridView2.Columns[8].Width = 70;
            gridView2.Columns[9].Width = 70;
            gridView2.Columns[10].Width = 300;
            gridView2.Columns[11].Width = 150;


            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Select_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;
                string s = "SELECT [MaTochuc] ,[TenTochuc] ,[Diachi]  ,[Masothue] ,[Giamdoc] ,convert(NVARCHAR, NgayTL, 103) as NgayTL FROM [GIAODAT].[dbo].[TenTochuc] WHERE MaTochuc='" + table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString() + "' ";
                label_MTC.Text = sql.GetData(s, 0);
                label_TTC.Text = sql.GetData(s, 1);
                label_DiaChi.Text = sql.GetData(s, 2);
                label_MST.Text = sql.GetData(s, 3);
                label_GD.Text = sql.GetData(s, 4);
                label_NTL.Text = sql.GetData(s, 5);
                DataColumn[] Array_col2 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
                string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan asc) AS Row#,Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.MaTochuc = '" + table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString() + "' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
                table_DSDuAn.Clear();
                sql.ViewDataTable(s1, table_DSDuAn, Array_col2);
                
                Cursor = Cursors.Default;
            }
            catch { }
        }

        private void toolStripMenuItem_Refesh_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            this.RefeshDS();
            Cursor = Cursors.Default;
        }

        public void RefeshDS()
        {
            table_DSTenToChuc.Clear();
            table_DSDuAn.Clear();
            DataColumn[] Array_col1 = { col0, col1, col2, col3 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY t1.TenTochuc asc) AS Row#,t1.MaTochuc,t1.TenTochuc,ISNULL(t2.soduan, 0 ) as SoDuAn FROM (Select MaTochuc,TenTochuc from TenTochuc) t1  LEFT JOIN  (Select MaTochuc, COUNT(MaTochuc) as soduan from Giaodat group by MaTochuc) t2 ON t1.MaTochuc = t2.MaTochuc WHERE t2.soduan IS NULL OR t2.soduan >= 0";
            sql.ViewDataTable(s, table_DSTenToChuc, Array_col1);
            label_MTC.Text = "";
            label_TTC.Text = "";
            label_DiaChi.Text = "";
            label_MST.Text = "";
            label_GD.Text = "";
            label_NTL.Text = "";
        }

        private void toolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            if (nguoi.Cap > 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền !");
                return;
            }

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            int rowSel = -1;
            int[] selectedRows = gridView1.GetSelectedRows();
            foreach (int r in selectedRows) rowSel = r;

            F_Main_ThemToChuc frm = new F_Main_ThemToChuc(this, table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString(), int.Parse(table_DSTenToChuc.Rows[rowSel].ItemArray[3].ToString()));
            frm.Show();

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            if (nguoi.Cap > 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không đủ quyền !");
                return;
            }

            int rowSel = -1;
            int[] selectedRows = gridView1.GetSelectedRows();
            foreach (int r in selectedRows) rowSel = r;

            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa tổ chức '" + table_DSTenToChuc.Rows[rowSel].ItemArray[2].ToString() + "' ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                if (int.Parse(table_DSTenToChuc.Rows[rowSel].ItemArray[3].ToString()) > 0)
                {
                    string s = "SELECT [IDGD] FROM [GIAODAT].[dbo].[Giaodat] WHERE MaTochuc = '" + table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString() + "' ";
                    string[] mangIDGD = sql.GetDataArray(s, 0);
                    int i = 0;
                    while (!string.IsNullOrEmpty(mangIDGD[i]))
                    {
                        s = "DELETE FROM LDTruocGiao WHERE IDGD=" + mangIDGD[i] + "";
                        sql.ExecuteData(s);
                        s = "DELETE FROM LDDuocGiao WHERE IDGD=" + mangIDGD[i] + "";
                        sql.ExecuteData(s);
                        i++;
                    }
                    s = "DELETE FROM Giaodat WHERE MaTochuc='" + table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString() + "'";
                    sql.ExecuteData(s);
                }
                string s1 = "DELETE FROM TenTochuc WHERE MaTochuc='" + table_DSTenToChuc.Rows[rowSel].ItemArray[1].ToString() + "'";
                sql.ExecuteData(s1);
                DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công !");
                this.RefeshDS();
                Cursor = Cursors.Default;
            }
        }

        private void toolStripMenuItem1_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView2.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                if (formXemDuAn == null)
                {
                    formXemDuAn = new F_XemDuAn(table_DSDuAn.Rows[rowSel].ItemArray[6].ToString());
                    formXemDuAn.FormClosed += new FormClosedEventHandler(formXemDuAn_FormClosed);
                    formXemDuAn.Show();
                }
                else
                    formXemDuAn.Activate();
            }
            catch { }
        }

        void formXemDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formXemDuAn = null;
        }
    }
}