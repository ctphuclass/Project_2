using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class TaiKhoan_DAO
    {
        private static SqlConnection conn;
        private static Provider sprovider;
        public static List<TaiKhoan_DTO> List_TK(TaiKhoan_DTO tk)
        {
            try
            {
                string sQuery = string.Format("exec proc_LoadTK @MANV = '{0}'", tk.Username);
                sprovider = new Provider();
                //var u = sprovider.ExcuteData(sQuery);
                DataTable dt = sprovider.GetData(sQuery);
                List<TaiKhoan_DTO> lslTK = new List<TaiKhoan_DTO>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TaiKhoan_DTO t = new TaiKhoan_DTO();
                    t.PassWord = dt.Rows[i]["PassWord"].ToString();
                    t.TenNV = dt.Rows[i]["Ten_NV"].ToString();
                    t.Chucvu = dt.Rows[i]["Chuc_Vu"].ToString();
                    lslTK.Add(t);
                }
                return lslTK;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public static Results Change_Pass(TaiKhoan_DTO tk)
        {
            Results re = new Results();
            try
            {
                SqlConnection conn = Provider.Connect();
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_USER_ChangePassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psUsername", tk.Username);
                cmd.Parameters.AddWithValue("@psPassword", tk.PassWord);
                cmd.Parameters.AddWithValue("@psChangePasword", tk.newPassWord);
                cmd.Parameters.AddWithValue("@pResultMessage", re.TK_Message);
                cmd.Parameters.AddWithValue("@pResultCode", re.TK_result);
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultCode"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Size = 50;
                var u = cmd.ExecuteNonQuery();
                re.TK_result = Int32.Parse(cmd.Parameters["@pResultCode"].Value.ToString());
                re.TK_Message = cmd.Parameters["@pResultMessage"].Value.ToString();
            }
            catch(Exception ex)
            {
                re.TK_result = -1;
                re.TK_Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return re;
        }
        public static Results Create_User(TaiKhoan_DTO tk)
        {
            Results re = new Results();
            try
            {
                SqlConnection conn = Provider.Connect();
                conn.Open();
                SqlCommand cmd = new SqlCommand("usp_USER_CreateUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psUsername", tk.Username);
                cmd.Parameters.AddWithValue("@psPassword", tk.PassWord);
                cmd.Parameters.AddWithValue("@pResultMessage", re.Create_message);
                cmd.Parameters.AddWithValue("@pResultCode", re.Create_result);
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultCode"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Size = 50;
            }
            catch (Exception ex)
            {
                re.Create_result = -1;
                re.Create_message = ex.ToString();
            }
            return re;
        }
    }
}
