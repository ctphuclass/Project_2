using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BUS
{
    public class UserBUS
    {
        public static bool CheckUser(UserDTO User)
        {
            return UserDAO.checklogin(User);
        }
    }
}
