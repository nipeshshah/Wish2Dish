using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace W2DApi.FW
{
    public class ApiHelper
    {
        public static object Response(HttpStatusCode statusCode, object data)
        {
            return new
            {
                Status = statusCode,
                Data = data
            };
        }

        public static object Response(Exception exception)
        {
            return new
            {
                Status = HttpStatusCode.InternalServerError,
                Data = exception
            };
        }
    }
}
