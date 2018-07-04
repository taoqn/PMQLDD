using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PMQLDD
{
    public partial class F_Main_ThoiHanSuDung : DevExpress.XtraEditors.XtraForm
    {
        private SQLConnect sql;
        private NguoiDung nguoi;
        private SqlConnection conn;

        private F_XemDuAn formXemDuAn;

        private DataTable table_DSDuAn;
        private DataColumn c0, c1, c2, c3, c4, c6, c7, c8, c9, c10, c11;

        private XtraForm1 formIn;

        public F_Main_ThoiHanSuDung()
        {
            InitializeComponent();

            spinEdit_soNam.Properties.Mask.EditMask = "d";
            spinEdit_soThang.Properties.Mask.EditMask = "d";

            spinEdit_soNam.Properties.MinValue = 0;
            spinEdit_soNam.Properties.MaxValue = 50;
            spinEdit_soThang.Properties.MinValue = 0;
            spinEdit_soThang.Properties.MaxValue = 12;

            spinEdit_soNam.Value = 50;
            spinEdit_soThang.Value = 0;
        }

        private void F_Main_ThoiHanSuDung_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            sql = F_DangNhap.SQL_con_object as SQLConnect;
            nguoi = F_DangNhap.person_object as NguoiDung;

            //GridControl2 DSDuAn

            table_DSDuAn = new DataTable();

            c0 = new DataColumn();
            c0.DataType = System.Type.GetType("System.Int32");
            c0.ColumnName = "STT";
            table_DSDuAn.Columns.Add(c0);

            c1 = new DataColumn();
            c1.DataType = System.Type.GetType("System.String");
            c1.ColumnName = "Tên dự án";
            table_DSDuAn.Columns.Add(c1);

            c2 = new DataColumn();
            c2.DataType = System.Type.GetType("System.String");
            c2.ColumnName = "Ngày giao";
            table_DSDuAn.Columns.Add(c2);

            c3 = new DataColumn();
            c3.DataType = System.Type.GetType("System.String");
            c3.ColumnName = "Hết hạn";
            table_DSDuAn.Columns.Add(c3);

            c4 = new DataColumn();
            c4.DataType = System.Type.GetType("System.String");
            c4.ColumnName = "Còn lại";
            table_DSDuAn.Columns.Add(c4);

            //c5 = new DataColumn();
            //c5.DataType = System.Type.GetType("System.String");
            //c5.ColumnName = "Số tháng còn lại khoảng";
            //table_DSDuAn.Columns.Add(c5);

            c6 = new DataColumn();
            c6.DataType = System.Type.GetType("System.String");
            c6.ColumnName = "Địa điểm";
            table_DSDuAn.Columns.Add(c6);

            c7 = new DataColumn();
            c7.DataType = System.Type.GetType("System.String");
            c7.ColumnName = "Mã huyện";
            table_DSDuAn.Columns.Add(c7);

            c8 = new DataColumn();
            c8.DataType = System.Type.GetType("System.String");
            c8.ColumnName = "Số quyết định";
            table_DSDuAn.Columns.Add(c8);

            c9 = new DataColumn();
            c9.DataType = System.Type.GetType("System.String");
            c9.ColumnName = "Ngày quyết định";
            table_DSDuAn.Columns.Add(c9);

            c10 = new DataColumn();
            c10.DataType = System.Type.GetType("System.String");
            c10.ColumnName = "Hình thức sử dụng";
            table_DSDuAn.Columns.Add(c10);

            c11 = new DataColumn();
            c11.DataType = System.Type.GetType("System.String");
            c11.ColumnName = "Tình trạng pháp lý";
            table_DSDuAn.Columns.Add(c11);

            gridControl1.Width = int.MaxValue;
            gridControl1.DataSource = table_DSDuAn;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            gridView1.Columns[0].Width = 25;
            gridView1.Columns[1].Width = 350;
            gridView1.Columns[2].Width = 90;
            gridView1.Columns[3].Width = 90;
            gridView1.Columns[4].Width = 120;
            //gridView1.Columns[5].Width = 150;
            gridView1.Columns[5].Width = 250;
            gridView1.Columns[6].Width = 110;
            gridView1.Columns[7].Width = 90;
            gridView1.Columns[8].Width = 90;
            gridView1.Columns[9].Width = 370;
            gridView1.Columns[10].Width = 200;


            this.ShowAllData(-1);

            Cursor = Cursors.Default;
        }

        private void ShowAllData(double nam_thang)
        {
            DataColumn[] column = { c0, c1, c2, c3, c4, c6, c7, c8, c9, c10, c11 };

            string cmd = "";

            if(!checkEdit1.Checked)
                cmd = "SELECT ROW_NUMBER() OVER(ORDER BY TenDuan asc) AS Row#,TenDuan,CONVERT(NVARCHAR, Ngaygiao, 103) as Ngaygiao,CONVERT(NVARCHAR, Thoihan, 103) as Thoihan,(DATEPART(YY,Thoihan - GETDATE()) - 1900) as soNam,DATEPART(MONTH,Thoihan - GETDATE()) as soThang,Diadiem,DMDvhc.TenDvhc ,SoQD,CONVERT(NVARCHAR, NgayQD, 103) as NgayQD,DMHinhthucsudung.TenHinhthuc,TinhtrangPL FROM Giaodat,DMHinhthucsudung,DMDvhc WHERE Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc";
            else
                cmd = "SELECT ROW_NUMBER() OVER(ORDER BY TenDuan asc) AS Row#,TenDuan,CONVERT(NVARCHAR, Ngaygiao, 103) as Ngaygiao,CONVERT(NVARCHAR, Thoihan, 103) as Thoihan,(DATEPART(YY,Thoihan - GETDATE()) - 1900) as soNam,DATEPART(MONTH,Thoihan - GETDATE()) as soThang,Diadiem,DMDvhc.TenDvhc ,SoQD,CONVERT(NVARCHAR, NgayQD, 103) as NgayQD,DMHinhthucsudung.TenHinhthuc,TinhtrangPL FROM Giaodat,DMHinhthucsudung,DMDvhc WHERE (DMHinhthucsudung.MaHinhthuc = 'DT-KCN-THN' or DMHinhthucsudung.MaHinhthuc = 'DT-KCN-TML' or DMHinhthucsudung.MaHinhthuc = 'DT-THN' or DMHinhthucsudung.MaHinhthuc = 'DT-TML') and Giaodat.MaDvhc = DMDvhc.MaDvhc and Giaodat.MaHinhthuc = DMHinhthucsudung.MaHinhthuc";

            conn = sql.getConn();
            conn.Open();
            SqlCommand c = new SqlCommand(cmd, conn);
            SqlDataReader reader = c.ExecuteReader();
            DataRow row;
            table_DSDuAn.BeginLoadData();
            while (reader.Read())
            {
                int i = 0, j = 0;
                int soNam,soThang;
                double compare = 0;
                row = table_DSDuAn.NewRow();
                foreach (DataColumn col in column)
                {
                    switch (i)
                    {
                        case 0:
                            row[i] = int.Parse(reader.GetValue(j).ToString().Trim());
                            break;
                        case 4:
                            soNam = int.Parse(reader.GetValue(j).ToString().Trim());
                            j++;
                            soThang = int.Parse(reader.GetValue(j).ToString().Trim());

                            if(soThang >= 10)
                                compare = double.Parse(soNam + "." + soThang);
                            else
                                compare = double.Parse(soNam + ".0" + soThang);
                            
                            if (soNam < 0)
                            {
                                row[i] = "Đã hết hạn";
                            }
                            else
                            {
                                if(soNam == 0)
                                    row[i] = "gần " + soThang + " tháng";
                                else
                                    row[i] = "gần " + soNam + " năm, " + soThang + " tháng";
                            }
                            break;
                        default:
                            row[i] = reader.GetValue(j).ToString().Trim();
                            break;
                    }
                    i++;
                    j++;
                }

                if(nam_thang == -1)
                    table_DSDuAn.Rows.Add(row);
                if (nam_thang == 0)
                {
                    if (row[4].ToString().Equals("Đã hết hạn"))
                        table_DSDuAn.Rows.Add(row);
                }
                if (nam_thang > 0)
                {
                    if (!row[4].ToString().Equals("Đã hết hạn"))
                    {
                        if(nam_thang >= compare)
                            table_DSDuAn.Rows.Add(row);
                    }
                }

            }
            table_DSDuAn.EndLoadData();
            reader.Close();
            c.Dispose();
            conn.Close();
        }

        private void simpleButton_Select_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            this.table_DSDuAn.Clear();
            if (spinEdit_soThang.Value >= 10)
                this.ShowAllData(double.Parse(spinEdit_soNam.Value + "." + spinEdit_soThang.Value));
            else
            {
                if(spinEdit_soThang.Value >= 0)
                    this.ShowAllData(double.Parse(spinEdit_soNam.Value + ".0" + spinEdit_soThang.Value));
                else
                    this.ShowAllData(0);
            }
            Cursor = Cursors.Default;
        }

        private void simpleButton_Expired_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            spinEdit_soNam.Value = 0;
            spinEdit_soThang.Value = 0;
            this.table_DSDuAn.Clear();
            this.ShowAllData(0);
            Cursor = Cursors.Default;
        }

        private void simpleButton_SelectAll_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            spinEdit_soNam.Value = 50;
            spinEdit_soThang.Value = 0;
            this.table_DSDuAn.Clear();
            this.ShowAllData(-1);
            Cursor = Cursors.Default;
        }

        private void toolStripMenuItem_Select_Click(object sender, EventArgs e)
        {
            try
            {
                int rowSel = -1;
                int[] selectedRows = gridView1.GetSelectedRows();
                foreach (int r in selectedRows) rowSel = r;

                if (formXemDuAn == null)
                {
                    formXemDuAn = new F_XemDuAn(table_DSDuAn.Rows[rowSel].ItemArray[7].ToString());
                    formXemDuAn.FormClosed += new FormClosedEventHandler(formXemDuAn_FormClosed);
                    formXemDuAn.Show();
                }
                else
                    formXemDuAn.Activate();
            }
            catch { }
        }

        void formXemDuAn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formXemDuAn = null;
        }

        private void toolStripMenuItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (formIn == null)
                {
                    formIn = new XtraForm1("BÁO CÁO THỜI HẠN SỬ DỤNG", table_DSDuAn);
                    formIn.FormClosed += new FormClosedEventHandler(formIn_FormClosed);
                    formIn.Show();
                }
                else
                    formIn.Activate();
            }
            catch { }
        }

        void formIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            formIn = null;
        }

        private void toolStripMenuItem_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "Microsoft Excel Files (*.xlsx)|*.xlsx",
                FileName = "SavedDocument"
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetFullPath(save.FileName);
                sql.ExportExcel2007(ext, table_DSDuAn);
            }
        }

    }
}