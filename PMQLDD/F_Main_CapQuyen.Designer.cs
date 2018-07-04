namespace PMQLDD
{
    partial class F_Main_CapQuyen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main_CapQuyen));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup_capQuyen = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.listBox_DanhSach = new DevExpress.XtraEditors.ListBoxControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton_Xoa = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_capQuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_DanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.radioGroup_capQuyen);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.listBox_DanhSach);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(399, 221);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách tài khoản";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Location = new System.Drawing.Point(204, 72);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(90, 19);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "labelControl5";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(145, 76);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Họ Tên :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(239, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Quyền :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(145, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Tài khoản : ";
            // 
            // radioGroup_capQuyen
            // 
            this.radioGroup_capQuyen.EditValue = "0";
            this.radioGroup_capQuyen.Location = new System.Drawing.Point(145, 122);
            this.radioGroup_capQuyen.Name = "radioGroup_capQuyen";
            this.radioGroup_capQuyen.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Quản trị hệ thống"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Thao tác dữ liệu"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Tra cứu thông tin")});
            this.radioGroup_capQuyen.Size = new System.Drawing.Size(249, 94);
            this.radioGroup_capQuyen.TabIndex = 2;
            this.radioGroup_capQuyen.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(204, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "labelControl1";
            // 
            // listBox_DanhSach
            // 
            this.listBox_DanhSach.Location = new System.Drawing.Point(6, 25);
            this.listBox_DanhSach.Name = "listBox_DanhSach";
            this.listBox_DanhSach.Size = new System.Drawing.Size(133, 191);
            this.listBox_DanhSach.TabIndex = 0;
            this.listBox_DanhSach.SelectedIndexChanged += new System.EventHandler(this.listBox_DanhSach_SelectedIndexChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageIndex = 1;
            this.simpleButton1.ImageList = this.imageCollection1;
            this.simpleButton1.Location = new System.Drawing.Point(19, 240);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Thêm";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Ribbon_Exit_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "Tasks_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "Trash_16x16.png");
            // 
            // simpleButton_Xoa
            // 
            this.simpleButton_Xoa.ImageIndex = 2;
            this.simpleButton_Xoa.ImageList = this.imageCollection1;
            this.simpleButton_Xoa.Location = new System.Drawing.Point(176, 240);
            this.simpleButton_Xoa.Name = "simpleButton_Xoa";
            this.simpleButton_Xoa.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Xoa.TabIndex = 2;
            this.simpleButton_Xoa.Text = "Xóa";
            this.simpleButton_Xoa.Click += new System.EventHandler(this.simpleButton_Xoa_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.ImageIndex = 0;
            this.simpleButton3.ImageList = this.imageCollection1;
            this.simpleButton3.Location = new System.Drawing.Point(332, 240);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Đóng";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // F_Main_CapQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 272);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton_Xoa);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Main_CapQuyen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấp quyền tài khoản";
            this.Load += new System.EventHandler(this.F_Main_CapQuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_capQuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listBox_DanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ListBoxControl listBox_DanhSach;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Xoa;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.RadioGroup radioGroup_capQuyen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.Utils.ImageCollection imageCollection1;

    }
}