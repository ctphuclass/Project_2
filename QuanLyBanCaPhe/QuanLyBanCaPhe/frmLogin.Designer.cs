namespace QuanLyBanCaPhe
{
    partial class frmLogin
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
            this.TBMaNV = new System.Windows.Forms.TextBox();
            this.TBMK = new System.Windows.Forms.TextBox();
            this.BTDangNhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBMaNV
            // 
            this.TBMaNV.Location = new System.Drawing.Point(160, 12);
            this.TBMaNV.Name = "TBMaNV";
            this.TBMaNV.Size = new System.Drawing.Size(164, 20);
            this.TBMaNV.TabIndex = 2;
            // 
            // TBMK
            // 
            this.TBMK.Location = new System.Drawing.Point(160, 49);
            this.TBMK.Name = "TBMK";
            this.TBMK.Size = new System.Drawing.Size(164, 20);
            this.TBMK.TabIndex = 3;
            this.TBMK.UseSystemPasswordChar = true;
            // 
            // BTDangNhap
            // 
            this.BTDangNhap.Location = new System.Drawing.Point(47, 79);
            this.BTDangNhap.Name = "BTDangNhap";
            this.BTDangNhap.Size = new System.Drawing.Size(78, 43);
            this.BTDangNhap.TabIndex = 4;
            this.BTDangNhap.Text = "LOGIN";
            this.BTDangNhap.UseVisualStyleBackColor = true;
            this.BTDangNhap.Click += new System.EventHandler(this.BTDangNhap_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(44, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật Khẩu";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 331);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTDangNhap);
            this.Controls.Add(this.TBMK);
            this.Controls.Add(this.TBMaNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TBMK;
        private System.Windows.Forms.Button BTDangNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TBMaNV;
    }
}