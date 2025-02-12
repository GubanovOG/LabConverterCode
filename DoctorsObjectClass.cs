using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
    public class DoctorsObjectClass
    {
        public int DoctorId
        {
            get;
            set;
        }

        public string DoctorSurname
        {
            get;
            set;
        }

        public string DoctorName
        {
            get;
            set;
        }

    
        public string DoctorSecondName
        {
            get;
            set;
        }

        public string PostalAddress
        {
            get;
            set;
        }

        public string PassportSeries
        {
            get;
            set;
        }

        public string PassportNumber
        {
            get;
            set;
        }

        public string IssurerCode
        {
            get;
            set;
        }

        public DateTime DateOfIssue
        {
            get;
            set;
        }

        public string ContactEmail
        {
            get;
            set;
        }

        public string ContactPhone
        {
            get;
            set;
        }

        public int SpecialityCode
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public DoctorsObjectClass(int pDoctorId,
            string pDoctorSurname,
            string pDoctorName,
            string pDoctorSecondName,
            string pDoctorPostalAddress,
            string pPassportSeries,
            string pPassportNumber,
            string pIssuerCode,
            DateTime pDateOfIssue,
            string pContactEmail,
            string pContactPhone,
            int pSpecialityCode,
            string pUsername)
        {
            DoctorId = pDoctorId;
            DoctorSurname = pDoctorSurname;
            DoctorName = pDoctorName;
            DoctorSecondName = pDoctorSecondName;
            PostalAddress = pDoctorPostalAddress;
            PassportSeries = pPassportSeries;
            PassportNumber = pPassportNumber;
            IssurerCode = pIssuerCode;
            DateOfIssue = pDateOfIssue;
            ContactEmail = pContactEmail;
            ContactPhone = pContactPhone;
            SpecialityCode = pSpecialityCode;
            UserName = pUsername;
        }
    }
}
