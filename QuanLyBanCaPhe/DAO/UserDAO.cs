using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class UserDAO
    {
        private static SqlConnection conn;
        private static Provider sprovider;
        public static bool checklogin(UserDTO UserDTO)
        {
            try
            {

                //conn = new SqlConnection(@"Data Source=NTDPC\SQLEXPRESS;Initial Catalog=Cafe_New_1;Integrated Security=True");

                string Query = "usp_USER_CheckUser @psUsername, @psPassword";
                conn = Provider.Connect();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);

                SqlParameter User = new SqlParameter("@psUsername", SqlDbType.Char);
                User.Value = UserDTO.manv;
                cmd.Parameters.Add(User);

                SqlParameter Pass = new SqlParameter("@psPassword", SqlDbType.Char);
                Pass.Value = UserDTO.pass;
                cmd.Parameters.Add(Pass);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UserDTO.chucvu = dt.Rows[i]["Chuc_Vu"].ToString();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw;
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
