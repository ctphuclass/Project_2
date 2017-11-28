using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using DTO;

namespace DAO
{
    public class DoanhThu_DAO
    {
        public static SqlConnection conn;
        public static Provider sprovider;
        public static List<DoanhThu_DTO> List_DoanhThu(DoanhThu_DTO DT)
        {
            string sQuery = string.Format("exec [proc_DoanhThu] @TenBan = '{0}',@NgayDau = '{1}',@NgayCuoi='{2}'", DT.Ten_Ban, DT.Ngay_Dau, DT.Ngay_cuoi);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<DoanhThu_DTO> DoanhThu = new List<DoanhThu_DTO>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                DoanhThu_DTO d = new DoanhThu_DTO();
                d.Ten_Ban = dt.Rows[i]["Ten_Ban"].ToString();
                d.Ngay_Lap = DateTime.Parse(dt.Rows[i]["Ngay_Lap"].ToString());
                d.Ten_SP = dt.Rows[i]["Ten_SP"].ToString();
                d.Loai = dt.Rows[i]["Loai_SP"].ToString();
                d.Thanh_Tien = Int32.Parse(dt.Rows[i]["ThanhTien"].ToString());
                DoanhThu.Add(d);
            }
            return DoanhThu;
        }

        public static int TongTienBan(DoanhThu_DTO DT)
        {
            string sQuery = string.Format("exec [proc_TongTienBan] @TenBan = '{0}',@NgayDau = '{1}',@NgayCuoi='{2}'", DT.Ten_Ban, DT.Ngay_Dau, DT.Ngay_cuoi);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                DT.TongThanhTien = Int32.Parse(dt.Rows[0][0].ToString());
            }
            return DT.TongThanhTien;
        }

    }
}
