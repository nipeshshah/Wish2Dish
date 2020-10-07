using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2DApi.FW;

namespace W2DApi.SQL
{
    public class SQLBase
    {
        internal SqlConnection Conn;
        internal void CreateConnection()
        {
            SettingsHelper helper = new SettingsHelper();
            string ConnStr = helper.GetConfigurationValue<string>("DataConnection", ConfigurationTypes.ConnectionString);
            //ConfigurationManager.ConnectionStrings["TFSDataConnection"].ConnectionString;
            Conn = new SqlConnection(ConnStr);
        }

        private DataSet GetDataSet(SqlCommand sqlComm)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return ds;
        }

        private bool ExecuteStoredProcedure(SqlCommand sqlComm)
        {
            try
            {
                Conn.Open();
                sqlComm.ExecuteScalar();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
                //throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        internal bool ExecuteStoredProcedure(string procedureName, List<SqlParameter> sqlParameters)
        {
            SQLBase sqlBase = new SQLBase();
            sqlBase.CreateConnection();
            //string procedure = "at_getAttendanceEvents";

            SqlCommand sqlComm = new SqlCommand(procedureName, sqlBase.Conn);
            sqlComm.Parameters.AddRange(sqlParameters.ToArray());
            sqlComm.CommandType = CommandType.StoredProcedure;

            return sqlBase.ExecuteStoredProcedure(sqlComm);
        }

        internal DataSet GetDataSetFromProcedure(string procedureName)
        {
            SQLBase sqlBase = new SQLBase();
            sqlBase.CreateConnection();
            //string procedure = "at_getAttendanceEvents";

            SqlCommand sqlComm = new SqlCommand(procedureName, sqlBase.Conn);
            sqlComm.CommandType = CommandType.StoredProcedure;

            return sqlBase.GetDataSet(sqlComm);
        }

        internal DataSet GetDataSetFromProcedure(string procedureName, List<SqlParameter> sqlParameters)
        {
            SQLBase sqlBase = new SQLBase();
            sqlBase.CreateConnection();
            //string procedure = "at_getAttendanceEvents";

            SqlCommand sqlComm = new SqlCommand(procedureName, sqlBase.Conn);
            sqlComm.Parameters.AddRange(sqlParameters.ToArray());
            sqlComm.CommandType = CommandType.StoredProcedure;

            return sqlBase.GetDataSet(sqlComm);
        }
    }

    
}
