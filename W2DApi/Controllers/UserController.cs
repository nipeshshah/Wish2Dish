using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using W2DApi.FW;
using W2DApi.Models;
using W2DApi.SQL;

namespace W2DApi.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/VerifyUniqueMobile/{MobileNumber}")]
        public object VerifyUniqueMobile(string MobileNumber)
        {
            try
            {
                Validation validation = new Validation();
                SQLHelper helper = new SQLHelper();
                List<string> errors;
                if (validation.VMobile(MobileNumber, out errors))
                {
                    return ApiHelper.Response(HttpStatusCode.ExpectationFailed, errors);
                }

                bool status = helper.VerifyUniqueMobile(MobileNumber);
                return ApiHelper.Response(HttpStatusCode.OK, status);
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        [HttpGet]
        [Route("api/user/GenerateAndSendOTP/{MobileNumber}")]
        public object GenerateAndSendOTP(string MobileNumber)
        {
            try
            {
                //TODO Validations
                SQLHelper helper = new SQLHelper();
                Random random = new Random();
                string otp = random.Next(1000, 9999).ToString();
                //string otp = helper.GenerateOTP(MobileNumber, newCode.ToString());
                if (helper.GenerateOTP(MobileNumber, otp))
                {
                    SMSHelper smshelper = new SMSHelper();
                    bool response = smshelper.SendOTP(MobileNumber, otp);
                    if (response)
                        return ApiHelper.Response(HttpStatusCode.OK, true);
                    else
                        return ApiHelper.Response(new Exception("OTP Generated but SMS Sending Failed."));
                }
                else
                {
                    return ApiHelper.Response(new Exception("OTP Generation Failed. Please try again"));
                }
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        [HttpGet]
        [Route("api/user/VerifyOTP/{MobileNumber}/{otp}")]
        public object VerifyOTP(string MobileNumber, string otp)
        {
            //TODO Validations
            try
            {
                SQLHelper helper = new SQLHelper();
                bool response = helper.VerifyOTP(MobileNumber, otp);
                return ApiHelper.Response(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        [HttpPost]
        [Route("api/user/Save")]
        public object Save(RegisterModal registerModal)
        {
            //TODO Validations
            /*
             var settings = {
                "url": "http://localhost:62054/api/User/Save",
                "method": "POST",
                "timeout": 0,
                "headers": {
                "Content-Type": "application/json"
                },
                "data": JSON.stringify({"FirstName":"U1","LastName":"U11","MobileNo":"8866554488","Pincode":"325896","ReferralCode":"WB00000001"}),
            };

            $.ajax(settings).done(function (response) {
                console.log(response);
            });
            */
            try
            {
                SQLHelper helper = new SQLHelper();
                helper.SaveUser(registerModal);
                return ApiHelper.Response(HttpStatusCode.NotFound, "");
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        [HttpGet]
        [Route("api/user/GetReferralDetails/{ReferralCode}")]
        public object GetReferralDetails(string ReferralCode)
        {
            try
            {
                //TODO Validations
                SQLHelper helper = new SQLHelper();
                bool isValidReferralCode = false;
                if (ReferralCode.StartsWith("W2D1") && ReferralCode.Length == 15)
                {
                    //do nothing
                    isValidReferralCode = true;
                }
                else if(!ReferralCode.StartsWith("W2D1") && ReferralCode.Length <= 11)
                {
                    int rc;
                    Int32.TryParse(ReferralCode, out rc);
                    if(rc > 0)
                    {
                        ReferralCode = "W2D1" + rc.ToString().PadLeft(11,'0');
                        isValidReferralCode = true;
                    }
                }
                else if(!ReferralCode.StartsWith("W2D1") && ReferralCode.Length == 15)
                {
                    isValidReferralCode = true;
                }
                if (!isValidReferralCode)
                    return ApiHelper.Response(new Exception("Invalid Referral Code"));
                else
                {
                    object response = helper.GetReferralDetails(ReferralCode);
                    if(response.ToString().Length > 0)
                        return ApiHelper.Response(HttpStatusCode.OK, response);
                    else
                        return ApiHelper.Response(new Exception("Referral not found."));
                }
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        [HttpGet]
        [Route("api/user/SendRegisterEmail/{MobileNumber}")]
        public object SendRegisterEmail(string MobileNumber)
        {
            try
            {
                //TODO Validations
                SQLDataRowHelper rowHelper = new SQLDataRowHelper();
                SQLHelper sqlHelper = new SQLHelper();
                DataRow user = sqlHelper.GetUserFromMobileNumber(MobileNumber);
                SMSHelper smsHelper = new SMSHelper();
                bool smsreg = smsHelper.SendRegisterSuccessMessage(MobileNumber);
                bool smsref = smsHelper.SendReferralJoinedMessage(rowHelper.GetValue<string>(user, "ReferredByMobileNo"));
                if (smsreg && smsref)
                    return ApiHelper.Response(HttpStatusCode.OK, true);
                else
                    return ApiHelper.Response(HttpStatusCode.BadRequest, "Something went Wrong");
            }
            catch (Exception ex)
            {
                return ApiHelper.Response(ex);
            }
        }

        //public object GetName(int id)
        //{
        //    List<Student> st = new List<Student>();
        //    Student name = new Student()
        //    {
        //        name = "Nipesh Shah",
        //        id = 5,
        //        age = 20.53M
        //    };
        //    st.Add(name);

        //    DataTable dt = new DataTable("Employee");
        //    dt.Columns.Add("A");
        //    dt.Columns.Add("B");
        //    dt.Columns.Add("C", typeof(decimal));
        //    dt.Columns.Add("D", typeof(DateTime));
        //    dt.Rows.Add(1, "Hello", 5.02F, DateTime.Now);
        //    dt.Rows.Add(2, "World", 3.24M, DateTime.Now.AddMinutes(365));

        //    DataTable dt2 = new DataTable("Skills");
        //    dt2.Columns.Add("A");
        //    dt2.Columns.Add("B");
        //    dt2.Columns.Add("C", typeof(decimal));
        //    dt2.Columns.Add("D", typeof(DateTime));
        //    dt2.Rows.Add(1, "Hello", 5.02F, DateTime.Now);
        //    dt2.Rows.Add(2, "World", 3.24M, DateTime.Now.AddMinutes(365));


        //    DataSet ds = new DataSet("CustomDataSet");
        //    ds.Tables.Add(dt);
        //    ds.Tables.Add(dt2); 


        //    if (true)
        //    {
        //        return ApiHelper.Response(HttpStatusCode.Accepted, ds);
        //        //Exception
        //        //return Response(HttpStatusCode.BadRequest, new Exception("Age should be greater then 20"));
        //    }
        //    if (true)
        //    {
        //        //Exception
        //        //return Response(HttpStatusCode.Unauthorized, new UnauthorizedAccessException());
        //    }

        //    //if (name == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //else 
        //    //return Send("Custom Message: Success");
        //    //return Response(HttpStatusCode.OK, name);
        //    //if (st.Count == 0)
        //    //{
        //    //    return ResponseMessage(new HttpResponseMessage()
        //    //    {
        //    //        Content = new StringContent("Data Not Found"),
        //    //        StatusCode = HttpStatusCode.NoContent,
        //    //        RequestMessage = Request
        //    //    });
        //    //}
        //    //else
        //    //{
        //    //    return Ok(st);
        //    //}
        //}
    }
}
