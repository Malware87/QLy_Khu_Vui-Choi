using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Ql_Khu_Vui_Choi
{
    public partial class TroChoi : Form
    {
        SqlConnection con = new SqlConnection();
        public TroChoi()
        {
            InitializeComponent();
        }
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

        private void TroChoi_Load(object sender, EventArgs e)
        {
            Load_TroChoi();
            Load_MaKhu();
            txtMaTro.Enabled = false;
            txtTenTro.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            cbMaKhu.Enabled = false;
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
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool check_matrung(String p_MaTro)
        {
            bool a = false;
            for (int i = 0; i < grvTroChoi.Rows.Count - 1; i++)
            {
                if (p_MaTro == grvTroChoi.Rows[i].Cells[0].Value.ToString())
                    a = true;
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaTro.Enabled = true;
            txtTenTro.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            cbMaKhu.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("TroChoi_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaTroChoi", SqlDbType.NVarChar, 50).Value = txtMaTro.Text.ToString();
            cmd.Parameters.Add("@TenTro", SqlDbType.NVarChar, 50).Value = txtTenTro.Text.ToString();
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = cbMaKhu.SelectedValue.ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Load_TroChoi();
            MessageBox.Show("Đã sửa đổi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("TroChoi_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaTroChoi", SqlDbType.NVarChar, 50).Value = txtMaTro.Text.ToString();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            Load_TroChoi();
            MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string p_MaTro = txtMaTro.Text.ToString();
            string p_TenTro = txtTenTro.Text.ToString();
            string p_MaKhu = cbMaKhu.SelectedValue.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("TroChoi_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaTroChoi", SqlDbType.NVarChar, 50).Value = p_MaTro;
            cmd.Parameters.Add("@TenTro", SqlDbType.NVarChar, 50).Value = p_TenTro;
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
            if (check_matrung(p_MaTro) == true) MessageBox.Show("Trùng mã!");
            else if (txtMaTro.Text == "") MessageBox.Show("Mã không được trống!");
            else
            {
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                Load_TroChoi();
                MessageBox.Show("Đã thêm mới  thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            String find = txtTimKiem.Text;
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("TroChoi_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaTroChoi", SqlDbType.NVarChar, 50).Value = find;
            cmd.Parameters.Add("@TenTro", SqlDbType.NVarChar, 50).Value = find;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            grvTroChoi.DataSource = tb;
            grvTroChoi.Refresh();
        }

        private void grvTroChoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaTro.Text = grvTroChoi["MaTroChoi", e.RowIndex].Value.ToString();
                txtTenTro.Text = grvTroChoi["TenTro", e.RowIndex].Value.ToString();
                cbMaKhu.Text = grvTroChoi["MaKhu", e.RowIndex].Value.ToString();
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                txtTenTro.Enabled = true;
                cbMaKhu.Enabled = true;
            }
        }
    }
}
