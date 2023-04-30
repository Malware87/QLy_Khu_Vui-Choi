using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class KhuVuiChoi : Form
    {
        SqlConnection con = new SqlConnection();
        public KhuVuiChoi()
        {
            InitializeComponent();
        }
        private bool check_matrung(String p_MaKhu, DataGridView dgv)
        {
            bool a = false;
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                if (p_MaKhu == dgv.Rows[i].Cells[0].Value.ToString())
                    a = true;
            }
            return a;
        }
        private void dgvKhuVuiChoi_search(String p_MaKhu, String p_TenKhu)
        {
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("KhuVuiChoi_find", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
                cmd.Parameters.Add("@TenKhu", SqlDbType.NVarChar, 50).Value = p_TenKhu;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable tb = new DataTable();
                da.Fill(tb);
                dgvKhuVuiChoi.DataSource = tb;
                dgvKhuVuiChoi.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void KhuVuiChoi_Load(object sender, EventArgs e)
        {
            dgvKhuVuiChoi_search("", "");
            btUpdate.Enabled = false;
            btDel.Enabled = false;
            label3.Visible = false;
            btCancel.Enabled = false;

        }
        private void dgvKhuVuiChoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKhu.Text = dgvKhuVuiChoi["MaKhu", e.RowIndex].Value.ToString();
                txtTenKhu.Text = dgvKhuVuiChoi["TenKhu", e.RowIndex].Value.ToString();
                txtGioMo.Text = dgvKhuVuiChoi["GioMoCua", e.RowIndex].Value.ToString();
                txtGioDong.Text = dgvKhuVuiChoi["GioDongCua", e.RowIndex].Value.ToString();
                txtGiaTE.Text = dgvKhuVuiChoi["GiaTE", e.RowIndex].Value.ToString();
                txtGiaNL.Text = dgvKhuVuiChoi["GiaNL", e.RowIndex].Value.ToString();
                txtDienTich.Text = dgvKhuVuiChoi["DienTich", e.RowIndex].Value.ToString();
                txtMaKhu.Enabled = false;
                btDel.Enabled = true;
                btUpdate.Enabled = true;
                btCancel.Enabled = true;
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            int p_GiaTE = 0, p_GiaNL = 0, p_DienTich = 0;
            String p_MaKhu = "";
            String p_TenKhu = "";
            String p_GioMoCua = "";
            String p_GioDongCua = "";
            if (txtMaKhu.Text == "" || txtTenKhu.Text == "" || txtGioMo.Text == "" || txtGioDong.Text == "" || txtGiaTE.Text == "" || txtGiaNL.Text == "" || txtDienTich.Text == "") label3.Visible = true;
            else
            {
                {
                    p_MaKhu = txtMaKhu.Text.ToString();
                    p_TenKhu = txtTenKhu.Text.ToString();
                    p_GioMoCua = txtGioMo.Text.ToString();
                    p_GioDongCua = txtGioDong.Text.ToString();
                    p_GiaTE = Convert.ToInt32(txtGiaTE.Text.ToString());
                    p_GiaNL = Convert.ToInt32((txtGiaNL.Text.ToString()));
                    p_DienTich = Convert.ToInt32(txtDienTich.Text.ToString());
                }
                if (con.State != ConnectionState.Open)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    con.Open();
                }
                if (check_matrung(p_MaKhu, dgvKhuVuiChoi) == true) MessageBox.Show("Mã khu đã tồn tại");
                else
                {
                    SqlCommand cmd = new SqlCommand("KhuVuiChoi_ins", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
                    cmd.Parameters.Add("@TenKhu", SqlDbType.NVarChar, 50).Value = p_TenKhu;
                    cmd.Parameters.Add("@GioMoCua", SqlDbType.Time).Value = p_GioMoCua;
                    cmd.Parameters.Add("@GioDongCua", SqlDbType.Time).Value = p_GioDongCua;
                    cmd.Parameters.Add("@GiaTE", SqlDbType.Int).Value = p_GiaTE;
                    cmd.Parameters.Add("@GiaNL", SqlDbType.Int).Value = p_GiaNL;
                    cmd.Parameters.Add("@DienTich", SqlDbType.Int).Value = p_DienTich;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    dgvKhuVuiChoi_search("", "");
                }
            }
            label3.Visible = false;
            con.Close();
            con.Close();
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            String p_MaKhu = txtMaKhu.Text.ToString();
            String p_TenKhu = txtTenKhu.Text.ToString();
            String p_GioMoCua = txtGioMo.Text.ToString();
            String p_GioDongCua = txtGioDong.Text.ToString();
            int p_GiaTE = Convert.ToInt32(txtGiaTE.Text.ToString());
            int p_GiaNL = Convert.ToInt32((txtGiaNL.Text.ToString()));
            int p_DienTich = Convert.ToInt32(txtDienTich.Text.ToString());
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("KhuVuiChoi_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
            cmd.Parameters.Add("@TenKhu", SqlDbType.NVarChar, 50).Value = p_TenKhu;
            cmd.Parameters.Add("@GioMoCua", SqlDbType.Time).Value = p_GioMoCua;
            cmd.Parameters.Add("@GioDongCua", SqlDbType.Time).Value = p_GioDongCua;
            cmd.Parameters.Add("@GiaTE", SqlDbType.Int).Value = p_GiaTE;
            cmd.Parameters.Add("@GiaNL", SqlDbType.Int).Value = p_GiaNL;
            cmd.Parameters.Add("@DienTich", SqlDbType.Int).Value = p_DienTich;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            btDel.Enabled = false;
            btUpdate.Enabled = false;
            txtMaKhu.Enabled = true;
            btCancel.Enabled = false;
            dgvKhuVuiChoi_search("", "");
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            String p_MaKhu = txtMaKhu.Text.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("KhuVuiChoi_del", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKhu", SqlDbType.NVarChar, 50).Value = p_MaKhu;
            DialogResult dlr = MessageBox.Show("Xác nhận xóa ?", "Thông báo", MessageBoxButtons.OKCancel);
            if (dlr == DialogResult.OK)
                cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            btUpdate.Enabled = false;
            btDel.Enabled = false;
            txtMaKhu.Enabled = true;
            txtMaKhu.Enabled = true;
            btCancel.Enabled = false;
            dgvKhuVuiChoi_search("", "");
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            String p_MaKhu = txtSearch.Text.ToString();
            dgvKhuVuiChoi_search(p_MaKhu, p_MaKhu);
        }
        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.Clear();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            txtMaKhu.Clear();
            txtGioDong.Clear();
            txtDienTich.Clear();
            txtGiaNL.Clear();
            txtGiaTE.Clear();
            txtGioMo.Clear();
            txtTenKhu.Clear();
            txtMaKhu.Enabled = true;
            btUpdate.Enabled = false;
            btDel.Enabled = false;
            btCancel.Enabled = false;
        }
    }
}
