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
    public class NhanVien_DAO
    {
        public static Provider sprovider;
        public static SqlConnection conn;
        public static List<NhanVien_DTO> List_NV()
        {
            string Squery = "exec proc_LoadNV";
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(Squery);
            List<NhanVien_DTO> NV = new List<NhanVien_DTO>();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                NhanVien_DTO N = new NhanVien_DTO();
                N.MaNV = dt.Rows[i]["Ma_NV"].ToString();
                N.TenNV = dt.Rows[i]["Ten_NV"].ToString();
                N.NgaySinh = DateTime.Parse(dt.Rows[i]["Ngay_Sinh"].ToString());
                N.DiaChi = dt.Rows[i]["Dia_Chi"].ToString();
                N.GioiTinh = dt.Rows[i]["Gioi_Tinh"].ToString();
                N.Luong = Int32.Parse(dt.Rows[i]["Luong"].ToString());
                N.NgayVaoLam = DateTime.Parse(dt.Rows[i]["Ngay_Vao_Lam"].ToString());
                N.ChucVu = dt.Rows[i]["Chuc_Vu"].ToString();
                N.Email = dt.Rows[i]["Email"].ToString();
                N.SDT = dt.Rows[i]["SDT"].ToString();
                NV.Add(N);
            }
            return NV;
        }
        public static bool Add_NV(NhanVien_DTO nv)
        {
            try
            {
                string squery = string.Format("exec proc_AddNV @MaNV='{0}',@TenNV=N'{1}',@GT='{2}',@DiaChi=N'{3}',@SDT='{4}',@Email='{5}',@Ngay_Sinh ='{6}',@Chuc_Vu=N'{7}',@NVL='{8}',@Luong={9}", nv.MaNV, nv.TenNV, nv.GioiTinh, nv.DiaChi, nv.SDT, nv.Email, nv.NgaySinh, nv.ChucVu, nv.NgayVaoLam, nv.Luong);
                sprovider = new Provider();
                var u = sprovider.ExcuteData(squery);
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }
        public  static Results Update_NV(NhanVien_DTO nv)
        {
            Results re = new Results();
            try
            {
                //string sQuery = string.Format("exec proc_UpdateNV @TenNV=N'{0}',@GT='{1}',@DiaChi=N'{2}',@SDT='{3}',@Email='{4}',@Ngay_Sinh ='{5}',@Chuc_Vu=N'{6}',@NVL='{7}',@Luong={8},@MaNV='{9}'", nv.TenNV, nv.GioiTinh, nv.DiaChi, nv.SDT, nv.Email, nv.NgaySinh, nv.ChucVu, nv.NgayVaoLam, nv.Luong, nv.MaNV);
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("proc_UpdateNV", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNV);
                cmd.Parameters.AddWithValue("@TenNV",nv.TenNV);
                cmd.Parameters.AddWithValue("@GT", nv.GioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", nv.SDT);
                cmd.Parameters.AddWithValue("@Email", nv.Email);
                cmd.Parameters.AddWithValue("@Ngay_Sinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@Chuc_Vu", nv.ChucVu);
                cmd.Parameters.AddWithValue("@NVL", nv.NgayVaoLam);
                cmd.Parameters.AddWithValue("@Luong", nv.Luong);               
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
            catch(Exception ex)
            {
                re.ResultID = -1;
                re.Message = ex.Message;
            }
            return re;
        }
        public static Results Delete_NV(NhanVien_DTO nv)
        {
            //try
            //{
            //    string sQuery = string.Format("exec proc_DeleteNV @MaNV='{0}'", nv.MaNV);
            //    sprovider = new Provider();
            //    var u = sprovider.ExcuteData(sQuery);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //    throw;
            //}
            Results re = new Results();
            try
            {
                conn = Provider.Connect();
                SqlCommand cmd = new SqlCommand("usp_USER_DeleteUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@psMaNV", nv.MaNV);
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
        public static List<NhanVien_DTO> List_Search(NhanVien_DTO nv)
        {
            string sQuery = string.Format("exec proc_Search @TenNV = N'%{0}%'",nv.TenNV);
            sprovider = new Provider();
            DataTable dt = sprovider.GetData(sQuery);
            List<NhanVien_DTO> NV = new List<NhanVien_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NhanVien_DTO N = new NhanVien_DTO();
                N.MaNV = dt.Rows[i]["Ma_NV"].ToString();
                N.TenNV = dt.Rows[i]["Ten_NV"].ToString();
                N.NgaySinh = DateTime.Parse(dt.Rows[i]["Ngay_Sinh"].ToString());
                N.DiaChi = dt.Rows[i]["Dia_Chi"].ToString();
                N.GioiTinh = dt.Rows[i]["Gioi_Tinh"].ToString();
                N.Luong = Int32.Parse(dt.Rows[i]["Luong"].ToString());
                N.NgayVaoLam = DateTime.Parse(dt.Rows[i]["Ngay_Vao_Lam"].ToString());
                N.ChucVu = dt.Rows[i]["Chuc_Vu"].ToString();
                N.Email = dt.Rows[i]["Email"].ToString();
                N.SDT = dt.Rows[i]["SDT"].ToString();
                NV.Add(N);
            }
            return NV;
        }
            
    }
}
