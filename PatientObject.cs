using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
    public class PatientObject
    {

       public int ClientCode
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }

        public string SecondName
        {
            get;
            set;
        }

        public int AgeVal
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public string PostalAddress
        {
            get;
            set;
        }

        public int NationalInsuranceNumber
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

        public string GenderdObject
        {
            get;
            set;
        }

        public int PassportSeries
        {
            get;
            set;
        }

        public int PassportNumber
        {
            get;
            set;
        }
        public PatientObject(int clientCode,
            string clientName,
            string clientSurname,
            string clientSecondName,
            int ageVal,
            DateTime dateOfBirtn,
            string postalAddress,
            int pNationalInsuranceNumber,
            string contactEmail,
            string contactPhone,
            string pGenderObject,
            int pPassportSeries,
            int pPassportNumber)
        {
            ClientCode = clientCode;
            ClientName = clientName;
            Surname = clientSurname;
            SecondName = clientSecondName;
            AgeVal = ageVal;
            DateOfBirth = dateOfBirtn;
            PostalAddress = postalAddress;
            NationalInsuranceNumber = pNationalInsuranceNumber;
            ContactEmail = contactEmail;
            ContactPhone = contactPhone;
            GenderdObject = pGenderObject;
            PassportSeries = pPassportSeries;
            PassportNumber = pPassportNumber;
        }

        public PatientObject()
        {
            ClientCode = 0;
            ClientName = null;
            Surname = null;
            SecondName = null;
            AgeVal = 0;
            DateOfBirth = DateTime.MinValue;
            PostalAddress = null;
            NationalInsuranceNumber = 0;
            ContactEmail = null;
            ContactPhone = null;
            GenderdObject = null;
            PassportSeries = 0;
            PassportNumber = 0;
        }

    }
}
