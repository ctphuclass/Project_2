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
    public class ChiTietHD_DAO
    {
        private static SqlConnection conn;
        private static Provider sprovider;
        public static List<ChiTietHD_DTO> List_CTHD(int Ma_HD)
        {
            string sQuery = string.Format("select * from Chi_Tiet_Hoa_Don where Ma_Hoa_Don = {0}", Ma_HD);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<ChiTietHD_DTO> lisChiTiet = new List<ChiTietHD_DTO>();
            for (int i =0;i<dt.Rows.Count;i++)
            {
                ChiTietHD_DTO ct = new ChiTietHD_DTO();
                ct.TenSP = dt.Rows[i]["TenSP"].ToString();
                ct.SoLuong = Int32.Parse(dt.Rows[i]["So_Luong"].ToString());
                lisChiTiet.Add(ct);
            }
            return lisChiTiet;
        }
        public static bool InsertChiTietHoaDon(int MaHD, string MaSP, string TenSP, int SL)
        {
            try
            {
                string sQuery = string.Format("exec proc_InsertCTHD @MaHD={0}, @MaSP='{1}',@TenSP = N'{2}', @SL={3}", MaHD, MaSP,TenSP, SL);
                sprovider = new Provider();
                var u = sprovider.ExcuteData(sQuery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        public static int GetMaHD()
        {
            try
            {
                string sQuery = "Select Max(Ma_Hoa_Don) From Hoa_Don ";
                sprovider = new Provider();
                //int i = Convert.ToInt32(sprovider.ExcuteScalar(sQuery));
                //return i;
                DataTable dt = sprovider.GetData(sQuery);
                int i = Int32.Parse(dt.Rows[0][0].ToString());
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
            }
        }
    }
}
