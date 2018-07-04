using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace PMQLDD
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private XtraReport xtra;

        private SQLConnect sql;
        private NguoiDung nguoi;

        private DataTable table_Columns, table_In;
        private DataColumn c0, c1, c2, c3;

        private float[] doRong = new float[1000];
        private int[] xuatHien = new int[1000];

        public XtraForm1(string tieuDe, DataTable dt)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            InitializeComponent();

            table_In = dt;
            xtra = new XtraReport();

            dateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            dateEdit1.Properties.EditMask = "dd/MM/yyyy";
            dateEdit1.EditValue = DateTime.Now;

            textEdit_TieuDe.Text = tieuDe;
            textEdit_KyTen.Text = "Đinh Công Nghĩa";

            xtra.xrLabel_TieuDe.Text = tieuDe;
            xtra.xrLabel_NgayThang.Text = "Bình Định, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " ";

            Cursor = Cursors.Default;
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            
            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl Columns

            table_Columns = new DataTable();

            c0 = new DataColumn();
            c0.DataType = System.Type.GetType("System.Int32");
            c0.ColumnName = "STT";
            table_Columns.Columns.Add(c0);

            c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.String");
            c1.ColumnName = "Tên cột";
            table_Columns.Columns.Add(c1);

            c2 = new DataColumn();
            c2.DataType = System.Type.GetType("System.Double");
            c2.ColumnName = "Độ rộng";
            table_Columns.Columns.Add(c2);

            c3 = new DataColumn();
            c3.DataType = System.Type.GetType("System.Int32");
            c3.ColumnName = "Hiện";
            table_Columns.Columns.Add(c3);

            gridControl1.DataSource = table_Columns;

            RepositoryItemTrackBar trackBaritem = new RepositoryItemTrackBar();
            trackBaritem.Minimum = 10;
            trackBaritem.Maximum = 500;
            gridView1.Columns[2].ColumnEdit = trackBaritem;

            RepositoryItemCheckEdit checkEdititem = new RepositoryItemCheckEdit();
            checkEdititem.ValueChecked = 1;
            checkEdititem.ValueUnchecked = 0;
            gridView1.Columns[3].ColumnEdit = checkEdititem;

            gridView1.Columns[0].Width = 20;
            gridView1.Columns[1].Width = 100;
            gridView1.Columns[2].Width = 200;
            gridView1.Columns[3].Width = 50;

            gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            gridView1.Columns[1].OptionsColumn.AllowEdit = false;

            this.InsertDataTable(table_In, false);

            trackBarControl_DoRong.Properties.Minimum = 30;
            trackBarControl_DoRong.Properties.Maximum = 1000;
            trackBarControl_DoRong.EditValue = xtra.xrTable1.WidthF;

            trackBarControl_ViTri_X.Properties.Minimum = 0;
            trackBarControl_ViTri_X.Properties.Maximum = 300;
            trackBarControl_ViTri_X.EditValue = xtra.xrTable1.LocationF.X;

            this.documentViewer1.PrintingSystem = xtra.PrintingSystem;
            xtra.CreateDocument();

            Cursor = Cursors.Default;
        }

        private void SetThuocTinh()
        {
            int i = 0;
            foreach (DataRow row in table_Columns.Rows)
            {
                int j = 0;
                foreach (DataColumn column in table_Columns.Columns)
                {
                    if (j == 2)
                        doRong[i] = float.Parse(row[column].ToString());
                    if (j == 3)
                        xuatHien[i] = int.Parse(row[column].ToString());
                    j++;
                }
                i++;
            }
        }

        private void InsertDataTable(DataTable dt, bool dk)
        {
            xtra.xrTableRow1.Cells.Clear();
            xtra.xrTable1.Rows.Clear();
            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (j == 0)
                {
                    DevExpress.XtraReports.UI.XRTableRow row_new1 = new DevExpress.XtraReports.UI.XRTableRow();
                    row_new1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) | DevExpress.XtraPrinting.BorderSide.Right) | DevExpress.XtraPrinting.BorderSide.Bottom)));
                    row_new1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    row_new1.StylePriority.UseBorders = false;
                    row_new1.StylePriority.UseFont = false;
                    row_new1.Weight = 1D;

                    table_Columns.BeginLoadData();
                    int i = 0, n = 0;
                    while(i < dt.Columns.Count)
                    {
                        if (!dk)
                        {
                            doRong[i] = 150;
                            xuatHien[i] = 1;
                            DataRow rowTable = table_Columns.NewRow();
                            rowTable[0] = i + 1;
                            rowTable[1] = dt.Columns[i].ColumnName.ToString();
                            rowTable[2] = doRong[i];
                            rowTable[3] = xuatHien[i];
                            table_Columns.Rows.Add(rowTable);
                        }

                        if (xuatHien[i] == 1)
                        {
                            DevExpress.XtraReports.UI.XRTableCell column = new DevExpress.XtraReports.UI.XRTableCell();
                            column.Text = dt.Columns[i].ColumnName.ToString();
                            row_new1.Cells.Add(column);
                            row_new1.Cells[n].WidthF = doRong[i];
                            n++;
                        }
                        i++;
                    }
                    table_Columns.EndLoadData();
                    xtra.xrTable1.Rows.Add(row_new1);
                }

                int k = 0, m = 0;
                DevExpress.XtraReports.UI.XRTableRow row_new = new DevExpress.XtraReports.UI.XRTableRow();
                row_new.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) | DevExpress.XtraPrinting.BorderSide.Right) | DevExpress.XtraPrinting.BorderSide.Bottom)));
                row_new.StylePriority.UseBorders = false;
                row_new.StylePriority.UseFont = false;
                row_new.Weight = 1D;

                foreach (DataColumn column in dt.Columns)
                {
                    if (xuatHien[k] == 1)
                    {
                        DevExpress.XtraReports.UI.XRTableCell column_new = new DevExpress.XtraReports.UI.XRTableCell();
                        column_new.Text = row[column].ToString();
                        row_new.Cells.Add(column_new);
                        row_new.Cells[m].WidthF = doRong[k];
                        m++;
                    }
                    k++;
                }

                xtra.xrTable1.Rows.Add(row_new);
                j++;
            }
        }

        private void simpleButton_Preview_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            xtra.xrTable1.WidthF = trackBarControl_DoRong.Value;
            xtra.xrTable1.LocationF = new PointF(float.Parse(trackBarControl_ViTri_X.Value + ""), 10);

            xtra.xrLabel_NgayThang.Text = "Bình Định, ngày " + dateEdit1.DateTime.Day + " tháng " + dateEdit1.DateTime.Month + " năm " + dateEdit1.DateTime.Year + " ";
            xtra.xrLabel_TieuDe.Text = textEdit_TieuDe.Text.ToString();
            xtra.xrLabel_KT.Text = textEdit_KyTen.Text.ToString();
            this.SetThuocTinh();
            this.InsertDataTable(table_In, true);
            this.documentViewer1.PrintingSystem = xtra.PrintingSystem;
            xtra.CreateDocument();

            Cursor = Cursors.Default;
        }
    }
}