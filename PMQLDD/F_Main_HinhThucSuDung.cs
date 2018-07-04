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
    public partial class F_Main_HinhThucSuDung : DevExpress.XtraEditors.XtraForm
    {

        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_XemDuAn formXemDuAn;

        private DataTable table_DSHinhThucSuDung;
        private DataColumn col0, col1, col2, col3, col4;

        private DataTable table_DSToChuc;
        private DataColumn co0, co1, co2, co3, co4, co5, co6, co7;

        private DataTable table_DSDuAn;
        private DataColumn c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11;

        private string maHinhThuc, tenHinhThuc;

        public F_Main_HinhThucSuDung()
        {
            InitializeComponent();
        }

        private void F_Main_HinhThucSuDung_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl DSHinhThucSuDung

            table_DSHinhThucSuDung = new DataTable();

            col0 = new DataColumn();
            col0.DataType = System.Type.GetType("System.Int32");
            col0.ColumnName = "STT";
            table_DSHinhThucSuDung.Columns.Add(col0);

            col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Mã";
            table_DSHinhThucSuDung.Columns.Add(col1);

            col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Hình thức sử dụng";
            table_DSHinhThucSuDung.Columns.Add(col2);

            col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.Int32");
            col3.ColumnName = "Số tổ chức";
            table_DSHinhThucSuDung.Columns.Add(col3);

            col4 = new DataColumn();
            col4.DataType = System.Type.GetType("System.Int32");
            col4.ColumnName = "Số dự án";
            table_DSHinhThucSuDung.Columns.Add(col4);

            gridControl1.DataSource = table_DSHinhThucSuDung;
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.Columns[0].Width = 25;
            gridView1.Columns[1].Width = 80;
            gridView1.Columns[2].Width = 300;
            //gridView1.Columns[2].Width = 60;
            //gridView1.Columns[3].Width = 50;

            DataColumn[] Array_col1 = { col0, col1, col2, col3, col4 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY t1.MaHinhthuc asc) AS Row#, t1.MaHinhthuc, t1.TenHinhthuc, ISNULL(t2.SoToChuc, 0 ) as SoToChuc, ISNULL(t2.SoDuAn, 0 ) as SoDuAn FROM (SELECT MaHinhthuc,TenHinhthuc FROM DMHinhthucsudung) t1 LEFT JOIN (SELECT a.MaHinhthuc, a.SoDuAn , b.SoToChuc FROM (SELECT MaHinhthuc, COUNT(IDGD) as SoDuAn FROM Giaodat GROUP BY MaHinhthuc) a, (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc FROM (SELECT MaHinhthuc FROM Giaodat GROUP BY MaHinhthuc, MaTochuc) a GROUP BY a.MaHinhthuc) b WHERE a.MaHinhthuc=b.MaHinhthuc) t2 ON t1.MaHinhthuc = t2.MaHinhthuc";
            sql.ViewDataTable(s, table_DSHinhThucSuDung, Array_col1);

            string TCThueDat = "SELECT a.TongSoToChuc, b.TongDT FROM (SELECT SUM(a.SoToChuc) as TongSoToChuc FROM (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc  FROM (SELECT MaHinhthuc FROM Giaodat WHERE MaHinhthuc = 'DT-KCN-THN' or MaHinhthuc = 'DT-KCN-TML' or MaHinhthuc = 'DT-THN' or MaHinhthuc = 'DT-TML' GROUP BY MaHinhthuc, MaTochuc) a  GROUP BY a.MaHinhthuc) a) a, (SELECT SUM(b.TongDTTruoc) as TongDT FROM (SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD and (MaHinhthuc = 'DT-KCN-THN' or MaHinhthuc = 'DT-KCN-TML' or MaHinhthuc = 'DT-THN' or MaHinhthuc = 'DT-TML') GROUP BY LDTruocGiao.IDGD) b) b";
            string TCGiaoDat = "SELECT a.TongSoToChuc, b.TongDT FROM (SELECT SUM(a.SoToChuc) as TongSoToChuc FROM (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc  FROM (SELECT MaHinhthuc FROM Giaodat WHERE MaHinhthuc = 'DG-CTT' or MaHinhthuc = 'DG-KTT' or MaHinhthuc = 'DG-QL' or MaHinhthuc = 'CNQ-KTT' or MaHinhthuc = 'CNQ-CTT' GROUP BY MaHinhthuc, MaTochuc) a  GROUP BY a.MaHinhthuc) a) a, (SELECT SUM(b.TongDTTruoc) as TongDT FROM (SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD and (MaHinhthuc = 'DG-CTT' or MaHinhthuc = 'DG-KTT' or MaHinhthuc = 'DG-QL' or MaHinhthuc = 'CNQ-KTT' or MaHinhthuc = 'CNQ-CTT') GROUP BY LDTruocGiao.IDGD) b) b";
            groupControl2.Text = "Có " + sql.GetData(TCThueDat, 0) + " tổ chức thuê đất, tổng diện tích đất cho thuê là " + sql.GetData(TCThueDat, 1) + " m2 || Có " + sql.GetData(TCGiaoDat, 0) + " tổ chức được giao đất, tổng diện tích đất giao là " + sql.GetData(TCGiaoDat, 1) + " m2  ";

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
            co3.DataType = System.Type.GetType("System.Int32");
            co3.ColumnName = "Số dự án với hình thức sử dụng";
            table_DSToChuc.Columns.Add(co3);

            co4 = new DataColumn();
            co4.DataType = System.Type.GetType("System.String");
            co4.ColumnName = "Địa chỉ";
            table_DSToChuc.Columns.Add(co4);

            co5 = new DataColumn();
            co5.DataType = System.Type.GetType("System.String");
            co5.ColumnName = "Mã số thuế";
            table_DSToChuc.Columns.Add(co5);

            co6 = new DataColumn();
            co6.DataType = System.Type.GetType("System.String");
            co6.ColumnName = "Giám đốc";
            table_DSToChuc.Columns.Add(co6);

            co7 = new DataColumn();
            co7.DataType = System.Type.GetType("System.String");
            co7.ColumnName = "Ngày thành lập";
            table_DSToChuc.Columns.Add(co7);

            gridControl2.Width = int.MaxValue;
            gridControl2.DataSource = table_DSToChuc;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView2.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView2.Columns[0].Width = 25;
            gridView2.Columns[1].Width = 70;
            gridView2.Columns[2].Width = 300;
            gridView2.Columns[3].Width = 170;
            gridView2.Columns[4].Width = 350;
            gridView2.Columns[5].Width = 100;
            gridView2.Columns[6].Width = 100;
            gridView2.Columns[7].Width = 100;


            //GridControl3 DSDuAn

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

            gridControl3.Width = int.MaxValue;
            gridControl3.DataSource = table_DSDuAn;
            gridView3.OptionsBehavior.Editable = false;
            gridView3.OptionsView.ColumnAutoWidth = false;
            gridView3.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView3.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView3.Columns[0].Width = 25;
            gridView3.Columns[1].Width = 300;
            gridView3.Columns[2].Width = 250;
            gridView3.Columns[3].Width = 110;
            gridView3.Columns[4].Width = 130;
            gridView3.Columns[5].Width = 120;
            gridView3.Columns[6].Width = 90;
            gridView3.Columns[7].Width = 90;
            gridView3.Columns[8].Width = 70;
            gridView3.Columns[9].Width = 70;
            gridView3.Columns[10].Width = 300;
            gridView3.Columns[11].Width = 150;


            Cursor = Cursors.Default;
        }

        private void F_Main_HinhThucSuDung_SizeChanged(object sender, EventArgs e)
        {
            int i = (groupControl2.Height - 29) / 2;
            groupControl3.Height = i;
            groupControl4.Height = i;
        }

        private void toolStripMenuItem1_Select_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                groupControl3.Text = "Danh sách tổ chức với hình thức sử dụng : '" + table_DSHinhThucSuDung.Rows[rowSel].ItemArray[2].ToString() + "' :";
                DataColumn[] Array_col2 = { co0, co1, co2, co3, co4, co5, co6, co7 };
                string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY a.SoDuAn desc) AS Row#, TenTochuc.MaTochuc, TenTochuc, a.SoDuAn, TenTochuc.Diachi, TenTochuc.Masothue, TenTochuc.Giamdoc, convert(NVARCHAR, TenTochuc.NgayTL, 103) as NgayTL FROM TenTochuc, (SELECT MaTochuc, MaHinhthuc, COUNT(MaHinhthuc) as SoDuAn FROM Giaodat GROUP BY MaTochuc, MaHinhthuc) a WHERE a.MaHinhthuc = '" + table_DSHinhThucSuDung.Rows[rowSel].ItemArray[1].ToString() + "' and a.MaTochuc = TenTochuc.MaTochuc GROUP BY a.SoDuAn, TenTochuc.MaTochuc,TenTochuc.TenTochuc,TenTochuc.Diachi,TenTochuc.Masothue,TenTochuc.Giamdoc,TenTochuc.NgayTL ";
                table_DSToChuc.Clear();
                sql.ViewDataTable(s1, table_DSToChuc, Array_col2);

                groupControl4.Text = "Danh sách dự án với hình thức sử dụng : '" + table_DSHinhThucSuDung.Rows[rowSel].ItemArray[2].ToString() + "'";
                DataColumn[] Array_col3 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
                s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan ASC) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.MaHinhthuc = '" + table_DSHinhThucSuDung.Rows[rowSel].ItemArray[1].ToString() + "' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
                table_DSDuAn.Clear();
                sql.ViewDataTable(s1, table_DSDuAn, Array_col3);

                this.maHinhThuc = table_DSHinhThucSuDung.Rows[rowSel].ItemArray[1].ToString();
                this.tenHinhThuc = table_DSHinhThucSuDung.Rows[rowSel].ItemArray[2].ToString();

                Cursor = Cursors.Default;
            }
            catch { }
        }

        private void toolStripMenuItem1_Refesh_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            table_DSHinhThucSuDung.Clear();
            table_DSToChuc.Clear();
            table_DSDuAn.Clear();
            groupControl3.Text = "Danh sách tổ chức";
            groupControl4.Text = "Danh sách dự án";

            DataColumn[] Array_col1 = { col0, col1, col2, col3, col4 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY t1.MaHinhthuc asc) AS Row#, t1.MaHinhthuc, t1.TenHinhthuc, ISNULL(t2.SoToChuc, 0 ) as SoToChuc, ISNULL(t2.SoDuAn, 0 ) as SoDuAn FROM (SELECT MaHinhthuc,TenHinhthuc FROM DMHinhthucsudung) t1 LEFT JOIN (SELECT a.MaHinhthuc, a.SoDuAn , b.SoToChuc FROM (SELECT MaHinhthuc, COUNT(IDGD) as SoDuAn FROM Giaodat GROUP BY MaHinhthuc) a, (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc FROM (SELECT MaHinhthuc FROM Giaodat GROUP BY MaHinhthuc, MaTochuc) a GROUP BY a.MaHinhthuc) b WHERE a.MaHinhthuc=b.MaHinhthuc) t2 ON t1.MaHinhthuc = t2.MaHinhthuc";
            sql.ViewDataTable(s, table_DSHinhThucSuDung, Array_col1);

            string TCThueDat = "SELECT a.TongSoToChuc, b.TongDT FROM (SELECT SUM(a.SoToChuc) as TongSoToChuc FROM (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc  FROM (SELECT MaHinhthuc FROM Giaodat WHERE MaHinhthuc = 'DT-KCN-THN' or MaHinhthuc = 'DT-KCN-TML' or MaHinhthuc = 'DT-THN' or MaHinhthuc = 'DT-TML' GROUP BY MaHinhthuc, MaTochuc) a  GROUP BY a.MaHinhthuc) a) a, (SELECT SUM(b.TongDTTruoc) as TongDT FROM (SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD and (MaHinhthuc = 'DT-KCN-THN' or MaHinhthuc = 'DT-KCN-TML' or MaHinhthuc = 'DT-THN' or MaHinhthuc = 'DT-TML') GROUP BY LDTruocGiao.IDGD) b) b";
            string TCGiaoDat = "SELECT a.TongSoToChuc, b.TongDT FROM (SELECT SUM(a.SoToChuc) as TongSoToChuc FROM (SELECT a.MaHinhthuc, COUNT(a.MaHinhthuc) as SoToChuc  FROM (SELECT MaHinhthuc FROM Giaodat WHERE MaHinhthuc = 'DG-CTT' or MaHinhthuc = 'DG-KTT' or MaHinhthuc = 'DG-QL' or MaHinhthuc = 'CNQ-KTT' or MaHinhthuc = 'CNQ-CTT' GROUP BY MaHinhthuc, MaTochuc) a  GROUP BY a.MaHinhthuc) a) a, (SELECT SUM(b.TongDTTruoc) as TongDT FROM (SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD and (MaHinhthuc = 'DG-CTT' or MaHinhthuc = 'DG-KTT' or MaHinhthuc = 'DG-QL' or MaHinhthuc = 'CNQ-KTT' or MaHinhthuc = 'CNQ-CTT') GROUP BY LDTruocGiao.IDGD) b) b";
            groupControl2.Text = "Có " + sql.GetData(TCThueDat, 0) + " tổ chức thuê đất, tổng diện tích đất cho thuê là " + sql.GetData(TCThueDat, 1) + " m2 || Có " + sql.GetData(TCGiaoDat, 0) + " tổ chức được giao đất, tổng diện tích đất giao là " + sql.GetData(TCGiaoDat, 1) + " m2  ";

            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem2_Select_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                int rowSel = -1;
                int[] selectedRows = gridView2.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                groupControl4.Text = "Danh sách dự án của tổ chức : " + table_DSToChuc.Rows[rowSel].ItemArray[2].ToString() + "' ,  với hình thức sử dụng : '" + this.tenHinhThuc + "'";
                DataColumn[] Array_col3 = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11 };
                string s1 = "SELECT ROW_NUMBER() OVER(ORDER BY Giaodat.TenDuan ASC) AS Row#, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, a.TongDTTruoc, b.TongDTDuoc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL FROM Giaodat, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.MaTochuc = '" + table_DSToChuc.Rows[rowSel].ItemArray[1].ToString() + "' and Giaodat.MaHinhthuc = '" + this.maHinhThuc + "' and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD GROUP BY Giaodat.TenDuan, Giaodat.Diadiem, a.TongDTTruoc, b.TongDTDuoc, DMDvhc.TenDvhc, Giaodat.SoQD, Giaodat.NgayQD, Giaodat.Ngaygiao, Giaodat.Thoihan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL";
                table_DSDuAn.Clear();
                sql.ViewDataTable(s1, table_DSDuAn, Array_col3);

                Cursor = Cursors.Default;
            }
            catch { }
        }

        private void toolStripMenuItem3_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView3.GetSelectedRows();
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