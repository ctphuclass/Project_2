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
    public partial class form_Menu : Form
    {
        public form_Menu()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            List<Menu_DTO> Menu_main_1 = Menu_BUS.Menu_Main_1();
            dataGridView1.DataSource = Menu_main_1; 
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgrv = dataGridView1.CurrentRow;
            tbxMaSP.Text = dgrv.Cells["MaSP"].Value.ToString();
            tbxTenSP.Text = dgrv.Cells["TenSP"].Value.ToString();
            tbxLoaiSP.Text = dgrv.Cells["LoaiSP"].Value.ToString();
            tbxDVT.Text = dgrv.Cells["DVT"].Value.ToString();
            tbxDG.Text = (dgrv.Cells["DonGia"].Value.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(tbxTenSP.Text == "" || tbxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Menu_DTO Menu_DTO = new Menu_DTO();
            Menu_DTO.MaSP = tbxMaSP.Text;
            Menu_DTO.TenSP = tbxTenSP.Text;
            Menu_DTO.LoaiSP = tbxLoaiSP.Text;
            Menu_DTO.DVT = tbxDVT.Text;
            Menu_DTO.DonGia = Int32.Parse(tbxDG.Text);
            if (Menu_BUS.Them_Menu_1(Menu_DTO) == true)
            {
                MessageBox.Show("Thêm Thành Công!");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (tbxTenSP.Text == "" || tbxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Menu_DTO Menu_DTO = new Menu_DTO();
            Menu_DTO.MaSP = tbxMaSP.Text;
            Menu_DTO.TenSP = tbxTenSP.Text;
            Menu_DTO.LoaiSP = tbxLoaiSP.Text;
            Menu_DTO.DVT = tbxDVT.Text;
            Menu_DTO.DonGia = Int32.Parse(tbxDG.Text);
            if (Menu_BUS.Sua_Menu_1(Menu_DTO) == true)
            {
                MessageBox.Show("Sua Thành Công!");
            }
            else
            {
                MessageBox.Show("Sua Thất Bại!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbxTenSP.Text == "" || tbxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Menu_DTO Menu_DTO = new Menu_DTO();
            Menu_DTO.MaSP = tbxMaSP.Text;
            Menu_DTO.TenSP = tbxTenSP.Text;
            Menu_DTO.LoaiSP = tbxLoaiSP.Text;
            Menu_DTO.DVT = tbxDVT.Text;
            Menu_DTO.DonGia = Int32.Parse(tbxDG.Text);
            if (Menu_BUS.Xoa_Menu_1(Menu_DTO) == true)
            {
                MessageBox.Show("Xoa Thành Công!");
            }
            else
            {
                MessageBox.Show("Xoa Thất Bại!");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureLoad_2_Click(object sender, EventArgs e)
        {
            List<Menu_DTO> Menu_2 = Menu_BUS.Menu_Main_2();
            dataGridView2.DataSource = Menu_2;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView2.CurrentRow;
            tbxMaSP.Text = dgvr.Cells["MaSP"].Value.ToString();
            tbxTenSP.Text = dgvr.Cells["TenSP"].Value.ToString();
            tbxLoaiSP.Text = dgvr.Cells["LoaiSP"].Value.ToString();
            tbxDVT.Text = dgvr.Cells["DVT"].Value.ToString();
            tbxDG.Text = (dgvr.Cells["DonGia"].Value.ToString());
        }

        private void pictureBoxLoad3_Click(object sender, EventArgs e)
        {
            List<Menu_DTO> Menu = Menu_BUS.List_Menu_3();
            dataGridView3.DataSource = Menu;
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView3.CurrentRow;
            tbxMaSP.Text = dgvr.Cells["MaSP"].Value.ToString();
            tbxTenSP.Text = dgvr.Cells["TenSP"].Value.ToString();
            tbxLoaiSP.Text = dgvr.Cells["LoaiSP"].Value.ToString();
            tbxDVT.Text = dgvr.Cells["DVT"].Value.ToString();
            tbxDG.Text = (dgvr.Cells["DonGia"].Value.ToString());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Menu_DTO Searching = new Menu_DTO();
            Searching.TenSP = tbxSearch.Text; 
            List<Menu_DTO> List_1 = Menu_BUS.Search_1( Searching);
            dataGridView1.DataSource = List_1;
            List<Menu_DTO> List_2 = Menu_BUS.Search_2(Searching);
            dataGridView2.DataSource = List_2;
            List<Menu_DTO> List_3 = Menu_BUS.Search_3(Searching);
            dataGridView3.DataSource = List_3;


        }
    }
}
