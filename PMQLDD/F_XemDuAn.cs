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
    public partial class F_XemDuAn : DevExpress.XtraEditors.XtraForm
    {

        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_Truoc;
        private DataColumn col_truoc1, col_truoc2;

        private DataTable table_Sau;
        private DataColumn col_sau1, col_sau2;

        public F_XemDuAn(string soQD)
        {
            InitializeComponent();

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //Gridcontrol2 Trươc giao

            table_Truoc = new DataTable();
            col_truoc1 = new DataColumn();
            col_truoc1.DataType = System.Type.GetType("System.String");
            col_truoc1.ColumnName = "Loại đất";
            table_Truoc.Columns.Add(col_truoc1);

            col_truoc2 = new DataColumn();
            col_truoc2.DataType = Type.GetType("System.Double");
            col_truoc2.ColumnName = "Diện tích (m2)";
            table_Truoc.Columns.Add(col_truoc2);
            gridControl2.DataSource = table_Truoc;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.Columns[0].Width = 150;


            //Gridcontrol3 Sau giao

            table_Sau = new DataTable();
            col_sau1 = new DataColumn();
            col_sau1.DataType = System.Type.GetType("System.String");
            col_sau1.ColumnName = "Loại đất";
            table_Sau.Columns.Add(col_sau1);

            col_sau2 = new DataColumn();
            col_sau2.DataType = Type.GetType("System.Double");
            col_sau2.ColumnName = "Diện tích (m2)";
            table_Sau.Columns.Add(col_sau2);
            gridControl3.DataSource = table_Sau;
            gridView3.OptionsBehavior.Editable = false;
            gridView3.Columns[0].Width = 150;

            // Chèn dữ liệu

            string s = "SELECT Giaodat.IDGD, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL, TenTochuc.TenTochuc, a.TongDTTruoc, b.TongDTDuoc FROM Giaodat, TenTochuc, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.SoQD='" + soQD + "' and Giaodat.MaTochuc = TenTochuc.MaTochuc and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD";

            labelControl_Ma.Text = sql.GetData(s, 0);
            labelControl_TenDA.Text = sql.GetData(s, 1);
            labelControl_DiaDiem.Text = sql.GetData(s, 2);
            labelControl_Huyen.Text = sql.GetData(s, 3);
            labelControl_SoQD.Text = sql.GetData(s, 4);
            labelControl_NgayQD.Text = sql.GetData(s, 5);
            labelControl_NgayGiao.Text = sql.GetData(s, 6);
            labelControl_ThoiHan.Text = sql.GetData(s, 7);
            labelControl_HinhThuc.Text = sql.GetData(s, 8);
            labelControl_TinhTrang.Text = sql.GetData(s, 9);
            labelControl_ToChuc.Text = sql.GetData(s, 10);
            groupControl4.Text = "Tổng diện tích trước giao : " + sql.GetData(s, 11) + " m2";
            groupControl5.Text = "Tổng diện tích sau giao : " + sql.GetData(s, 12) + " m2";

            DataColumn[] Array_col2 = { col_truoc1, col_truoc2 };
            s = "SELECT DMLoaidat.TenLD,Dientich FROM DMLoaidat,LDTruocGiao WHERE LDTruocGiao.MaLD = DMLoaidat.MaLD and IDGD = " + labelControl_Ma.Text;
            table_Truoc.Clear();
            sql.ViewDataTable(s, table_Truoc, Array_col2);

            DataColumn[] Array_col3 = { col_sau1, col_sau2 };
            s = "SELECT DMLoaidat.TenLD,Dientich FROM DMLoaidat,LDDuocGiao WHERE LDDuocGiao.MaLD = DMLoaidat.MaLD and IDGD = " + labelControl_Ma.Text;
            table_Sau.Clear();
            sql.ViewDataTable(s, table_Sau, Array_col3);

            Cursor = Cursors.Default;

        }

        private void F_XemDuAn_Load(object sender, EventArgs e)
        {

        }

        private void F_XemDuAn_SizeChanged(object sender, EventArgs e)
        {
            int i = groupControl2.Width / 2;
            groupControl4.Width = i;
            groupControl5.Width = i;
        }
    }
}