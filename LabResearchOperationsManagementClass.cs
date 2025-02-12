using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BregisDigitalConverterServiceObject.SystemObjects;
using BregisDigitalConverterServiceObject.ManagementClasses;
using BregisDigitalConverterServiceObject.Dialogs;
using BregisDigitalConverterServiceObject.MainForms;

namespace BregisDigitalConverterServiceObject.ManagementClasses
{
  public  class LabResearchOperationsManagementClass : DatabaseManagementClass  
  {

      public List<LabResearchObjectClass> pLabResearchCollectionObject;
      public List<CAnalytesObjectClass> pAnalytesObjectManagementList;
      public DataTable pOutputTableLabResearch;
      public SqlConnection pSqlConnectionObject;
      public SqlCommand pMySqlCommandObject;
      public DatabaseManagementClass pDatabaseManagementClass;

      public LabResearchOperationsManagementClass()
      {
          pDatabaseManagementClass = GlobalVariablesClass.pDatabaseManagementClass;
          pLabResearchCollectionObject = new List<LabResearchObjectClass>();
           mySqlConnection = pDatabaseManagementClass.mySqlConnection;
            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pizzaString"].ConnectionString;
                mySqlConnection.Open();
            }

            pAnalytesObjectManagementList = new List<CAnalytesObjectClass>();
        
      }
    

