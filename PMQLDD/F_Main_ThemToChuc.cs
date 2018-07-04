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
    public partial class F_Main_ThemToChuc : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_Main_TenToChuc formTenToChuc;
        private string maToChuc;
        private int soduan;

        public F_Main_ThemToChuc()
        {
            InitializeComponent();
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;
        }

        public F_Main_ThemToChuc(F_Main_TenToChuc frm, string ma, int so)
        {
            InitializeComponent();
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            this.formTenToChuc = frm;
            this.maToChuc = ma;
            this.soduan = so;

            this.Text = "Chỉnh sửa thông tin tổ chức";
            string s = "SELECT [MaTochuc] ,[TenTochuc] ,[Diachi]  ,[Masothue] ,[Giamdoc] ,convert(NVARCHAR, NgayTL, 101) as NgayTL FROM [GIAODAT].[dbo].[TenTochuc] WHERE MaTochuc='" + ma + "' ";

            textEdit_maToChuc.Text = sql.GetData(s, 0);
            textEdit_TenToChuc.Text = sql.GetData(s, 1);
            textEdit_DiaChi.Text = sql.GetData(s, 2);
            textEdit_MST.Text = sql.GetData(s, 3);
            textEdit_GiamDoc.Text = sql.GetData(s, 4);
            dateEdit_NgayThanhLap.EditValue = sql.GetData(s, 5);

            simpleButton_NhapLai.Enabled = false;
        }

        private void simpleButton_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_Main_TiepNhanHoSo_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton_NhapLai_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn nhập lại từ đầu ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                textEdit_maToChuc.Text = "";
                textEdit_TenToChuc.Text = "";
                textEdit_DiaChi.Text = "";
                textEdit_MST.Text = "";
                textEdit_GiamDoc.Text = "";
                dateEdit_NgayThanhLap.EditValue = "";
            }
        }

        private void simpleButton_Luu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEdit_maToChuc.Text) || String.IsNullOrEmpty(textEdit_TenToChuc.Text) || String.IsNullOrEmpty(textEdit_DiaChi.Text) || String.IsNullOrEmpty(textEdit_MST.Text)
                || String.IsNullOrEmpty(textEdit_GiamDoc.Text) || String.IsNullOrEmpty(dateEdit_NgayThanhLap.EditValue.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin !");
                return;
            }

            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn lưu \"'" + textEdit_maToChuc.Text + "'\" ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                string ngaythanhlap = dateEdit_NgayThanhLap.DateTime.Month + "/" + dateEdit_NgayThanhLap.DateTime.Day + "/" + dateEdit_NgayThanhLap.DateTime.Year;
                try
                {
                    if (!String.IsNullOrEmpty(this.maToChuc))
                    {

                        if(!textEdit_maToChuc.Text.ToString().Equals(this.maToChuc)){
                            string s = "SELECT MaTochuc FROM TenTochuc WHERE MaTochuc='" + textEdit_maToChuc.Text + "'";
                            if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("Mã tổ chức đã tồn tại !", "Cảnh Báo");
                                return;
                            }
                        }

                        if (this.soduan > 0)
                        {
                            string s10 = "ALTER TABLE Giaodat DROP CONSTRAINT FK__Giaodat__MaTochu__0A9D95DB";
                            sql.ExecuteData(s10);
                            s10 = "UPDATE Giaodat SET MaTochuc=N'" + textEdit_maToChuc.Text + "' WHERE MaTochuc='" + this.maToChuc + "' ";
                            sql.ExecuteData(s10);
                            s10 = "UPDATE TenTochuc SET MaTochuc=N'" + textEdit_maToChuc.Text + "', TenTochuc=N'" + textEdit_TenToChuc.Text + "', Diachi=N'" + textEdit_DiaChi.Text + "', Masothue=N'" + textEdit_MST.Text + "', Giamdoc=N'" + textEdit_GiamDoc.Text + "', NgayTL=N'" + ngaythanhlap + "' WHERE MaTochuc='" + this.maToChuc + "'";
                            sql.ExecuteData(s10);
                            s10 = "ALTER TABLE Giaodat ADD CONSTRAINT FK__Giaodat__MaTochu__0A9D95DB FOREIGN KEY([MaTochuc]) REFERENCES [dbo].[TenTochuc] ([MaTochuc])";
                            sql.ExecuteData(s10);
                        }
                        else
                        {
                            string s1 = "UPDATE TenTochuc SET MaTochuc=N'" + textEdit_maToChuc.Text + "', TenTochuc=N'" + textEdit_TenToChuc.Text + "', Diachi=N'" + textEdit_DiaChi.Text + "', Masothue=N'" + textEdit_MST.Text + "', Giamdoc=N'" + textEdit_GiamDoc.Text + "', NgayTL=N'" + ngaythanhlap + "' WHERE MaTochuc='" + this.maToChuc + "'";
                            sql.ExecuteData(s1);
                        }

                        this.formTenToChuc.RefeshDS();
                    }
                    else
                    {
                        string s = "SELECT MaTochuc FROM TenTochuc WHERE MaTochuc='" + textEdit_maToChuc.Text + "'";
                        if (!String.IsNullOrEmpty(sql.GetData(s, 0)))
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Mã tổ chức đã tồn tại !", "Cảnh Báo");
                            return;
                        }

                        string s1 = "INSERT INTO TenTochuc(MaTochuc, TenTochuc, Diachi, Masothue, Giamdoc, NgayTL) VALUES (N'" + textEdit_maToChuc.Text + "',N'" + textEdit_TenToChuc.Text + "',N'" + textEdit_DiaChi.Text + "',N'" + textEdit_MST.Text + "',N'" + textEdit_GiamDoc.Text + "',N'" + ngaythanhlap + "');";
                        sql.ExecuteData(s1);
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
    }
}