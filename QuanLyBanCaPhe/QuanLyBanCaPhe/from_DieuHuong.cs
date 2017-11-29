using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanCaPhe
{
    public partial class from_DieuHuong : Form
    {
        public from_DieuHuong()
        {
            InitializeComponent();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Form_Layer Main = new Main_Form_Layer();
            Main.ShowDialog();
        }

        private void quảnLíMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_Menu Menu = new form_Menu();
            Menu.ShowDialog();
        }

        private void quảnLíNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_NhanVien NhanVien = new form_NhanVien();
            NhanVien.ShowDialog();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_DoanhThu DT = new form_DoanhThu();
            DT.ShowDialog();
        }

        private void quảnLíBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_Ban Ban = new form_Ban();
            Ban.ShowDialog();
        }
    }
}
