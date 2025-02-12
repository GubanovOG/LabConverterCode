using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BregisDigitalConverterServiceObject.ManagementClasses
{
   public class LabResearchObjectClass
    {
       public string UUIdObject
       {
           get;
           set;
       }

      

       public int StatusCodeParam
       {
           get;
           set;
       }

       public string StatusTextParam
       {
           get;
           set;
       }

       public string OrderNumber
       {
           get;
           set;
       }

       public string LabResearchId
       {
           get;
           set;
       }

     public string ResearchName
       {
           get;
           set;
       }

     


       public LabResearchObjectClass(string pUUIdObject,
          int pStatusCodeObject,
          string pStatusTextParam,
          string pOrderNumber,
          string pLabResearchId,
          string pResearchName)
     {
         UUIdObject = pUUIdObject;
         StatusCodeParam = pStatusCodeObject;
         StatusTextParam = pStatusTextParam;
         OrderNumber = pOrderNumber;
         LabResearchId = pLabResearchId; 
         ResearchName = pResearchName;
       }

    }
}
