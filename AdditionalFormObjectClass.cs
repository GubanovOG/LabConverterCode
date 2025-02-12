using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;


namespace BregisDigitalConverterServiceObject.SystemObjects
{

    [DataContract]  //Клаc
    public class AdditionalFormObjectClass
    {
        [DataMember]
        public int AdditionalFormCode
        {
            get;
            set;
        }

        [DataMember]
        public int SpecimenTypeCode
        {
            get;
            set;
        }

       [DataMember]
        public string SpecimenTypeName
        {
            get;
            set;
        }

        [DataMember]
        public int ValueId
        {
            get;
            set;
        }

        [DataMember]
        public float FormValue
        {
            get;
            set;
        }

        public AdditionalFormObjectClass(int pAdditionalFormCode,
            int pSpecimentTypeCode,
            string pSpecimentTypeName,
            int pValueId,
            float pFormValue)
        {
            AdditionalFormCode = pAdditionalFormCode;
            SpecimenTypeCode = pSpecimentTypeCode;
            SpecimenTypeName = pSpecimentTypeName;
            ValueId = pValueId;
            FormValue = pFormValue;
        }
    }
}
