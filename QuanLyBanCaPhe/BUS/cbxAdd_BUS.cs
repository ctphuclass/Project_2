using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class cbxAdd_BUS
    {
        public static List<cbxAdd> ListBan()
        {
            return cbxAdd_DAO.List_Ban();
        }
    }
}
