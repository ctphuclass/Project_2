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
        public static int TongTienBan(DoanhThu_DTO DT)
        {
             return DoanhThu_DAO.TongTienBan(DT);
        }
    }
}
