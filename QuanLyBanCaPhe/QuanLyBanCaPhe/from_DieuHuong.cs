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
        int count = 0;
        int time = 0;
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

        private void from_DieuHuong_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true && e.KeyCode == Keys.B)
            {
                bánHàngToolStripMenuItem.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Q)
            {
                quảnLíToolStripMenuItem.ShowDropDown();
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                doanhThuToolStripMenuItem.PerformClick();
            }
            if(e.Control == true && e.KeyCode == Keys.T)
            {
                tàiKhoảnToolStripMenuItem.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if(count ==0)
            {
                this.BackgroundImage = Properties.Resources.caphe;
                count = 2;
                timer1.Interval = 1500;
            }
            else
            {
                if (count == 2)
                {
                    this.BackgroundImage = Properties.Resources.c1;
                    count = 3;
                    timer1.Interval = 1500;
                }
                else
                {
                    if(count == 3)
                    {
                        this.BackgroundImage = Properties.Resources.c2;
                        count = 4;
                        timer1.Interval = 1500;
                    }
                    else
                    {
                        this.BackgroundImage = Properties.Resources.c3;
                        count = 0;
                        timer1.Interval = 1500;
                    }
                    
                }

            }


        }

        private void from_DieuHuong_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(time == 0)
            {
                label2.Text = "Lê Văn Pháp";
                time = 1;
                timer2.Interval = 400;
            }
            else
            {
                label2.Text = "Nguyễn Thành Đạt";
                time = 0;
                timer2.Interval = 400;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Events.Dispose();
            frmLogin lo = new frmLogin();
            lo.Show();
            this.Hide();
            
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TK tk = new Form_TK();
            tk.ShowDialog();
            
        }

        private void from_DieuHuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát không ?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;                
            }
               
        }

        private void from_DieuHuong_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin lo = new frmLogin();
            lo.Dispose();
            lo.Close();

        }
    }
}
