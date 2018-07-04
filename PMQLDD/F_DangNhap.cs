using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PMQLDD
{
    public partial class F_DangNhap : DevExpress.XtraEditors.XtraForm
    {

        public static object person_object;
        public static object SQL_con_object;
        public static String RegistryDocMIS = "HKEY_CURRENT_USER\\SOFTWARE\\PMQLDD\\1.0\\CONNECT";
        public static String RegistryDoc = "";

        private F_Main form_Main;
        private F_DangNhap_CauHinh form_DangNhap_CauHinh;

        public F_DangNhap()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                if (String.IsNullOrEmpty(textEdit_tenDangNhap.Text) || String.IsNullOrEmpty(textEdit_matKhau.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin !");
                    return;
                }
                SQLConnect sql = (SQLConnect)SQL_con_object;
                string s = "SELECT * FROM Taikhoan WHERE (TenDangNhap='" + textEdit_tenDangNhap.Text + "') AND (MatKhau='" + sql.StringToMD5(textEdit_matKhau.Text) + "')";
                if (String.IsNullOrEmpty(sql.GetData(s, 0)))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Username và Password không đúng !", "Cảnh Báo");
                    return;
                }
                if (checkEdit_luu.Checked)
                {
                    Registry.SetValue(RegistryDocMIS, "Login_Check", "true");
                    Registry.SetValue(RegistryDocMIS, "Login_Username", textEdit_tenDangNhap.Text);
                    Registry.SetValue(RegistryDocMIS, "Login_Password", textEdit_matKhau.Text);
                }
                else
                {
                    Registry.SetValue(RegistryDocMIS, "Login_Check", "false");
                }

                NguoiDung person = new NguoiDung(sql.GetData(s, 0), sql.GetData(s, 1), sql.GetData(s, 2), sql.GetData(s, 3), sql.GetData(s, 4), sql.GetData(s, 5), sql.GetData(s, 6), int.Parse(sql.GetData(s, 7)), sql.GetData(s, 8));
                person_object = (NguoiDung)person;

                s = "INSERT INTO Taikhoan_Lichsu VALUES (" + person.MaID + ",'" + DateTime.Now + "',NULL,N'" + sql.GetLocalIPAddress() + "',0)";
                sql.ExecuteData(s);

                form_Main = new F_Main(this);
                form_Main.Show();
                khay_HeThong.Visible = true;
                khay_HeThong.ShowBalloonTip(10);
                this.Hide();
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn chưa kết nối CSDL !", "Cảnh Báo");
                form_DangNhap_CauHinh = new F_DangNhap_CauHinh();
                form_DangNhap_CauHinh.Show();
            }
            Cursor = Cursors.Default;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            form_DangNhap_CauHinh = new F_DangNhap_CauHinh();
            form_DangNhap_CauHinh.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void F_DangNhap_Load(object sender, EventArgs e)
        {
            try
            {
                string Server = (string)Registry.GetValue(RegistryDocMIS, "SQL_ServerName", RegistryDoc);
                string Authentication = (string)Registry.GetValue(RegistryDocMIS, "SQL_LoginWin", RegistryDoc);
                string Username = (string)Registry.GetValue(RegistryDocMIS, "SQL_UserName", RegistryDoc);
                string Password = (string)Registry.GetValue(RegistryDocMIS, "SQL_Password", RegistryDoc);
                string Database = (string)Registry.GetValue(RegistryDocMIS, "SQL_DataBase", RegistryDoc);
                SqlConnection sqlcon;
                if (Authentication.Equals("0"))
                {
                    sqlcon = new SqlConnection("Server=" + Server + "; Database=" + Database + "; Trusted_Connection=True");
                }
                else
                {
                    sqlcon = new SqlConnection("@”Data Source=" + Server + ";Initial Catalog=" + Database + ";User ID=" + Username + ";password=" + Password);
                }
                SQLConnect sql = new SQLConnect(sqlcon);
                SQL_con_object = sql;

                textEdit_tenDangNhap.Text = (string)Registry.GetValue(RegistryDocMIS, "Login_Username", RegistryDoc);
                textEdit_matKhau.Text = (string)Registry.GetValue(RegistryDocMIS, "Login_Password", RegistryDoc);

                if (Convert.ToString(Registry.GetValue(RegistryDocMIS, "Login_Check", RegistryDoc)).Equals("true"))
                {
                    checkEdit_luu.Checked = true;
                }
                else
                {
                    checkEdit_luu.Checked = false;
                }
            }
            catch { }
        }

        private void checkEdit_luu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn đăng xuất tài khoản '" + textEdit_tenDangNhap.Text + "' ra khỏi hể thống ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dangxuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn đăng xuất tài khoản '" + textEdit_tenDangNhap.Text + "' ra khỏi hể thống ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                this.ketThucDangNhap();
                form_Main.Close();
                this.Show();
            }
        }

        public void ketThucDangNhap()
        {
            string s = "update Taikhoan_Lichsu set ThoiDiemKetThuc = '" + DateTime.Now + "', LogOn = 1  where LogOn = 0 ";
            SQLConnect sql = (SQLConnect)SQL_con_object;
            sql.ExecuteData(s);
            khay_HeThong.Visible = false;
        }

        private void F_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ketThucDangNhap();
        }

    }
}
