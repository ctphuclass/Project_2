using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ShowHoaDon_DAO
    {
        private static SqlConnection conn;
        private static Provider sprovider;

        public static List<ShowHoaDown_DTO> Show_HD(string Ma_Ban, int MaHD)
        {
            string sQuery = string.Format("select Hoa_Don.Ma_Hoa_Don,MENU.Ten_SP, Chi_Tiet_Hoa_Don.So_Luong,MENU.DVT,Chi_Tiet_Hoa_Don.So_Luong*MENU.Don_Gia As N'Thanh_Tien' from Ban join Hoa_Don on Ban.Ma_Ban = Hoa_Don.Ma_Ban join Chi_Tiet_Hoa_Don on Hoa_Don.Ma_Hoa_Don = Chi_Tiet_Hoa_Don.Ma_Hoa_Don join MENU on Chi_Tiet_Hoa_Don.Ma_SP = MENU.Ma_SP Where Hoa_Don.Tinh_Trang = 'C' and Ban.Ma_Ban = '{0}' and Hoa_Don.Ma_Hoa_Don = {1}", Ma_Ban,MaHD);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<ShowHoaDown_DTO> List_HD = new List<ShowHoaDown_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ShowHoaDown_DTO Show = new ShowHoaDown_DTO();
                Show.MaHD = Int32.Parse(dt.Rows[i]["Ma_Hoa_Don"].ToString());
                Show.Ten_Mon = dt.Rows[i]["Ten_SP"].ToString();
                Show.So_Luong = Int32.Parse(dt.Rows[i]["So_Luong"].ToString());
                Show.DVT = dt.Rows[i]["DVT"].ToString();
                Show.Tong_Tien = Int32.Parse(dt.Rows[i]["Thanh_Tien"].ToString());
                List_HD.Add(Show);
            }
            return List_HD;
        }
    }
}
    


