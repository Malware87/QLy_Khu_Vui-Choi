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
    public partial class MenuNV : Form
    {
        public MenuNV()
        {
            InitializeComponent();
        }
        

       
        private Form currentformchild;
        private void OpenChildForm(Form chilForm)
        {
            if (currentformchild != null)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new KhuVuiChoi()); 


        }

        private void btn_trochoi_Click_1(object sender, EventArgs e)
        {
            btn_trochoi.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new TroChoi());
        }

        private void Btn_dichvu_Click_1(object sender, EventArgs e)
        {
            Btn_dichvu.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new DichVu());
        }

        private void Btn_ve_Click_1(object sender, EventArgs e)
        {
            Btn_ve.BackColor = Color.DeepPink;
            button3.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new Ve());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.BackColor = Color.DeepPink;
            Btn_ve.BackColor = Color.FromArgb(222, 142, 190);
            Btn_dichvu.BackColor = Color.FromArgb(222, 142, 190);
            button2.BackColor = Color.FromArgb(222, 142, 190);
            btn_trochoi.BackColor = Color.FromArgb(222, 142, 190);
            OpenChildForm(new Xuất_Báo_Cáo());
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuNV_Load(object sender, EventArgs e)
        {

        }

        private void MenuNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có thật sự muốn thoát chương trình ", "Thong Bao", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentformchild != null)
            {
                currentformchild.Close();
            }
        }
    }
}
