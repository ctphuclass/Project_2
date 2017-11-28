using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class HoaDon_BUS
    {
        public static bool InsertHoaDon(string Ma_Ban)
        {
            return HoaDon_DAO.InsertHoaDon(Ma_Ban);
        }
        public static int KTHoaDon(string Ma_Ban)
        {
           return HoaDon_DAO.KTHoaDon(Ma_Ban);
        }
        //public static bool InsertHoaDon(string Ma_Ban)
        //{
        //    return HoaDon_DAO.InsertHoaDon(Ma_Ban);
        //}
        //public static bool  GetMax()
        //{
        //    return HoaDon_BUS.GetMax();
        //}
        public  static void TinhTien(int Ma_HD)
        {
              HoaDon_DAO.TinhTien(Ma_HD);
        }
    }
}
