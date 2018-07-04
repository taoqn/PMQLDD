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
    public partial class F_Main_CapQuyen_Them : DevExpress.XtraEditors.XtraForm
    {
        F_Main_CapQuyen Form;

        public F_Main_CapQuyen_Them(F_Main_CapQuyen frm)
        {
            InitializeComponent();
            this.Form = frm;
        }

        private void simpleButton_Reset_Click(object sender, EventArgs e)
        {
            textEdit_Username.Text = "";
            textEdit_Password.Text = "";
            textEdit_HT.Text = "";
            textEdit_DiaChi.Text = "";
            dateEdit_NS.EditValue = "12/25/1990";
            radioGroup_GT.SelectedIndex = 0;
            radioGroup_CapQuyen.SelectedIndex = 1;
        }

        private void simpleButton_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_OK_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textEdit_Username.Text) || String.IsNullOrEmpty(textEdit_Password.Text) || String.IsNullOrEmpty(textEdit_HT.Text) || String.IsNullOrEmpty(textEdit_DiaChi.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin !");
                return;
            }
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn thêm '" + textEdit_Username.Text + "' ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                try
                {
                    SQLConnect sql = F_DangNhap.SQL_con_object as SQLConnect;
                    string s1 = "SELECT TenDangNhap FROM Taikhoan WHERE TenDangNhap='" + textEdit_Username.Text + "'";
                    if (!String.IsNullOrEmpty(sql.GetData(s1, 0)))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Tên đăng nhập đã tồn tại !", "Cảnh Báo");
                        return;
                    }

                    string user = textEdit_Username.Text;
                    string pass = textEdit_Password.Text;
                    string HoTen = textEdit_HT.Text;
                    string NgaySinh = dateEdit_NS.DateTime.Month + "/" + dateEdit_NS.DateTime.Day + "/" + dateEdit_NS.DateTime.Year;
                    string DiaChi = textEdit_DiaChi.Text;
                    string gtinh = "Nam";
                    if (radioGroup_GT.SelectedIndex.ToString().Equals("0"))
                    {
                        gtinh = "Nam";
                    }
                    else
                    {
                        gtinh = "Nữ";
                    }
                    int quyen = radioGroup_CapQuyen.SelectedIndex;

                    string s2 = "INSERT INTO Taikhoan(TenDangNhap, MatKhau, HoTen, NgaySinh, QueQuan, GioiTinh, Cap, NgayTao) VALUES (N'" + user + "',N'" + sql.StringToMD5(pass) + "',N'" + HoTen + "',N'" + NgaySinh + "',N'" + DiaChi + "',N'" + gtinh + "'," + quyen + ",'" + DateTime.Now + "');";
                    sql.ExecuteData(s2);
                    DevExpress.XtraEditors.XtraMessageBox.Show("Thêm thành công !");
                    this.Close();
                }
                catch { }
            }
        }

        private void F_Main_CapQuyen_Them_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Form.loadListArray();
        }
    }
}