     public DataTable DownloadLabResearchSystemObjectData(out List<LabResearchObjectClass> ppLabResearchOutputCollection)
     {
         pLabResearchCollectionObject.Clear();
         pOutputTableLabResearch = new DataTable();
         pOutputTableLabResearch.Columns.Add("Идентнификатор", typeof(string));
         pOutputTableLabResearch.Columns.Add("Код Статус", typeof(string));
         pOutputTableLabResearch.Columns.Add("Статус", typeof(string));
         pOutputTableLabResearch.Columns.Add("Номер Заказа", typeof(string));
         pOutputTableLabResearch.Columns.Add("Код Исследования", typeof(string));
         pOutputTableLabResearch.Columns.Add("Название Исследования", typeof(string));

         string pSqlStr = string.Format(@"Select *
                FROM CLabMedicalResearchObjectTable, OrderObjects
            WHERE CLabMedicalResearchObjectTable.[OrderNumber] = OrderObjects.[OrderId]");

         using (mySqlCommand = new SqlCommand())
         {
             mySqlCommand.CommandText = pSqlStr;
             mySqlCommand.Connection = mySqlConnection;

             try
             {
                 mySqlDataReader = mySqlCommand.ExecuteReader();
                 while (mySqlDataReader.Read())
                 {
                     string pUUIDObject = Convert.ToString(mySqlDataReader["UUIdObject"].ToString());
                     int pStatusCodeObject = Convert.ToInt32(mySqlDataReader["StatusCodeParam"].ToString());
                    string pStatusName = Convert.ToString(mySqlDataReader["StatusTextParam"].ToString());
                    string pOrderId = Convert.ToString(mySqlDataReader["OrderId"].ToString());
                    string pLabResearchId = Convert.ToString(mySqlDataReader["LabResearchId"].ToString());
                    string pLabResearchName = Convert.ToString(mySqlDataReader["LabResearchName"].ToString());

                     LabResearchObjectClass pLabReseachObject = new LabResearchObjectClass(
                         pUUIDObject,
                         pStatusCodeObject,
                         pStatusName,
                         pOrderId,
                         pLabResearchId,
                         pLabResearchName);
                     pLabResearchCollectionObject.Add(pLabReseachObject);
                     
                 }
             }
             catch (Exception ex)
             {
                 ShowMessage(ex.Message.ToString());
             }
             finally
             {
                 mySqlDataReader.Close();
             }
         }

         foreach (LabResearchObjectClass pLabResearchObject in pLabResearchCollectionObject)
         {
             pOutputTableLabResearch.Rows.Add(
                 pLabResearchObject.UUIdObject,
                 pLabResearchObject.StatusCodeParam,
                 pLabResearchObject.StatusTextParam,
                 pLabResearchObject.OrderNumber,
                 pLabResearchObject.LabResearchId,
                 pLabResearchObject.ResearchName);
         }

         ppLabResearchOutputCollection = pLabResearchCollectionObject;
         return pOutputTableLabResearch;
     } 
    

      public DataTable DownloadAnalytDataTable(out List<CAnalytesObjectClass> ppLabResearchOutputCollection)
     {
        pAnalytesObjectManagementList.Clear();
         pOutputTableLabResearch = new DataTable();
         pOutputTableLabResearch.Columns.Add("Идентнификатор Аналита", typeof(int));
         pOutputTableLabResearch.Columns.Add("Код Статус", typeof(int));
         pOutputTableLabResearch.Columns.Add("Код Группы", typeof(int));
         pOutputTableLabResearch.Columns.Add("Код Классификатора", typeof(string));
         pOutputTableLabResearch.Columns.Add("Код Объекта", typeof(int));
         pOutputTableLabResearch.Columns.Add("Наименование Аналита", typeof(string));
         pOutputTableLabResearch.Columns.Add("Полное Наименование", typeof(string));
         pOutputTableLabResearch.Columns.Add("Код Образца", typeof(string));
         pOutputTableLabResearch.Columns.Add("Синоним", typeof(string));
         pOutputTableLabResearch.Columns.Add("Время Захвата", typeof(string));
         pOutputTableLabResearch.Columns.Add("Тип Шкалы", typeof(string));
         pOutputTableLabResearch.Columns.Add("Краткое Наименование", typeof(string));
         pOutputTableLabResearch.Columns.Add("Тип Метода", typeof(string));
         pOutputTableLabResearch.Columns.Add("Статус Теста", typeof(string));
         pOutputTableLabResearch.Columns.Add("Иностранное Наименование", typeof(string));
         pOutputTableLabResearch.Columns.Add("Единицы Измерения", typeof(string));
         pOutputTableLabResearch.Columns.Add("Категория", typeof(int));

         string pSqlStr = string.Format(@"Select *
                FROM AnalytesObjectClass");

         using (mySqlCommand = new SqlCommand())
         {
             mySqlCommand.CommandText = pSqlStr;
             mySqlCommand.Connection = mySqlConnection;

             try
             {
                 mySqlDataReader = mySqlCommand.ExecuteReader();
                 while (mySqlDataReader.Read())
                 {
                     int pAnalytCodeObject = Convert.ToInt32(mySqlDataReader["AnalytsCode"].ToString());
                    int pSortCode = Convert.ToInt32(mySqlDataReader["SortCode"].ToString());
                    int pGroupCode = Convert.ToInt32(mySqlDataReader["GroupCode"].ToString());
                    string pClassifierCode = Convert.ToString(mySqlDataReader["LoincCode"].ToString());
                    int pObjectId = Convert.ToInt32(mySqlDataReader["IdObject"].ToString());
                    string pAnalytsName = Convert.ToString(mySqlDataReader["AnalytName"].ToString());
                    string pAnalytsFullName = Convert.ToString(mySqlDataReader["FullName"].ToString());
                    string pSpecimentCode = Convert.ToString(mySqlDataReader["Speciment"].ToString());
                    string pSynonymObject = Convert.ToString(mySqlDataReader["Synonym"].ToString());
                    string pTimeCode = Convert.ToString(mySqlDataReader["TimeChar"].ToString());
                    string pScaleType = Convert.ToString(mySqlDataReader["ScaleType"].ToString());
                    string pShortName = Convert.ToString(mySqlDataReader["ShortName"].ToString());
                    string pMethodType = Convert.ToString(mySqlDataReader["MethodType"].ToString());
                    string pTestStatus = Convert.ToString(mySqlDataReader["TestStatus"].ToString());
                    string pEnglishName = Convert.ToString(mySqlDataReader["EnglshName"].ToString());
                    string pMeasureMentcode = Convert.ToString(mySqlDataReader["MeasurementObject"].ToString());
                   string pSpecialityCode = Convert.ToString(mySqlDataReader["SpecialityCode"].ToString());
                     CAnalytesObjectClass pAnalytObjectClass = new CAnalytesObjectClass(
                         pAnalytCodeObject,
                         pSortCode,
                         pGroupCode,
                         pClassifierCode,
                         pObjectId,
                         pAnalytsName,
                         pAnalytsFullName,
                         pSpecimentCode,
                         pSynonymObject,
                         pTimeCode,
                         pScaleType,
                         pShortName,
                         pMethodType,
                         pTestStatus,
                         pEnglishName,
                         pMeasureMentcode,
                         pSpecialityCode);
                     pAnalytesObjectManagementList.Add(pAnalytObjectClass);
                     
                 }
             }
             catch (Exception ex)
             {
                 ShowMessage(ex.Message.ToString());
             }
             finally
             {
                 mySqlDataReader.Close();
             }
         }

         foreach ( CAnalytesObjectClass pLabResearchObject in  pAnalytesObjectManagementList)
         {
             pOutputTableLabResearch.Rows.Add(
                 pLabResearchObject.AnalyteCode,
                 pLabResearchObject.SortCode,
                 pLabResearchObject.GroupCode,
                 pLabResearchObject.LoincCode,
                 pLabResearchObject.IdObject,
                 pLabResearchObject.AnalytName,
                 pLabResearchObject.FullName,
                 pLabResearchObject.SpecialityCode,
                 pLabResearchObject.Synonym,
                 pLabResearchObject.TimeChar,
                 pLabResearchObject.ScaleType,
                 pLabResearchObject.ShortName,
                 pLabResearchObject.MethodType,
                 pLabResearchObject.TestStatus,
                 pLabResearchObject.EnglishName,
                 pLabResearchObject.MeasurementObject,
                 pLabResearchObject.SpecialityCode);
         }

         ppLabResearchOutputCollection = pAnalytesObjectManagementList;
         return pOutputTableLabResearch;
     } 
  
  }
}
