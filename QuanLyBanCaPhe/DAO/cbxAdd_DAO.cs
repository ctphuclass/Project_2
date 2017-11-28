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
    public class cbxAdd_DAO
    {
        public static SqlConnection conn;
        public static Provider sprovider;
        public static List<cbxAdd> List_Ban()
        {
            string sQuery = "Select Ma_Ban,Ten_Ban from Ban";
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<cbxAdd> ListBan = new List<cbxAdd>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                cbxAdd Ban = new cbxAdd();
                Ban.Ma_Ban = dt.Rows[i]["Ma_Ban"].ToString();
                Ban.Ten_Ban = dt.Rows[i]["Ten_Ban"].ToString();
                ListBan.Add(Ban);
            }
            return ListBan;
        }
    }
}
