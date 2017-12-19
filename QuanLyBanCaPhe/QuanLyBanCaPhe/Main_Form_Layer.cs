using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DTO;
using DAO;
using BUS;

namespace QuanLyBanCaPhe
{
    public partial class Main_Form_Layer : Form
    {
        int time = 0;
        public Main_Form_Layer()
        {
            InitializeComponent();
            //Main_Form_Layer Main = new Main_Form_Layer();
            //Main.BackColor = Color.FromArgb(236, 135, 14);
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#BE8B5C");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E91818");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E91818");
            LoadBan();
            btnClose.Image = Properties.Resources.Close_icon__1_;
            btnClose.BackColor = System.Drawing.ColorTranslator.FromHtml("#9E5428");
            btnMinimize.Image = Properties.Resources.minimize_icon__1_;
            btnMinimize.BackColor = System.Drawing.ColorTranslator.FromHtml("#BFB992");
            //button1.Image = Properties.Resources.money_icon;
        }

        private void Main_Form_Layer_Load(object sender, EventArgs e)
        {
            //Main_Form_Layer Main = new Main_Form_Layer();
            //Main.BackColor = Color.FromArgb(236, 135, 14);
            List<Menu_DTO> Menu = Menu_BUS.List_All_Menu();
            dataGridView1.DataSource = Menu;
            timer1.Start();
            flp1.AutoScroll = true;
        }
        public void LoadBan()
        {
            flp1.Controls.Clear();
            List<Ban_DTO> ListBan = Ban_BUS.List_Ban();

            foreach (Ban_DTO item in ListBan)
            {
                System.Windows.Forms.Button btn = new System.Windows.Forms.Button()
                {
                    Width = Ban_BUS.tablewidth,
                    Height = Ban_BUS.tableheight
                };
                btn.Text = item.Tenn_Ban + Environment.NewLine + item.Tinh_Trang;
                btn.Image = Properties.Resources.User_icon;
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
            string Ma_Ban = ((sender as System.Windows.Forms.Button).Tag as Ban_DTO).Ma_Ban;
            label2.Text = Ma_Ban;
            listView1.Tag = (sender as System.Windows.Forms.Button).Tag;
            ShowThongTin_Ban(Ma_Ban);
        }
        //private void dataGridView1_Click(object sender, EventArgs e)
        //{
        //    Ban_DTO Table = listView1.Tag as Ban_DTO;
        //    int MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);

        //    DataGridViewRow dgvr = dataGridView1.CurrentRow;

        //    string MaSP = dgvr.Cells["MaSP"].Value.ToString();
        //    string TenSP = dgvr.Cells["TenSP"].Value.ToString();
        //    int SL = 1;
        //    if (MaHD == -1)
        //    {
        //        HoaDon_BUS.InsertHoaDon(Table.Ma_Ban);
        //        int Ma_HDD = ChiTietHD_DAO.GetMaHD();
        //        ChiTietHoaDon_BUS.InsertChiTietHoaDon(Ma_HDD, MaSP, TenSP, SL);
        //        MessageBox.Show("Them mon thanh cong 1!");
        //    }
        //    else
        //    {
        //        ChiTietHoaDon_BUS.InsertChiTietHoaDon(MaHD, MaSP, TenSP, SL);
        //        MessageBox.Show("Them mon thanh cong 2!");
        //    }
        //    ShowThongTin_Ban(Table.Ma_Ban);
        //    LoadBan();

        //    //HoaDon_DTO HD = new HoaDon_DTO();
        //    //if (HoaDon_BUS.InsertHoaDon(HD) == true)
        //    //    MessageBox.Show("Them HD thanh cong");
        //    //else
        //    //    MessageBox.Show("Them Hd that bai");
        //    //InsertCTHD();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int MaHD;
            Ban_DTO Table = listView1.Tag as Ban_DTO;
            if (Table.Ma_Ban == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn thanh toán");
                return;
            }
            else
            {
               MaHD = HoaDon_BUS.KTHoaDon(Table.Ma_Ban);
                if (MaHD != -1)
                {
                    PrintHD();
                    HoaDon_BUS.TinhTien(MaHD);
                    ShowThongTin_Ban(Table.Ma_Ban);
                    LoadBan();
                }
                else
                {
                    MessageBox.Show("Không có danh mục thu tiền!");
                    return;
                }
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
                    MessageBox.Show("Thêm món thành công!");
                }
                ShowThongTin_Ban(Table.Ma_Ban);
                LoadBan();
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi chọn món");
            }

        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //PrintHD(listView1);
        }
        private void PrintHD()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Wordnook|*.xls", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Cà phê The Coffee House";
                    ws.Cells[2, 1] = "Editor: Nguyễn Thành Đạt - Lê Văn Pháp";
                    ws.Cells[3, 4] = "HÓA ĐƠN TÍNH TIỀN";
                    ws.Cells[4, 1] = string.Format("Bàn số {0}", label2.Text);
                    ws.Cells[5, 1] = "Tên SP";
                    ws.Cells[5, 2] = "Số Lượng";
                    ws.Cells[5, 3] = "Đơn vị tính";
                    ws.Cells[5, 4] = "Thành Tiền";

                    int i = 6, tt = 0;
                    foreach (ListViewItem item in listView1.Items)
                    {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        i++;
                        tt = tt + Int32.Parse(item.SubItems[3].Text);
                    }
                    ws.Cells[i + 1, 1] = string.Format("Tổng Tiền là: {0}", tt.ToString());
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    MessageBox.Show("Thanh Toán Thành Công!");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult i = MessageBox.Show("Do you really want exit?", "Information", MessageBoxButtons.YesNo);
            if (i == DialogResult.Yes)
                this.Close();
            else
                return;
        }

        private void btnMinimize_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Main_Form_Layer m = new Main_Form_Layer();
            label3.Location = new System.Drawing.Point(label3.Location.X + 5, label3.Location.Y);
            if(label3.Location.X > 580)
            {
                label3.Location = new System.Drawing.Point(470 - label3.Width, label3.Location.Y);
            }
            if (time == 0)
            {
                label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#D3EBB2");
                timer1.Interval = 200;
                time = 4;
            }
            //if(time == 2)
            //{
            //    label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FF8B55");
            //    time = 4;
            //}
            else
            {
                label3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FADAA3");
                time = 0;
            }
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {           
            
        }
    }
}
