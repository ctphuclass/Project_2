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
    public class Ban_DAO
    {
        public static SqlConnection conn;
        public static Provider sprovider;
        //ban
        public static List<Ban_DTO> List_Ban()
        {
            string sQuery = "select * from Ban ";
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);

            List<Ban_DTO> list_ban = new List<Ban_DTO>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Ban_DTO Ban = new Ban_DTO();
                Ban.Ma_Ban = dt.Rows[i]["Ma_Ban"].ToString();
                Ban.Tenn_Ban = dt.Rows[i]["Ten_Ban"].ToString();
                Ban.Ma_KV = dt.Rows[i]["Ma_KV"].ToString();
                Ban.Tinh_Trang = dt.Rows[i]["Tinh_Trang"].ToString();
                Ban.So = Int32.Parse(dt.Rows[i]["So_TT"].ToString());                
                list_ban.Add(Ban);
            }
            return list_ban;
        }
        public static bool Them_Ban(Ban_DTO Ban_DTO)
        {

            try
            {
                string sQuery2 = string.Format("Insert into Ban(Ma_Ban,Ten_Ban,Ma_KV,Tinh_Trang,So_TT) Values('{0}',N'{1}',N'{2}','{3}',{4})", Ban_DTO.Ma_Ban, Ban_DTO.Tenn_Ban, Ban_DTO.Ma_KV, Ban_DTO.Tinh_Trang, Ban_DTO.So);
                Provider provider = new Provider();
                var u = provider.ExcuteData(sQuery2);
                return true;
                conn.Close();
            }
            catch (Exception Ex)
            {
                return false;

            }
        }
        public static Results Sua_Ban(Ban_DTO Ban_DTO)
        {

            //try
            //{
            //    string sQuery2 = string.Format("Update Ban set Ten_Ban = N'{0}', Ma_KV =N'{1}', Tinh_Trang = '{2}', So_TT = {3} where Ma_Ban = '{4}'", Ban_DTO.Tenn_Ban, Ban_DTO.Ma_KV, Ban_DTO.Tinh_Trang, Ban_DTO.So, Ban_DTO.Ma_Ban);
            //    sprovider = new Provider();
            //    var u = sprovider.ExcuteData(sQuery2);
            //    return true;
            //    conn.Close();
            //}
            //catch (Exception Ex)
            //{
            //    return false;

            //}
            Results re = new Results();
            try
            {
                //string sQuery = string.Format("exec proc_UpdateNV @TenNV=N'{0}',@GT='{1}',@DiaChi=N'{2}',@SDT='{3}',@Email='{4}',@Ngay_Sinh ='{5}',@Chuc_Vu=N'{6}',@NVL='{7}',@Luong={8},@MaNV='{9}'", nv.TenNV, nv.GioiTinh, nv.DiaChi, nv.SDT, nv.Email, nv.NgaySinh, nv.ChucVu, nv.NgayVaoLam, nv.Luong, nv.MaNV);
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("proc_UpdateBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ma_Ban", Ban_DTO.Ma_Ban);
                cmd.Parameters.AddWithValue("@Ten_Ban", Ban_DTO.Tenn_Ban);
                cmd.Parameters.AddWithValue("@Ma_KV", Ban_DTO.Ma_KV);
                cmd.Parameters.AddWithValue("@Tinh_Trang", Ban_DTO.Tinh_Trang);
                cmd.Parameters.AddWithValue("@So_TT", Ban_DTO.So);
                cmd.Parameters.AddWithValue("@resutsID", re.ResultID);
                cmd.Parameters.AddWithValue("@Message", re.Message);
                cmd.Parameters["@resutsID"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Message"].Size = 50;
                conn.Open();
                var u = cmd.ExecuteNonQuery();
                re.ResultID = int.Parse(cmd.Parameters["@resutsID"].Value.ToString());
                re.Message = cmd.Parameters["@Message"].Value.ToString();

            }
            catch (Exception ex)
            {
                re.ResultID = -1;
                re.Message = ex.Message;
            }
            return re;
        }
        public static Results Xoa_Ban(Ban_DTO Ban_DTO)
        {

            //try
            //{
            //    string sQuery2 = string.Format("Delete from Ban where Ma_Ban = '{0}'", Ban_DTO.Ma_Ban);
            //    sprovider = new Provider();
            //    var u = sprovider.ExcuteData(sQuery2);
            //    return true;
            //    conn.Close();
            //}
            //catch (Exception Ex)
            //{
            //    return false;

            //}
            Results re = new Results();
            try
            {
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("XoaBan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psMaban", Ban_DTO.Ma_Ban);
                cmd.Parameters.AddWithValue("@pResultCode", re.ResultID);
                cmd.Parameters.AddWithValue("@pResultMessage", re.Message);
                cmd.Parameters["@pResultCode"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pResultMessage"].Size = 50;
                conn.Open();
                var u = cmd.ExecuteNonQuery();
                re.ResultID = int.Parse(cmd.Parameters["@pResultCode"].Value.ToString());
                re.Message = cmd.Parameters["@pResultMessage"].Value.ToString();
            }
            catch (Exception ex)
            {
                re.ResultID = -1;
                re.Message = ex.Message;
            }
            return re;
        }
    }
}
