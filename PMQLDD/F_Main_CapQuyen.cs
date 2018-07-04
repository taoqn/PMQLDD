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
    public partial class F_Main_CapQuyen : DevExpress.XtraEditors.XtraForm
    {

        private SQLConnect sql;
        private NguoiDung nguoi;
        private string[] mang_ID;
        private string[] mang_TenDangNhap;
        private string[] mang_TenNguoiDung;
        private string[] mang_NhomQuanLy;
        private int intSelect;

        public F_Main_CapQuyen()
        {
            InitializeComponent();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = "UPDATE Taikhoan SET Cap=" + radioGroup_capQuyen.SelectedIndex + " WHERE MaID=" + mang_ID[intSelect];
            sql.ExecuteData(s);
            mang_NhomQuanLy[intSelect] = radioGroup_capQuyen.SelectedIndex + "";
        }

        private void F_Main_CapQuyen_Load(object sender, EventArgs e)
        {
            loadListArray();
        }

        private void listBox_DanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            intSelect = listBox_DanhSach.SelectedIndex;
            try
            {
                labelControl1.Text = mang_TenDangNhap[intSelect];
                labelControl5.Text = mang_TenNguoiDung[intSelect];
                if (mang_ID[intSelect].Equals(nguoi.MaID))
                {
                    radioGroup_capQuyen.Enabled = false;
                    simpleButton_Xoa.Enabled = false;
                }
                else
                {
                    radioGroup_capQuyen.Enabled = true;
                    simpleButton_Xoa.Enabled = true;
                }
                if (mang_NhomQuanLy[intSelect].Equals("0")) radioGroup_capQuyen.SelectedIndex = 0;
                if (mang_NhomQuanLy[intSelect].Equals("1")) radioGroup_capQuyen.SelectedIndex = 1;
                if (mang_NhomQuanLy[intSelect].Equals("2")) radioGroup_capQuyen.SelectedIndex = 2;
            }
            catch
            {

            }
        }

        public void loadListArray()
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            try
            {
                sql.ToString();
            }
            catch 
            {
                sql = F_DangNhap.SQL_con_object as SQLConnect;
                nguoi = F_DangNhap.person_object as NguoiDung;
            }
            listBox_DanhSach.Items.Clear();
            string s = "SELECT MaID,TenDangNhap,HoTen,Cap FROM Taikhoan";
            mang_ID = sql.GetDataArray(s, 0);
            mang_TenDangNhap = sql.GetDataArray(s, 1);
            mang_TenNguoiDung = sql.GetDataArray(s, 2);
            mang_NhomQuanLy = sql.GetDataArray(s, 3);
            int i = 0;
            while (!string.IsNullOrEmpty(mang_TenDangNhap[i]))
            {
                listBox_DanhSach.Items.Add(i + ".  " + mang_TenDangNhap[i]);
                i++;
            }
            Cursor = Cursors.Default;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            F_Main_CapQuyen_Them frm = new F_Main_CapQuyen_Them(this);
            frm.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn thực sự muốn xóa '" + mang_TenDangNhap[intSelect] + "' ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                string s = "DELETE FROM Taikhoan WHERE MaID=" + mang_ID[intSelect] + "";
                sql.ExecuteData(s);
                listBox_DanhSach.Items.RemoveAt(intSelect);
                loadListArray();
            }
        }
    }
}