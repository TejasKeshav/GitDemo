using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.Model
{
    public class RestResponse
    {
        private int statusCode;
        private String responseData;

        public RestResponse(int statusCode,String responseData)
        { 
        this.statusCode = statusCode;
            this.responseData = responseData;
        }

        public int StatusCode
        {
            get
            { 
            return statusCode;
            }
        }

        public String ResponseData
        {
            get
            {
                return responseData;
            }
        }

        public String ResponseContent { get; internal set; }

        public override String ToString()
        {
            return String.Format("StatusCode : {0} ResponseData : {1},statusCode,responseData");
        }
    }
}
