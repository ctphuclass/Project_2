using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class Ban_BUS
    {
        public static int tablewidth = 100;
        public static int tableheight = 100;
        public static List<Ban_DTO> List_Ban()
        {
            return Ban_DAO.List_Ban();
        }
    }
}
