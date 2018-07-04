namespace PMQLDD
{
    partial class F_Main_ThoiHanSuDung
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton_Expired = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_SelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_Select = new DevExpress.XtraEditors.SimpleButton();
            this.spinEdit_soThang = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spinEdit_soNam = new DevExpress.XtraEditors.SpinEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolStripMenuItem_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Excel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_soThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_soNam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkEdit1);
            this.groupControl1.Controls.Add(this.simpleButton_Expired);
            this.groupControl1.Controls.Add(this.simpleButton_SelectAll);
            this.groupControl1.Controls.Add(this.simpleButton_Select);
            this.groupControl1.Controls.Add(this.spinEdit_soThang);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.spinEdit_soNam);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1008, 66);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Lựa chọn";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(762, 32);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Chỉ hiển thị doanh nghiệp thuê đất";
            this.checkEdit1.Size = new System.Drawing.Size(202, 19);
            this.checkEdit1.TabIndex = 7;
            // 
            // simpleButton_Expired
            // 
            this.simpleButton_Expired.Location = new System.Drawing.Point(565, 28);
            this.simpleButton_Expired.Name = "simpleButton_Expired";
            this.simpleButton_Expired.Size = new System.Drawing.Size(173, 23);
            this.simpleButton_Expired.TabIndex = 6;
            this.simpleButton_Expired.Text = "Hiển thị danh sách hết hạn";
            this.simpleButton_Expired.Click += new System.EventHandler(this.simpleButton_Expired_Click);
            // 
            // simpleButton_SelectAll
            // 
            this.simpleButton_SelectAll.Location = new System.Drawing.Point(424, 28);
            this.simpleButton_SelectAll.Name = "simpleButton_SelectAll";
            this.simpleButton_SelectAll.Size = new System.Drawing.Size(117, 23);
            this.simpleButton_SelectAll.TabIndex = 5;
            this.simpleButton_SelectAll.Text = "Hiển thị tất cả";
            this.simpleButton_SelectAll.Click += new System.EventHandler(this.simpleButton_SelectAll_Click);
            // 
            // simpleButton_Select
            // 
            this.simpleButton_Select.Location = new System.Drawing.Point(330, 28);
            this.simpleButton_Select.Name = "simpleButton_Select";
            this.simpleButton_Select.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_Select.TabIndex = 4;
            this.simpleButton_Select.Text = "Chọn";
            this.simpleButton_Select.Click += new System.EventHandler(this.simpleButton_Select_Click);
            // 
            // spinEdit_soThang
            // 
            this.spinEdit_soThang.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_soThang.Location = new System.Drawing.Point(257, 31);
            this.spinEdit_soThang.Name = "spinEdit_soThang";
            this.spinEdit_soThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_soThang.Properties.Mask.EditMask = "d";
            this.spinEdit_soThang.Size = new System.Drawing.Size(48, 20);
            this.spinEdit_soThang.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(168, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Số tháng còn lại :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Số năm còn lại :";
            // 
            // spinEdit_soNam
            // 
            this.spinEdit_soNam.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_soNam.Location = new System.Drawing.Point(93, 31);
            this.spinEdit_soNam.Name = "spinEdit_soNam";
            this.spinEdit_soNam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit_soNam.Properties.Mask.EditMask = "d";
            this.spinEdit_soNam.Size = new System.Drawing.Size(49, 20);
            this.spinEdit_soNam.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 66);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1008, 355);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Danh sách dự án";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 21);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1004, 332);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Select,
            this.toolStripMenuItem_Print,
            this.toolStripMenuItem_Excel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 92);
            // 
            // toolStripMenuItem_Select
            // 
            this.toolStripMenuItem_Select.Name = "toolStripMenuItem_Select";
            this.toolStripMenuItem_Select.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_Select.Text = "Xem thông tin dự án";
            this.toolStripMenuItem_Select.Click += new System.EventHandler(this.toolStripMenuItem_Select_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // toolStripMenuItem_Print
            // 
            this.toolStripMenuItem_Print.Name = "toolStripMenuItem_Print";
            this.toolStripMenuItem_Print.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_Print.Text = "In";
            this.toolStripMenuItem_Print.Click += new System.EventHandler(this.toolStripMenuItem_Print_Click);
            // 
            // toolStripMenuItem_Excel
            // 
            this.toolStripMenuItem_Excel.Name = "toolStripMenuItem_Excel";
            this.toolStripMenuItem_Excel.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem_Excel.Text = "Xuất ra Excel";
            this.toolStripMenuItem_Excel.Click += new System.EventHandler(this.toolStripMenuItem_Excel_Click);
            // 
            // F_Main_ThoiHanSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 421);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "F_Main_ThoiHanSuDung";
            this.Text = "Thời hạn sử dụng đất";
            this.Load += new System.EventHandler(this.F_Main_ThoiHanSuDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_soThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_soNam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SpinEdit spinEdit_soNam;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spinEdit_soThang;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_SelectAll;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Select;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_Expired;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Select;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Print;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Excel;
    }
}