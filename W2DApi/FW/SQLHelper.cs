using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2DApi.Models;

namespace W2DApi.SQL
{
    public class SQLHelper
    {
        internal bool GenerateOTP(string mobileNumber, string otp)
        {
            SQLBase sqlBase = new SQLBase();
            string procedure = "GenerateOTP";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@MobileNumber", mobileNumber));
            sqlParameters.Add(new SqlParameter("@OTP", otp));

            bool ds = sqlBase.ExecuteStoredProcedure(procedure, sqlParameters);
            return ds;
            //if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1 && ds.Tables[0].Rows[0]["MobileNumber"] != null)
            //{
            //    return ds.Tables[0].Rows[0].Field<string>("OTP");
            //}
            //else
            //    return string.Empty;
        }

        //public DataSet GetAttendanceEvents()
        //{
        //    SQLBase sqlBase = new SQLBase();
        //    return sqlBase.GetDataSetFromProcedure("at_getAttendanceEvents");
        //}

        //public bool UpdateAttendanceHourRecord(DateTime TransactionDate, string Employee)
        //{
        //    SQLBase sqlBase = new SQLBase();
        //    string procedure = "at_UpdateAttendanceHour";

        //    List<SqlParameter> sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@TransactionDate", TransactionDate));
        //    sqlParameters.Add(new SqlParameter("@Employee", Employee));

        //    return sqlBase.ExecuteStoredProcedure(procedure,sqlParameters);
        //}

        internal bool VerifyUniqueMobile(string mobileNumber)
        {
            SQLBase sqlBase = new SQLBase();
            string procedure = "VerifyUniqueMobile";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@MobileNumber", mobileNumber));

            DataSet ds = sqlBase.GetDataSetFromProcedure(procedure, sqlParameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1 && ds.Tables[0].Rows[0]["MobileNumber"] != null)
            {
                return false;// ds.Tables[0].Rows[0].Field<string>("MobileNumber") == mobileNumber;
            }
            else
                return true;
        }

        internal object GetReferralDetails(string referralCode)
        {
            SQLBase sqlBase = new SQLBase();
            string procedure = "GetReferralDetails";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ReferralCode", referralCode));

            DataSet ds = sqlBase.GetDataSetFromProcedure(procedure, sqlParameters);
            if (ds.Tables.Count > 0
                && ds.Tables[0].Rows.Count == 1
                && ds.Tables[0].Rows[0]["Name"] != null)
            {
                return ds.Tables[0].Rows[0].Field<string>("Name");
            }
            else
            {
                return string.Empty;
            }
        }

        internal bool SaveUser(RegisterModal registerModal)
        {
            SQLBase sqlBase = new SQLBase();
            string procedure = "SaveUser";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@FirstName", registerModal.FirstName));
            sqlParameters.Add(new SqlParameter("@LastName", registerModal.LastName));
            sqlParameters.Add(new SqlParameter("@MobileNo", registerModal.MobileNo));
            sqlParameters.Add(new SqlParameter("@Pincode", registerModal.Pincode));
            sqlParameters.Add(new SqlParameter("@ReferralCode", registerModal.ReferralCode));
            
            return sqlBase.ExecuteStoredProcedure(procedure, sqlParameters);
        }

        internal DataRow GetUserFromMobileNumber(string mobileNumber)
        {
            throw new NotImplementedException();
        }

        internal bool VerifyOTP(string mobileNumber, string otp)
        {
            SQLBase sqlBase = new SQLBase();
            string procedure = "VerifyOTP";

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@MobileNumber", mobileNumber));
            sqlParameters.Add(new SqlParameter("@OTP", otp));

            DataSet ds = sqlBase.GetDataSetFromProcedure(procedure, sqlParameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1 
                && ds.Tables[0].Rows[0]["Status"] != null)
            {
                return ds.Tables[0].Rows[0].Field<string>("Status") == "Valid";
            }
            else
                return false;
        }

        //public DataSet GetTestAttendanceEvents()
        //{
        //    SQLBase sqlBase = new SQLBase();
        //    return sqlBase.GetDataSetFromProcedure("at_temp_getAttendanceEvents");
        //}

        //public bool UpdateAttendanceEventFieldValue(string fieldName, string fieldValue, int rowId)
        //{
        //    //[at_UpdateAttendanceEventFieldValue]
        //    SQLBase sqlBase = new SQLBase();
        //    string procedure = "at_UpdateAttendanceEventFieldValue";

        //    List<SqlParameter> sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@FieldName", fieldName));
        //    sqlParameters.Add(new SqlParameter("@FieldValue", fieldValue));
        //    sqlParameters.Add(new SqlParameter("@Id", rowId));

        //    return sqlBase.ExecuteStoredProcedure(procedure, sqlParameters);
        //}

        //public string GetAttendanceEventFieldValue(string fieldName, int rowId)
        //{
        //    SQLBase sqlBase = new SQLBase();
        //    string procedure = "at_GetAttendanceEventFieldValue";

        //    List<SqlParameter> sqlParameters = new List<SqlParameter>();
        //    sqlParameters.Add(new SqlParameter("@FieldName", fieldName));
        //    sqlParameters.Add(new SqlParameter("@Id", rowId));

        //    DataSet ds = sqlBase.GetDataSetFromProcedure(procedure, sqlParameters);
        //    if(ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1 && ds.Tables[0].Rows[0]["FieldValue"] != null)
        //    {
        //        return ds.Tables[0].Rows[0].Field<string>("FieldValue");
        //    }
        //    return string.Empty;
        //}
    }
}
