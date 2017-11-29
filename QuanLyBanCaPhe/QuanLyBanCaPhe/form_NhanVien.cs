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
    public partial class form_NhanVien : Form
    {
        public form_NhanVien()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240,230,140);
            button1.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF3209");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label3.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label4.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label5.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label6.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label7.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label8.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label9.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label10.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            label11.BackColor = System.Drawing.ColorTranslator.FromHtml("#BBB7A4");
            btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#27AE60");
            btnUpdate.BackColor = System.Drawing.ColorTranslator.FromHtml("#E67E22");
            btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#F31D2F");
            LoadNV();

            btnAdd.Image = Properties.Resources.add_iconn;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbxSearch_Click(object sender, EventArgs e)
        {
            tbxSearch.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien_DTO nv = new NhanVien_DTO();
                nv.MaNV = tbxMaNV.Text;
                nv.TenNV = tbxTenNV.Text;
                nv.GioiTinh = tbxGT.Text;
                nv.Luong = Int32.Parse(tbxLuong.Text);
                nv.NgaySinh = DateTime.Parse(tbxNgaySinh.Text);
                nv.NgayVaoLam = DateTime.Parse(tbxNgayVaoLam.Text);
                nv.SDT = tbxSDT.Text;
                nv.DiaChi = tbxDC.Text;
                nv.ChucVu = tbxChucVu.Text;
                nv.Email = tbxEmail.Text;
                if (NhanVien_BUS.Add_NV(nv) == true)
                    MessageBox.Show("Thêm Nhân Viên Thành Công!", "Thông Báo");
                else
                    MessageBox.Show("Thêm Nhân Viên Thất Bại!", "Thông Báo");
                tbxMaNV.Text = "";
                tbxTenNV.Text = "";
                tbxGT.Text = "";
                tbxLuong.Text = "";
                tbxNgaySinh.Text = "";
                tbxNgayVaoLam.Text = "";
                tbxSDT.Text = "";
                tbxDC.Text = "";
                tbxChucVu.Text = "";
                tbxEmail.Text = "";
                LoadNV();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên");
            }
     
        }
        public void LoadNV()
        {
            List<NhanVien_DTO> ListNV = NhanVien_BUS.List_NV();
            dataGridView1.DataSource = ListNV;
            dataGridView1.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns["TenNV"].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dataGridView1.Columns["Luong"].HeaderText = "Lương";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dataGridView1.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";
            dataGridView1.Columns["SDT"].HeaderText = "Số Điện Thoại";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dataGridView1.Columns["ChucVu"].HeaderText = "Chức Vụ";
            tbxMaNV.Enabled = false;
            checkBox1.Checked = false;
        }
        

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            DataGridViewRow drvr = dataGridView1.CurrentRow;
            tbxMaNV.Text = drvr.Cells["MaNV"].Value.ToString();
            tbxTenNV.Text = drvr.Cells["TenNV"].Value.ToString();
            tbxGT.Text = drvr.Cells["GioiTinh"].Value.ToString();
            tbxLuong.Text = drvr.Cells["Luong"].Value.ToString();
            tbxNgaySinh.Text = drvr.Cells["NgaySinh"].Value.ToString();
            tbxNgayVaoLam.Text = drvr.Cells["NgayVaoLam"].Value.ToString();
            tbxSDT.Text = drvr.Cells["SDT"].Value.ToString();
            tbxDC.Text = drvr.Cells["DiaChi"].Value.ToString();
            tbxChucVu.Text = drvr.Cells["ChucVu"].Value.ToString();
            tbxEmail.Text = drvr.Cells["Email"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxMaNV.Text == "" || tbxTenNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin!");
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = tbxMaNV.Text;
            nv.TenNV = tbxTenNV.Text;
            nv.GioiTinh = tbxGT.Text;
            nv.Luong = Int32.Parse(tbxLuong.Text);
            nv.NgaySinh = DateTime.Parse(tbxNgaySinh.Text);
            nv.NgayVaoLam = DateTime.Parse(tbxNgayVaoLam.Text);
            nv.SDT = tbxSDT.Text;
            nv.DiaChi = tbxDC.Text;
            nv.ChucVu = tbxChucVu.Text;
            nv.Email = tbxEmail.Text;
            if (NhanVien_BUS.Update_NV(nv) == true)
                MessageBox.Show("Sửa Nhân Viên Thành Công!", "Thông Báo");
            else
                MessageBox.Show("Sửa Nhân Viên Thất Bại!", "Thông Báo");
            tbxMaNV.Text = "";
            tbxTenNV.Text = "";
            tbxGT.Text = "";
            tbxLuong.Text = "";
            tbxNgaySinh.Text = "";
            tbxNgayVaoLam.Text = "";
            tbxSDT.Text = "";
            tbxDC.Text = "";
            tbxChucVu.Text = "";
            tbxEmail.Text = "";
            LoadNV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tbxMaNV.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập thông tin!");
            }
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.MaNV = tbxMaNV.Text;
            if (NhanVien_BUS.Delete_NV(nv) == true)
                MessageBox.Show("Xóa Nhân Viên Thành Công!", "Thông Báo");
            else
                MessageBox.Show("Xóa Nhân Viên Thất Bại!", "Thông Báo");
            tbxMaNV.Text = "";
            tbxTenNV.Text = "";
            tbxGT.Text = "";
            tbxLuong.Text = "";
            tbxNgaySinh.Text = "";
            tbxNgayVaoLam.Text = "";
            tbxSDT.Text = "";
            tbxDC.Text = "";
            tbxChucVu.Text = "";
            tbxEmail.Text = "";
            LoadNV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            NhanVien_DTO nv = new NhanVien_DTO();
            nv.TenNV = tbxSearch.Text;
            List<NhanVien_DTO> Search = NhanVien_BUS.Search_NV(nv);
            dataGridView1.DataSource = Search;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoadNV();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                // MessageBox.Show("Chỉ chọn mục này khi bạn muốn thêm 1 nhân viên mới", "Cảnh báo",MessageBoxButtons.OKCancel);
                //if( == DialogResult.OK)
                tbxMaNV.Enabled = true;
            }
        }
    }
}
