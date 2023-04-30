
namespace Ql_Khu_Vui_Choi
{
    partial class TroChoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbMaKhu = new System.Windows.Forms.ComboBox();
            this.txtTenTro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaTro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.MaKhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TenTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grvTroChoi = new System.Windows.Forms.DataGridView();
            this.MaTroChoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTroChoi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbMaKhu
            // 
            this.cbMaKhu.FormattingEnabled = true;
            this.cbMaKhu.Location = new System.Drawing.Point(130, 169);
            this.cbMaKhu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMaKhu.Name = "cbMaKhu";
            this.cbMaKhu.Size = new System.Drawing.Size(222, 28);
            this.cbMaKhu.TabIndex = 2;
            // 
            // txtTenTro
            // 
            this.txtTenTro.Location = new System.Drawing.Point(132, 125);
            this.txtTenTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenTro.Name = "txtTenTro";
            this.txtTenTro.Size = new System.Drawing.Size(222, 27);
            this.txtTenTro.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Trò:";
            // 
            // txtMaTro
            // 
            this.txtMaTro.Location = new System.Drawing.Point(132, 79);
            this.txtMaTro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaTro.Name = "txtMaTro";
            this.txtMaTro.Size = new System.Drawing.Size(222, 27);
            this.txtMaTro.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Trò:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(154, 54);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(198, 27);
            this.txtTimKiem.TabIndex = 29;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 45);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 48);
            this.button6.TabIndex = 29;
            this.button6.Text = "Tìm Kiếm";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MaKhu
            // 
            this.MaKhu.DataPropertyName = "MaKhu";
            this.MaKhu.HeaderText = "MãKhu";
            this.MaKhu.MinimumWidth = 6;
            this.MaKhu.Name = "MaKhu";
            this.MaKhu.Width = 125;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTimKiem);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 214);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(405, 106);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // TenTro
            // 
            this.TenTro.DataPropertyName = "TenTro";
            this.TenTro.HeaderText = "Tên Trò";
            this.TenTro.MinimumWidth = 6;
            this.TenTro.Name = "TenTro";
            this.TenTro.Width = 125;
            // 
            // grvTroChoi
            // 
            this.grvTroChoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvTroChoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTroChoi,
            this.TenTro,
            this.MaKhu});
            this.grvTroChoi.Location = new System.Drawing.Point(12, 362);
            this.grvTroChoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grvTroChoi.Name = "grvTroChoi";
            this.grvTroChoi.RowHeadersWidth = 51;
            this.grvTroChoi.RowTemplate.Height = 24;
            this.grvTroChoi.Size = new System.Drawing.Size(1034, 210);
            this.grvTroChoi.TabIndex = 28;
            this.grvTroChoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvTroChoi_CellClick);
            // 
            // MaTroChoi
            // 
            this.MaTroChoi.DataPropertyName = "MaTroChoi";
            this.MaTroChoi.HeaderText = "Mã Trò Chơi";
            this.MaTroChoi.MinimumWidth = 6;
            this.MaTroChoi.Name = "MaTroChoi";
            this.MaTroChoi.Width = 125;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(829, 62);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 54);
            this.button5.TabIndex = 20;
            this.button5.Text = "Hủy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(655, 111);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 54);
            this.button4.TabIndex = 19;
            this.button4.Text = "Lưu";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(486, 111);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 54);
            this.button3.TabIndex = 18;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 35);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 54);
            this.button2.TabIndex = 17;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 54);
            this.button1.TabIndex = 16;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Khu:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbMaKhu);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenTro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaTro);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1034, 347);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // TroChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.grvTroChoi);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TroChoi";
            this.Text = "TroChoi";
            this.Load += new System.EventHandler(this.TroChoi_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvTroChoi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbMaKhu;
        private System.Windows.Forms.TextBox txtTenTro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaTro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTro;
        private System.Windows.Forms.DataGridView grvTroChoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTroChoi;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}