using System;
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
    public partial class F_Main_TiepNhanHoSo : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;
        private DataTable table_Truoc;
        private DataTable table_Sau;

        public F_Main_TiepNhanHoSo()
        {
            InitializeComponent();
        }

        private void simpleButton_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Main_TiepNhanHoSo_Load(object sender, EventArgs e)
        {
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //Lookupedit Huyen
            DataTable table_Huyen = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Mã";
            table_Huyen.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Đơn vị";
            table_Huyen.Columns.Add(col2);

            lookUpEdit_Huyen.Properties.DataSource = table_Huyen;
            lookUpEdit_Huyen.Properties.DisplayMember = "Đơn vị";
            lookUpEdit_Huyen.Properties.ValueMember = "Mã";

            DataColumn[] Array_col1 = { col1, col2 };
            string s1 = "SELECT [MaDvhc],[TenDvhc] FROM [GIAODAT].[dbo].[DMDvhc] ORDER BY TenDvhc asc";
            sql.ViewDataTable(s1, table_Huyen, Array_col1);

            //Lookupedit Hình thức sử dụng

            DataTable table_HinhThucSuDung = new DataTable();
            DataColumn column1 = new DataColumn();
            column1.DataType = System.Type.GetType("System.String");
            column1.ColumnName = "Mã";
            table_HinhThucSuDung.Columns.Add(column1);

            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "Hình thức";
            table_HinhThucSuDung.Columns.Add(column2);

            lookUpEdit_HinhThuc.Properties.DataSource = table_HinhThucSuDung;
            lookUpEdit_HinhThuc.Properties.DisplayMember = "Hình thức";
            lookUpEdit_HinhThuc.Properties.ValueMember = "Mã";

            DataColumn[] Array_col2 = { column1, column2 };
            string s2 = "SELECT [MaHinhthuc],[TenHinhthuc] FROM [GIAODAT].[dbo].[DMHinhthucsudung] ORDER BY TenHinhthuc asc";
            sql.ViewDataTable(s2, table_HinhThucSuDung, Array_col2);

            //Lookupedit Tình trạng pháp lý

            DataTable table_TinhTrangPL = new DataTable();
            DataColumn cot = new DataColumn();
            cot.DataType = System.Type.GetType("System.String");
            cot.ColumnName = "Tình trạng";
            table_TinhTrangPL.Columns.Add(cot);

            lookUpEdit_TinhTrangPL.Properties.DataSource = table_TinhTrangPL;
            lookUpEdit_TinhTrangPL.Properties.DisplayMember = "Tình trạng";
            lookUpEdit_TinhTrangPL.Properties.ValueMember = "Tình trạng";

            table_TinhTrangPL.BeginLoadData();
            DataRow row = table_TinhTrangPL.NewRow();
            row[0] = "Đã cấp giấy chứng nhận";
            table_TinhTrangPL.Rows.Add(row);
            row = table_TinhTrangPL.NewRow();
            row[0] = "Chưa cấp giấy chứng nhận";
            table_TinhTrangPL.Rows.Add(row);
            table_TinhTrangPL.EndLoadData();


            //Lookupedit Loai đất

            DataTable table_LoaiDat = new DataTable();
            DataColumn col_loaidat1 = new DataColumn();
            col_loaidat1.DataType = System.Type.GetType("System.String");
            col_loaidat1.ColumnName = "Mã";
            table_LoaiDat.Columns.Add(col_loaidat1);

            DataColumn col_loaidat2 = new DataColumn();
            col_loaidat2.DataType = System.Type.GetType("System.String");
            col_loaidat2.ColumnName = "Loại đất";
            table_LoaiDat.Columns.Add(col_loaidat2);

            DataColumn[] Array_col3 = { col_loaidat1, col_loaidat2 };
            string s3 = "SELECT [MaLD],[TenLD] FROM [GIAODAT].[dbo].[DMLoaidat] ORDER BY TenLD asc";
            sql.ViewDataTable(s3, table_LoaiDat, Array_col3);


            //Gridcontrol Trươc giao

            table_Truoc = new DataTable();
            DataColumn col_truoc1 = new DataColumn();
            col_truoc1.DataType = System.Type.GetType("System.String");
            col_truoc1.ColumnName = "Loại đất";
            table_Truoc.Columns.Add(col_truoc1);

            DataColumn col_truoc2 = new DataColumn();
            col_truoc2.DataType = Type.GetType("System.Double");
            col_truoc2.ColumnName = "Diện tích (m2)";
            table_Truoc.Columns.Add(col_truoc2);
            gridControl1.DataSource = table_Truoc;

            RepositoryItemLookUpEdit riLookup1 = new RepositoryItemLookUpEdit();
            riLookup1.DataSource = table_LoaiDat;
            riLookup1.DisplayMember = "Loại đất";
            riLookup1.ValueMember = "Mã";
            gridView1.Columns[0].ColumnEdit = riLookup1;
            gridView1.Columns[0].Width = 200;

            //Gridcontrol Sau giao

            table_Sau = new DataTable();
            DataColumn col_sau1 = new DataColumn();
            col_sau1.DataType = System.Type.GetType("System.String");
            col_sau1.ColumnName = "Loại đất";
            table_Sau.Columns.Add(col_sau1);

            DataColumn col_sau2 = new DataColumn();
            col_sau2.DataType = Type.GetType("System.Double");
            col_sau2.ColumnName = "Diện tích (m2)";
            table_Sau.Columns.Add(col_sau2);
            gridControl2.DataSource = table_Sau;

            RepositoryItemLookUpEdit riLookup2 = new RepositoryItemLookUpEdit();
            riLookup2.DataSource = table_LoaiDat;
            riLookup2.DisplayMember = "Loại đất";
            riLookup2.ValueMember = "Mã";
            gridView2.Columns[0].ColumnEdit = riLookup2;
            gridView2.Columns[0].Width = 200;

        }

        private void simpleButton_NhapLai_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn nhập lại từ đầu ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                textEdit_tenDuAn.Text = "";
                textEdit_diaDiem.Text = "";
                dateEdit_NgayGiao.EditValue = "";
                lookUpEdit_Huyen.EditValue = "";
                textEdit_SoQD.Text = "";
                dateEdit_NgayQD.EditValue = "";
                lookUpEdit_HinhThuc.EditValue = "";
                spinEdit_ThoiHan.Value = 50;
                lookUpEdit_TinhTrangPL.EditValue = "";
                textEdit_maToChuc.Text = "";
                textEdit_TenToChuc.Text = "";
                textEdit_DiaChi.Text = "";
                textEdit_MST.Text = "";
                textEdit_GiamDoc.Text = "";
                dateEdit_NgayThanhLap.EditValue = "";
                table_Truoc.Clear();
                table_Sau.Clear();
            }
        }

        private void simpleButton_themTruoc_Click(object sender, EventArgs e)
        {
            table_Truoc.BeginLoadData();
            DataRow row = table_Truoc.NewRow();
            row[0] = "LUA";
            row[1] = 50.55;
            table_Truoc.Rows.Add(row);
            table_Truoc.EndLoadData();
        }

        private void simpleButton_xoaTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;
                table_Truoc.BeginLoadData();
                table_Truoc.Rows.RemoveAt(rowSel);
                table_Truoc.EndLoadData();
            }
            catch { }
        }

        private void simpleButton_themSau_Click(object sender, EventArgs e)
        {
            table_Sau.BeginLoadData();
            DataRow row = table_Sau.NewRow();
            row[0] = "SKC";
            row[1] = 50.55;
            table_Sau.Rows.Add(row);
            table_Sau.EndLoadData();
        }

        private void simpleButton_xoaSau_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView2.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;
                table_Sau.BeginLoadData();
                table_Sau.Rows.RemoveAt(rowSel);
                table_Sau.EndLoadData();
            }
            catch { }
        }

        private void simpleButton_Luu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEdit_tenDuAn.Text) || String.IsNullOrEmpty(textEdit_diaDiem.Text)
                || String.IsNullOrEmpty(dateEdit_NgayGiao.EditValue.ToString()) || String.IsNullOrEmpty(lookUpEdit_Huyen.EditValue.ToString())
                || String.IsNullOrEmpty(textEdit_SoQD.Text) || String.IsNullOrEmpty(dateEdit_NgayQD.EditValue.ToString()) 
                || String.IsNullOrEmpty(lookUpEdit_HinhThuc.EditValue.ToString()) || String.IsNullOrEmpty(lookUpEdit_TinhTrangPL.EditValue.ToString())
                || String.IsNullOrEmpty(textEdit_maToChuc.Text) || String.IsNullOrEmpty(textEdit_TenToChuc.Text) || String.IsNullOrEmpty(textEdit_DiaChi.Text) || String.IsNullOrEmpty(textEdit_MST.Text)
                || String.IsNullOrEmpty(textEdit_GiamDoc.Text) || String.IsNullOrEmpty(dateEdit_NgayThanhLap.EditValue.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin !");
                return;
            }

            if (!checkError_Table_Truoc())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin bảng loại đất 'Trước' khi giao !");
                return;
            }

            if (!checkError_Table_Sau())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin bảng loại đất 'Sau' khi giao !");
                return;
            }

            string s = "SELECT MaTochuc FROM TenTochuc WHERE MaTochuc='" + textEdit_maToChuc.Text + "'";
            if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Mã tổ chức đã tồn tại !", "Cảnh Báo");
                return;
            }

            s = "SELECT MaTochuc FROM Giaodat WHERE MaTochuc='" + textEdit_maToChuc.Text + "' and TenDuan='" + textEdit_tenDuAn.Text + "'";
            if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Mã tổ chức và tên dữ án đã tồn tại trong CSDL !", "Cảnh Báo");
                return;
            }

            s = "SELECT SoQD FROM Giaodat WHERE SoQD='" + textEdit_SoQD.Text + "' ";
            if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Số quyết định đã tồn tại trong CSDL !", "Cảnh Báo");
                return;
            }

            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn lưu \"'" + textEdit_tenDuAn.Text + "'\" ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    string ngaythanhlap = dateEdit_NgayThanhLap.DateTime.Month + "/" + dateEdit_NgayThanhLap.DateTime.Day + "/" + dateEdit_NgayThanhLap.DateTime.Year;
                    string ngaygiao = dateEdit_NgayGiao.DateTime.Month + "/" + dateEdit_NgayGiao.DateTime.Day + "/" + dateEdit_NgayGiao.DateTime.Year;
                    string ngayQD = dateEdit_NgayQD.DateTime.Month + "/" + dateEdit_NgayQD.DateTime.Day + "/" + dateEdit_NgayQD.DateTime.Year;
                    string thoihan = dateEdit_NgayGiao.DateTime.Month + "/" + dateEdit_NgayGiao.DateTime.Day + "/" + (dateEdit_NgayGiao.DateTime.Year + spinEdit_ThoiHan.Value);

                    string s1 = "INSERT INTO TenTochuc(MaTochuc, TenTochuc, Diachi, Masothue, Giamdoc, NgayTL) VALUES (N'" + textEdit_maToChuc.Text + "',N'" + textEdit_TenToChuc.Text + "',N'" + textEdit_DiaChi.Text + "',N'" + textEdit_MST.Text + "',N'" + textEdit_GiamDoc.Text + "',N'" + ngaythanhlap + "');";
                    sql.ExecuteData(s1);

                    string s2 = "INSERT INTO Giaodat(MaTochuc, Ngaygiao, TenDuan, Diadiem, MaDvhc, SoQD, NgayQD, Thoihan, MaHinhthuc, TinhtrangPL, MaIDNguoiNhap) VALUES (N'" + textEdit_maToChuc.Text + "',N'" + ngaygiao + "',N'" + textEdit_tenDuAn.Text + "',N'" + textEdit_diaDiem.Text + "',N'" + lookUpEdit_Huyen.EditValue + "',N'" + textEdit_SoQD.Text + "',N'" + ngayQD + "',N'" + thoihan + "',N'" + lookUpEdit_HinhThuc.EditValue + "',N'" + lookUpEdit_TinhTrangPL.EditValue + "'," + nguoi.MaID + ");";
                    sql.ExecuteData(s2);

                    string s3 = "SELECT TOP 1 [IDGD] FROM [GIAODAT].[dbo].[Giaodat] ORDER BY IDGD desc";
                    this.Insert_Table_Truoc(sql.GetData(s3,0));
                    this.Insert_Table_Sau(sql.GetData(s3, 0));

                    Cursor = Cursors.Default;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Lưu dữ liệu thành công !");
                    this.Close();
                }
                catch {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Đã xãy ra lỗi !");
                }
            }
        }

        private void Insert_Table_Truoc(string IDGD)
        {
            String s;
            int i = 0;
            foreach (DataRow row in table_Truoc.Rows)
            {
                s = "INSERT INTO LDTruocGiao(IDGD, MaLD, Dientich) VALUES (" + IDGD + ",";
                foreach (DataColumn column in table_Truoc.Columns)
                {
                    if (i % 2 == 0)
                        s += "N'" + row[column].ToString() + "',";
                    else
                        s += row[column].ToString() + ")";
                    i++;
                }
                sql.ExecuteData(s);
            }
        }

        private void Insert_Table_Sau(string IDGD)
        {
            String s;
            int i = 0;
            foreach (DataRow row in table_Sau.Rows)
            {
                s = "INSERT INTO LDDuocGiao(IDGD, MaLD, Dientich) VALUES (" + IDGD + ",";
                foreach (DataColumn column in table_Sau.Columns)
                {
                    if (i % 2 == 0)
                        s += "N'" + row[column].ToString() + "',";
                    else
                        s += row[column].ToString() + ")";
                    i++;
                }
                sql.ExecuteData(s);
            }
        }

        private bool checkError_Table_Truoc()
        {
            return table_Truoc.Rows.Count > 0;
        }

        private bool checkError_Table_Sau()
        {
            return table_Sau.Rows.Count > 0;
        }
    }
}