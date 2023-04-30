using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class HoaDon : Form
    {
        SqlConnection con = new SqlConnection();
        public HoaDon()
        {
            InitializeComponent();
        }
        private void HoaDon_search(String P_MaHD)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("BienLai_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBienLai", SqlDbType.NVarChar, 50).Value = P_MaHD;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
            dataGridView1.Refresh();
        }
        private void Load_GiaTien()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Ve", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dgvGiaTien.DataSource = tb;
            dgvGiaTien.Refresh();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            Load_GiaTien();
            HoaDon_search("");
            TaoMa();
            btDel.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
        }
        private void TaoMa()
        {
            int dem = DemCot();
            String p_MaBienLai;
            do
            {
                dem++;
                p_MaBienLai = "BL" + dem.ToString();
                MaBienLai.Text = p_MaBienLai;
            } while (check_matrung(p_MaBienLai, dataGridView1) == true);
        }
        private int DemCot()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select count(MaBienLai) Dem from BienLai", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            return Convert.ToInt32(tb.Rows[0][0].ToString());
        }
        private bool check_matrung(String p, DataGridView dgv)
        {
            bool a = false;
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (p == dgv.Rows[i].Cells[0].Value.ToString())
                    a = true;
            }
            return a;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            string p_MaBienLai = MaBienLai.Text.ToString();
            DateTime p_NgayLap = dtpNgayLap.Value;
            int p_SoTE = SoTE.Text.ToString() == "" ? 0 : Convert.ToInt32(SoTE.Text.ToString());
            int p_SoNL = SoNL.Text.ToString() == "" ? 0 : Convert.ToInt32(SoNL.Text.ToString());
            int p_ThanhTien = Convert.ToInt32(ThanhTien.Text.ToString());
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("BienLai_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBienLai", SqlDbType.NVarChar, 50).Value = p_MaBienLai;
            cmd.Parameters.Add("@NgayLap", SqlDbType.Date).Value = p_NgayLap;
            cmd.Parameters.Add("@SoTE", SqlDbType.Int).Value = p_SoTE;
            cmd.Parameters.Add("@SoNL", SqlDbType.Int).Value = p_SoNL;
            cmd.Parameters.Add("@ThanhTien", SqlDbType.Int).Value = p_ThanhTien;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SoTE.Clear();
            SoNL.Clear();
            TaoMa();
            HoaDon_search("");
        }
        private void SoTE_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }
        private void SoNL_TextChanged(object sender, EventArgs e)
        {
            TinhTien();
        }
        private void TinhTien()
        {
            _ = int.TryParse(SoTE.Text.ToString(), out int p_SoTE);
            _ = int.TryParse(SoNL.Text.ToString(), out int p_SoNL);
            int p_ThanhTien = p_SoTE * Convert.ToInt32(dgvGiaTien.Rows[1].Cells[2].Value.ToString()) + p_SoNL * Convert.ToInt32(dgvGiaTien.Rows[0].Cells[2].Value.ToString());
            ThanhTien.Text = p_ThanhTien.ToString();
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            string p_MaBienLai = MaBienLai.Text.ToString();
            DateTime p_NgayLap = dtpNgayLap.Value;
            int p_SoTE = Convert.ToInt32(SoTE.Text.ToString());
            int p_SoNL = Convert.ToInt32(SoNL.Text.ToString());
            int p_ThanhTien = Convert.ToInt32(ThanhTien.Text.ToString());
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("BienLai_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBienLai", SqlDbType.NVarChar, 50).Value = p_MaBienLai;
            cmd.Parameters.Add("@NgayLap", SqlDbType.Date).Value = p_NgayLap;
            cmd.Parameters.Add("@SoTE", SqlDbType.Int).Value = p_SoTE;
            cmd.Parameters.Add("@SoNL", SqlDbType.Int).Value = p_SoNL;
            cmd.Parameters.Add("@ThanhTien", SqlDbType.Int).Value = p_ThanhTien;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SoTE.Clear();
            SoNL.Clear();
            TaoMa();
            HoaDon_search("");
            btDel.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            string p_MaBienLai = MaBienLai.Text.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("BienLai_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBienLai", SqlDbType.NVarChar, 50).Value = p_MaBienLai;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            TaoMa();
            SoTE.Clear();
            SoNL.Clear();
            HoaDon_search("");
            btDel.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                MaBienLai.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                dtpNgayLap.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                SoTE.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                SoNL.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                btDel.Enabled = true;
                btUpdate.Enabled = true;
                btCancel.Enabled = true;
            }
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            TaoMa();
            dtpNgayLap.Value = DateTime.Now;
            SoTE.Clear();
            SoNL.Clear();
            btDel.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
            HoaDon_search("");
        }

        private void ExportHoaDon (DataTable tb,string sheetname)
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

            Microsoft.Office.Interop.Excel.Range r1 = oSheet.get_Range("A1", "E1");
            r1.MergeCells = true;
            r1.Value2 = "Khu Vui Chơi Gì Cũng Được ";
            r1.Font.Bold = true;
            r1.Font.Name = "Times New Roman";
            r1.Font.Size = "18";
            r1.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            
            
            Microsoft.Office.Interop.Excel.Range r2 = oSheet.get_Range("A2", "E2");
            r2.MergeCells = true;
            r2.Value2 = "Hóa Đơn Thu Tiền";
            r2.Font.Bold = true;
            r2.Font.Name = "Times New Roman";
            r2.Font.Size = "16";
            r2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range r3 = oSheet.get_Range("A3", "E3");
            r3.MergeCells = true;
            r3.Value2 = "Địa Chỉ :Số 54, p.Triều Khúc, Thanh Xuân, Hà Nội ";
            r3.Font.Italic = true;
            r3.Font.Name = "Times New Roman";
            r3.Font.Size = "12";

            Microsoft.Office.Interop.Excel.Range r4 = oSheet.get_Range("A4", "E4");
            r4.MergeCells = true;
            r4.Value2 = "SĐT : 0866 789 JQK";
            r4.Font.Italic = true;
            r4.Font.Name = "Times New Roman";
            r4.Font.Size = "12";

            Microsoft.Office.Interop.Excel.Range r5c1 = oSheet.get_Range("A5", "A5");
            r5c1.Value2 = "Mã Biên Lai";
            r5c1.ColumnWidth = 15.0;

            Microsoft.Office.Interop.Excel.Range r5c2 = oSheet.get_Range("B5", "B5");
            r5c2.Value2 = "Ngày Lập";
            r5c2.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r5c3 = oSheet.get_Range("C5", "C5");
            r5c3.Value2 = "Số Trẻ Em";
            r5c3.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r5c4 = oSheet.get_Range("D5", "D5");
            r5c4.Value2 = "Số Người Lớn";
            r5c4.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range r5c5 = oSheet.get_Range("E5", "E5");
            r5c5.Value2 = "Tổng Tiền";
            r5c5.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A5", "E5");
            rowHead.Font.Bold = true;
            rowHead.Font.Italic = true;
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
            int rowStart = 6;
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

        private void print_Click(object sender, EventArgs e)
        {
            string find = MaBienLai.Text.Trim();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("BienLai_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBienLai", SqlDbType.NVarChar, 50).Value = find;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
            dataGridView1.Refresh();
            ExportHoaDon(tb, "sheet1");
        }
    }
}