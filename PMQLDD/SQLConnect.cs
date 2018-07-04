using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Net;
using System.Security.Cryptography;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace PMQLDD
{
    class SQLConnect
    {
        SqlConnection conn = null;

        public SQLConnect(SqlConnection sql)
        {
            this.conn = sql;
        }
        public SqlConnection getConn()
        {
            return conn;
        }
        public DataTable ViewData(string cmd)
        {
            conn.Open();
            SqlDataAdapter cmdResults = new SqlDataAdapter(cmd, conn);
            DataTable dSetExam = new DataTable();
            cmdResults.Fill(dSetExam);
            conn.Close();
            return dSetExam;
        }
        public void ViewDataTable(string cmd, DataTable table, DataColumn[] column)
        {
            conn.Open();
            SqlCommand c = new SqlCommand(cmd, conn);
            SqlDataReader reader = c.ExecuteReader();
            DataRow row;
            table.BeginLoadData();
            while (reader.Read())
            {
                int i = 0;
                row = table.NewRow();
                foreach (DataColumn col in column)
                {
                    if (col.DataType.ToString().Equals("System.String"))
                    {
                        row[i] = reader.GetValue(i).ToString().Trim();
                    }
                    if (col.DataType.ToString().Equals("System.Int32"))
                    {
                        row[i] = int.Parse(reader.GetValue(i).ToString().Trim());
                    }
                    if (col.DataType.ToString().Equals("System.Double"))
                    {
                        row[i] = double.Parse(reader.GetValue(i).ToString().Trim());
                    }
                    if (col.DataType.ToString().Equals("System.DateTime"))
                    {
                        //DateTime Da = DateTime.Parse(reader.GetValue(i).ToString().Trim());
                        //row[i] =  Da.ToString("dd/MM/yyyy");
                        //DateTime dt = DateTime.ParseExact(reader.GetValue(i).ToString().Trim(), "M/d/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        //row[i] = dt.ToString("dd/M/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        row[i] = reader.GetValue(i).ToString().Trim();
                    }
                    i++;
                }
                table.Rows.Add(row);
            }
            table.EndLoadData();
            reader.Close();
            c.Dispose();
            conn.Close();
        }
        public String GetData(string cmd, int k)
        {
            conn.Open();
            string s = "";
            SqlCommand c = new SqlCommand(cmd, conn);
            SqlDataReader reader = c.ExecuteReader();
            if (reader.Read())
                s = reader.GetValue(k).ToString().Trim();
            reader.Close();
            c.Dispose();
            conn.Close();
            return s;
        }
        public string[] GetDataArray(string cmd, int k)
        {
            conn.Open();
            string[] s = new string[1000];
            SqlCommand c = new SqlCommand(cmd, conn);
            SqlDataReader reader = c.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                s[i] = reader.GetValue(k).ToString().Trim();
                i++;
            }
            reader.Close();
            c.Dispose();
            conn.Close();
            return s;
        }
        public void ExecuteData(String str)
        {
            conn.Open();
            try
            {
                SqlCommand sqlcmd = new SqlCommand(str, conn);
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception e) { e.ToString(); }
            conn.Close();
        }

        private byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public string StringToMD5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        public string GetLocalIPAddress()
        {
            string strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[2].ToString();
        }

        public void ExportExcel2003(string name, string path, DataTable dt)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            COMExcel.Worksheet exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            //exSheet.Activate();
            exSheet.Name = name;

            int i = 1;
            foreach (DataRow row in dt.Rows)
            {
                int j = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    COMExcel.Range r = (COMExcel.Range)exSheet.Cells[i, j];
                    if (column.DataType.ToString().Equals("System.String"))
                    {
                        r.Value2 = row[column].ToString();
                    }
                    if (column.DataType.ToString().Equals("System.Int32"))
                    {
                        r.Value2 = int.Parse(row[column].ToString());
                    }
                    if (column.DataType.ToString().Equals("System.Double"))
                    {
                        r.Value2 = double.Parse(row[column].ToString());
                    }
                    r.Columns.AutoFit();
                    j++;
                }
                i++;
            }
            exApp.Visible = false;
            exBook.SaveAs(path, COMExcel.XlFileFormat.xlWorkbookNormal,null, null, false, false,COMExcel.XlSaveAsAccessMode.xlExclusive,false, false, false, false, false);
            exApp.Visible = true;
            exBook.Close(false, false, false);
            //exApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exBook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);
        }

        public void ExportExcel2007(string path, DataTable dt)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

            COMExcel._Application obj = new COMExcel.Application();
            obj.Application.Workbooks.Add(Type.Missing);
            for (int i = 1; i <= dt.Columns.Count; i++)
            {
                obj.Cells[1, i] = dt.Columns[i-1].ColumnName.ToString();
                obj.Cells[1, i].Font.Bold = true;
                obj.Cells[1, i].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            }

            int k = 2;
            foreach (DataRow row in dt.Rows)
            {
                int j = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.DataType.ToString().Equals("System.String"))
                    {
                        obj.Cells[k, j] = row[column].ToString();
                    }
                    if (column.DataType.ToString().Equals("System.Int32"))
                    {
                        obj.Cells[k, j] = int.Parse(row[column].ToString());
                    }
                    if (column.DataType.ToString().Equals("System.Double"))
                    {
                        obj.Cells[k, j] = double.Parse(row[column].ToString());
                    }
                    j++;
                }
                k++;
            }
            obj.Columns.AutoFit();
            obj.ActiveWorkbook.SaveCopyAs(path);
            obj.ActiveWorkbook.Saved = true;
            //obj.Visible = true;
            obj.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }
}
