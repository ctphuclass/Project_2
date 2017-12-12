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
            this.BackColor = Color.FromArgb(240, 230, 140);
            pictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#27AE60");
            pictureBox2.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67E22");
            pictureBox3.BackColor = System.Drawing.ColorTranslator.FromHtml("#F31D2F");
            pictureBox4.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFF2");
            pictureLoad_2.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFF2");
            pictureBoxLoad3.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFF2");
            tabPage1.BackColor = System.Drawing.ColorTranslator.FromHtml("#A69688");
            tabPage2.BackColor = System.Drawing.ColorTranslator.FromHtml("#A69688");
            tabPage3.BackColor = System.Drawing.ColorTranslator.FromHtml("#A69688");

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoadMenu1();
        }
        public void LoadMenu1()
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
            tbxMaSP.Text = "";
            tbxTenSP.Text = "";
            tbxLoaiSP.Text = "";
            tbxDVT.Text = "";
            tbxDG.Text = "";
            checkBox1.Checked = false;
            tbxMaSP.Enabled = false;
            LoadMenu1();
            LoadMenu2();
            LoadMenu3();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (tbxTenSP.Text == "" || tbxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Results rs = new Results();
            Menu_DTO Menu_DTO = new Menu_DTO();
            Menu_DTO.MaSP = tbxMaSP.Text;
            Menu_DTO.TenSP = tbxTenSP.Text;
            Menu_DTO.LoaiSP = tbxLoaiSP.Text;
            Menu_DTO.DVT = tbxDVT.Text;
            Menu_DTO.DonGia = Int32.Parse(tbxDG.Text);
            rs = Menu_BUS.Sua_Menu_1(Menu_DTO);
            if (rs.ResultID > 0)
                MessageBox.Show(rs.Message);
            else
                MessageBox.Show(rs.Message);
            //if (Menu_BUS.Sua_Menu_1(Menu_DTO) == true)
            //{
            //    MessageBox.Show("Sua Thành Công!");
            //}
            //else
            //{
            //    MessageBox.Show("Sua Thất Bại!");
            //}
            tbxMaSP.Text = "";
            tbxTenSP.Text = "";
            tbxLoaiSP.Text = "";
            tbxDVT.Text = "";
            tbxDG.Text = "";
            LoadMenu1();
            LoadMenu2();
            LoadMenu3();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (tbxTenSP.Text == "" || tbxMaSP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu!");
                return;
            }
            Results rs = new Results();
            Menu_DTO Menu_DTO = new Menu_DTO();
            Menu_DTO.MaSP = tbxMaSP.Text;
            Menu_DTO.TenSP = tbxTenSP.Text;
            Menu_DTO.LoaiSP = tbxLoaiSP.Text;
            Menu_DTO.DVT = tbxDVT.Text;
            Menu_DTO.DonGia = Int32.Parse(tbxDG.Text);
            rs = Menu_BUS.Xoa_Menu_1(Menu_DTO);
            if (rs.ResultID > 0)
                MessageBox.Show(rs.Message);
            else
                MessageBox.Show(rs.Message);
            //if (Menu_BUS.Xoa_Menu_1(Menu_DTO) == true)
            //{
            //    MessageBox.Show("Xoa Thành Công!");
            //}
            //else
            //{
            //    MessageBox.Show("Xoa Thất Bại!");
            //}
            tbxMaSP.Text = "";
            tbxTenSP.Text = "";
            tbxLoaiSP.Text = "";
            tbxDVT.Text = "";
            tbxDG.Text = "";
            LoadMenu1();
            LoadMenu2();
            LoadMenu3();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureLoad_2_Click(object sender, EventArgs e)
        {
            LoadMenu2();
        }
        public void LoadMenu2()
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
            LoadMenu3();   
        }
        public void LoadMenu3()
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                var i = MessageBox.Show("Chỉ chọn mục này khi bạn muốn thêm 1 nhân viên mới", "Cảnh báo", MessageBoxButtons.OKCancel);
                if (i == DialogResult.OK)
                    tbxMaSP.Enabled = true;
                else
                {
                    checkBox1.Checked = false;
                    return;
                }
            }
            else
                tbxMaSP.Enabled = false;
        }
    }
}
