using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
  public  class CHttpResponseObject
    {
        public int HttpResponseId
        {
            get;
            set;
        }
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

        public string HttpResponseData
        {
            get;
            set;
        }

        public int HttpStatus
        {
            get;
            set;
        }

        public DateTime DateOfRequest
        {
            get;
            set;
        }

        public CHttpResponseObject(int pRequestId,
            string pHttpAddress,
            string pHttpRequestData,
            string pHttpResponseData,
            int pHttpStatus,
            DateTime pDateOfRequest)
        {
            HttpRequestId = pRequestId;
            HttpAddress = pHttpAddress;
            HttpRequestData = pHttpRequestData;
            HttpResponseData = pHttpResponseData;
            HttpStatus = pHttpStatus;
            DateOfRequest = pDateOfRequest;
        }
    }
}
