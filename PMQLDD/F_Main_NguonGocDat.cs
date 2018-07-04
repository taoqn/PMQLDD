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
    public partial class F_Main_NguonGocDat : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_XemDuAn formXemDuAn;

        private DataTable table_DSNguonGocDat;
        private DataColumn col1, col2, col3, col4;

        private DataTable table_DSDuAn;
        private DataColumn c0, c1, c2, c3, c3_5, c4, c5, c6, c7, c8, c9, c10, c11;

        public F_Main_NguonGocDat()
        {
            InitializeComponent();
        }

        private void F_Main_NguonGocDat_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl DSDiaDiem
            table_DSNguonGocDat = new DataTable();
            col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Mã";
            table_DSNguonGocDat.Columns.Add(col1);

            col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Tên loại đất";
            table_DSNguonGocDat.Columns.Add(col2);

            col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.Int32");
            col3.ColumnName = "Số dự án";
            table_DSNguonGocDat.Columns.Add(col3);

            col4 = new DataColumn();
            col4.DataType = System.Type.GetType("System.Double");
            col4.ColumnName = "Tổng diện tích (m2)";
            table_DSNguonGocDat.Columns.Add(col4);

            gridControl1.DataSource = table_DSNguonGocDat;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.Columns[0].Width = 40;
            gridView1.Columns[1].Width = 200;
            gridView1.Columns[2].Width = 60;
            gridView1.Columns[3].Width = 100;

            DataColumn[] Array_col1 = { col1, col2, col3, col4 };
            string s = "SELECT t1.MaLD,t1.TenLD,ISNULL(t2.SoDuAn, 0 ) as DuAn,ISNULL(t2.TongDT, 0 ) as DT FROM (SELECT MaLD,TenLD FROM DMLoaidat) t1 LEFT JOIN (SELECT a.MaLD, COUNT(a.IDGD) as SoDuAn, SUM(a.DT) as TongDT FROM (SELECT IDGD,MaLD, SUM(Dientich) as DT FROM LDTruocGiao GROUP BY IDGD,MaLD) a GROUP BY a.MaLD) t2 ON t1.MaLD = t2.MaLD ORDER BY DuAn desc";
            sql.ViewDataTable(s, table_DSNguonGocDat, Array_col1);


            //GridControl2 DSDuAn

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

            c3_5 = new DataColumn();
            c3_5.DataType = System.Type.GetType("System.Double");
            c3_5.ColumnName = "Diện tích theo nguồn gốc đất (m2)";
            table_DSDuAn.Columns.Add(c3_5);

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
            gridView2.Columns[4].Width = 170;
            gridView2.Columns[5].Width = 130;
            gridView2.Columns[6].Width = 120;
            gridView2.Columns[7].Width = 90;
            gridView2.Columns[8].Width = 90;
            gridView2.Columns[9].Width = 70;
            gridView2.Columns[10].Width = 70;
            gridView2.Columns[11].Width = 320;
            gridView2.Columns[12].Width = 150;

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Select_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                groupControl2.Text = "Danh sách dự án | Thuộc nguồn gốc đất : " + table_DSNguonGocDat.Rows[rowSel].ItemArray[1].ToString() + " | Tổng số dự án : " + table_DSNguonGocDat.Rows[rowSel].ItemArray[2].ToString() + " | Tổng diện tích : " + table_DSNguonGocDat.Rows[rowSel].ItemArray[3].ToString() + " m2";
                DataColumn[] Array_col3 = { c0, c1, c2, c3, c3_5, c4, c5, c6, c7, c8, c9, c10, c11 };
                string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan ASC) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, c.DT, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b, (SELECT IDGD,MaLD, SUM(Dientich) as DT FROM LDTruocGiao GROUP BY IDGD,MaLD) c WHERE Giaodat.IDGD = c.IDGD and c.MaLD = '" + table_DSNguonGocDat.Rows[rowSel].ItemArray[0].ToString() + "' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, c.DT, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
                table_DSDuAn.Clear();
                sql.ViewDataTable(s1, table_DSDuAn, Array_col3);

                Cursor = Cursors.Default;
            }
            catch { }
        }

        private void toolStripMenuItem1_Refesh_Click(object sender, EventArgs e)
        {
            table_DSDuAn.Clear();
            table_DSNguonGocDat.Clear();
            groupControl2.Text = "Danh sách dự án";

            DataColumn[] Array_col1 = { col1, col2, col3, col4 };
            string s = "SELECT t1.MaLD,t1.TenLD,ISNULL(t2.SoDuAn, 0 ) as DuAn,ISNULL(t2.TongDT, 0 ) as DT FROM (SELECT MaLD,TenLD FROM DMLoaidat) t1 LEFT JOIN (SELECT a.MaLD, COUNT(a.IDGD) as SoDuAn, SUM(a.DT) as TongDT FROM (SELECT IDGD,MaLD, SUM(Dientich) as DT FROM LDTruocGiao GROUP BY IDGD,MaLD) a GROUP BY a.MaLD) t2 ON t1.MaLD = t2.MaLD ORDER BY DuAn desc";
            sql.ViewDataTable(s, table_DSNguonGocDat, Array_col1);
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