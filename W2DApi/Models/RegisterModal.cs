using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2DApi.Models
{
    public class RegisterModal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Pincode { get; set; }
        public string ReferralCode { get; set; }
    }
}
