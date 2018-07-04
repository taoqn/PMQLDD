using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMQLDD
{
    class NguoiDung
    {
        private string maID;
        private string tenDangNhap;
        private string matKhau;
        private string hoTen;
        private string ngaySinh;
        private string queQuan;
        private bool gioiTinh;
        private int cap;
        private string ngayTao;

        public NguoiDung(string maID, string tenDangNhap, string matKhau, string hoTen, string ngaySinh, string queQuan, string gioiTinh, int cap, string ngayTao)
        {
            this.maID = maID;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.queQuan = queQuan;
            if (gioiTinh.Equals("Nam"))
                this.gioiTinh = true;
            else
                this.gioiTinh = false;
            this.cap = cap;
            this.ngayTao = ngayTao;

        }

        public string MaID
        {
            get { return maID; }
            set { maID = value; }
        }

        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        public string MatKhau
        {
            get { return matKhau; }
            set { matKhau = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        public bool GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public int Cap
        {
            get { return cap; }
            set { cap = value; }
        }

        public string NgayTao
        {
            get { return ngayTao; }
            set { ngayTao = value; }
        }
    }
}
