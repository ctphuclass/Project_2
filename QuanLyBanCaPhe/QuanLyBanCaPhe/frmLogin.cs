using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
namespace QuanLyBanCaPhe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.logo1;
        }

        private void BTDangNhap_Click_1(object sender, EventArgs e)
        {
            UserDTO User = new UserDTO();
            User.manv = TBMaNV.Text;
            User.pass = TBMK.Text;
            if (UserBUS.CheckUser(User) == true)
            {
                TaiKhoan_BUS.SAve_dt = TBMaNV.Text;
                MessageBox.Show("Đăng nhập thành công!");
                from_DieuHuong dh = new from_DieuHuong();
                Form_TK tk = new Form_TK();
                if (User.chucvu == "NhanVien")
                {
                    dh.quảnLíToolStripMenuItem.Enabled = false;
                    dh.doanhThuToolStripMenuItem.Enabled = false;
                    tk.textBox1.Enabled = false;
                    tk.textBox2.Enabled = false;
                    tk.button1.Enabled = false;
                }
                this.Hide();
                dh.ShowDialog();

            }
            else
                MessageBox.Show("Đăng nhập thất bại!");
          
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát không ?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
