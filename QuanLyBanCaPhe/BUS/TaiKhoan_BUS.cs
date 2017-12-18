using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static string SAve_dt { get; set; }
        public static List<TaiKhoan_DTO> List_TK(TaiKhoan_DTO tk)
        {
             return TaiKhoan_DAO.List_TK(tk);
        }
        public static Results Change_Pass(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.Change_Pass(tk);
        }
        public static Results Create_User(TaiKhoan_DTO tk)
        {
            return TaiKhoan_DAO.Create_User(tk);
        }
    }
}
