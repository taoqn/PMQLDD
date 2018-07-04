using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PMQLDD
{
    public partial class F_DangNhap_CauHinh : DevExpress.XtraEditors.XtraForm
    {

        public F_DangNhap_CauHinh()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                string myServer = Environment.MachineName;
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
                comboBoxEdit_Server.Properties.Items.Clear();
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    if (myServer == servers.Rows[i]["ServerName"].ToString())
                        comboBoxEdit_Server.Properties.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        comboBoxEdit_Server.Properties.Items.Add(servers.Rows[i]["ServerName"] + "");
                }
                Cursor = Cursors.Default;
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã xảy ra lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                comboBoxEdit_Database.Properties.Items.Clear();
                SqlConnection sql;
                if (radioGroup_Authentication.SelectedIndex.ToString().Equals("0"))
                {
                    sql = new SqlConnection("Server=" + comboBoxEdit_Server.Text + "; Trusted_Connection=True");
                }
                else
                {
                    //sql = new SqlConnection("@”Data Source=" + comboBoxEdit_TenMayChu.Text + ";User ID=" + textEdit_TenDangNhap.Text + ";password=" + textEdit_MatKhau.Text);
                    sql = new SqlConnection("Server=" + comboBoxEdit_Server.Text + ";User ID=" + textEdit_Username.Text + ";password=" + textEdit_Password.Text);
                }
                sql.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_databases";
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                    comboBoxEdit_Database.Properties.Items.Add(read.GetString(0).ToString());
                sql.Close();
                Cursor = Cursors.Default;
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã xảy ra lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void simpleButton_OK_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlcon;
                if (comboBoxEdit_Server.Text.Equals("") || comboBoxEdit_Database.Text.Equals(""))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Chưa có thông tin máy chủ hoặc CSDL !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    if (radioGroup_Authentication.SelectedIndex.ToString().Equals("0"))
                    {
                        sqlcon = new SqlConnection("Server=" + comboBoxEdit_Server.Text + "; Database=" + comboBoxEdit_Database.Text + "; Trusted_Connection=True");
                    }
                    else
                    {
                        if (textEdit_Username.Text.Equals("") || textEdit_Password.Text.Equals(""))
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Chưa có thông tin Tên người dùng hoặc mật khẩu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                        else
                        {
                            sqlcon = new SqlConnection("@”Data Source=" + comboBoxEdit_Server.Text + ";Initial Catalog=" + comboBoxEdit_Database.Text + ";User ID=" + textEdit_Username.Text + ";password=" + textEdit_Password.Text);
                        }
                    }
                }
                SQLConnect sql = new SQLConnect(sqlcon);
                F_DangNhap.SQL_con_object = sql;
                DevExpress.XtraEditors.XtraMessageBox.Show("Kết nối thành công !");
                this.Close();
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Đã xảy ra lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void simpleButton_LuuLai_Click(object sender, EventArgs e)
        {
            Registry.SetValue(F_DangNhap.RegistryDocMIS, "SQL_ServerName", comboBoxEdit_Server.Text);
            Registry.SetValue(F_DangNhap.RegistryDocMIS, "SQL_LoginWin", radioGroup_Authentication.SelectedIndex.ToString());
            Registry.SetValue(F_DangNhap.RegistryDocMIS, "SQL_UserName", textEdit_Username.Text);
            Registry.SetValue(F_DangNhap.RegistryDocMIS, "SQL_Password", textEdit_Password.Text);
            Registry.SetValue(F_DangNhap.RegistryDocMIS, "SQL_DataBase", comboBoxEdit_Database.Text);
        }

        private void simpleButton_HuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioGroup_Authentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup_Authentication.SelectedIndex.ToString().Equals("0"))
            {
                textEdit_Username.Enabled = false;
                textEdit_Password.Enabled = false;
            }
            else
            {
                textEdit_Username.Enabled = true;
                textEdit_Password.Enabled = true;
            }
        }

        private void F_DangNhap_CauHinh_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxEdit_Server.Text = (string)Registry.GetValue(F_DangNhap.RegistryDocMIS, "SQL_ServerName", F_DangNhap.RegistryDoc);
                radioGroup_Authentication.SelectedIndex = int.Parse((string)Registry.GetValue(F_DangNhap.RegistryDocMIS, "SQL_LoginWin", F_DangNhap.RegistryDoc));
                if (radioGroup_Authentication.SelectedIndex.ToString().Equals("0"))
                {
                    radioGroup_Authentication.SelectedIndex = 0;
                }
                else
                {
                    radioGroup_Authentication.SelectedIndex = 1;
                    textEdit_Username.Text = (string)Registry.GetValue(F_DangNhap.RegistryDocMIS, "SQL_UserName", F_DangNhap.RegistryDoc);
                    textEdit_Password.Text = (string)Registry.GetValue(F_DangNhap.RegistryDocMIS, "SQL_Password", F_DangNhap.RegistryDoc);
                }
                comboBoxEdit_Database.Text = (string)Registry.GetValue(F_DangNhap.RegistryDocMIS, "SQL_DataBase", F_DangNhap.RegistryDoc);
            }
            catch
            {

            }
        }

        private void F_DangNhap_CauHinh_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}