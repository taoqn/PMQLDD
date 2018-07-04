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
    public partial class F_Main_TinhTrangPL : DevExpress.XtraEditors.XtraForm
    {

        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_XemDuAn formXemDuAn;

        private DataTable table_DSDuAn_DaCap;
        private DataColumn c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11;

        private DataTable table_DSDuAn_ChuaCap;
        //private DataColumn c01, c02, c03, c04, c05, c06, c07, c08, c09, c010, c011;

        public F_Main_TinhTrangPL()
        {
            InitializeComponent();
        }

        private void F_Main_TinhTrangPL_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl DSDuAn_DaCap
            table_DSDuAn_DaCap = new DataTable();

            c0 = new DataColumn();
            c0.DataType = System.Type.GetType("System.Int32");
            c0.ColumnName = "STT";
            table_DSDuAn_DaCap.Columns.Add(c0);

            c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.String");
            c1.ColumnName = "Tên dự án";
            table_DSDuAn_DaCap.Columns.Add(c1);

            c2 = new DataColumn();
            c2.DataType = System.Type.GetType("System.String");
            c2.ColumnName = "Địa điểm";
            table_DSDuAn_DaCap.Columns.Add(c2);

            c3 = new DataColumn();
            c3.DataType = System.Type.GetType("System.String");
            c3.ColumnName = "Huyện";
            table_DSDuAn_DaCap.Columns.Add(c3);

            c4 = new DataColumn();
            c4.DataType = System.Type.GetType("System.Double");
            c4.ColumnName = "Diện tích trước giao (m2)";
            table_DSDuAn_DaCap.Columns.Add(c4);

            c5 = new DataColumn();
            c5.DataType = System.Type.GetType("System.Double");
            c5.ColumnName = "Diện tích sau giao (m2)";
            table_DSDuAn_DaCap.Columns.Add(c5);

            c6 = new DataColumn();
            c6.DataType = System.Type.GetType("System.String");
            c6.ColumnName = "Số quyết định";
            table_DSDuAn_DaCap.Columns.Add(c6);

            c7 = new DataColumn();
            c7.DataType = System.Type.GetType("System.String");
            c7.ColumnName = "Ngày quyết định";
            table_DSDuAn_DaCap.Columns.Add(c7);

            c8 = new DataColumn();
            c8.DataType = System.Type.GetType("System.String");
            c8.ColumnName = "Ngày giao";
            table_DSDuAn_DaCap.Columns.Add(c8);

            c9 = new DataColumn();
            c9.DataType = System.Type.GetType("System.String");
            c9.ColumnName = "Thời hạn";
            table_DSDuAn_DaCap.Columns.Add(c9);

            c10 = new DataColumn();
            c10.DataType = System.Type.GetType("System.String");
            c10.ColumnName = "Hình thức sử dụng";
            table_DSDuAn_DaCap.Columns.Add(c10);

            c11 = new DataColumn();
            c11.DataType = System.Type.GetType("System.String");
            c11.ColumnName = "Tình trạng pháp lý";
            table_DSDuAn_DaCap.Columns.Add(c11);

            gridControl1.Width = int.MaxValue;
            gridControl1.DataSource = table_DSDuAn_DaCap;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView1.Columns[0].Width = 25;
            gridView1.Columns[1].Width = 300;
            gridView1.Columns[2].Width = 250;
            gridView1.Columns[3].Width = 110;
            gridView1.Columns[4].Width = 130;
            gridView1.Columns[5].Width = 120;
            gridView1.Columns[6].Width = 90;
            gridView1.Columns[7].Width = 90;
            gridView1.Columns[8].Width = 70;
            gridView1.Columns[9].Width = 70;
            gridView1.Columns[10].Width = 300;
            gridView1.Columns[11].Width = 150;

            // Chèn dữ liệu đã cấp

            string daCap = "SELECT COUNT(TinhtrangPL) as SoDuAn FROM Giaodat WHERE TinhtrangPL = N'Đã cấp giấy chứng nhận'";
            groupControl1.Text = "Danh sách dự án  |  Tổng số dự án đã cấp giấy chứng nhận : " + sql.GetData(daCap, 0);

            DataColumn[] Array_col2 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
            string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan asc) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.TinhtrangPL = N'Đã cấp giấy chứng nhận' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
            table_DSDuAn_DaCap.Clear();
            sql.ViewDataTable(s1, table_DSDuAn_DaCap, Array_col2);


            //GridControl DSDuAn_ChuaCap
            table_DSDuAn_ChuaCap = new DataTable();

            c0 = new DataColumn();
            c0.DataType = System.Type.GetType("System.Int32");
            c0.ColumnName = "STT";
            table_DSDuAn_ChuaCap.Columns.Add(c0);

            c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.String");
            c1.ColumnName = "Tên dự án";
            table_DSDuAn_ChuaCap.Columns.Add(c1);

            c2 = new DataColumn();
            c2.DataType = System.Type.GetType("System.String");
            c2.ColumnName = "Địa điểm";
            table_DSDuAn_ChuaCap.Columns.Add(c2);

            c3 = new DataColumn();
            c3.DataType = System.Type.GetType("System.String");
            c3.ColumnName = "Huyện";
            table_DSDuAn_ChuaCap.Columns.Add(c3);

            c4 = new DataColumn();
            c4.DataType = System.Type.GetType("System.Double");
            c4.ColumnName = "Diện tích trước giao (m2)";
            table_DSDuAn_ChuaCap.Columns.Add(c4);

            c5 = new DataColumn();
            c5.DataType = System.Type.GetType("System.Double");
            c5.ColumnName = "Diện tích sau giao (m2)";
            table_DSDuAn_ChuaCap.Columns.Add(c5);

            c6 = new DataColumn();
            c6.DataType = System.Type.GetType("System.String");
            c6.ColumnName = "Số quyết định";
            table_DSDuAn_ChuaCap.Columns.Add(c6);

            c7 = new DataColumn();
            c7.DataType = System.Type.GetType("System.String");
            c7.ColumnName = "Ngày quyết định";
            table_DSDuAn_ChuaCap.Columns.Add(c7);

            c8 = new DataColumn();
            c8.DataType = System.Type.GetType("System.String");
            c8.ColumnName = "Ngày giao";
            table_DSDuAn_ChuaCap.Columns.Add(c8);

            c9 = new DataColumn();
            c9.DataType = System.Type.GetType("System.String");
            c9.ColumnName = "Thời hạn";
            table_DSDuAn_ChuaCap.Columns.Add(c9);

            c10 = new DataColumn();
            c10.DataType = System.Type.GetType("System.String");
            c10.ColumnName = "Hình thức sử dụng";
            table_DSDuAn_ChuaCap.Columns.Add(c10);

            c11 = new DataColumn();
            c11.DataType = System.Type.GetType("System.String");
            c11.ColumnName = "Tình trạng pháp lý";
            table_DSDuAn_ChuaCap.Columns.Add(c11);

            gridControl2.Width = int.MaxValue;
            gridControl2.DataSource = table_DSDuAn_ChuaCap;
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

            // Chèn dữ liệu chưa cấp

            string chuaCap = "SELECT COUNT(TinhtrangPL) as SoDuAn FROM Giaodat WHERE TinhtrangPL = N'Chưa cấp giấy chứng nhận'";
            groupControl2.Text = "Danh sách dự án  |  Tổng số dự án chưa cấp giấy chứng nhận : " + sql.GetData(chuaCap, 0);

            DataColumn[] Array_col3 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
            string s2 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan asc) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.TinhtrangPL = N'Chưa cấp giấy chứng nhận' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
            table_DSDuAn_ChuaCap.Clear();
            sql.ViewDataTable(s2, table_DSDuAn_ChuaCap, Array_col3);

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                if (formXemDuAn == null)
                {
                    formXemDuAn = new F_XemDuAn(table_DSDuAn_DaCap.Rows[rowSel].ItemArray[5].ToString());
                    formXemDuAn.FormClosed += new FormClosedEventHandler(formXemDuAn_FormClosed);
                    formXemDuAn.Show();
                }
                else
                    formXemDuAn.Activate();
            }
            catch { }
        }

        private void toolStripMenuItem1_Refesh_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            table_DSDuAn_DaCap.Clear();

            string daCap = "SELECT COUNT(TinhtrangPL) as SoDuAn FROM Giaodat WHERE TinhtrangPL = N'Đã cấp giấy chứng nhận'";
            groupControl1.Text = "Danh sách dự án  |  Tổng số dự án đã cấp giấy chứng nhận : " + sql.GetData(daCap, 0);

            DataColumn[] Array_col2 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
            string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan asc) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.TinhtrangPL = N'Đã cấp giấy chứng nhận' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
            table_DSDuAn_DaCap.Clear();
            sql.ViewDataTable(s1, table_DSDuAn_DaCap, Array_col2);

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem2_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView2.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                if (formXemDuAn == null)
                {
                    formXemDuAn = new F_XemDuAn(table_DSDuAn_ChuaCap.Rows[rowSel].ItemArray[5].ToString());
                    formXemDuAn.FormClosed += new FormClosedEventHandler(formXemDuAn_FormClosed);
                    formXemDuAn.Show();
                }
                else
                    formXemDuAn.Activate();
            }
            catch { }
        }

        private void toolStripMenuItem2_Refesh_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            table_DSDuAn_ChuaCap.Clear();

            string chuaCap = "SELECT COUNT(TinhtrangPL) as SoDuAn FROM Giaodat WHERE TinhtrangPL = N'Chưa cấp giấy chứng nhận'";
            groupControl2.Text = "Danh sách dự án  |  Tổng số dự án chưa cấp giấy chứng nhận : " + sql.GetData(chuaCap, 0);

            DataColumn[] Array_col3 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
            string s2 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan asc) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.TinhtrangPL = N'Chưa cấp giấy chứng nhận' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
            table_DSDuAn_ChuaCap.Clear();
            sql.ViewDataTable(s2, table_DSDuAn_ChuaCap, Array_col3);

            Cursor = Cursors.Default;
        }

        void formXemDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formXemDuAn = null;
        }
    }
}