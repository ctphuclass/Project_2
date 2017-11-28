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
            if(tbxMaNV.Text == "" || tbxTenNV.Text == "")
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
            if (NhanVien_BUS.Add_NV(nv) == true)
                MessageBox.Show("Thêm Nhân Viên Thành Công!", "Thông Báo");
            else
                MessageBox.Show("Thêm Nhân Viên Thất Bại!", "Thông Báo");
            LoadNV();     
        }
        public void LoadNV()
        {
            List<NhanVien_DTO> ListNV = NhanVien_BUS.List_NV();
            dataGridView1.DataSource = ListNV;
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
    }
}
