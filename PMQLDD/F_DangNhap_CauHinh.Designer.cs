namespace PMQLDD
{
    partial class F_DangNhap_CauHinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_DangNhap_CauHinh));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxEdit_Server = new DevExpress.XtraEditors.ComboBoxEdit();
            this.servername = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit_Password = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_Username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioGroup_Authentication = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEdit_Database = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_OK = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_LuuLai = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_HuyBo = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Server.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_Authentication.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Database.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.comboBoxEdit_Server);
            this.groupControl1.Controls.Add(this.servername);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(302, 73);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Server Name";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageIndex = 1;
            this.simpleButton1.ImageList = this.imageList1;
            this.simpleButton1.Location = new System.Drawing.Point(264, 28);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(23, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Ribbon_Exit_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Ribbon_Find_16x16.png");
            this.imageList1.Images.SetKeyName(2, "Ribbon_Save_16x16.png");
            this.imageList1.Images.SetKeyName(3, "Tasks_16x16.png");
            // 
            // comboBoxEdit_Server
            // 
            this.comboBoxEdit_Server.Location = new System.Drawing.Point(77, 29);
            this.comboBoxEdit_Server.Name = "comboBoxEdit_Server";
            this.comboBoxEdit_Server.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Server.Size = new System.Drawing.Size(181, 20);
            this.comboBoxEdit_Server.TabIndex = 1;
            // 
            // servername
            // 
            this.servername.Location = new System.Drawing.Point(19, 32);
            this.servername.Name = "servername";
            this.servername.Size = new System.Drawing.Size(32, 13);
            this.servername.TabIndex = 0;
            this.servername.Text = "Server";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.textEdit_Password);
            this.groupControl2.Controls.Add(this.textEdit_Username);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.radioGroup_Authentication);
            this.groupControl2.Location = new System.Drawing.Point(13, 92);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(302, 150);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Authentication";
            // 
            // textEdit_Password
            // 
            this.textEdit_Password.Location = new System.Drawing.Point(76, 116);
            this.textEdit_Password.Name = "textEdit_Password";
            this.textEdit_Password.Size = new System.Drawing.Size(182, 20);
            this.textEdit_Password.TabIndex = 4;
            // 
            // textEdit_Username
            // 
            this.textEdit_Username.Location = new System.Drawing.Point(77, 88);
            this.textEdit_Username.Name = "textEdit_Username";
            this.textEdit_Username.Size = new System.Drawing.Size(181, 20);
            this.textEdit_Username.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(19, 119);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(46, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Password";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 91);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Username";
            // 
            // radioGroup_Authentication
            // 
            this.radioGroup_Authentication.EditValue = "1";
            this.radioGroup_Authentication.Location = new System.Drawing.Point(6, 25);
            this.radioGroup_Authentication.Name = "radioGroup_Authentication";
            this.radioGroup_Authentication.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Window Authentication"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "SQL Server Authentication")});
            this.radioGroup_Authentication.Size = new System.Drawing.Size(291, 57);
            this.radioGroup_Authentication.TabIndex = 0;
            this.radioGroup_Authentication.SelectedIndexChanged += new System.EventHandler(this.radioGroup_Authentication_SelectedIndexChanged);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.simpleButton2);
            this.groupControl3.Controls.Add(this.comboBoxEdit_Database);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Location = new System.Drawing.Point(13, 249);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(302, 70);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Database Name";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageIndex = 1;
            this.simpleButton2.ImageList = this.imageList1;
            this.simpleButton2.Location = new System.Drawing.Point(264, 33);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(23, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // comboBoxEdit_Database
            // 
            this.comboBoxEdit_Database.Location = new System.Drawing.Point(77, 36);
            this.comboBoxEdit_Database.Name = "comboBoxEdit_Database";
            this.comboBoxEdit_Database.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit_Database.Size = new System.Drawing.Size(181, 20);
            this.comboBoxEdit_Database.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(19, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Database";
            // 
            // simpleButton_OK
            // 
            this.simpleButton_OK.ImageIndex = 3;
            this.simpleButton_OK.ImageList = this.imageList1;
            this.simpleButton_OK.Location = new System.Drawing.Point(322, 13);
            this.simpleButton_OK.Name = "simpleButton_OK";
            this.simpleButton_OK.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_OK.TabIndex = 3;
            this.simpleButton_OK.Text = "OK";
            this.simpleButton_OK.Click += new System.EventHandler(this.simpleButton_OK_Click);
            // 
            // simpleButton_LuuLai
            // 
            this.simpleButton_LuuLai.ImageIndex = 2;
            this.simpleButton_LuuLai.ImageList = this.imageList1;
            this.simpleButton_LuuLai.Location = new System.Drawing.Point(322, 63);
            this.simpleButton_LuuLai.Name = "simpleButton_LuuLai";
            this.simpleButton_LuuLai.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_LuuLai.TabIndex = 4;
            this.simpleButton_LuuLai.Text = "Lưu lại";
            this.simpleButton_LuuLai.Click += new System.EventHandler(this.simpleButton_LuuLai_Click);
            // 
            // simpleButton_HuyBo
            // 
            this.simpleButton_HuyBo.ImageIndex = 0;
            this.simpleButton_HuyBo.ImageList = this.imageList1;
            this.simpleButton_HuyBo.Location = new System.Drawing.Point(321, 117);
            this.simpleButton_HuyBo.Name = "simpleButton_HuyBo";
            this.simpleButton_HuyBo.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_HuyBo.TabIndex = 5;
            this.simpleButton_HuyBo.Text = "Hủy bỏ";
            this.simpleButton_HuyBo.Click += new System.EventHandler(this.simpleButton_HuyBo_Click);
            // 
            // F_DangNhap_CauHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 331);
            this.Controls.Add(this.simpleButton_HuyBo);
            this.Controls.Add(this.simpleButton_LuuLai);
            this.Controls.Add(this.simpleButton_OK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "F_DangNhap_CauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu Hình Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_DangNhap_CauHinh_FormClosing);
            this.Load += new System.EventHandler(this.F_DangNhap_CauHinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Server.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_Authentication.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit_Database.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Server;
        private DevExpress.XtraEditors.LabelControl servername;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit textEdit_Password;
        private DevExpress.XtraEditors.TextEdit textEdit_Username;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.RadioGroup radioGroup_Authentication;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit_Database;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton_OK;
        private DevExpress.XtraEditors.SimpleButton simpleButton_LuuLai;
        private DevExpress.XtraEditors.SimpleButton simpleButton_HuyBo;
        private System.Windows.Forms.ImageList imageList1;
    }
}