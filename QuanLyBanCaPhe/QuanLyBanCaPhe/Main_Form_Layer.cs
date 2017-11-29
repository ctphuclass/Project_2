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
using DAO;
using BUS;

namespace QuanLyBanCaPhe
{
    public partial class Main_Form_Layer : Form
    {
        public Main_Form_Layer()
        {
            InitializeComponent();
            //Main_Form_Layer Main = new Main_Form_Layer();
            //Main.BackColor = Color.FromArgb(236, 135, 14);
            this.BackColor = Color.FromArgb(240, 230, 140);
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F24D16");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F24D16");

            LoadBan();
        }

        private void Main_Form_Layer_Load(object sender, EventArgs e)
        {
            //Main_Form_Layer Main = new Main_Form_Layer();
            //Main.BackColor = Color.FromArgb(236, 135, 14);
            List<Menu_DTO> Menu = Menu_BUS.List_All_Menu();
            dataGridView1.DataSource = Menu;
        }
        public void LoadBan()
        {
            flp1.Controls.Clear();
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();

            foreach (Ban_DTO item in ListBan)
            {
                Button btn = new Button()
                {
                    Width = Ban_BUS.tablewidth,
                    Height = Ban_BUS.tableheight
                };
                btn.Text = item.Tenn_Ban + Environment.NewLine + item.Tinh_Trang;
                string Connectimage = @"C:\Users\Nguyen Thanh Dat\Documents\Visual Studio 2015\Projects\QL_CAFE_SOLUTION\User_icon.png";
                btn.Image = Image.FromFile(Connectimage);
                //btn.Font = new Font(40);
                //Nut click vo tung ban//
                btn.Click += Btn_Click;
                btn.Tag = item;
                //
                switch (item.So)
                {
                    case 1:
                        btn.BackColor = Color.FromArgb(252, 245, 76);
                        break;
                    //case "Off":
                    //    btn.BackColor = Color.Orange;
                    //    break;
                    default:
                        btn.BackColor = Color.FromArgb(233, 53, 57);
                        break;
                }
                flp1.Controls.Add(btn);
            }

        }
        public void ShowThongTin_Ban(string Ma_Ban)
        {

            //List<ChiTietHD_DTO> List_CTHD = ChiTietHD_BUS.List_chiTiet(HoaDon_BUS.ListHD());
            //List<Ban_DTO> Ban = HoaDon_BUS.List_HoaDon(Ma_Ban);
            //List<Ban_DTO> List_Ban = Ban_BUS.List_Ban(Ma_Ban);
            //List<HoaDon_DTO> List_HD = HoaDon_BUS.ListHD();
            listView1.Items.Clear();
            Ban_DTO Table = listView1.Tag as Ban_DTO;
            int MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);
            //List<ChiTietHD_DTO> List_CT = ChiTietHD_DAO.List_CTHD(HoaDon_DAO.KTHoaDon(Ma_Ban));
            List<ShowHoaDown_DTO> show = ShowHoaDon_BUS.ShowHD(Ma_Ban, MaHD);
            foreach (ShowHoaDown_DTO item in show)
            {
                ListViewItem List_item = new ListViewItem(item.Ten_Mon.ToString());
                List_item.SubItems.Add(item.So_Luong.ToString());
                List_item.SubItems.Add(item.DVT.ToString());
                List_item.SubItems.Add(item.Tong_Tien.ToString());
                listView1.Items.Add(List_item);
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            string Ma_Ban = ((sender as Button).Tag as Ban_DTO).Ma_Ban;
            label2.Text = Ma_Ban;
            listView1.Tag = (sender as Button).Tag;
            ShowThongTin_Ban(Ma_Ban);
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            Ban_DTO Table = listView1.Tag as Ban_DTO;
            int MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);

            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            string MaSP = dgvr.Cells["MaSP"].Value.ToString();
            string TenSP = dgvr.Cells["TenSP"].Value.ToString();
            int SL = 1;
            if (MaHD == -1)
            {
                HoaDon_BUS.InsertHoaDon(Table.Ma_Ban);
                int Ma_HDD = ChiTietHD_DAO.GetMaHD();
                ChiTietHoaDon_BUS.InsertChiTietHoaDon(Ma_HDD, MaSP, TenSP, SL);
                MessageBox.Show("Them mon thanh cong 1!");
            }
            else
            {
                ChiTietHoaDon_BUS.InsertChiTietHoaDon(MaHD, MaSP, TenSP, SL);
                MessageBox.Show("Them mon thanh cong 2!");
            }
            ShowThongTin_Ban(Table.Ma_Ban);
            LoadBan();

            //HoaDon_DTO HD = new HoaDon_DTO();
            //if (HoaDon_BUS.InsertHoaDon(HD) == true)
            //    MessageBox.Show("Them HD thanh cong");
            //else
            //    MessageBox.Show("Them Hd that bai");
            //InsertCTHD();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ban_DTO Table = listView1.Tag as Ban_DTO;
            int MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);
            if (MaHD != 1)
            {
                HoaDon_BUS.TinhTien(MaHD);
                ShowThongTin_Ban(Table.Ma_Ban);
                LoadBan();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Ban_DTO Table = listView1.Tag as Ban_DTO;
                int MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);
                DataGridViewRow dgvr = dataGridView1.CurrentRow;
                string MaSP = dgvr.Cells["MaSP"].Value.ToString();
                string TenSP = dgvr.Cells["TenSP"].Value.ToString();
                int SL = 1;
                if (MaHD == -1)
                {
                    HoaDon_BUS.InsertHoaDon(Table.Ma_Ban);
                    int Ma_HDD = ChiTietHD_DAO.GetMaHD();
                    ChiTietHoaDon_BUS.InsertChiTietHoaDon(Ma_HDD, MaSP, TenSP, SL);
                    MessageBox.Show("Thêm món thành công!");
                }
                else
                {
                    ChiTietHoaDon_BUS.InsertChiTietHoaDon(MaHD, MaSP, TenSP, SL);
                    MessageBox.Show("Cộng món thành công!");
                }
                ShowThongTin_Ban(Table.Ma_Ban);
                LoadBan();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi chọn món");
            }

        }
    }
}
