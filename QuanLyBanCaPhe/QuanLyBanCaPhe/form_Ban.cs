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
    public partial class form_Ban : Form
    {
        public form_Ban()
        {
            InitializeComponent();
        }
//load
        private void form_Ban_Load(object sender, EventArgs e)
        {
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();
            dtgvBan.DataSource = ListBan;
        }

        private void dtgvBan_Click(object sender, EventArgs e)
        {
            DataGridViewRow drvr = dtgvBan.CurrentRow;
            textBox1.Text = drvr.Cells["Ma_Ban"].Value.ToString();
            textBox2.Text = drvr.Cells["Tenn_Ban"].Value.ToString();
            textBox3.Text = drvr.Cells["Ma_KV"].Value.ToString();
            textBox4.Text = drvr.Cells["Tinh_Trang"].Value.ToString();
            textBox5.Text = drvr.Cells["So"].Value.ToString();
        }
        //them
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Ban_DTO Ban_DTO = new Ban_DTO();
            Ban_DTO.Ma_Ban = textBox1.Text;
            Ban_DTO.Tenn_Ban = textBox2.Text;
            Ban_DTO.Ma_KV = textBox3.Text;
            Ban_DTO.Tinh_Trang = textBox4.Text;
            Ban_DTO.So = Int32.Parse(textBox5.Text);
            if (Ban_BUS.Them_Ban(Ban_DTO) == true)
            {
                MessageBox.Show("Thêm Thành Công!");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();
            dtgvBan.DataSource = ListBan;

        }
        //sua
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Ban_DTO Ban_DTO = new Ban_DTO();
            Ban_DTO.Ma_Ban = textBox1.Text;
            Ban_DTO.Tenn_Ban = textBox2.Text;
            Ban_DTO.Ma_KV = textBox3.Text;
            Ban_DTO.Tinh_Trang = textBox4.Text;
            Ban_DTO.So = Int32.Parse(textBox5.Text);
            if (Ban_BUS.Sua_Ban(Ban_DTO) == true)
            {
                MessageBox.Show("Sua Thành Công!");
            }
            else
            {
                MessageBox.Show("Sua Thất Bại!");
            }
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();
            dtgvBan.DataSource = ListBan;
        }
        //xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Ban_DTO Ban_DTO = new Ban_DTO();
            Ban_DTO.Ma_Ban = textBox1.Text;
            Ban_DTO.Tenn_Ban = textBox2.Text;
            Ban_DTO.Ma_KV = textBox3.Text;
            Ban_DTO.Tinh_Trang = textBox4.Text;
            Ban_DTO.So = Int32.Parse(textBox5.Text);
            if (Ban_BUS.Xoa_Ban(Ban_DTO) == true)
            {
                MessageBox.Show("Xoa Thành Công!");
            }
            else
            {
                MessageBox.Show("Xoa Thất Bại!");
            }
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();
            dtgvBan.DataSource = ListBan;
        }
    }
}
