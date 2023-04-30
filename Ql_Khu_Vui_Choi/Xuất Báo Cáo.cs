using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class Xuất_Báo_Cáo : Form
    {
        public Xuất_Báo_Cáo()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection();
        private void Load_TroChoi()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from TroChoi", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
        }
        private void Load_MaKhu()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from KhuVuiChoi", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cbMaKhu.DataSource = tb;
            cbMaKhu.DisplayMember = "TenKhu";
            cbMaKhu.ValueMember = "MaKhu";
            con.Close();
            cmd.Dispose();
        }
        private void ExportTroChoi(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A1", "C1");
            r1.MergeCells = true;
            r1.Value2 = "DANH SÁCH TRÒ CHƠI";
            r1.Font.Bold = true;
            r1.Font.Name = "Times New Roman";
            r1.Font.Size = "18";
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range r3c1 = oSheet.get_Range("A3", "A3");
            r3c1.Value2 = "Mã trò";
            r3c1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range r3c2 = oSheet.get_Range("B3", "B3");
            r3c2.Value2 = "Tên trò";
            r3c2.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c3 = oSheet.get_Range("C3", "C3");
            r3c3.Value2 = "Mã khu";
            r3c3.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "C3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void Load_DichVu()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("select * from DichVu", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvDichVu.DataSource = tb;
            grvDichVu.Refresh();
        }
        private void Load_NhanVien()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from NhanVien", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cbMaKhu.DataSource = tb;
            cbMaKhu.DisplayMember = "HoTen";
            cbMaKhu.ValueMember = "MaNV";
            con.Close();
            cmd.Dispose();
        }
        private void ExportDichVu(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH DỊCH VỤ";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã Dịch Vụ";
            cl1.ColumnWidth = 7.5;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên Dịch Vụ";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Giá TE";
            cl3.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl3.Value2 = "Giá NL";
            cl3.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl3.Value2 = "MãKhu";
            cl3.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void Xuất_Báo_Cáo_Load(object sender, EventArgs e)
        {
            Load_DichVu();
            Load_MaKhu();
            Load_NhanVien();
            Load_TroChoi();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from DichVu", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
            ExportDichVu(tb, "sheet1");
        }
        private void btExportNhanVien_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from NhanVien", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
            ExportNhanVien(tb, "sheet1");
        }

        private void btExportVe_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Ve", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
            ExportVe(tb, "sheet1");
        }

        private void btExportTroChoi_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from TroChoi", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
            ExportTroChoi(tb, "sheet1");
        }

        private void btExportDichVu_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from DichVu", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
            ExportDichVu(tb, "sheet1");
        }

        private void ExportNhanVien(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A1", "I1");
            r1.MergeCells = true;
            r1.Value2 = "DANH SÁCH NHÂN VIÊN";
            r1.Font.Bold = true;
            r1.Font.Name = "Times New Roman";
            r1.Font.Size = "18";
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range r3c1 = oSheet.get_Range("A3", "A3");
            r3c1.Value2 = "Mã nhân viên";
            r3c1.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range r3c2 = oSheet.get_Range("B3", "B3");
            r3c2.Value2 = "Họ tên nhân viên";
            r3c2.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c3 = oSheet.get_Range("C3", "C3");
            r3c3.Value2 = "Ngày sinh";
            r3c3.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c4 = oSheet.get_Range("D3", "D3");
            r3c4.Value2 = "Số điện thoại";
            r3c4.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c5 = oSheet.get_Range("E3", "E3");
            r3c5.Value2 = "Giới tính";
            r3c5.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c6 = oSheet.get_Range("F3", "F3");
            r3c6.Value2 = "Địa chỉ";
            r3c6.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c7 = oSheet.get_Range("G3", "G3");
            r3c7.Value2 = "Chức vụ";
            r3c7.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c8 = oSheet.get_Range("H3", "H3");
            r3c8.Value2 = "Lương";
            r3c8.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r3c9 = oSheet.get_Range("I3", "I3");
            r3c9.Value2 = "Mã khu vực";
            r3c9.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        private void ExportVe(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;

            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A1", "J1");
            r1.MergeCells = true;
            r1.Value2 = "DANH SÁCH VÉ";
            r1.Font.Bold = true;
            r1.Font.Name = "Times New Roman";
            r1.Font.Size = "18";
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range r3c1 = oSheet.get_Range("A3", "A3");
            r3c1.Value2 = "Mã vé";
            r3c1.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range r3c2 = oSheet.get_Range("B3", "B3");
            r3c2.Value2 = "Ngày in";
            r3c2.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c3 = oSheet.get_Range("C3", "C3");
            r3c3.Value2 = "Số trẻ em";
            r3c3.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c4 = oSheet.get_Range("D3", "D3");
            r3c4.Value2 = "Số người lớn";
            r3c4.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c5 = oSheet.get_Range("E3", "E3");
            r3c5.Value2 = "Thành tiền";
            r3c5.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c6 = oSheet.get_Range("F3", "F3");
            r3c6.Value2 = "Mã trưởng đoàn";
            r3c6.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c7 = oSheet.get_Range("G3", "G3");
            r3c7.Value2 = "Số điện thoại";
            r3c7.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c8 = oSheet.get_Range("H3", "H3");
            r3c8.Value2 = "Giới tính";
            r3c8.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c9 = oSheet.get_Range("I3", "I3");
            r3c9.Value2 = "Mã khu";
            r3c9.ColumnWidth = 20;

            Microsoft.Office.Interop.Excel.Range r3c10 = oSheet.get_Range("J3", "J3");
            r3c10.Value2 = "Mã nhân viên";
            r3c10.ColumnWidth = 20;






            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "J3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột STT
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
    }
}
