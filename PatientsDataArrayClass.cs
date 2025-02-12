using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BregisDigitalConverterServiceObject.SystemObjects
{
    public class PatientsDataArrayClass
    {
        public List<PatientObject> pListOfPatientsDataArray;

        public PatientsDataArrayClass(List<PatientObject> pPatientListData)
        {
            pListOfPatientsDataArray = pPatientListData;
        }

        public PatientsDataArrayClass()
        {
            pListOfPatientsDataArray = new List<PatientObject>();
            pListOfPatientsDataArray.Clear();
        }

        
    }
}
