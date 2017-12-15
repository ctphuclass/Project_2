using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class DoanhThu_BUS
    {
        public static List<DoanhThu_DTO> List_DoanhThu(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.List_DoanhThu(DT);
        }
        public static List<DoanhThu_DTO> List_DoanhThu2(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.List_DoanhThu2(DT);
        }
        public static int TongTienBan(DoanhThu_DTO DT)
        {
             return DoanhThu_DAO.TongTienBan(DT);
        }
        public static int TongTienBan2(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.TongTienBan2(DT);
        }
        public static List<DoanhThu_DTO> List_All(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.List_ALL(DT);
        }
        public static int TongTien_All(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.TongTien_All(DT);
        }
        public static List<DoanhThu_DTO> List_All2(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.List_ALL2(DT);
        }
        public static int TongTien_All2(DoanhThu_DTO DT)
        {
            return DoanhThu_DAO.TongTien_All2(DT);
        }
    }
}
