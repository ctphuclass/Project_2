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
        public static bool Sua_Ban(Ban_DTO Ban_DTO)
        {

            try
            {
                string sQuery2 = string.Format("Update Ban set Ten_Ban = N'{0}', Ma_KV =N'{1}', Tinh_Trang = '{2}', So_TT = {3} where Ma_Ban = '{4}'", Ban_DTO.Tenn_Ban, Ban_DTO.Ma_KV, Ban_DTO.Tinh_Trang, Ban_DTO.So, Ban_DTO.Ma_Ban);
                sprovider = new Provider();
                var u = sprovider.ExcuteData(sQuery2);
                return true;
                conn.Close();
            }
            catch (Exception Ex)
            {
                return false;

            }
        }
        public static bool Xoa_Ban(Ban_DTO Ban_DTO)
        {

            try
            {
                string sQuery2 = string.Format("Delete from Ban where Ma_Ban = '{0}'", Ban_DTO.Ma_Ban);
                sprovider = new Provider();
                var u = sprovider.ExcuteData(sQuery2);
                return true;
                conn.Close();
            }
            catch (Exception Ex)
            {
                return false;

            }
        }
    }
}
