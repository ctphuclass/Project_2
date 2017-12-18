using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QuanLyBanCaPhe
{
    public partial class Form_TK : Form
    {
        public Form_TK()
        {
            InitializeComponent();
            tbxMaNV.Text = TaiKhoan_BUS.SAve_dt;
        }

        private void Form_TK_Load(object sender, EventArgs e)
        {
            tbxMaNV.Enabled = false;
            tbxTenNV.Enabled = false;
            tbxChucVu.Enabled = false;           
            LoadNV();
        }
        public void LoadNV()
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.Username = tbxMaNV.Text;
            List<TaiKhoan_DTO> Ls_TK = TaiKhoan_BUS.List_TK(tk);
            foreach(var item in Ls_TK)
            {
                tbxMKOld.Text = "";
                tbxTenNV.Text = item.TenNV;
                tbxChucVu.Text = item.Chucvu;
            }
            if(tbxChucVu.Text == "NhanVien")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.PassWord = tbxMKOld.Text;
            tk.Username = tbxMaNV.Text;
            tk.newPassWord = tbxMKNew.Text;
            Results re = new Results();
            re = TaiKhoan_BUS.Change_Pass(tk);
            if(re.TK_result == 1)
            {
                MessageBox.Show(re.TK_Message);
            }
            else
            {
                MessageBox.Show(re.TK_Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoan_DTO tk = new TaiKhoan_DTO();
            tk.Username = textBox1.Text;
            tk.PassWord = textBox2.Text;
            Results re = new Results();
            re = TaiKhoan_BUS.Create_User(tk);
            if(re.Create_result == 1)
            {
                MessageBox.Show(re.Create_message);
            }
            else
            {
                MessageBox.Show(re.Create_message);
            }
                
        }
    }
}
