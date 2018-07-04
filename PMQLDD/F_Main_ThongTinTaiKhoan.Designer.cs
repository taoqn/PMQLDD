namespace PMQLDD
{
    partial class F_Main_ThongTinTaiKhoan
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label_NgayTao = new DevExpress.XtraEditors.LabelControl();
            this.label_NSinh = new DevExpress.XtraEditors.LabelControl();
            this.label_Work = new DevExpress.XtraEditors.LabelControl();
            this.label_Location = new DevExpress.XtraEditors.LabelControl();
            this.label_Gender = new DevExpress.XtraEditors.LabelControl();
            this.label_Name = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.ContentImage = global::PMQLDD.Properties.Resources.id_card_template_aeuzgoqp;
            this.groupControl1.Controls.Add(this.label_NgayTao);
            this.groupControl1.Controls.Add(this.label_NSinh);
            this.groupControl1.Controls.Add(this.label_Work);
            this.groupControl1.Controls.Add(this.label_Location);
            this.groupControl1.Controls.Add(this.label_Gender);
            this.groupControl1.Controls.Add(this.label_Name);
            this.groupControl1.Location = new System.Drawing.Point(1, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(405, 285);
            this.groupControl1.TabIndex = 0;
            // 
            // label_NgayTao
            // 
            this.label_NgayTao.Location = new System.Drawing.Point(112, 189);
            this.label_NgayTao.Name = "label_NgayTao";
            this.label_NgayTao.Size = new System.Drawing.Size(63, 13);
            this.label_NgayTao.TabIndex = 6;
            this.label_NgayTao.Text = "labelControl7";
            // 
            // label_NSinh
            // 
            this.label_NSinh.Location = new System.Drawing.Point(112, 170);
            this.label_NSinh.Name = "label_NSinh";
            this.label_NSinh.Size = new System.Drawing.Size(63, 13);
            this.label_NSinh.TabIndex = 4;
            this.label_NSinh.Text = "labelControl5";
            // 
            // label_Work
            // 
            this.label_Work.Location = new System.Drawing.Point(112, 151);
            this.label_Work.Name = "label_Work";
            this.label_Work.Size = new System.Drawing.Size(63, 13);
            this.label_Work.TabIndex = 3;
            this.label_Work.Text = "labelControl4";
            // 
            // label_Location
            // 
            this.label_Location.Location = new System.Drawing.Point(112, 132);
            this.label_Location.Name = "label_Location";
            this.label_Location.Size = new System.Drawing.Size(63, 13);
            this.label_Location.TabIndex = 2;
            this.label_Location.Text = "labelControl3";
            // 
            // label_Gender
            // 
            this.label_Gender.Location = new System.Drawing.Point(112, 112);
            this.label_Gender.Name = "label_Gender";
            this.label_Gender.Size = new System.Drawing.Size(63, 13);
            this.label_Gender.TabIndex = 1;
            this.label_Gender.Text = "labelControl2";
            // 
            // label_Name
            // 
            this.label_Name.Location = new System.Drawing.Point(112, 93);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(63, 13);
            this.label_Name.TabIndex = 0;
            this.label_Name.Text = "labelControl1";
            // 
            // F_Main_ThongTinTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 283);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Main_ThongTinTaiKhoan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Tài Khoản";
            this.Load += new System.EventHandler(this.F_Main_ThongTinTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl label_Gender;
        private DevExpress.XtraEditors.LabelControl label_Name;
        private DevExpress.XtraEditors.LabelControl label_Work;
        private DevExpress.XtraEditors.LabelControl label_Location;
        private DevExpress.XtraEditors.LabelControl label_NgayTao;
        private DevExpress.XtraEditors.LabelControl label_NSinh;
    }
}