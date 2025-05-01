using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.SystemObjects
{
   public class CAnalytesAttributeClass
    {
       public int AnalytesCode
       {
           get;
           set;
       }

       public int AnalytesAttributeCode
       {
           get;
           set;
       }

       public string AnalytesAttributeName
       {
           get;
           set;
       }

    

       public int UnitsCode
       {
           get;
           set;
       }

       public string AnalytesAttributeDescription
       {
           get;
           set;
       }

       public float AnalytesAttributeValue
       {
           get;
           set;
       }

       public float CurrentDayRecord
       {
           get;
           set;
       }

       public CAnalytesAttributeClass(int pAnalytesCode,
           int pAnalytesAttributeCode,
           string pAnalytesAttributeName,
           int pUnitsCode,
           string pAnalytesAttributeDescription,
           float pAnalytesAttributeValue,
           float pCurrentDayRecord)
         {
             AnalytesCode = pAnalytesCode;
             AnalytesAttributeCode = pAnalytesAttributeCode;
             AnalytesAttributeName = pAnalytesAttributeName;
             UnitsCode = pUnitsCode;
             AnalytesAttributeDescription = pAnalytesAttributeDescription;
             AnalytesAttributeValue = pAnalytesAttributeValue;
             CurrentDayRecord = pCurrentDayRecord;
         }

    }
}
