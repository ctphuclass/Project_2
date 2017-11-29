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
    public class HoaDon_DAO
    {
        private static SqlConnection conn;
        private static Provider sProvider;

        //public string GetUncheckBillIDByTableID(string Ma_Ban)
        //{
        //    sProvider = new Provider();
        //    DataTable data = sProvider.ExcuteData.("SELECT * FROM dbo.Bill WHERE idTable = " + Ma_Ban + " AND status = 0");

        //    if (data.Rows.Count > 0)
        //    {
        //        Bill bill = new Bill(data.Rows[0]);
        //        return bill.ID;
        //    }
        //    return ;
        //}

        public static bool InsertHoaDon(string Ma_Ban)
        {
            try
            {
                sProvider = new Provider();
                string Squery = string.Format("exec proc_InsertHD @Ma_Ban='{0}'", Ma_Ban);
                var u = sProvider.ExcuteData(Squery);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public static  int KTHoaDon(string Ma_Ban)
        {
            try
            {
                string sQuery = string.Format("Select  Ma_Hoa_Don From Hoa_Don where Ma_Ban = '{0}' and Tinh_Trang = 'C'", Ma_Ban);
                sProvider = new Provider();
                DataTable dt = sProvider.GetData(sQuery);
                //List<HoaDon_DTO> HD = new List<HoaDon_DTO>();
                HoaDon_DTO hd = new HoaDon_DTO();

                if (dt.Rows.Count > 0)
                {
                    //HoaDon_DTO a = new HoaDon_DTO(dt.Rows[0]);
                    hd.Ma_Hoa_Don = Int32.Parse(dt.Rows[0][0].ToString());
                    return hd.Ma_Hoa_Don;
                }
                else
                    return -1;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        //public static ToCheckMaBan(string Ma_Ban)
        //{
        //    string sQuery = string.Format("select")
        //}
        public static void TinhTien(int Ma_HD)
        {
            string sQuery = string.Format("Update Hoa_Don set Tinh_Trang = 'R' where Ma_Hoa_Don = {0}", Ma_HD);
            sProvider = new Provider();
            var u = sProvider.ExcuteData(sQuery);
        }
    }
}
