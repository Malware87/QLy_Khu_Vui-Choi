using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class DichVu : Form
    {
        SqlConnection con = new SqlConnection();

        public DichVu()
        {
            InitializeComponent();
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
        private void Load_MaKhu()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select MaKhu,TenKhu from KhuVuiChoi", con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            cbMaKhu.DataSource = tb;
            cbMaKhu.DisplayMember = "TenKhu";
            cbMaKhu.ValueMember = "MaKhu";
        }

        private void grvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells[0].Value.ToString();
                txtTenDV.Text = row.Cells[1].Value.ToString();
                txtGiaTE.Text = row.Cells[2].Value.ToString();
                txtGiaNL.Text = row.Cells[3].Value.ToString();
                cbMaKhu.Text = row.Cells[4].Value.ToString();
                button2.Enabled = true;
                button3.Enabled = true;
                txtMaDV.Enabled = true;
                txtGiaTE.Enabled = true;
                txtGiaNL.Enabled = true;
                txtTenDV.Enabled = true;
                cbMaKhu.Enabled = true;
                button5.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaDV.Enabled = true;
            txtGiaTE.Enabled = true;
            txtGiaNL.Enabled = true;
            txtTenDV.Enabled = true;
            button4.Enabled = true;
            cbMaKhu.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtMaDV.Text == "" || txtTenDV.Text == "" || txtGiaTE.Text == "" || txtGiaNL.Text == "") label6.Visible = true;
            else
            {
                string p_MaDV = txtMaDV.Text.ToString();
                string p_TenDV = txtTenDV.Text.ToString();
                int p_GiaTE = Convert.ToInt32(txtGiaTE.Text.ToString());
                int p_GiaNL = Convert.ToInt32(txtGiaTE.Text.ToString());
                string p_MaKhu = cbMaKhu.SelectedValue.ToString();
                if (con.State != ConnectionState.Open)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DichVu_ins", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDV", SqlDbType.NVarChar, 50).Value = p_MaDV;
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50).Value = p_TenDV;
                cmd.Parameters.Add("@GiaTE", SqlDbType.Int).Value = p_GiaTE;
                cmd.Parameters.Add("@GiaNL", SqlDbType.Int).Value = p_GiaNL;
                cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
                if (check_matrung(p_MaDV) == true) MessageBox.Show("Trùng mã!");
                else if (txtMaDV.Text == "") MessageBox.Show("Mã không được trống!");
                else
                {
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    Load_DichVu();
                    MessageBox.Show("Đã thêm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                label6.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string p_MaDV = txtMaDV.Text.ToString();
            string p_TenDV = txtTenDV.Text.ToString();
            int p_GiaTE = Convert.ToInt32(txtGiaTE.Text.ToString());
            int p_GiaNL = Convert.ToInt32(txtGiaTE.Text.ToString());
            string p_MaKhu = cbMaKhu.SelectedValue.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DichVu_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.NVarChar, 50).Value = p_MaDV;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50).Value = p_TenDV;
            cmd.Parameters.Add("@GiaTE", SqlDbType.Int).Value = p_GiaTE;
            cmd.Parameters.Add("@GiaNL", SqlDbType.Int).Value = p_GiaNL;
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Load_DichVu();
            MessageBox.Show("Đã sửa đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DichVu_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.NVarChar, 50).Value = txtMaDV.Text.ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Load_DichVu();
            MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String find = txtTimKiem.Text;
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("DichVu_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.NVarChar, 50).Value = find;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50).Value = find;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            grvDichVu.DataSource = tb;
            grvDichVu.Refresh();
        }
        private bool check_matrung(String p_MaDV)
        {
            bool a = false;
            for (int i = 0; i < grvDichVu.Rows.Count - 1; i++)
            {
                if (p_MaDV == grvDichVu.Rows[i].Cells[0].Value.ToString())
                    a = true;
            }
            return a;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            Load_DichVu();
            Load_MaKhu();
            label6.Visible = false;
            txtMaDV.Enabled = false;
            txtGiaTE.Enabled = false;
            txtGiaNL.Enabled = false;
            txtTenDV.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            cbMaKhu.Enabled = false;
        }
    }
}
