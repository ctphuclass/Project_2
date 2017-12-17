
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
        public static Results Sua_Menu_1(Menu_DTO Menu_DTO)
        {

            //try
            //{     

            //    string sQuery2 = string.Format("Update MENU set Ten_SP = N'{0}', Loai_SP =N'{1}', DVT = N'{2}', Don_Gia = {3} where Ma_SP = '{4}'", Menu_DTO.TenSP, Menu_DTO.LoaiSP, Menu_DTO.DVT, Menu_DTO.DonGia, Menu_DTO.MaSP);               
            //    sprovider = new Provider();              
            //    var u = sprovider.ExcuteData(sQuery2);               
            //    return true;
            //    conn.Close();
            //}
            //catch (Exception Ex)
            //{
            //    return false;
            //    throw Ex;
            //}
            Results re = new Results();
            try
            {
                //string sQuery = string.Format("exec proc_UpdateNV @TenNV=N'{0}',@GT='{1}',@DiaChi=N'{2}',@SDT='{3}',@Email='{4}',@Ngay_Sinh ='{5}',@Chuc_Vu=N'{6}',@NVL='{7}',@Luong={8},@MaNV='{9}'", nv.TenNV, nv.GioiTinh, nv.DiaChi, nv.SDT, nv.Email, nv.NgaySinh, nv.ChucVu, nv.NgayVaoLam, nv.Luong, nv.MaNV);
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("proc_UpdateMENU", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ma_SP", Menu_DTO.MaSP);
                cmd.Parameters.AddWithValue("@Ten_SP", Menu_DTO.TenSP);
                cmd.Parameters.AddWithValue("@Loai_SP", Menu_DTO.LoaiSP);
                cmd.Parameters.AddWithValue("@DVT", Menu_DTO.DVT);
                cmd.Parameters.AddWithValue("@Don_Gia", Menu_DTO.DonGia);                      
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
        public static Results Xoa_Menu_1(Menu_DTO Menu_DTO)
        {
            Results re = new Results();
            try
            {
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("proc_XoaMENU", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psMaSP", Menu_DTO.MaSP);
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
            //try
            //{

            //    string sQuery2 = string.Format("Delete From MENU  where Ma_SP = '{0}'", Menu_DTO.MaSP);
            //    sprovider = new Provider();
            //    var u = sprovider.ExcuteData(sQuery2);
            //    return true;
            //    conn.Close();
            //}
            //catch (Exception Ex)
            //{
            //    return false;
            //    throw Ex;
            //}
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
