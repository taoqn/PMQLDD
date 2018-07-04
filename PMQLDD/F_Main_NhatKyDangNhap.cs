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
    public partial class F_Main_NhatKyDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public F_Main_NhatKyDangNhap()
        {
            InitializeComponent();
        }

        private void F_Main_NhatKyDangNhap_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            DataTable table = new DataTable();

            DataColumn col0 = new DataColumn();
            col0.DataType = System.Type.GetType("System.Int32");
            col0.ColumnName = "STT";
            table.Columns.Add(col0);

            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.String");
            col1.ColumnName = "Tên đăng nhập";
            table.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.String");
            col2.ColumnName = "Họ và tên";
            table.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.DataType = System.Type.GetType("System.String");
            col3.ColumnName = "Thời điểm bắt đầu";
            table.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.DataType = System.Type.GetType("System.String");
            col4.ColumnName = "Thời điểm kết thúc";
            table.Columns.Add(col4);

            DataColumn col5 = new DataColumn();
            col5.DataType = System.Type.GetType("System.String");
            col5.ColumnName = "Địa chỉ IP";
            table.Columns.Add(col5);

            gridControl1.DataSource = table;
            gridView1.Columns[0].Width = 25;


            DataColumn[] col = { col0, col1, col2, col3, col4, col5 };
            SQLConnect sql = F_DangNhap.SQL_con_object as SQLConnect;
            string s = "SELECT ROW_NUMBER() OVER(ORDER BY Taikhoan_Lichsu.ThoiDiemBatDau desc) AS Row#, Taikhoan.TenDangNhap,Taikhoan.HoTen,Taikhoan_Lichsu.ThoiDiemBatDau,Taikhoan_Lichsu.ThoiDiemKetThuc,Taikhoan_Lichsu.DiaChiIP  FROM Taikhoan INNER JOIN  Taikhoan_Lichsu ON Taikhoan.MaID=Taikhoan_Lichsu.MaID WHERE (Taikhoan_Lichsu.LogOn=1)";
            sql.ViewDataTable(s,table,col);

            Cursor = Cursors.Default;

        }
    }
}