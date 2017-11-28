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
    }
}
