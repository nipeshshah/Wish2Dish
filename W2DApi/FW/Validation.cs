using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2DApi.FW
{
    public class Validation
    {
        public bool VMobile(string MobileNumber, out List<String> errors)
        {
            errors = new List<string>();
            errors.AddRange(VRequiredString(MobileNumber));
            errors.AddRange(VLength(MobileNumber, 10));
            return errors.Count > 0;
        }

        private List<String> VLength(string text, int minlength, int maxlength)
        {
            if (text != null && text.Length >= minlength && text.Length <= maxlength )
                return new List<string>();
            else
                return new List<string>() { $"Invalid length. Must be between ${minlength} and ${maxlength} characters." };
        }

        private List<String> VLength(string text, int length)
        {
            if (text != null && text.Length == length)
                return new List<string>();
            else
                return new List<string>() { $"Invalid length. Must be equal to ${length} characters." };
        }

        public List<String> VRequiredString(string text)
        {
            if (text != null && text.Trim().Length > 0)
                return new List<string>();
            else
                return new List<string>() { $"Empty text not allowed." };
        }
    }
}
