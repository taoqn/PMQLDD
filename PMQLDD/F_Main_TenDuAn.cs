﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace PMQLDD
{
    public partial class F_Main_SoQuyetDinh : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_DSTenDuAn;
        private DataColumn col0, col1, col2;

        private DataTable table_Truoc;
        private DataColumn col_truoc1, col_truoc2;

        private DataTable table_Sau;
        private DataColumn col_sau1, col_sau2;

        public F_Main_SoQuyetDinh()
        {
            InitializeComponent();
        }

        private void F_Main_TenDuAn_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl DSTenToChuc
            table_DSTenDuAn = new DataTable();

            col0 = new DataColumn();
            col0.DataType = System.Type.GetType("System.Int32");
            col0.ColumnName = "STT";
            table_DSTenDuAn.Columns.Add(col0);

            col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "ID";
            table_DSTenDuAn.Columns.Add(col1);

            col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Tên dự án";
            table_DSTenDuAn.Columns.Add(col2);

            gridControl1.DataSource = table_DSTenDuAn;
            gridView1.OptionsBehavior.Editable = false;
            //gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.Columns[0].Width = 20;
            gridView1.Columns[1].Width = 20;
            gridView1.Columns[2].Width = 200;

            DataColumn[] Array_col1 = { col0, col1, col2 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY TenDuan asc) AS Row#,[IDGD],[TenDuan] FROM [GIAODAT].[dbo].[Giaodat]";
            sql.ViewDataTable(s, table_DSTenDuAn, Array_col1);


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


            Cursor = Cursors.Default;
        }

        private void F_Main_TenDuAn_SizeChanged(object sender, EventArgs e)
        {
            int i = groupControl2.Width / 2;
            groupControl4.Width = i;
            groupControl5.Width = i;
        }

        private void toolStripMenuItem_Select_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                string s = "SELECT Giaodat.IDGD, Giaodat.TenDuan, Giaodat.Diadiem, DMDvhc.TenDvhc, Giaodat.SoQD, convert(NVARCHAR, Giaodat.NgayQD, 103) as NgayQD, convert(NVARCHAR, Giaodat.Ngaygiao, 103) as NgayGiao, convert(NVARCHAR, Giaodat.Thoihan, 103) as ThoiHan, DMHinhthucsudung.TenHinhthuc, Giaodat.TinhtrangPL, TenTochuc.TenTochuc, a.TongDTTruoc, b.TongDTDuoc FROM Giaodat, TenTochuc, DMDvhc, DMHinhthucsudung,( SELECT LDTruocGiao.IDGD, SUM(Dientich) as TongDTTruoc FROM LDTruocGiao, Giaodat WHERE Giaodat.IDGD = LDTruocGiao.IDGD GROUP BY LDTruocGiao.IDGD ) a, (SELECT LDDuocGiao.IDGD, SUM(Dientich) as TongDTDuoc FROM LDDuocGiao, Giaodat WHERE Giaodat.IDGD = LDDuocGiao.IDGD GROUP BY LDDuocGiao.IDGD) b WHERE Giaodat.IDGD = " + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString() + " and Giaodat.MaTochuc = TenTochuc.MaTochuc and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc and Giaodat.IDGD = a.IDGD and Giaodat.IDGD = b.IDGD";

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
                s = "SELECT DMLoaidat.TenLD,Dientich FROM DMLoaidat,LDTruocGiao WHERE LDTruocGiao.MaLD = DMLoaidat.MaLD and IDGD = " + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString();
                table_Truoc.Clear();
                sql.ViewDataTable(s, table_Truoc, Array_col2);

                DataColumn[] Array_col3 = { col_sau1, col_sau2 };
                s = "SELECT DMLoaidat.TenLD,Dientich FROM DMLoaidat,LDDuocGiao WHERE LDDuocGiao.MaLD = DMLoaidat.MaLD and IDGD = " + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString();
                table_Sau.Clear();
                sql.ViewDataTable(s, table_Sau, Array_col3);


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
            table_DSTenDuAn.Clear();
            table_Truoc.Clear();
            table_Sau.Clear();
            DataColumn[] Array_col1 = { col0, col1, col2 };
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY TenDuan asc) AS Row#,[IDGD],[TenDuan] FROM [GIAODAT].[dbo].[Giaodat]";
            sql.ViewDataTable(s, table_DSTenDuAn, Array_col1);
            labelControl_Ma.Text = "";
            labelControl_TenDA.Text = "";
            labelControl_DiaDiem.Text = "";
            labelControl_Huyen.Text = "";
            labelControl_SoQD.Text = "";
            labelControl_NgayQD.Text = "";
            labelControl_NgayGiao.Text = "";
            labelControl_ThoiHan.Text = "";
            labelControl_HinhThuc.Text = "";
            labelControl_TinhTrang.Text = "";
            labelControl_ToChuc.Text = "";
            groupControl4.Text = "Tổng diện tích trước giao : ";
            groupControl5.Text = "Tổng diện tích sau giao : ";

        }

        private void toolStripMenuItem_Modify_Click(object sender, EventArgs e)
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

            F_Main_ThemDuAn frm = new F_Main_ThemDuAn(this, table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString());
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
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa dự án '" + table_DSTenDuAn.Rows[rowSel].ItemArray[2].ToString() + "' ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                string s = "DELETE FROM LDTruocGiao WHERE IDGD=" + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString();
                sql.ExecuteData(s);
                s = "DELETE FROM LDDuocGiao WHERE IDGD=" + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString();
                sql.ExecuteData(s);
                s = "DELETE FROM Giaodat WHERE IDGD=" + table_DSTenDuAn.Rows[rowSel].ItemArray[1].ToString();
                sql.ExecuteData(s);
                DevExpress.XtraEditors.XtraMessageBox.Show("Xóa thành công !");
                this.RefeshDS();
                Cursor = Cursors.Default;
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}