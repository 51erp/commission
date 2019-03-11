using Commission.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Commission
{
    public class SqlHelper
    {

        public static string connectionString = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4}", ConfigurationManager.AppSettings["IPAddr"],ConfigurationManager.AppSettings["Port"], ConfigurationManager.AppSettings["DBName"], ConfigurationManager.AppSettings["UserName"], DEncrypt.Decrypt(ConfigurationManager.AppSettings["Password"]));
        public static SqlConnection OpenConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;

            }
            catch (Exception)
            {
                throw new Exception("数据库连接错误！请设置数据连接或联系管理员。");
            }
        }

        public static SqlDataReader ExecuteReader(string cmdText)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = cmdText;
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return rdr;
                }
                catch(Exception ex)
                {
                    conn.Close();
                    throw new Exception(ex.Message);
                }
            }
        }

        #region ======================== ExecuteNonQuery =========================

        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, null);
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();
            }
        }

        #endregion


        #region ======================== ExecuteScalar =========================


        public static object ExecScalarEx(string strSql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(strSql, conn);
            conn.Open();
            Object objResult = sqlCommand.ExecuteScalar();
            conn.Close();

            return objResult;
        }

        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText, null);
        }

        public static object ExecuteScalar(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }

        public static object ExecuteScalar(SqlConnection conn, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;

                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteScalar();
            }
        }

        #endregion


        #region ======================== ExecuteDataTable =========================

        public static DataTable ExecuteDataTable(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, null);
            }
        }

        public static DataTable ExecuteDataTable(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, parameters);
            }
        }

        public static DataTable ExecuteDataTable(SqlConnection conn, string cmdText, params SqlParameter[] parameters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        #endregion
    }
}
