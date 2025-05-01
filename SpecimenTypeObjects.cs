using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;
namespace BregisDigitalConverterServiceObject.SystemObjects
{


    [DataContract]
   public class SpecimentTypeObject 
    {
       public int SpecimentTypeId
       {
           get;
           set;
       }


       public string SpecimentTypeName
       {
           get;
           set;
       }

       public string SpecimentTypeDescription
       {
           get;
           set;
       }


       public SpecimentTypeObject(int pSpeciemntTypeId,
           string pSpecimentTypeName,
           string pSpecimentTypeDescription)
       {
           SpecimentTypeId = pSpeciemntTypeId;
           SpecimentTypeName = pSpecimentTypeName;
           SpecimentTypeDescription = pSpecimentTypeDescription;
       }



    }
}
