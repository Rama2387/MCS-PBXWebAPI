using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSDataLayer
{
    public sealed class SqlHelper
    {
        public static string strConnectionString;         
       

        #region ExecuteNonQuery
        public static void ExecuteNonQuery(string cmdtxt)
        {
            using (SqlConnection cn = new SqlConnection(strConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdtxt, cn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    throw ex;
                }
                cn.Close();

            }
        }

        public static void ExecuteNonQuery(string cmdtxt, List<InputParam> inputParams)
        {
            using (SqlConnection cn = new SqlConnection(strConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(cmdtxt, cn);
                GenerateInputParams(inputParams, cmd);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    throw ex;
                }
                cn.Close();

            }
        }
        #endregion

        #region ExecuteDataTable

        public static DataTable ExecuteDataTable(string cmdtxt, List<InputParam> inputParams)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(strConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdtxt,cn))
                    {
                        GenerateInputParams(inputParams, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //to do serilog
            }
            return dt;
        }

        public static DataTable ExecuteDataTable(string cmdtxt)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(strConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdtxt, cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //to do serilog
            }
            return dt;
        }

        public static DataSet ExecuteDataSet(string cmdtxt, List<InputParam> inputParams)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection cn = new SqlConnection(strConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdtxt, cn))
                    {
                        GenerateInputParams(inputParams, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                //to do serilog
            }
            return ds;
        }

        public static void ExecuteDataTable(string cmdtxt, List<InputParam> inputParams, string cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(strConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdtxt,cn))
                    {
                        cmd.CommandType = cmdType == "SP" ? CommandType.StoredProcedure : CommandType.Text;
                        GenerateInputParams(inputParams, cmd);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //to do serilog
            }
            //return dt;
        }
        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(string cmdtxt, List<InputParam> inputParams)
        {
            SqlConnection cn = new SqlConnection(strConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand(cmdtxt, cn);
            GenerateInputParams(inputParams, cmd);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch { throw; }
        }

        #endregion

        private static void GenerateInputParams(List<InputParam> inputParams, SqlCommand cmd)
        {
            foreach (InputParam inputParam in inputParams)
            {
                cmd.Parameters.Add(inputParam.ParamName, inputParam.ParamType).Value = inputParam.ParamValue;
            }
        }


    }
}
