using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BregisDigitalConverterServiceObject.Dialogs;
using BregisDigitalConverterServiceObject.SystemObjects;
using BregisDigitalConverterServiceObject.MainForms;

namespace BregisDigitalConverterServiceObject.ManagementClasses
{
  public class HttpCommunicationsManagementClass : DatabaseManagementClass
    {
        public List<CHttpRequestObject> pHttpRequestObjectCollectionBregis;
        public List<CHttpResponseObject> pHttpResponseObjectCollectionBregis;

        public List<CHttpRequestObject> pHttpRequestObjectCollectionRam;
        public List<CHttpResponseObject> pHttpResponseObjectCollectionRam;

        public List<CHttpRequestObject> pHttpRequestObjectCollectionExternalSystem;
        public List<CHttpResponseObject> pHttpResponseObjectCollectionExternalSystem;

        public List<CHttpRequestObject> pHttpRequestObjectCollection;
        public List<CHttpResponseObject> pHttpResponseObjectCollection;

        public DatabaseManagementClass pDatabaseManagementClass;
        GlobalVariablesClass myClobalVariablesClass;
        SqlConnection pSqlConnection;
        SqlCommand pCorporateClientCommand;

      public HttpCommunicationsManagementClass()
        {
            pHttpRequestObjectCollectionBregis = new List<CHttpRequestObject>();
            pHttpResponseObjectCollectionBregis = new List<CHttpResponseObject>();
            pHttpRequestObjectCollectionRam = new List<CHttpRequestObject>();
            pHttpResponseObjectCollectionRam = new List<CHttpResponseObject>();
            pHttpRequestObjectCollectionExternalSystem = new List<CHttpRequestObject>();
            pHttpResponseObjectCollectionExternalSystem = new List<CHttpResponseObject>();
     
            myClobalVariablesClass = Program.pGlobalVariablesClass;
            pDatabaseManagementClass = GlobalVariablesClass.pDatabaseManagementClass;
            pSqlConnection = pDatabaseManagementClass.mySqlConnection;


            if (pSqlConnection.State != ConnectionState.Open)
            {
                pSqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pizzaString"].ConnectionString;
                pSqlConnection.Open();
            }
        }


      public void InsertHttpRequestObjectBregis(CHttpRequestObject pHttpRequest)
      {
          string pSqlStr = string.Format(@"Insert Into HttpRequestObjectsTableBregis
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @DateOfRequestParam)");

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pSqlStr;

              SqlParameter pHttpRequestIdParam = new SqlParameter();
              pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
              pHttpRequestIdParam.SourceColumn = "HttpRequestId";
              pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
              pHttpRequestIdParam.SqlValue = pHttpRequest.HttpRequestId;
              mySqlCommand.Parameters.Add(pHttpRequestIdParam);

              SqlParameter pHttpAddressParam = new SqlParameter();
              pHttpAddressParam.ParameterName = "@HttpAddressParam";
              pHttpAddressParam.SourceColumn = "HttpAddress";
              pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
              pHttpAddressParam.SqlValue = pHttpRequest.HttpAddress;
              mySqlCommand.Parameters.Add(pHttpRequestIdParam);

              SqlParameter pHttpRequestParam = new SqlParameter();
              pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
              pHttpRequestParam.SourceColumn = "HttpRequestData";
              pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
              pHttpRequestParam.SqlValue = pHttpRequest.HttpRequestData;
              mySqlCommand.Parameters.Add(pHttpRequestParam);

              SqlParameter pDateOfRequestParam = new SqlParameter();
              pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
              pDateOfRequestParam.SourceColumn = "DateOfRequest";
              pDateOfRequestParam.SqlDbType = SqlDbType.Date;
              pDateOfRequestParam.SqlValue = pHttpRequest.DateOfRequest;
              mySqlCommand.Parameters.Add(pDateOfRequestParam);

              try
              {
                  mySqlCommand.ExecuteNonQuery();
              }
              catch (SqlException ex)
              {
                  MessageBox.Show(ex.Message.ToString());
              }
          }




      }


