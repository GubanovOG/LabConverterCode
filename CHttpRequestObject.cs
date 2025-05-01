using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
    public class CHttpRequestObject
    {
        public int HttpRequestId
        {
            get;
            set;
        }

        public string HttpAddress
        {
            get;
            set;
        }

        public string HttpRequestData
        {
            get;
            set;
        }

        public DateTime DateOfRequest
        {
            get;
            set;
        }

        public CHttpRequestObject(int pRequestId,
            string pHttpAddress,
            string pHttpRequestData,
            DateTime pDateOfRequest)
        {
            HttpRequestId = pRequestId;
            HttpAddress = pHttpAddress;
            HttpRequestData = pHttpRequestData;
            DateOfRequest = pDateOfRequest;
        }
    }
}
