﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class Provider
    {
        SqlConnection conn;
        public Provider()
        {
            string sQuery = @"Data Source=NTDPC\SQLEXPRESS;Initial Catalog=Cafe_New_1;Integrated Security=True";
            conn = new SqlConnection(sQuery);
        }
        public static SqlConnection Connect()
        {
            string sQuery = @"Data Source=NTDPC\SQLEXPRESS;Initial Catalog=Cafe_New_1;Integrated Security=True";
            SqlConnection con = new SqlConnection(sQuery);
            return con;
        }
        
        public DataTable GetData(string sQuery)
        {
            SqlDataAdapter da = new SqlDataAdapter(sQuery, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool ExcuteData(string sQuery)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                int rowcount = cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ExcuteScalar(string sQuery)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                int rowcount = Convert.ToInt32(cmd.ExecuteScalar());
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
