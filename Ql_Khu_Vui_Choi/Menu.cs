using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ql_Khu_Vui_Choi
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có thật sự muốn thoát chương trình ", "Thong Bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;

            }
        }

        private void btn_trochoi_Click(object sender, EventArgs e)
        {
            //Form f=new TroChoi();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            btn_trochoi.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            Btn_Nhanvien.BackColor = Color.FromArgb(222, 142, 190);
          //  button3.MouseHover = Color.FromArgb(255, 255, 255);
            OpenChildForm(new TroChoi());
        }

        private void Btn_dichvu_Click(object sender, EventArgs e)
        {
            //Form f = new DichVu();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            Btn_dichvu.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            Btn_Nhanvien.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new DichVu());
        }

        private void Btn_ve_Click(object sender, EventArgs e)
        {
            //Form f = new Ve();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            Btn_ve.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            Btn_Nhanvien.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new Ve());
        }

        private void Btn_Nhanvien_Click(object sender, EventArgs e)
        {
            //Form f = new NhanVien();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            Btn_Nhanvien.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new NhanVien());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form f = new KhuVuiChoi();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            button2.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            Btn_Nhanvien.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new KhuVuiChoi());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Form f = new Xuất_Báo_Cáo();
            //this.Hide();
            //f.ShowDialog();
            //this.Show();
            button3.BackColor = Color.DeepPink;
            Btn_Nhanvien.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new Xuất_Báo_Cáo());
        }
        private Form currentformchild;
        private void OpenChildForm(Form chilForm)
        {
            if(currentformchild != null)
            {
                currentformchild.Close();
            }
            currentformchild = chilForm;
            chilForm.TopLevel = false;
            chilForm.FormBorderStyle = FormBorderStyle.None;
            chilForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(chilForm);
            panel_body.Tag = chilForm;
            chilForm.BringToFront();
            chilForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentformchild != null)
            {
                currentformchild.Close();
            }
        }

        private void btBill_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HoaDon());
        }
    }
}
