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
    public partial class Login : Form
    {

        SqlConnection con = new SqlConnection();
        public Login()
        {
            InitializeComponent();
        }
        public static string UserName = "";
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có thật sự muốn thoát chương trình ", "Thong Bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                if (con.State != ConnectionState.Open)
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("TaiKhoan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Checklogin";
                cmd.Parameters.AddWithValue("@UserName", txtUser.Text);
                cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                cmd.Connection = con;
                UserName = txtUser.Text;
                object kq = cmd.ExecuteScalar();
                int code = Convert.ToInt32(kq);
                if (code == 0)
                {
                    MessageBox.Show("Chào mừng bạn đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form f = new MenuNV();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }

                else if (code == 1)
                {
                    MessageBox.Show("Chào mừng Admin đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form f = new Menu();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
                else if (code == 2)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Text = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Text = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void checkboxShowMk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowMk.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
            txtUser.Focus();
        }

        private void txtUser_MouseClick_1(object sender, MouseEventArgs e)
        {
            label1.Visible = false;
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
            txtPass.Focus();
        }

        private void txtPass_MouseClick_1(object sender, MouseEventArgs e)
        {
            label2.Visible = false;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text == "") label1.Visible = true;
            else label1.Visible = false;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == "") label2.Visible = true;
            else label2.Visible = false;
        }
    }
}
