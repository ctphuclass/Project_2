using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class NhanVien_BUS
    {
        public static List<NhanVien_DTO> List_NV()
        {
            return NhanVien_DAO.List_NV();
        }
        public static bool Add_NV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.Add_NV(nv);
        }
        public static bool Update_NV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.Update_NV(nv);
        }
        public static bool Delete_NV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.Delete_NV(nv);
        }
        public static List<NhanVien_DTO> Search_NV(NhanVien_DTO nv)
        {
            return NhanVien_DAO.List_Search(nv);
        }
    }
}
