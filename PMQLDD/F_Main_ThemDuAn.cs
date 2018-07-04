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
    public partial class F_Main_ThemDuAn : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_Truoc;
        private DataColumn col_truoc1;
        private DataColumn col_truoc2;

        private DataTable table_Sau;
        private DataColumn col_sau1;
        private DataColumn col_sau2;

        private F_Main_SoQuyetDinh formTenDuAn;
        private string IDGD;
        private string soQD;

        public F_Main_ThemDuAn()
        {
            InitializeComponent();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            this.LoadData();
            Cursor = Cursors.Default;
        }

        public F_Main_ThemDuAn(F_Main_SoQuyetDinh frm, string id)
        {
            InitializeComponent();
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            this.LoadData();
            this.Text = "Chỉnh sửa thông tin dự án";
            string s = "SELECT TenDuan, Diadiem, convert(NVARCHAR, Ngaygiao, 101) as NgayGiao, MaDvhc, SoQD, convert(NVARCHAR, NgayQD, 101) as NgayQD, MaHinhthuc, YEAR(Thoihan)-YEAR(Ngaygiao) as SoNam , TinhtrangPL, MaTochuc FROM Giaodat WHERE IDGD = " + id;
            this.formTenDuAn = frm;
            this.IDGD = id;
            this.soQD = sql.GetData(s, 4);
            
            textEdit_tenDuAn.Text = sql.GetData(s, 0);
            textEdit_diaDiem.Text = sql.GetData(s, 1);
            dateEdit_NgayGiao.EditValue = sql.GetData(s, 2);
            lookUpEdit_Huyen.EditValue = sql.GetData(s, 3);
            textEdit_SoQD.Text = sql.GetData(s, 4);
            dateEdit_NgayQD.EditValue = sql.GetData(s, 5);
            lookUpEdit_HinhThuc.EditValue = sql.GetData(s, 6);
            spinEdit_ThoiHan.Value = int.Parse(sql.GetData(s, 7).ToString().Trim());
            lookUpEdit_TinhTrangPL.EditValue = sql.GetData(s, 8);
            lookUpEdit_MaToChuc.EditValue = sql.GetData(s, 9);

            DataColumn[] Array_coltruoc = { col_truoc1, col_truoc2 };
            s = "SELECT [MaLD],[Dientich] FROM [GIAODAT].[dbo].[LDTruocGiao] WHERE IDGD = " + id;
            sql.ViewDataTable(s, table_Truoc, Array_coltruoc);

            DataColumn[] Array_colsau = { col_sau1, col_sau2 };
            s = "SELECT [MaLD],[Dientich] FROM [GIAODAT].[dbo].[LDDuocGiao] WHERE IDGD = " + id;
            sql.ViewDataTable(s, table_Sau, Array_colsau);


            simpleButton_NhapLai.Enabled = false;

            Cursor = Cursors.Default;

        }

        private void simpleButton_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Main_TiepNhanHoSo_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            spinEdit_ThoiHan.Properties.Mask.EditMask = "##;";
            spinEdit_ThoiHan.Properties.MinValue = 1;
            spinEdit_ThoiHan.Properties.MaxValue = 50;
            spinEdit_ThoiHan.Value = 50;

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

            //Lookupedit mã tổ chức

            DataTable table_MTC = new DataTable();
            DataColumn col_mtc1 = new DataColumn();
            col_mtc1.DataType = System.Type.GetType("System.String");
            col_mtc1.ColumnName = "Mã";
            table_MTC.Columns.Add(col_mtc1);

            DataColumn col_mtc2 = new DataColumn();
            col_mtc2.DataType = System.Type.GetType("System.String");
            col_mtc2.ColumnName = "Tên tổ chức";
            table_MTC.Columns.Add(col_mtc2);

            lookUpEdit_MaToChuc.Properties.DataSource = table_MTC;
            lookUpEdit_MaToChuc.Properties.DisplayMember = "Tên tổ chức";
            lookUpEdit_MaToChuc.Properties.ValueMember = "Mã";

            DataColumn[] Array_col4 = { col_mtc1, col_mtc2 };
            string s4 = "SELECT [MaTochuc],[TenTochuc] FROM [GIAODAT].[dbo].[TenTochuc] ORDER BY TenTochuc asc";
            sql.ViewDataTable(s4, table_MTC, Array_col4);


            //Gridcontrol Trươc giao

            table_Truoc = new DataTable();
            col_truoc1 = new DataColumn();
            col_truoc1.DataType = System.Type.GetType("System.String");
            col_truoc1.ColumnName = "Loại đất";
            table_Truoc.Columns.Add(col_truoc1);

            col_truoc2 = new DataColumn();
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
            col_sau1 = new DataColumn();
            col_sau1.DataType = System.Type.GetType("System.String");
            col_sau1.ColumnName = "Loại đất";
            table_Sau.Columns.Add(col_sau1);

            col_sau2 = new DataColumn();
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
                lookUpEdit_MaToChuc.EditValue = "";
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
                || String.IsNullOrEmpty(lookUpEdit_MaToChuc.EditValue.ToString()))
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

            if (String.IsNullOrEmpty(this.IDGD))
            {
                string s = "SELECT MaTochuc FROM Giaodat WHERE MaTochuc='" + lookUpEdit_MaToChuc.EditValue + "' and TenDuan='" + textEdit_tenDuAn.Text + "'";
                if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Mã tổ chức và tên dữ án đã tồn tại trong CSDL !", "Cảnh Báo");
                    return;
                }
            }

            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn lưu \"'" + textEdit_tenDuAn.Text + "'\" ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                try
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                    string ngaygiao = dateEdit_NgayGiao.DateTime.Month + "/" + dateEdit_NgayGiao.DateTime.Day + "/" + dateEdit_NgayGiao.DateTime.Year;
                    string ngayQD = dateEdit_NgayQD.DateTime.Month + "/" + dateEdit_NgayQD.DateTime.Day + "/" + dateEdit_NgayQD.DateTime.Year;
                    string thoihan = dateEdit_NgayGiao.DateTime.Month + "/" + dateEdit_NgayGiao.DateTime.Day + "/" + (dateEdit_NgayGiao.DateTime.Year + spinEdit_ThoiHan.Value);

                    if (String.IsNullOrEmpty(this.IDGD))
                    {

                        string s1 = "SELECT SoQD FROM Giaodat WHERE SoQD='" + textEdit_SoQD.Text + "' ";
                        if (!String.IsNullOrEmpty(sql.GetData(s1, 0)))
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Số quyết định đã tồn tại trong CSDL !", "Cảnh Báo");
                            return;
                        }

                        string s2 = "INSERT INTO Giaodat(MaTochuc, Ngaygiao, TenDuan, Diadiem, MaDvhc, SoQD, NgayQD, Thoihan, MaHinhthuc, TinhtrangPL, MaIDNguoiNhap) VALUES (N'" + lookUpEdit_MaToChuc.EditValue + "',N'" + ngaygiao + "',N'" + textEdit_tenDuAn.Text + "',N'" + textEdit_diaDiem.Text + "',N'" + lookUpEdit_Huyen.EditValue + "',N'" + textEdit_SoQD.Text + "',N'" + ngayQD + "',N'" + thoihan + "',N'" + lookUpEdit_HinhThuc.EditValue + "',N'" + lookUpEdit_TinhTrangPL.EditValue + "'," + nguoi.MaID + ");";
                        sql.ExecuteData(s2);
                        string s3 = "SELECT TOP 1 [IDGD] FROM [GIAODAT].[dbo].[Giaodat] ORDER BY IDGD desc";
                        this.Insert_Table_Truoc(sql.GetData(s3, 0));
                        this.Insert_Table_Sau(sql.GetData(s3, 0));
                    }
                    else
                    {
                        if (!textEdit_SoQD.Text.Equals(this.soQD))
                        {
                            string s4 = "SELECT SoQD FROM Giaodat WHERE SoQD='" + textEdit_SoQD.Text + "' ";
                            if (!String.IsNullOrEmpty(sql.GetData(s4, 0)))
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Số quyết định đã tồn tại trong CSDL !", "Cảnh Báo");
                                return;
                            }
                        }

                        string s5 = "UPDATE Giaodat SET MaTochuc=N'" + lookUpEdit_MaToChuc.EditValue + "', Ngaygiao=N'" + ngaygiao + "', TenDuan=N'" + textEdit_tenDuAn.Text + "', Diadiem=N'" + textEdit_diaDiem.Text + "', MaDvhc=N'" + lookUpEdit_Huyen.EditValue + "', SoQD=N'" + textEdit_SoQD.Text + "', NgayQD=N'" + ngayQD + "', Thoihan=N'" + thoihan + "', MaHinhthuc=N'" + lookUpEdit_HinhThuc.EditValue + "', TinhtrangPL=N'" + lookUpEdit_TinhTrangPL.EditValue + "' WHERE IDGD='" + this.IDGD + "'";
                        sql.ExecuteData(s5);
                        s5 = "DELETE FROM LDTruocGiao WHERE IDGD=" + this.IDGD;
                        sql.ExecuteData(s5);
                        s5 = "DELETE FROM LDDuocGiao WHERE IDGD=" + this.IDGD;
                        sql.ExecuteData(s5);

                        this.Insert_Table_Truoc(this.IDGD);
                        this.Insert_Table_Sau(this.IDGD);

                        this.formTenDuAn.RefeshDS();
                    }

                    Cursor = Cursors.Default;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Lưu dữ liệu thành công !");
                    this.Close();
                }
                catch
                {
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