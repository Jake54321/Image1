using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace USASchedulerASPWEB
{
    public class Config
    {

        public static string ConfigConnection = "Default";

        public static DataTable SelectSchools()
        {

            DataTable Result = ExecuteQueryDT("[dbo].[cfg_SelectSchools]", ConfigConnection);
            return Result;
        }

        public static DataTable ExecuteQueryDT(string query, string Connection)
        {
            DataTable dt = new DataTable();
            string ConnectionString = ConfigurationManager.ConnectionStrings[Connection].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage(ex.Message);
            }

            conn.Close();
            conn.Dispose();

            return dt;
        }

        public static DataTable LoginUser(string LoginId, string Password, string SchoolId)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@LoginId", SqlDbType.VarChar, 10) { Value = LoginId},
                new SqlParameter("@Password", SqlDbType.VarChar, 50) { Value = Password },
                new SqlParameter("@SchoolId", SqlDbType.VarChar, 10) { Value = SchoolId }
            };

            DataTable Result = ExecuteParameterQueryDT("dbo.cfg_LoginUser", ConfigConnection, parameters);

            return Result;
        }

        public static string ReturnDataColumns(DataRow dr, string ColumnName)
        {
            if (dr[ColumnName] != DBNull.Value)
                return dr[ColumnName].ToString();
            else
                return "";
        }


        private static DataTable ExecuteParameterQueryDT(string query, string Connection, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            string ConnectionString = ConfigurationManager.ConnectionStrings[Connection].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < parameters.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parameters[i].ParameterName, parameters[i].Value);
                }

                try
                {
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }
                catch (Exception ex)
                {
                    LogErrorMessage(ex.Message);
                }
            }

            conn.Close();
            conn.Dispose();

            return dt;
        }

        private static void LogErrorMessage(string ErrorMessage)
        {

        }

    }
}
