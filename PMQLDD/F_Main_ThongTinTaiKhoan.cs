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
    public partial class F_Main_ThongTinTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        public F_Main_ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void F_Main_ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            NguoiDung ng = (NguoiDung)F_DangNhap.person_object;

            label_Name.Text = ng.HoTen;
            if (ng.GioiTinh)
                label_Gender.Text = "Nam";
            else
                label_Gender.Text = "Nữ";
            label_Location.Text = ng.QueQuan;

            if (ng.Cap == 0) 
            {
                label_Work.Text = "Quản trị hệ thống";
            }
            if (ng.Cap == 1)
            {
                label_Work.Text = "Thao tác dữ liệu";
            }
            if (ng.Cap == 2)
            {
                label_Work.Text = "Tra cứu thông tin";
            }
            label_NSinh.Text = ng.NgaySinh;
            //label_QueQuan.Text = ng.QueQuan;
            label_NgayTao.Text = ng.NgayTao;
        }
    }
}