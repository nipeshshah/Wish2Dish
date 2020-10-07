using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2DApi.FW
{
    public class SMSHelper
    {
        internal bool SendOTP(string mobileNumber, string otp)
        {
            return true;
        }

        internal bool SendRegisterSuccessMessage(string mobileNumber)
        {
            throw new NotImplementedException();
        }

        internal bool SendReferralJoinedMessage(string v)
        {
            throw new NotImplementedException();
        }
    }
}
