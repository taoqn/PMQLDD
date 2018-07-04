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
    public partial class F_Main_ThayDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public F_Main_ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void F_Main_ThayDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung nguoi = F_DangNhap.person_object as NguoiDung;
                SQLConnect sql = F_DangNhap.SQL_con_object as SQLConnect;
                string mkCu = this.textEdit_MKhauCu.Text;
                string mkMoi = this.textEdit_MKhauMoi.Text;
                string nLai = this.textEdit_NhapLai.Text;

                if (string.IsNullOrEmpty(mkCu) || string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(nLai))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin !");
                    return;
                }

                mkCu = sql.StringToMD5(mkCu);

                if (!mkCu.Equals(nguoi.MatKhau.ToString()))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Mật khẩu cũ không khớp !");
                    return;
                }

                if (!mkMoi.Equals(nLai))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Hai mật khẩu mới không trùng nhau !");
                    return;
                }

                nguoi.MatKhau = sql.StringToMD5(mkMoi);
                String s = "UPDATE Table_NhanVien SET MatKhau='" + nguoi.MatKhau.ToString() + "' WHERE MaID=" + nguoi.MaID.ToString();
                sql.ExecuteData(s);
                DevExpress.XtraEditors.XtraMessageBox.Show("Cập nhật thành công !");
                this.Close();
            }
            catch {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã xảy ra lỗi !");
            }
        }

        private void simpleButton_HuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}