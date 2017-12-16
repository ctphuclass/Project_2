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
    public partial class form_DoanhThu : Form
    {
        public form_DoanhThu()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 230, 140);
            List<cbxAdd> ListBan = cbxAdd_BUS.ListBan();
            comboBox1.DataSource = ListBan;
            comboBox1.DisplayMember = "Ten_Ban";
            comboBox2.DataSource = ListBan;
            comboBox2.DisplayMember = "Ten_Ban";
            dateTimePicker3.Value = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Ban_DTO> ListBan = Ban_BUS.List_Ban();
            //comboBox1.DataSource = ListBan;
            //comboBox1.DisplayMember = "Ma_Ban";
            //comboBox1.Items.Add("22");
        }

        private void form_DoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(dateTimePicker2.Text) <= DateTime.Parse(dateTimePicker1.Text))
            {
                MessageBox.Show("Mốc thời gian không đúng, Xin nhập lại!");
                dateTimePicker2.Focus();
                return;
            }
            listView1.Items.Clear();

            DoanhThu_DTO dt = new DoanhThu_DTO();
            dt.Ten_Ban = comboBox1.Text;
            dt.Ngay_Dau = DateTime.Parse(dateTimePicker1.Text);
            dt.Ngay_cuoi = DateTime.Parse(dateTimePicker2.Text);
            if (checkBox1.Checked == true)
            {
                
                List<DoanhThu_DTO> List_DoanhThu = DoanhThu_BUS.List_DoanhThu(dt);
                foreach (DoanhThu_DTO item in List_DoanhThu)
                {
                    ListViewItem List_item = new ListViewItem(item.Ten_Ban.ToString());
                    List_item.SubItems.Add(item.Ngay_Lap.ToString());
                    List_item.SubItems.Add(item.Ten_SP.ToString());
                    List_item.SubItems.Add(item.Loai.ToString());
                    List_item.SubItems.Add(item.Thanh_Tien.ToString());
                    listView1.Items.Add(List_item);
                }
                textBox1.Text = Convert.ToString(DoanhThu_BUS.TongTienBan(dt));
            }
            if(checkBox2.Checked == true)
            {
                listView1.Items.Clear();
                List<DoanhThu_DTO> List_DoanhThu = DoanhThu_BUS.List_All(dt);
                foreach (DoanhThu_DTO item in List_DoanhThu)
                {
                    ListViewItem List_item = new ListViewItem(item.Ten_Ban.ToString());
                    List_item.SubItems.Add(item.Ngay_Lap.ToString());
                    List_item.SubItems.Add(item.Ten_SP.ToString());
                    List_item.SubItems.Add(item.Loai.ToString());
                    List_item.SubItems.Add(item.Thanh_Tien.ToString());
                    listView1.Items.Add(List_item);
                }
                textBox1.Text = Convert.ToString(DoanhThu_BUS.TongTien_All(dt));
            }
            if(checkBox1.Checked == false && checkBox2.Checked == false )
            {
                MessageBox.Show("Xin Chon Phuong Thuc!");
            }
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            Printfile(listView1);
        }
        private void Printfile(ListView lv)
        {
            string filename = "";
            SaveFileDialog Save = new SaveFileDialog();
            Save.Title = "In Thống Kê Doanh Thu";
            Save.Filter = "Text File (.txt)|*.txt";
            if(Save.ShowDialog() == DialogResult.OK)
            {
                filename = Save.FileName.ToString();
                if(filename != "")
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename))
                    {
                        sw.WriteLine("Thông tin chi tiết doanh thu từ ngày:{0} đến ngày: {1}", dateTimePicker1.Text, dateTimePicker2.Text);
                        sw.WriteLine("Bàn số : {0}", comboBox1.Text);
                        foreach (ListViewItem item in lv.Items)
                        {
                            sw.WriteLine("{0} {1} {2} {3} {4}", item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text);
                        }
                        sw.WriteLine("Tong tien la: {0}",textBox1.Text);
                    }
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                listView1.Items.Clear();
                checkBox1.Checked = false;
                comboBox1.Enabled = false;
                comboBox1.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                listView1.Items.Clear();
                comboBox1.Enabled = true;
                checkBox2.Checked = false;
            }
            else
            {
                comboBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                listView1.Items.Clear();
                checkBox4.Checked = false;
                comboBox2.Enabled = false;
                comboBox2.Text = "";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                listView1.Items.Clear();
                comboBox2.Enabled = true;
                checkBox3.Checked = false;
            }
            else
            {
                comboBox2.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (DateTime.Now <= DateTime.Parse(dateTimePicker3.Text))
            //{
            //    MessageBox.Show("Mốc thời gian không đúng, Xin nhập lại!");
            //    dateTimePicker3.Focus();
            //    return;
            //}
            listView1.Items.Clear();

            DoanhThu_DTO DT = new DoanhThu_DTO();
            DT.Ten_Ban = comboBox2.Text;
            DT.Ngay_Hien_Tai = DateTime.Parse(dateTimePicker3.Text.ToString());
            if (checkBox4.Checked == true)
            {

                List<DoanhThu_DTO> List_DoanhThu = DoanhThu_BUS.List_DoanhThu2(DT);
                foreach (DoanhThu_DTO item in List_DoanhThu)
                {
                    ListViewItem List_item = new ListViewItem(item.Ten_Ban.ToString());
                    List_item.SubItems.Add(item.Ngay_Lap.ToString());
                    List_item.SubItems.Add(item.Ten_SP.ToString());
                    List_item.SubItems.Add(item.Loai.ToString());
                    List_item.SubItems.Add(item.Thanh_Tien.ToString());
                    listView1.Items.Add(List_item);
                }
                textBox1.Text = Convert.ToString(DoanhThu_BUS.TongTienBan2(DT));
            }
            if (checkBox3.Checked == true)
            {
                listView1.Items.Clear();
                List<DoanhThu_DTO> List_DoanhThu = DoanhThu_BUS.List_All2(DT);
                foreach (DoanhThu_DTO item in List_DoanhThu)
                {
                    ListViewItem List_item = new ListViewItem(item.Ten_Ban.ToString());
                    List_item.SubItems.Add(item.Ngay_Lap.ToString());
                    List_item.SubItems.Add(item.Ten_SP.ToString());
                    List_item.SubItems.Add(item.Loai.ToString());
                    List_item.SubItems.Add(item.Thanh_Tien.ToString());
                    listView1.Items.Add(List_item);
                }
                textBox1.Text = Convert.ToString(DoanhThu_BUS.TongTien_All2(DT));
            }
            if (checkBox3.Checked == false && checkBox4.Checked == false)
            {
                MessageBox.Show("Xin Chon Phuong Thuc!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
