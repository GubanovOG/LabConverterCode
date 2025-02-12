using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
    public class CAnalytesObjectClass
    {
        public int AnalyteCode
        {
            get;
            set;
        }

        public int SortCode
        {
            get;
            set;
        }

        public int GroupCode
        {
            get;
            set;
        }

        public string LoincCode
        {
            get;
            set;
        }

        public int IdObject
        {
            get;
            set;
        }

        public string AnalytName
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string Speciment
        {
            get;
            set;
        }

        public string Synonym
        {
            get;
            set;
        }

        public string TimeChar
        {
            get;
            set;
        }

        public string ScaleType
        {
            get;
            set;
        }

        public string ShortName
        {
            get;
            set;
        }

        public string MethodType
        {
            get;
            set;
        }

        public string TestStatus
        {
            get;
            set;
        }

        public string EnglishName
        {
            get;
            set;
        }

        public string MeasurementObject
        {
            get;
            set;
        }

        public string SpecialityCode
        {
            get;
            set;
        }
        

        public CAnalytesObjectClass(
            int pAnalytCode,
            int pSortCode,
            int pGroupCode,
            string pLoincCode,
            int pIdObject,
            string pAnalystObject,
            string pFullName,
            string pSpecimentObject,
            string pSynonymObject,
            string pTimeObject,
            string pScaleType,
            string pShortName,
            string pMethodType,
            string pTestStatus,
            string pEnglishName,
            string pMeasurementObject,
           string pSpecialityCode)
        {
            AnalyteCode = pAnalytCode;
            SortCode = pSortCode;
            GroupCode = pGroupCode;
            LoincCode = pLoincCode;
            IdObject = pIdObject;
            AnalyteCode = pAnalytCode;
            FullName = pFullName;
            Speciment = Speciment;
            Synonym = pSynonymObject;
            TimeChar = pTimeObject;
            ScaleType = pScaleType;
            ShortName = pShortName;
            MethodType = pMethodType;
            TestStatus = pTestStatus;
            EnglishName = pEnglishName;
            MeasurementObject = pMeasurementObject;
            SpecialityCode = pSpecialityCode;
        }
    }
    }

