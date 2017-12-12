using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class Menu_BUS
    {
        public static List<Menu_DTO> Menu_Main_1()
        {
            return Menu_DAO.List_Menu_1();
        }

        public static bool Them_Menu_1(Menu_DTO Menu_DTO)
        {
            return Menu_DAO.Them_Menu_1(Menu_DTO);
        }
        public static Results Sua_Menu_1(Menu_DTO Menu_DTO)
        {
            return Menu_DAO.Sua_Menu_1(Menu_DTO);
        }
        public static Results Xoa_Menu_1(Menu_DTO Menu_DTO)
        {
            return Menu_DAO.Xoa_Menu_1(Menu_DTO);
        }
        public static List<Menu_DTO> Menu_Main_2()
        {
            return Menu_DAO.List_Menu_2();
        }
        public static List<Menu_DTO> List_Menu_3()
        {
            return Menu_DAO.List_Menu_3();
        }
        public static List<Menu_DTO> Search_1(Menu_DTO Searching)
        {
            return Menu_DAO.List_Search_1(Searching);
        }
        public static List<Menu_DTO> Search_2(Menu_DTO Searching)
        {
            return Menu_DAO.ListSearch_2(Searching);
        }
        public static List<Menu_DTO> Search_3(Menu_DTO Searching)
        {
            return Menu_DAO.ListSearch_3(Searching);
        }
        public static List<Menu_DTO> List_All_Menu()
        {
            return Menu_DAO.List_All();
        }
    }
}
