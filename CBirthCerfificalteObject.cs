using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
    class CBirthCerfificalteObject
    {
        public int BirthCertificateId
        {
            get;
            set;
        }

        public int DocumentTypeCode
        {
            get;
            set;
        }

        public int SeriesParam
        {
            get;
            set;
        }

        public int DocumentNumber
        {
            get;
            set;
        }

        public string BirthPlace
        {
            get;
            set;
        }

        public DateTime IssueDate
        {
            get;
            set;
        }

        public string IsserCode
        {
            get;
            set;
        }

        public CBirthCerfificalteObject(
            int pBirthCertificateId,
            int pDocumentTypeCode,
            int pSeriesParam,
            int pDocumentNumber,
            string pBirthPlace,
            DateTime pIssuerDate,
            string pIssuerCode)
        {
            BirthCertificateId = pBirthCertificateId;
            DocumentTypeCode = pDocumentTypeCode;
            SeriesParam = pSeriesParam;
            DocumentNumber = pDocumentNumber;
            BirthPlace = pBirthPlace;
            IssueDate = pIssuerDate;
            IsserCode = pIssuerCode;
        }
    }
}
