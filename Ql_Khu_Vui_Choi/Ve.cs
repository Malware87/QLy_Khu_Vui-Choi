using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class Ve : Form
    {
        SqlConnection con = new SqlConnection();
        public Ve()
        {
            InitializeComponent();
        }
        private void load_DGV()
        {
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select * from Ve", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            cmd.Dispose();
            con.Close();
            DataTable tb = new DataTable();
            da.Fill(tb);
            dgv.DataSource = tb;
            dgv.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string p_mave = txtmave.Text.Trim();
            string p_ngay = txtLoaiVe.Text.Trim();
            int p_treem = int.Parse(txtGiaTien.Text.Trim());

            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Ve_ins", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaVe", SqlDbType.NVarChar, 50).Value = p_mave;
            cmd.Parameters.Add("@LoaiVe", SqlDbType.NVarChar, 50).Value = p_ngay;
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = p_treem;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            load_DGV();
            MessageBox.Show("Bạn đã thêm mới thành công");
            txtmave.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string p_mave = txtmave.Text.Trim();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("ve_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Mave", SqlDbType.NVarChar, 50).Value = p_mave;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            load_DGV();
            MessageBox.Show("Bạn đã xóa thành công");
            txtmave.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string p_MaVe = txtmave.Text.Trim();
            string p_LoaiVe = txtLoaiVe.Text.Trim();
            int p_GiaTien = int.Parse(txtGiaTien.Text.Trim());
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Ve_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaVe", SqlDbType.NVarChar, 50).Value = p_MaVe;
            cmd.Parameters.Add("@LoaiVe", SqlDbType.NVarChar, 50).Value = p_LoaiVe;
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int).Value = p_GiaTien;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            load_DGV();
            MessageBox.Show("Bạn đã sửa thành công");
            txtmave.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            txtmave.Enabled = true;
            txtLoaiVe.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            load_DGV();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string find = txttimkiem.Text.Trim();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Ve_find", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaVe", SqlDbType.NVarChar, 50).Value = find;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable tb = new DataTable();
            da.Fill(tb);
            dgv.DataSource = tb;
            dgv.Refresh();
        }
        private void Ve_Load_1(object sender, EventArgs e)
        {
            load_DGV();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            txtmave.Enabled = false;
            txtLoaiVe.Enabled = false;
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtmave.Text = dgv[0, e.RowIndex].Value.ToString();
            }
        }
    }
}