           public void InsertHttpRequestObjectRAM(CHttpRequestObject pHttpRequest)
      {
          string pSqlStr = string.Format(@"Insert Into HttpRequestObjectsTableRAM
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @DateOfRequestParam)");

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pSqlStr;

              SqlParameter pHttpRequestIdParam = new SqlParameter();
              pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
              pHttpRequestIdParam.SourceColumn = "HttpRequestId";
              pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
              pHttpRequestIdParam.SqlValue = pHttpRequest.HttpRequestId;
              mySqlCommand.Parameters.Add(pHttpRequestIdParam);

              SqlParameter pHttpAddressParam = new SqlParameter();
              pHttpAddressParam.ParameterName = "@HttpAddressParam";
              pHttpAddressParam.SourceColumn = "HttpAddress";
              pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
              pHttpAddressParam.SqlValue = pHttpRequest.HttpAddress;
              mySqlCommand.Parameters.Add(pHttpRequestIdParam);

              SqlParameter pHttpRequestParam = new SqlParameter();
              pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
              pHttpRequestParam.SourceColumn = "HttpRequestData";
              pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
              pHttpRequestParam.SqlValue = pHttpRequest.HttpRequestData;
              mySqlCommand.Parameters.Add(pHttpRequestParam);

              SqlParameter pDateOfRequestParam = new SqlParameter();
              pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
              pDateOfRequestParam.SourceColumn = "DateOfRequest";
              pDateOfRequestParam.SqlDbType = SqlDbType.Date;
              pDateOfRequestParam.SqlValue = pHttpRequest.DateOfRequest;
              mySqlCommand.Parameters.Add(pDateOfRequestParam);

              try
              {
                  mySqlCommand.ExecuteNonQuery();
              }
              catch (SqlException ex)
              {
                  MessageBox.Show(ex.Message.ToString());
              }
          }




      }


      
           public void InsertHttpRequestObjectExternalSystem(CHttpRequestObject pHttpRequest)
      {
          string pSqlStr = string.Format(@"Insert Into HttpRequestObjectsTableExternalResource
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @DateOfRequestParam)");

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pSqlStr;

              SqlParameter pHttpRequestIdParam = new SqlParameter();
              pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
              pHttpRequestIdParam.SourceColumn = "HttpRequestId";
              pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
              pHttpRequestIdParam.SqlValue = pHttpRequest.HttpRequestId;
              mySqlCommand.Parameters.Add(pHttpRequestIdParam);

              SqlParameter pHttpAddressParam = new SqlParameter();
              pHttpAddressParam.ParameterName = "@HttpAddressParam";
              pHttpAddressParam.SourceColumn = "HttpAddress";
              pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
              pHttpAddressParam.SqlValue = pHttpRequest.HttpAddress;
              mySqlCommand.Parameters.Add(pHttpAddressParam);

              SqlParameter pHttpRequestParam = new SqlParameter();
              pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
              pHttpRequestParam.SourceColumn = "HttpRequestData";
              pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
              pHttpRequestParam.SqlValue = pHttpRequest.HttpRequestData;
              mySqlCommand.Parameters.Add(pHttpRequestParam);

              SqlParameter pDateOfRequestParam = new SqlParameter();
              pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
              pDateOfRequestParam.SourceColumn = "DateOfRequest";
              pDateOfRequestParam.SqlDbType = SqlDbType.Date;
              pDateOfRequestParam.SqlValue = pHttpRequest.DateOfRequest;
              mySqlCommand.Parameters.Add(pDateOfRequestParam);

              try
              {
                  mySqlCommand.ExecuteNonQuery();
              }
              catch (SqlException ex)
              {
                  MessageBox.Show(ex.Message.ToString());
              }
          }




      }

           public void InsertHttpResponseObject(CHttpResponseObject pHttpResponse)
           {
               string pSqlStr = string.Format(@"Insert Into HttpRequestObjectsTable
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @HttpResponseDataParam,
            @DateOfRequestParam)");

               using (mySqlCommand = new SqlCommand())
               {
                   mySqlCommand.Connection = pSqlConnection;
                   mySqlCommand.CommandText = pSqlStr;

                   SqlParameter pHttpRequestIdParam = new SqlParameter();
                   pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
                   pHttpRequestIdParam.SourceColumn = "HttpRequestId";
                   pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
                   pHttpRequestIdParam.SqlValue = pHttpResponse.HttpRequestId;
                   mySqlCommand.Parameters.Add(pHttpRequestIdParam);

                   SqlParameter pHttpAddressParam = new SqlParameter();
                   pHttpAddressParam.ParameterName = "@HttpAddressParam";
                   pHttpAddressParam.SourceColumn = "HttpAddress";
                   pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
                   pHttpAddressParam.SqlValue = pHttpResponse.HttpAddress;
                   mySqlCommand.Parameters.Add(pHttpRequestIdParam);

                   SqlParameter pHttpRequestParam = new SqlParameter();
                   pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
                   pHttpRequestParam.SourceColumn = "HttpRequestData";
                   pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
                   pHttpRequestParam.SqlValue = pHttpResponse.HttpRequestData;
                   mySqlCommand.Parameters.Add(pHttpRequestParam);

                   SqlParameter pHttpResponseParam = new SqlParameter();
                   pHttpResponseParam.ParameterName = "@HttpResponseDataParam";
                   pHttpResponseParam.SourceColumn = "HttpResponseData";
                   pHttpResponseParam.SqlDbType = SqlDbType.NVarChar;
                   pHttpResponseParam.SqlValue = pHttpResponse.HttpResponseData;
                   mySqlCommand.Parameters.Add(pHttpResponseParam);

                   SqlParameter pDateOfRequestParam = new SqlParameter();
                   pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
                   pDateOfRequestParam.SourceColumn = "DateOfRequest";
                   pDateOfRequestParam.SqlDbType = SqlDbType.Date;
                   pDateOfRequestParam.SqlValue = pHttpResponse.DateOfRequest;
                   mySqlCommand.Parameters.Add(pDateOfRequestParam);

                   try
                   {
                       mySqlCommand.ExecuteNonQuery();
                   }
                   catch (SqlException ex)
                   {
                       MessageBox.Show(ex.Message.ToString());
                   }
               }
           }



          
         public void InsertHttpResponseObjectRam(CHttpResponseObject pHttpResponse)
      {
          string pSqlStr = string.Format(@"Insert Into HttpResponseObjectTableRAM
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @HttpResponseDataParam,
            @DateOfRequestParam)");
            
        using (mySqlCommand = new SqlCommand())
        {
            mySqlCommand.Connection = pSqlConnection;
            mySqlCommand.CommandText = pSqlStr;

            SqlParameter pHttpRequestIdParam = new SqlParameter();
            pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
            pHttpRequestIdParam.SourceColumn = "HttpRequestId";
            pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
            pHttpRequestIdParam.SqlValue = pHttpResponse.HttpRequestId;
            mySqlCommand.Parameters.Add(pHttpRequestIdParam);

            SqlParameter pHttpAddressParam = new SqlParameter();
            pHttpAddressParam.ParameterName = "@HttpAddressParam";
            pHttpAddressParam.SourceColumn = "HttpAddress";
            pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
            pHttpAddressParam.SqlValue = pHttpResponse.HttpAddress;
            mySqlCommand.Parameters.Add(pHttpRequestIdParam);

            SqlParameter pHttpRequestParam = new SqlParameter();
            pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
            pHttpRequestParam.SourceColumn = "HttpRequestData";
            pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
            pHttpRequestParam.SqlValue = pHttpResponse.HttpRequestData;
            mySqlCommand.Parameters.Add(pHttpRequestParam);

             SqlParameter pHttpResponseParam = new SqlParameter();
             pHttpResponseParam.ParameterName = "@HttpResponseDataParam";
             pHttpResponseParam.SourceColumn = "HttpResponseData";
            pHttpResponseParam.SqlDbType = SqlDbType.NVarChar;
            pHttpResponseParam.SqlValue = pHttpResponse.HttpResponseData;
            mySqlCommand.Parameters.Add(pHttpResponseParam);

             SqlParameter pDateOfRequestParam = new SqlParameter();
            pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
           pDateOfRequestParam.SourceColumn = "DateOfRequest";
            pDateOfRequestParam.SqlDbType = SqlDbType.Date;
            pDateOfRequestParam.SqlValue = pHttpResponse.DateOfRequest;
            mySqlCommand.Parameters.Add( pDateOfRequestParam);

            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
              MessageBox.Show(ex.Message.ToString());
            }
        }



        
      }



         public void InsertHttpResponseObjectBregis(CHttpResponseObject pHttpResponse)
      {
          string pSqlStr = string.Format(@"Insert Into HttpResponseObjectTableBregis
            Values (@HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @HttpResponseDataParam,
            @DateOfRequestParam)");
            
        using (mySqlCommand = new SqlCommand())
        {
            mySqlCommand.Connection = pSqlConnection;
            mySqlCommand.CommandText = pSqlStr;

            SqlParameter pHttpRequestIdParam = new SqlParameter();
            pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
            pHttpRequestIdParam.SourceColumn = "HttpRequestId";
            pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
            pHttpRequestIdParam.SqlValue = pHttpResponse.HttpRequestId;
            mySqlCommand.Parameters.Add(pHttpRequestIdParam);

            SqlParameter pHttpAddressParam = new SqlParameter();
            pHttpAddressParam.ParameterName = "@HttpAddressParam";
            pHttpAddressParam.SourceColumn = "HttpAddress";
            pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
            pHttpAddressParam.SqlValue = pHttpResponse.HttpAddress;
            mySqlCommand.Parameters.Add(pHttpRequestIdParam);

            SqlParameter pHttpRequestParam = new SqlParameter();
            pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
            pHttpRequestParam.SourceColumn = "HttpRequestData";
            pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
            pHttpRequestParam.SqlValue = pHttpResponse.HttpRequestData;
            mySqlCommand.Parameters.Add(pHttpRequestParam);

             SqlParameter pHttpResponseParam = new SqlParameter();
             pHttpResponseParam.ParameterName = "@HttpResponseDataParam";
             pHttpResponseParam.SourceColumn = "HttpResponseData";
            pHttpResponseParam.SqlDbType = SqlDbType.NVarChar;
            pHttpResponseParam.SqlValue = pHttpResponse.HttpResponseData;
            mySqlCommand.Parameters.Add(pHttpResponseParam);

             SqlParameter pDateOfRequestParam = new SqlParameter();
            pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
           pDateOfRequestParam.SourceColumn = "DateOfRequest";
            pDateOfRequestParam.SqlDbType = SqlDbType.Date;
            pDateOfRequestParam.SqlValue = pHttpResponse.DateOfRequest;
            mySqlCommand.Parameters.Add( pDateOfRequestParam);

            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
              MessageBox.Show(ex.Message.ToString());
            }
        }



        
      }




       public void InsertHttpResponseObjectExternalSystem(CHttpResponseObject pHttpResponse)
      {
          string pSqlStr = string.Format(@"Insert Into HttpResponseObjectTableExternalResource
            Values (@HttpResponseIdParam, @HttpRequestIdParam, @HttpAddressParam, @HttpRequestDataParam, @HttpResponseDataParam,
            @DateOfRequestParam)");
            
        using (mySqlCommand = new SqlCommand())
        {
            mySqlCommand.Connection = pSqlConnection;
            mySqlCommand.CommandText = pSqlStr;


            SqlParameter pHttpResponseIdParam = new SqlParameter();
            pHttpResponseIdParam.ParameterName = "@HttpResponseIdParam";
            pHttpResponseIdParam.SourceColumn = "HttpResponseId";
            pHttpResponseIdParam.SqlDbType = SqlDbType.Int;
            pHttpResponseIdParam.SqlValue = pHttpResponse.HttpResponseId;
            mySqlCommand.Parameters.Add(pHttpResponseIdParam);


            SqlParameter pHttpRequestIdParam = new SqlParameter();
            pHttpRequestIdParam.ParameterName = "@HttpRequestIdParam";
            pHttpRequestIdParam.SourceColumn = "HttpRequestId";
            pHttpRequestIdParam.SqlDbType = SqlDbType.Int;
            pHttpRequestIdParam.SqlValue = pHttpResponse.HttpRequestId;
            mySqlCommand.Parameters.Add(pHttpRequestIdParam);

            SqlParameter pHttpAddressParam = new SqlParameter();
            pHttpAddressParam.ParameterName = "@HttpAddressParam";
            pHttpAddressParam.SourceColumn = "HttpAddress";
            pHttpAddressParam.SqlDbType = SqlDbType.NVarChar;
            pHttpAddressParam.SqlValue = pHttpResponse.HttpAddress;
            mySqlCommand.Parameters.Add(pHttpAddressParam);

            SqlParameter pHttpRequestParam = new SqlParameter();
            pHttpRequestParam.ParameterName = "@HttpRequestDataParam";
            pHttpRequestParam.SourceColumn = "HttpRequestData";
            pHttpRequestParam.SqlDbType = SqlDbType.NVarChar;
            pHttpRequestParam.SqlValue = pHttpResponse.HttpRequestData;
            mySqlCommand.Parameters.Add(pHttpRequestParam);

             SqlParameter pHttpResponseParam = new SqlParameter();
             pHttpResponseParam.ParameterName = "@HttpResponseDataParam";
             pHttpResponseParam.SourceColumn = "HttpResponseData";
            pHttpResponseParam.SqlDbType = SqlDbType.NVarChar;
            pHttpResponseParam.SqlValue = pHttpResponse.HttpResponseData;
            mySqlCommand.Parameters.Add(pHttpResponseParam);

             SqlParameter pDateOfRequestParam = new SqlParameter();
            pDateOfRequestParam.ParameterName = "@DateOfRequestParam";
           pDateOfRequestParam.SourceColumn = "DateOfRequest";
            pDateOfRequestParam.SqlDbType = SqlDbType.Date;
            pDateOfRequestParam.SqlValue = pHttpResponse.DateOfRequest;
            mySqlCommand.Parameters.Add( pDateOfRequestParam);

            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
              MessageBox.Show(ex.Message.ToString());
            }
        }



        
      }


      public void CreateNewHttpRequestTask(int pRequestId, string pHttpAddress, string pMethod, string pHttpHeader, DateTime pCurrentDate,
          out string pContentValue)
         {
             string pOutputRequestVar = null;
            Console.WriteLine("Creating new Http Request Object");

            HttpWebRequest pWebRequestObject = HttpWebRequest.CreateHttp(pHttpAddress);
            pWebRequestObject.Method = pMethod;
            pWebRequestObject.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            pWebRequestObject.ContentType ="application/json";
            try
            {
                HttpWebResponse pWebResponse = (HttpWebResponse)pWebRequestObject.GetResponse();
                System.IO.Stream pStream = pWebResponse.GetResponseStream();

                using (StreamReader pReader = new StreamReader(pStream))
                {
                    pOutputRequestVar = pReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message.ToString());
            }
           
        
            pContentValue = pOutputRequestVar;
      }

     
           public void CreateNewHttpRequestTaskSamples(
          out string pContentValue)
         {
             int pIndex = pHttpRequestObjectCollectionExternalSystem.Count;
            pIndex = pIndex + 1;
             string pOutputRequestVar = null;
            Console.WriteLine("Creating new Http Request Object");

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest pWebRequestObject = HttpWebRequest.CreateHttp("https://mhdemo.incordmed.ru/api_v1/lab/get_lab_direct&uuid=25b60cc1-d0a1-4a04-9452-1e66240dd29c");
            pWebRequestObject.Method = "GET";
               pWebRequestObject.ContentType = "application/json";
            pWebRequestObject.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
            pWebRequestObject.ContentType ="application/json";
            try
            {
                HttpWebResponse pWebResponse = (HttpWebResponse)pWebRequestObject.GetResponse();
                System.IO.Stream pStream = pWebResponse.GetResponseStream();

                using (StreamReader pReader = new StreamReader(pStream))
                {
                    pOutputRequestVar = pReader.ReadToEnd();
                    System.IO.File.WriteAllText("C:\\RAMCALLS\\ResearchOne.json", pOutputRequestVar);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message.ToString());
            }

            CHttpRequestObject pHttpRequest = new CHttpRequestObject(pIndex, "https://mhdemo.incordmed.ru/api_v1/lab/get_list_directions",
                "https://mhdemo.incordmed.ru/api_v1/lab/get_list_directions", System.DateTime.Now);
            InsertHttpRequestObjectExternalSystem(pHttpRequest);
            CHttpResponseObject pResposeObject = new CHttpResponseObject(pIndex, "https://mhdemo.incordmed.ru/api_v1/lab/get_list_directions",
                "https://mhdemo.incordmed.ru/api_v1/lab/get_list_directions", pOutputRequestVar, 0, System.DateTime.Now);
            InsertHttpResponseObjectExternalSystem(pResposeObject);
        
            pContentValue = pOutputRequestVar;
      }


       public void SendHttpRequestObjectGeneral(int pRequestId, string pHttpAddress, string pHttpRequest, out string pResponseValue)
       {
           string pOutputStringValue = null;
           Console.WriteLine("Creating Http Request Object");
           System.DateTime pCurrentDate = System.DateTime.Now;
           CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId, pHttpAddress,
               pHttpRequest, pCurrentDate);
           Console.WriteLine("Saving Http Request to Database");
           pHttpRequestObjectCollectionExternalSystem.Add(pHttpRequestObject);
           InsertHttpRequestObjectExternalSystem(pHttpRequestObject);
           Console.WriteLine("Sending Http Request to Server");
           CreateNewHttpRequestTaskSamples(out pOutputStringValue);
           Console.WriteLine("Saving Http Response to Database");
           int pStatus = 0;
           System.DateTime pCurrentDateResponse = System.DateTime.Now;
           CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId, pHttpAddress, pHttpRequest, pOutputStringValue, pStatus, pCurrentDateResponse);
           InsertHttpResponseObjectExternalSystem(pHttpResponseObject);
           pHttpResponseObjectCollectionExternalSystem.Add(pHttpResponseObject);
           pResponseValue = pOutputStringValue;
          
    
       }



       public void SendHttpRequestObjectLabResearchObject(int pRequestId, string pHttpAddress, string pHttpRequest, out List<LabResearchObjectClass> pLabResearchObjectListOutput)
       {
           List<LabResearchObjectClass> pInternalLabResearchInternalList = new List<LabResearchObjectClass>();
           string pOutputStringValue = null;
           Console.WriteLine("Creating Http Request Object");
           System.DateTime pCurrentDate = System.DateTime.Now;
           CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId, pHttpAddress,
               pHttpRequest, pCurrentDate);
           Console.WriteLine("Saving Http Request to Database");
           pHttpRequestObjectCollectionExternalSystem.Add(pHttpRequestObject);
           InsertHttpRequestObjectExternalSystem(pHttpRequestObject);
           Console.WriteLine("Sending Http Request to Server");
           CreateNewHttpRequestTaskSamples(out pOutputStringValue);
           Console.WriteLine("Saving Http Response to Database");
           int pStatus = 0;
           System.DateTime pCurrentDateResponse = System.DateTime.Now;
           CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId, pHttpAddress, pHttpRequest, pOutputStringValue, pStatus, pCurrentDateResponse);
          
           
       

            var pGasFittingsData = JsonConvert.DeserializeObject<dynamic>(pOutputStringValue);
            Console.WriteLine(pGasFittingsData);

            string pDataToProcess = pGasFittingsData.ToString();
            JObject pMyJObject = new JObject();
            pMyJObject = JObject.Parse(pDataToProcess);

            Newtonsoft.Json.Linq.IJEnumerable<JToken> pTokenListObject = pMyJObject.Values();


            System.Collections.ArrayList pArrayList = new System.Collections.ArrayList();
            List<JToken> pListData = pTokenListObject.ToList();

            foreach (JToken pTokenoObject in pListData)
            {
                Console.WriteLine(pTokenoObject.ToString());
                List<JToken> pMyTokenData = pTokenoObject.ToList();
                pArrayList.Add(pMyTokenData);

            }

            List<JToken> pMyToketList = new List<JToken>();
            pMyToketList = (List<JToken>)pArrayList[0];

            Console.Clear();

            foreach (JToken pTokenoObject in pMyToketList)
            {
                Console.WriteLine(pTokenoObject.ToString());
                int pStatusVar = int.Parse(pTokenoObject["status"].ToString());
                string pStatusText = pTokenoObject["statud_text"].ToString();
                 string pOrderNum = pTokenoObject["order_num"].ToString();
                string pUUIdString = pTokenoObject["uuid"].ToString();
                string pRCode = pTokenoObject["rcode"].ToString();
                string pResearchName = pTokenoObject["rcode_name"].ToString();

                LabResearchObjectClass pLabResearchObject = new LabResearchObjectClass(
                    pUUIdString,
                    pStatusVar,
                    pStatusText,
                    pOrderNum,
                    pRCode,
                    pResearchName);
                pInternalLabResearchInternalList.Add(pLabResearchObject);
              
            }


            pLabResearchObjectListOutput = pInternalLabResearchInternalList;

       }



      public void InsertLabResearchObjectList(List<LabResearchObjectClass> pLabResearchObjectList)
       {
          foreach (LabResearchObjectClass pLabResearchObject in pLabResearchObjectList)
          {

          }
       }



       public void SendHttpRequestObjectBregis(int pRequestId, string pHttpAddress, string pHttpRequest, out string pResponseValue)
       {
           string pOutputStringValue = null;
           Console.WriteLine("Creating Http Request Object");
           System.DateTime pCurrentDate = System.DateTime.Now;
           CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId, pHttpAddress,
               pHttpRequest, pCurrentDate);
           Console.WriteLine("Saving Http Request to Database");
           pHttpRequestObjectCollection.Add(pHttpRequestObject);
           InsertHttpRequestObjectBregis(pHttpRequestObject);
           Console.WriteLine("Sending Http Request to Server");
           CreateNewHttpRequestTask(pRequestId, pHttpAddress, pHttpRequest,
               "GET",
               System.DateTime.Now, out pOutputStringValue);
           Console.WriteLine("Saving Http Response to Database");
           int pStatus = 0;
           System.DateTime pCurrentDateResponse = System.DateTime.Now;
           CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId, pHttpAddress, pHttpRequest, pOutputStringValue, pStatus, pCurrentDateResponse);
           InsertHttpResponseObjectBregis(pHttpResponseObject);
           pHttpRequestObjectCollectionExternalSystem.Add(pHttpRequestObject);
           pHttpResponseObjectCollectionExternalSystem.Add(pHttpResponseObject);
           pResponseValue = pHttpResponseObject.HttpResponseData;


       }

       public void SendHttpRequestObjectBregisRAM(int pRequestId, string pHttpAddress, string pHttpRequest, out string pResponseValue)
       {
           string pOutputStringValue = null;
           Console.WriteLine("Creating Http Request Object");
           System.DateTime pCurrentDate = System.DateTime.Now;
           CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId, pHttpAddress,
               pHttpRequest, pCurrentDate);
           Console.WriteLine("Saving Http Request to Database");
           pHttpRequestObjectCollection.Add(pHttpRequestObject);
           InsertHttpRequestObjectRAM(pHttpRequestObject);
           Console.WriteLine("Sending Http Request to Server");
           CreateNewHttpRequestTask(pRequestId, pHttpAddress, pHttpRequest,
               "GET",
               System.DateTime.Now, out pOutputStringValue);
           Console.WriteLine("Saving Http Response to Database");
           int pStatus = 0;
           System.DateTime pCurrentDateResponse = System.DateTime.Now;
           CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId, pHttpAddress, pHttpRequest, pOutputStringValue, pStatus, pCurrentDateResponse);
           InsertHttpResponseObjectRam(pHttpResponseObject);
           pHttpRequestObjectCollectionExternalSystem.Add(pHttpRequestObject);
           pHttpResponseObjectCollectionExternalSystem.Add(pHttpResponseObject);
           pResponseValue = pHttpResponseObject.HttpResponseData;


       }




      public DataTable DownloadHttpRequestsToExternalSystem(out List<CHttpRequestObject> pRequestManagementListOutput)
       {
           
          
          
          DataTable pOutputDataTable = new DataTable();
           pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
           pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
           pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
           pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format(@"Select * From HttpRequestObjectsTableExternalResource");

          pHttpRequestObjectCollectionExternalSystem.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpRequestData"].ToString());
                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                      CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId,
                          pRequestAddress,
                          pRequestData,
                          pDateOfRequest);
                      pHttpRequestObjectCollectionExternalSystem.Add(pHttpRequestObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpRequestObject pRequestObject in pHttpRequestObjectCollectionExternalSystem)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.DateOfRequest);
          }
          pRequestManagementListOutput = pHttpRequestObjectCollection;
          return pOutputDataTable;
       }



      public DataTable DownloadHttpResponseDataToExternalSystem(out List<CHttpResponseObject> pRequestManagementListOutput)
      {



          DataTable pOutputDataTable = new DataTable();
          pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
          pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Ответа", typeof(string));
          pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format(@"Select * From
          HttpRequestObjectsTableExternalResource, HttpResponseObjectTableExternalResource
          WHERE HttpResponseObjectTableExternalResource.[HttpRequestId] = HttpRequestObjectsTableExternalResource.[HttpRequestId]");

          pHttpResponseObjectCollectionExternalSystem.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pResponseId = Convert.ToInt32(mySqlDataReader["HttpResonseId"].ToString());
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpRequestData"].ToString());
                      string pResponseData = Convert.ToString(mySqlDataReader["HttpResponseData"].ToString());
                      int pHttpStatus = Convert.ToInt32(mySqlDataReader["HttpStatus"].ToString());

                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                       CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId,
                          pRequestAddress,
                          pRequestData,
                          pResponseData,
                          pHttpStatus,
                          pDateOfRequest);
                       pHttpResponseObjectCollectionExternalSystem.Add(pHttpResponseObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpResponseObject pRequestObject in pHttpResponseObjectCollectionExternalSystem)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.HttpResponseData,
                  pRequestObject.DateOfRequest);
          }
          pRequestManagementListOutput = pHttpResponseObjectCollectionExternalSystem;
          return pOutputDataTable;
      }




      public DataTable DownloadHttpRequestsToBregisSystem(out List<CHttpRequestObject> pRequestManagementListOutput)
      {



          DataTable pOutputDataTable = new DataTable();
          pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
          pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format("Select * From HttpRequestObjectsTableBregis");

          pHttpRequestObjectCollectionBregis.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpData"].ToString());
                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                      CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId,
                          pRequestAddress,
                          pRequestData,
                          pDateOfRequest);
                      pHttpRequestObjectCollectionBregis.Add(pHttpRequestObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpRequestObject pRequestObject in pHttpRequestObjectCollectionBregis)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.DateOfRequest);
          }
          pRequestManagementListOutput = pHttpRequestObjectCollectionBregis;
          return pOutputDataTable;
      }



      public DataTable DownloadHttpResponseDataToBregisSystem(out List<CHttpResponseObject> pRequestManagementListOutput)
      {



          DataTable pOutputDataTable = new DataTable();
          pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
          pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Ответа", typeof(string));
          pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format(@"Select * From
         HttpRequestObjectsTableBregis, HttpResponseObjectTableBregis
          WHERE HttpResponseObjectTableBregis.[HttpRequestId] =  HttpRequestObjectsTableBregis.[HttpRequestId]");

          pHttpRequestObjectCollectionBregis.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pResponseId = Convert.ToInt32(mySqlDataReader["HttpResonseId"].ToString());
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpRequestData"].ToString());
                      string pResponseData = Convert.ToString(mySqlDataReader["HttpResponseData"].ToString());
                      int pHttpStatus = Convert.ToInt32(mySqlDataReader["HttpStatus"].ToString());

                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                      CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId,
                         pRequestAddress,
                         pRequestData,
                         pResponseData,
                         pHttpStatus,
                         pDateOfRequest);
                      pHttpResponseObjectCollectionBregis.Add(pHttpResponseObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpResponseObject pRequestObject in pHttpResponseObjectCollectionBregis)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.HttpResponseData,
                  pRequestObject.DateOfRequest);
          }
          pRequestManagementListOutput = pHttpResponseObjectCollectionBregis;
          return pOutputDataTable;
      }





      public DataTable DownloadHttpRequestsToRAMSystem(out List<CHttpRequestObject> pRequestManagementListOutput)
      {



          DataTable pOutputDataTable = new DataTable();
          pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
          pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format(@"Select * From HttpRequestObjectsTableBregis");

          pHttpRequestObjectCollectionRam.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpData"].ToString());
                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                      CHttpRequestObject pHttpRequestObject = new CHttpRequestObject(pRequestId,
                          pRequestAddress,
                          pRequestData,
                          pDateOfRequest);
                      pHttpRequestObjectCollectionRam.Add(pHttpRequestObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpRequestObject pRequestObject in pHttpRequestObjectCollectionRam)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.DateOfRequest);
          }
          pRequestManagementListOutput = pHttpRequestObjectCollectionRam;
          return pOutputDataTable;
      }



      public DataTable DownloadHttpResponseDataToRAMSystem(out List<CHttpResponseObject> ppResponseObjectCollectionData)
      {



          DataTable pOutputDataTable = new DataTable();
          pOutputDataTable.Columns.Add("Код Запроса", typeof(int));
          pOutputDataTable.Columns.Add("Адрес Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Запроса", typeof(string));
          pOutputDataTable.Columns.Add("Текст Ответа", typeof(string));
          pOutputDataTable.Columns.Add("Дата Запроса", typeof(string));

          string pСommandTextData = string.Format(@"Select * From
         HttpRequestObjectsTableBregis, HttpResponseObjectTableBregis
          WHERE HttpResponseObjectTableBregis.[HttpRequestId] =  HttpRequestObjectsTableBregis.[HttpRequestId]");

          pHttpResponseObjectCollectionRam.Clear();

          using (mySqlCommand = new SqlCommand())
          {
              mySqlCommand.Connection = pSqlConnection;
              mySqlCommand.CommandText = pСommandTextData;

              try
              {
                  mySqlDataReader = mySqlCommand.ExecuteReader();
                  while (mySqlDataReader.Read())
                  {
                      int pResponseId = Convert.ToInt32(mySqlDataReader["HttpResonseId"].ToString());
                      int pRequestId = Convert.ToInt32(mySqlDataReader["HttpRequestId"].ToString());
                      string pRequestAddress = Convert.ToString(mySqlDataReader["HttpAddress"].ToString());
                      string pRequestData = Convert.ToString(mySqlDataReader["HttpRequestData"].ToString());
                      string pResponseData = Convert.ToString(mySqlDataReader["HttpResponseData"].ToString());
                      int pHttpStatus = Convert.ToInt32(mySqlDataReader["HttpStatus"].ToString());

                      DateTime pDateOfRequest = Convert.ToDateTime(mySqlDataReader["DateOfRequest"].ToString());

                      CHttpResponseObject pHttpResponseObject = new CHttpResponseObject(pRequestId,
                         pRequestAddress,
                         pRequestData,
                         pResponseData,
                         pHttpStatus,
                         pDateOfRequest);
                      pHttpResponseObjectCollectionRam.Add(pHttpResponseObject);
                  }
              }
              catch (SqlException ex)
              {
                  ShowMessage(ex.Message.ToString());
              }
              finally
              {
                  mySqlDataReader.Close();
              }
          }


          foreach (CHttpResponseObject pRequestObject in pHttpResponseObjectCollectionRam)
          {
              pOutputDataTable.Rows.Add(pRequestObject.HttpRequestId,
                  pRequestObject.HttpAddress,
                  pRequestObject.HttpRequestData,
                  pRequestObject.HttpResponseData,
                  pRequestObject.DateOfRequest);
          }
          ppResponseObjectCollectionData = pHttpResponseObjectCollectionRam;
          return pOutputDataTable;
      }




        // содержимое ответа
      
               
            }



         }


    

