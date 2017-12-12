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
        }

        private void BTDangNhap_Click_1(object sender, EventArgs e)
        {
            UserDTO User = new UserDTO();
            User.manv = TBMaNV.Text;
            User.pass = TBMK.Text;
            if (UserBUS.CheckUser(User) == true)
            {
                MessageBox.Show("dang nhap thanh cong!");
                from_DieuHuong dh = new from_DieuHuong();
                if (User.chucvu == "NhanVien")
                {
                    dh.quảnLíToolStripMenuItem.Enabled = false;
                    dh.doanhThuToolStripMenuItem.Enabled = false;
                }
                this.Hide();
                dh.ShowDialog();

            }
            else
                MessageBox.Show("dang nhap that bai , vui ong thu lai sau!");
        }

        private void BTThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
