using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;

namespace PMQLDD
{
    public partial class F_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private F_DangNhap formDN;
        private SQLConnect sql;
        private NguoiDung nguoi;

        private F_Main_TenToChuc formTenToChuc;
        private F_Main_SoQuyetDinh formTenDuAn;
        private F_Main_DSachDiaDiem formDSachDiaDiem;
        private F_Main_QuyetDinh formQuyetDinh;
        private F_Main_NguonGocDat formNguonGocDat;
        private F_Main_MucDichSuDungDat formMucDichSuDungDat;
        private F_Main_ThoiHanSuDung formThoiHanSuDung;
        private F_Main_HinhThucSuDung formHinhThucSuDung;
        private F_Main_TinhTrangPL formTinhtrangPL;

        private F_Main_DMToChuc formDMToChuc;
        private F_Main_DMLoaiDat formDMLoaiDat;
        private F_Main_DMHuyen formDMHuyen;
        private F_Main_DMHinhThucSuDung formDMHinhThucSuDung;

        public F_Main(F_DangNhap frm)
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
            this.formDN = frm;
        }

        private void F_Main_Load(object sender, EventArgs e)
        {
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            barButtonItem2.Caption = "Thông tin kết nối : Tên Server \"" + sql.getConn().DataSource + "\" ; Cơ sở dữ liệu \"" + sql.getConn().Database + "\"   ||   Tài khoản đang đăng nhập : " + nguoi.TenDangNhap;

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();

            switch (nguoi.Cap)
            {
                case 0:
                    break;
                case 1:
                    this.barButtonItem_CapQuyen.Enabled = false;
                    break;
                case 2:
                    this.barButtonItem_CapQuyen.Enabled = false;
                    this.barButtonItem_tiepNhan.Enabled = false;
                    this.barButtonItem_ThemToChuc.Enabled = false;
                    this.barButtonItem_ThemDuAn.Enabled = false;
                    break;
            }

        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            barButtonItem3.Caption = "  Ngày:  " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "  , Thời gian hiện tại:  " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " ";
        }

        private void barButtonItemThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void F_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult re = DialogResult.No;
            re = DevExpress.XtraEditors.XtraMessageBox.Show("Đóng chương trình thì tài khoản '" + nguoi.TenDangNhap + "' của bạn sẽ đăng xuất khỏi hể thống ?", "Cảnh Báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                this.formDN.Show();
                this.formDN.ketThucDangNhap();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void barButtonItem_ThongTin_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_ThongTinTaiKhoan frm = new F_Main_ThongTinTaiKhoan();
            frm.Show();
        }

        private void barButtonItem_ThayDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_ThayDoiMatKhau frm = new F_Main_ThayDoiMatKhau();
            frm.Show();
        }

        private void barButtonItem_CapQuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_CapQuyen frm = new F_Main_CapQuyen();
            frm.Show();
        }

        private void barButtonItem_MayIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintDialog pr = new PrintDialog();
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.DocumentName = "doc.txt";
            pr.UseEXDialog = false;
            pr.Document = printDocument1;
            pr.ShowDialog();
        }

        private void barButtonItem_NhatKy_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            F_Main_NhatKyDangNhap frm = new F_Main_NhatKyDangNhap();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem_tiepNhan_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_TiepNhanHoSo frm = new F_Main_TiepNhanHoSo();
            frm.Show();
        }

        private void barButtonItem_ThemToChuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_ThemToChuc frm = new F_Main_ThemToChuc();
            frm.Show();
        }

        private void barButtonItem_ThemDuAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            F_Main_ThemDuAn frm = new F_Main_ThemDuAn();
            frm.Show();
        }

        private void barButtonItem_ToChuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formTenToChuc == null)
            {
                formTenToChuc = new F_Main_TenToChuc();
                formTenToChuc.MdiParent = this;
                formTenToChuc.FormClosed += new FormClosedEventHandler(formTenToChuc_FormClosed);
                formTenToChuc.Show();
            }
            else
                formTenToChuc.Activate();
        }

        private void formTenToChuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTenToChuc = null;
        }

        private void barButtonItem_DuAn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formTenDuAn == null)
            {
                formTenDuAn = new F_Main_SoQuyetDinh();
                formTenDuAn.MdiParent = this;
                formTenDuAn.FormClosed += new FormClosedEventHandler(formTenDuAn_FormClosed);
                formTenDuAn.Show();
            }
            else
                formTenDuAn.Activate();
        }

        private void formTenDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTenDuAn = null;
        }

        private void barButtonItem_DiaDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formDSachDiaDiem == null)
            {
                formDSachDiaDiem = new F_Main_DSachDiaDiem();
                formDSachDiaDiem.MdiParent = this;
                formDSachDiaDiem.FormClosed += new FormClosedEventHandler(formDSachDiaDiem_FormClosed);
                formDSachDiaDiem.Show();
            }
            else
                formDSachDiaDiem.Activate();
        }

        void formDSachDiaDiem_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDSachDiaDiem = null;
        }

        private void barButtonItem_QuyetDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formQuyetDinh == null)
            {
                formQuyetDinh = new F_Main_QuyetDinh();
                formQuyetDinh.MdiParent = this;
                formQuyetDinh.FormClosed += new FormClosedEventHandler(formQuyetDinh_FormClosed);
                formQuyetDinh.Show();
            }
            else
                formQuyetDinh.Activate();
        }

        void formQuyetDinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            formQuyetDinh = null;
        }

        private void barButtonItem_LDTruocGiao_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formNguonGocDat == null)
            {
                formNguonGocDat = new F_Main_NguonGocDat();
                formNguonGocDat.MdiParent = this;
                formNguonGocDat.FormClosed += new FormClosedEventHandler(formNguonGocDat_FormClosed);
                formNguonGocDat.Show();
            }
            else
                formNguonGocDat.Activate();
        }

        void formNguonGocDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            formNguonGocDat = null;
        }

        private void barButtonItem_LDSauGiao_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formMucDichSuDungDat == null)
            {
                formMucDichSuDungDat = new F_Main_MucDichSuDungDat();
                formMucDichSuDungDat.MdiParent = this;
                formMucDichSuDungDat.FormClosed += new FormClosedEventHandler(formMucDichSuDungDat_FormClosed);
                formMucDichSuDungDat.Show();
            }
            else
                formMucDichSuDungDat.Activate();
        }

        void formMucDichSuDungDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            formMucDichSuDungDat = null;
        }

        private void barButtonItem_ThoiHan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formThoiHanSuDung == null)
            {
                formThoiHanSuDung = new F_Main_ThoiHanSuDung();
                formThoiHanSuDung.MdiParent = this;
                formThoiHanSuDung.FormClosed += new FormClosedEventHandler(formThoiHanSuDung_FormClosed);
                formThoiHanSuDung.Show();
            }
            else
                formThoiHanSuDung.Activate();
        }

        void formThoiHanSuDung_FormClosed(object sender, FormClosedEventArgs e)
        {
            formThoiHanSuDung = null;
        }

        private void barButtonItem_HinhThuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formHinhThucSuDung == null)
            {
                formHinhThucSuDung = new F_Main_HinhThucSuDung();
                formHinhThucSuDung.MdiParent = this;
                formHinhThucSuDung.FormClosed += new FormClosedEventHandler(formHinhThucSuDung_FormClosed);
                formHinhThucSuDung.Show();
            }
            else
                formHinhThucSuDung.Activate();
        }

        void formHinhThucSuDung_FormClosed(object sender, FormClosedEventArgs e)
        {
            formHinhThucSuDung = null;
        }

        private void barButtonItem_TinhTrang_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formTinhtrangPL == null)
            {
                formTinhtrangPL = new F_Main_TinhTrangPL();
                formTinhtrangPL.MdiParent = this;
                formTinhtrangPL.FormClosed += new FormClosedEventHandler(formTinhtrangPL_FormClosed);
                formTinhtrangPL.Show();
            }
            else
                formTinhtrangPL.Activate();
        }

        void formTinhtrangPL_FormClosed(object sender, FormClosedEventArgs e)
        {
            formTinhtrangPL = null;
        }

        private void barButtonItem_DmTochuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formDMToChuc == null)
            {
                formDMToChuc = new F_Main_DMToChuc();
                formDMToChuc.MdiParent = this;
                formDMToChuc.FormClosed += new FormClosedEventHandler(formDMToChuc_FormClosed);
                formDMToChuc.Show();
            }
            else
                formDMToChuc.Activate();
        }

        void formDMToChuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDMToChuc = null;
        }

        private void barButtonItem_DMLoaiDat_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formDMLoaiDat == null)
            {
                formDMLoaiDat = new F_Main_DMLoaiDat();
                formDMLoaiDat.MdiParent = this;
                formDMLoaiDat.FormClosed += new FormClosedEventHandler(formDMLoaiDat_FormClosed);
                formDMLoaiDat.Show();
            }
            else
                formDMLoaiDat.Activate();
        }

        void formDMLoaiDat_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDMLoaiDat = null;
        }

        private void barButtonItem_DMHuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formDMHuyen == null)
            {
                formDMHuyen = new F_Main_DMHuyen();
                formDMHuyen.MdiParent = this;
                formDMHuyen.FormClosed += new FormClosedEventHandler(formDMHuyen_FormClosed);
                formDMHuyen.Show();
            }
            else
                formDMHuyen.Activate();
        }

        void formDMHuyen_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDMHuyen = null;
        }

        private void barButtonItem_DmHinhThuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (formDMHinhThucSuDung == null)
            {
                formDMHinhThucSuDung = new F_Main_DMHinhThucSuDung();
                formDMHinhThucSuDung.MdiParent = this;
                formDMHinhThucSuDung.FormClosed += new FormClosedEventHandler(formDMHinhThucSuDung_FormClosed);
                formDMHinhThucSuDung.Show();
            }
            else
                formDMHinhThucSuDung.Activate();
        }

        void formDMHinhThucSuDung_FormClosed(object sender, FormClosedEventArgs e)
        {
            formDMHinhThucSuDung = null;
        }

        private void barButtonItem_TroGiup_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

    }
}