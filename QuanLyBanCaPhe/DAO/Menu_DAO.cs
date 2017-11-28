
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
    public class Menu_DAO
    {
        public static Provider sprovider;
        public  static SqlConnection conn;
        public static List<Menu_DTO> List_Menu_1()
        {
            string sQuery1 = "Select * From MENU Where Loai_SP like N'Thức Ăn'";
            sprovider = new Provider();

            DataTable dt = sprovider.GetData(sQuery1);
            
            List<Menu_DTO> Menu = new List<Menu_DTO>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu.Add(Me);
            }
            return Menu;
            
        }

        public static bool Them_Menu_1(Menu_DTO Menu_DTO)
        {
                
            try
            {
                //string sQuery2 = "Insert into MENU(Ma_SP,Ten_SP,Loai_SP,DVT,Don_Gia) values(@Ma_SP,Ten_SP,Loai_SP,@DVT,@DG)";
                //SqlCommand cmd = conn.CreateCommand();
                //cmd.CommandText = sQuery2;

                //SqlParameter MASP = new SqlParameter("@Ma_SP", SqlDbType.Char);
                //MASP.Value = Menu_DTO.MaSP;
                //cmd.Parameters.Add(MASP);

                //SqlParameter TENSP = new SqlParameter("@Ten_SP", SqlDbType.NVarChar);
                //TENSP.Value = Menu_DTO.TenSP;
                //cmd.Parameters.Add(TENSP);

                //SqlParameter LOAI = new SqlParameter("@Loai_SP", SqlDbType.NVarChar);
                //LOAI.Value = Menu_DTO.LoaiSP;
                //cmd.Parameters.Add(LOAI);

                //SqlParameter DVT = new SqlParameter("@DVT", SqlDbType.NVarChar);
                //DVT.Value = Menu_DTO.LoaiSP;
                //cmd.Parameters.Add(DVT);

                //SqlParameter DG = new SqlParameter("@DG", SqlDbType.Int);
                //DG.Value = Menu_DTO.DonGia;
                //cmd.Parameters.Add(DG);
                //int count = cmd.ExecuteNonQuery();
                string sQuery2 = string.Format("Insert into MENU(Ma_SP,Ten_SP,Loai_SP,DVT,Don_Gia) Values('{0}',N'{1}',N'{2}',N'{3}',{4})", Menu_DTO.MaSP, Menu_DTO.TenSP, Menu_DTO.LoaiSP, Menu_DTO.DVT, Menu_DTO.DonGia);
                Provider provider = new Provider();
                var u = provider.ExcuteData(sQuery2);                
                return true;
                conn.Close();
            }
            catch(Exception Ex)
            {
                return false;
                
            }
        }
        public static bool Sua_Menu_1(Menu_DTO Menu_DTO)
        {
            
            try
            {     
                           
                string sQuery2 = string.Format("Update MENU set Ten_SP = N'{0}', Loai_SP =N'{1}', DVT = N'{2}', Don_Gia = {3} where Ma_SP = '{4}'", Menu_DTO.TenSP, Menu_DTO.LoaiSP, Menu_DTO.DVT, Menu_DTO.DonGia, Menu_DTO.MaSP);               
                sprovider = new Provider();              
                var u = sprovider.ExcuteData(sQuery2);               
                return true;
                conn.Close();
            }
            catch (Exception Ex)
            {
                return false;
                throw Ex;
            }
        }
        public static bool Xoa_Menu_1(Menu_DTO Menu_DTO)
        {
            try
            {

                string sQuery2 = string.Format("Delete From MENU  where Ma_SP = '{0}'", Menu_DTO.MaSP);
                sprovider = new Provider();
                var u = sprovider.ExcuteData(sQuery2);
                return true;
                conn.Close();
            }
            catch (Exception Ex)
            {
                return false;
                throw Ex;
            }
        }

        public static List<Menu_DTO> List_Menu_2()
        {
            string sQuery = "Select * From MENU where Loai_SP like N'Đồ Uống'";
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);

            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    Menu_DTO Me = new Menu_DTO();
                    Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                    Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                    Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                    Me.DVT = dt.Rows[i]["DVT"].ToString();
                    Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                    Menu_DTO.Add(Me);
                }
            return Menu_DTO;            
        }

        public static List<Menu_DTO> List_Menu_3()
        {
            string squery = "Select * From MENU where Loai_SP like N'Dịch Vụ'";
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(squery);
            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu_DTO.Add(Me);
            }
            return Menu_DTO;
        }
        public static List<Menu_DTO> List_Search_1(Menu_DTO Searching)
        {
            string sQuery = string.Format("Select * From MENU where Loai_SP like N'Thức Ăn' and Ten_SP like N'%{0}%'", Searching.TenSP);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu_DTO.Add(Me);
            }
            return Menu_DTO;
        }
        public static List<Menu_DTO> ListSearch_2(Menu_DTO Searching)
        {
            string sQuery = string.Format("Select * From MENU where Loai_SP like N'Đồ Uống' and Ten_SP like N'%{0}%'", Searching.TenSP);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu_DTO.Add(Me);
            }
            return Menu_DTO;
        }
        public static List<Menu_DTO> ListSearch_3(Menu_DTO Searching)
        {
            string sQuery = string.Format("Select * From MENU where Loai_SP like N'Dịch Vụ' and Ten_SP like N'%{0}%'", Searching.TenSP);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu_DTO.Add(Me);
            }
            return Menu_DTO;
        }
        public static List<Menu_DTO> List_All()
        {
            string sQuery ="Select * From MENU " ;
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<Menu_DTO> Menu_DTO = new List<DTO.Menu_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Menu_DTO Me = new Menu_DTO();
                Me.MaSP = dt.Rows[i]["Ma_SP"].ToString();
                Me.TenSP = dt.Rows[i]["Ten_SP"].ToString();
                Me.LoaiSP = dt.Rows[i]["Loai_SP"].ToString();
                Me.DVT = dt.Rows[i]["DVT"].ToString();
                Me.DonGia = Int32.Parse(dt.Rows[i]["Don_Gia"].ToString());
                Menu_DTO.Add(Me);
            }
            return Menu_DTO;
        }
    }
}
