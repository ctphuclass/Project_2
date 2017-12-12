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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBMaNV = new System.Windows.Forms.TextBox();
            this.TBMK = new System.Windows.Forms.TextBox();
            this.BTDangNhap = new System.Windows.Forms.Button();
            this.BTThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu";
            // 
            // TBMaNV
            // 
            this.TBMaNV.Location = new System.Drawing.Point(135, 30);
            this.TBMaNV.Name = "TBMaNV";
            this.TBMaNV.Size = new System.Drawing.Size(100, 20);
            this.TBMaNV.TabIndex = 2;
            // 
            // TBMK
            // 
            this.TBMK.Location = new System.Drawing.Point(135, 91);
            this.TBMK.Name = "TBMK";
            this.TBMK.Size = new System.Drawing.Size(100, 20);
            this.TBMK.TabIndex = 3;
            this.TBMK.UseSystemPasswordChar = true;
            // 
            // BTDangNhap
            // 
            this.BTDangNhap.Location = new System.Drawing.Point(37, 150);
            this.BTDangNhap.Name = "BTDangNhap";
            this.BTDangNhap.Size = new System.Drawing.Size(75, 23);
            this.BTDangNhap.TabIndex = 4;
            this.BTDangNhap.Text = "Đăng Nhập";
            this.BTDangNhap.UseVisualStyleBackColor = true;
            this.BTDangNhap.Click += new System.EventHandler(this.BTDangNhap_Click_1);
            // 
            // BTThoat
            // 
            this.BTThoat.Location = new System.Drawing.Point(160, 150);
            this.BTThoat.Name = "BTThoat";
            this.BTThoat.Size = new System.Drawing.Size(75, 23);
            this.BTThoat.TabIndex = 5;
            this.BTThoat.Text = "Thoát";
            this.BTThoat.UseVisualStyleBackColor = true;
            this.BTThoat.Click += new System.EventHandler(this.BTThoat_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 200);
            this.Controls.Add(this.BTThoat);
            this.Controls.Add(this.BTDangNhap);
            this.Controls.Add(this.TBMK);
            this.Controls.Add(this.TBMaNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBMaNV;
        private System.Windows.Forms.TextBox TBMK;
        private System.Windows.Forms.Button BTDangNhap;
        private System.Windows.Forms.Button BTThoat;
    }
}