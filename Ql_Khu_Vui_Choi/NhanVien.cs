using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{

    public partial class NhanVien : Form
    {
        SqlConnection con = new SqlConnection();
        public NhanVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            Load_khu();
        }
        private void Load_khu()
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
            cmd.Dispose();
            con.Close();
            cbMaKhu.DataSource = tb;
            cbMaKhu.DisplayMember = "TenKhu";
            cbMaKhu.ValueMember = "MaKhu";
        }
        private bool check_matrung(String p_MaNV)
        {
            bool a = false;
            for (int i = 0; i < dataGridViewNhanVien.Rows.Count - 1; i++)
            {
                if (p_MaNV == dataGridViewNhanVien.Rows[i].Cells[0].Value.ToString())
                    a = true;
            }
            return a;
        }

        private void dataGridViewNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewNhanVien.Rows[e.RowIndex];
                txtMaNv.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtNgaySinh.Text = row.Cells[2].Value.ToString();
                txtSdt.Text = row.Cells[3].Value.ToString();
                cbGioiTinh.Text = row.Cells[4].Value.ToString();
                txtDiaChi.Text = row.Cells[5].Value.ToString();
                cbChucVu.Text = row.Cells[6].Value.ToString();
                txtLuong.Text = row.Cells[7].Value.ToString();
                cbMaKhu.Text = row.Cells[0].Value.ToString();
                txtMaNv.Enabled = false;
                
            }
        }
        private void ketnoicsdl()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            string sql = "select * from NhanVien";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, con); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            con.Close();  // đóng kết nối
            dataGridViewNhanVien.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        public bool KTTTtrong()
        {
            if (txtMaNv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNv.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (txtNgaySinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ngày sinh ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgaySinh.Focus();
                return false;
            }
            if (txtSdt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (cbChucVu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập chức vụ ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbChucVu.Focus();
                return false;
            }
            if (txtLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập lương ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLuong.Focus();
                return false;
            }
            if (cbGioiTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giới tính ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGioiTinh.Focus();
                return false;
            }
            if (cbMaKhu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaKhu.Focus();
                return false;
            }
            return true;
        }
        private void Reset()
        {
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtLuong.Text = "";
            txtMaNv.Text = "";
            txtNgaySinh.Text = "";
            txtSdt.Text = "";
            cbChucVu.Text = "";
            cbGioiTinh.Text = "";
            cbMaKhu.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

            Reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String p_MaNV = txtMaNv.Text.ToString();
            String p_HoTen = txtHoTen.Text.ToString();
            String p_NgaySinh = txtNgaySinh.Text.ToString();
            String p_SDT = txtSdt.Text.ToString();
            String p_DiaChi = txtDiaChi.Text.ToString();
            String p_ChucVu = cbChucVu.Text.ToString();
            String p_GioiTinh = cbGioiTinh.Text.ToString();
            String p_MaKhu = cbMaKhu.Text.ToString();
            int p_Luong = Convert.ToInt32(txtLuong.Text.ToString());
            if (KTTTtrong())
            {
                try
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("NhanVien_ins", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 50).Value = p_MaNV;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = p_NgaySinh;
                    cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 50).Value = p_SDT;
                    cmd.Parameters.Add("@Luong", SqlDbType.Int).Value = p_Luong;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).Value = p_DiaChi;
                    cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = p_ChucVu;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = p_HoTen;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50).Value = p_GioiTinh;
                    if (check_matrung(p_MaNV) == true) MessageBox.Show("Trùng mã sản phẩm!");
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    ketnoicsdl();
                    Reset();
                    MessageBox.Show("Đã thêm mới nhân viên  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaNv.Enabled = false; 
            if (txtMaNv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã học sinh cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNv.Focus();
            }
            
            else if (KTTTtrong())
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("NhanVien_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = cbMaKhu.Text;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 50).Value = txtMaNv.Text;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtNgaySinh.Text;
                    cmd.Parameters.Add("@SDT", SqlDbType.Int).Value = Convert.ToInt32(txtSdt.Text);
                    cmd.Parameters.Add("@Luong", SqlDbType.Int).Value = Convert.ToInt32(txtLuong.Text);
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).Value = txtDiaChi.Text;
                    cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = cbChucVu.Text;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = txtHoTen.Text;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50).Value = cbGioiTinh.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ketnoicsdl();
                    Reset();
                    MessageBox.Show("Đã sửa nhân viên  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string p_MaNV = txtMaNv.Text;
            if (txtMaNv.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNv.Focus();
            }
            else
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("NhanVien_del", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 50).Value = p_MaNV;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    ketnoicsdl();
                    Reset();
                    MessageBox.Show("Đã xóa nhân viên  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("bạn có thật sự muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {

            timkiemtheomanv();


        }
        private void timkiem()
        {
            String p_MaNV = txtMaNv.Text.ToString();
            String p_HoTen = txtHoTen.Text.ToString();
            String p_NgaySinh = txtNgaySinh.Text.ToString();
            String p_SDT = txtSdt.Text.ToString();
            String p_DiaChi = txtDiaChi.Text.ToString();
            String p_ChucVu = cbChucVu.Text.ToString();
            String p_GioiTinh = cbGioiTinh.Text.ToString();
            String p_MaKhu = cbMaKhu.Text.ToString();
            int p_Luong = Convert.ToInt32(txtLuong.Text.ToString());
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("NhanVien_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = cbMaKhu.Text;
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar, 50).Value = txtMaNv.Text;
            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtNgaySinh.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.Int).Value = Convert.ToInt32(txtSdt.Text);
            cmd.Parameters.Add("@Luong", SqlDbType.Int).Value = Convert.ToInt32(txtLuong.Text);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar, 50).Value = cbChucVu.Text;
            cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 50).Value = txtHoTen.Text;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 50).Value = cbGioiTinh.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dataGridViewNhanVien.DataSource = tb;
            dataGridViewNhanVien.Refresh();
        }
        private void timkiemtheomanv()
        {
            string rowFilter = string.Format("{0} like '{1}'", "MaNV", "*" + txtTKi.Text + "*");
            (dataGridViewNhanVien.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTKi_MouseClick(object sender, MouseEventArgs e)
        {
            txtTKi.Clear();
        }
    }
}

