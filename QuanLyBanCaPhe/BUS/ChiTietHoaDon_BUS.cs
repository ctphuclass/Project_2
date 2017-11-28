using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ChiTietHoaDon_BUS
    {
        public static bool InsertChiTietHoaDon(int MaHDD, string MaSP, string TenSP, int SL)
        {
            return ChiTietHD_DAO.InsertChiTietHoaDon(MaHDD,MaSP,TenSP,SL);
        }
        public static int GetMaHD()
        {
            return ChiTietHD_DAO.GetMaHD();
        }
        public List<ChiTietHD_DTO> List_CT(int Ma_HD)
        {
            return ChiTietHD_DAO.List_CTHD(Ma_HD);
        }

    }
}
