namespace PMQLDD
{
    partial class F_DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_DangNhap));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit_luu = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit_matKhau = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_tenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.khay_HeThong = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu_HeThong = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dangxuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_luu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_matKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tenDangNhap.Properties)).BeginInit();
            this.menu_HeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkEdit_luu);
            this.groupControl1.Controls.Add(this.textEdit_matKhau);
            this.groupControl1.Controls.Add(this.textEdit_tenDangNhap);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(330, 119);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Đăng Nhập";
            // 
            // checkEdit_luu
            // 
            this.checkEdit_luu.EditValue = true;
            this.checkEdit_luu.Location = new System.Drawing.Point(116, 90);
            this.checkEdit_luu.Name = "checkEdit_luu";
            this.checkEdit_luu.Properties.Caption = "Lưu tên đăng nhập";
            this.checkEdit_luu.Size = new System.Drawing.Size(193, 19);
            this.checkEdit_luu.TabIndex = 2;
            this.checkEdit_luu.CheckedChanged += new System.EventHandler(this.checkEdit_luu_CheckedChanged);
            // 
            // textEdit_matKhau
            // 
            this.textEdit_matKhau.Location = new System.Drawing.Point(116, 64);
            this.textEdit_matKhau.Name = "textEdit_matKhau";
            this.textEdit_matKhau.Properties.PasswordChar = '*';
            this.textEdit_matKhau.Size = new System.Drawing.Size(193, 20);
            this.textEdit_matKhau.TabIndex = 1;
            // 
            // textEdit_tenDangNhap
            // 
            this.textEdit_tenDangNhap.Location = new System.Drawing.Point(116, 29);
            this.textEdit_tenDangNhap.Name = "textEdit_tenDangNhap";
            this.textEdit_tenDangNhap.Size = new System.Drawing.Size(193, 20);
            this.textEdit_tenDangNhap.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageIndex = 2;
            this.simpleButton1.ImageList = this.imageList1;
            this.simpleButton1.Location = new System.Drawing.Point(12, 137);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(92, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Đăng nhập";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Ribbon_Exit_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Ribbon_Find_16x16.png");
            this.imageList1.Images.SetKeyName(2, "Tasks_16x16.png");
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageIndex = 1;
            this.simpleButton2.ImageList = this.imageList1;
            this.simpleButton2.Location = new System.Drawing.Point(130, 137);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(92, 23);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Cấu hình";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageIndex = 0;
            this.simpleButton3.ImageList = this.imageList1;
            this.simpleButton3.Location = new System.Drawing.Point(250, 137);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(92, 23);
            this.simpleButton3.TabIndex = 5;
            this.simpleButton3.Text = "Hủy bỏ";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // khay_HeThong
            // 
            this.khay_HeThong.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.khay_HeThong.BalloonTipText = "Click chuột phải";
            this.khay_HeThong.BalloonTipTitle = "PHẦN MỀM QUẢN LÝ HỒ SƠ ĐẤT ĐAI";
            this.khay_HeThong.ContextMenuStrip = this.menu_HeThong;
            this.khay_HeThong.Icon = ((System.Drawing.Icon)(resources.GetObject("khay_HeThong.Icon")));
            this.khay_HeThong.Text = "PHẦN MỀM QUẢN LÝ HỒ SƠ ĐẤT ĐAI";
            // 
            // menu_HeThong
            // 
            this.menu_HeThong.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dangxuatToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.menu_HeThong.Name = "menu_HeThong";
            this.menu_HeThong.Size = new System.Drawing.Size(130, 48);
            // 
            // dangxuatToolStripMenuItem
            // 
            this.dangxuatToolStripMenuItem.Image = global::PMQLDD.Properties.Resources.customer_login;
            this.dangxuatToolStripMenuItem.Name = "dangxuatToolStripMenuItem";
            this.dangxuatToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.dangxuatToolStripMenuItem.Text = "Đăng Xuất";
            this.dangxuatToolStripMenuItem.Click += new System.EventHandler(this.dangxuatToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::PMQLDD.Properties.Resources.Ribbon_Exit_16x16;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // F_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 172);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "F_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_DangNhap_FormClosing);
            this.Load += new System.EventHandler(this.F_DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_luu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_matKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_tenDangNhap.Properties)).EndInit();
            this.menu_HeThong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit textEdit_matKhau;
        private DevExpress.XtraEditors.TextEdit textEdit_tenDangNhap;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.CheckEdit checkEdit_luu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.NotifyIcon khay_HeThong;
        private System.Windows.Forms.ContextMenuStrip menu_HeThong;
        private System.Windows.Forms.ToolStripMenuItem dangxuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;

    }
}

