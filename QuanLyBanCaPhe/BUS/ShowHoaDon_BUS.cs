using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class ShowHoaDon_BUS
    {
        public static List<ShowHoaDown_DTO> ShowHD(string Ma_Ban, int MaHD)
        {
            return ShowHoaDon_DAO.Show_HD(Ma_Ban, MaHD);
        }
       
        
    }
}
