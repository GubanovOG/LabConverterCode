using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BregisDigitalConverterServiceObject.SystemObjects;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;



namespace BregisDigitalConverterServiceObject.ManagementClasses
{
    public class SpecimenDataManagementClass : DatabaseManagementClass
    {
        public List<AdditionalFormObjectClass> pAdditionalFormObjectList;
        public List<SpecimentTypeObject> pSpecimentTypeList;
        public SqlConnection pMySqlConnection;
        public DataTable pOutputDataTable;
        public GlobalVariablesClass pGlobalVariablesClass;
        public DatabaseManagementClass pDatabaseManagementClass;
        public SqlConnection pSqlConnection;
        public SqlCommand pMySqlCommand;
        public SpecimenDataManagementClass()
        {
            pAdditionalFormObjectList = new List<AdditionalFormObjectClass>();
            if (pDatabaseManagementClass == null)
            {
                pDatabaseManagementClass = new DatabaseManagementClass();
                pDatabaseManagementClass.EstablishConnectionToDatabase();
            }
            pSqlConnection = pDatabaseManagementClass.mySqlConnection;
            if (pSqlConnection.State != ConnectionState.Open)
            {
                pSqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pizzaString"].ConnectionString;
                pSqlConnection.Open();
            }
        }

        public DataTable DownloadDataAboutAdditionalForms(out List<AdditionalFormObjectClass> pAdditionaFormObjectListOutput)
        {

            DataTable pLocalTable = new DataTable();
            pAdditionalFormObjectList = new List<AdditionalFormObjectClass>();
            pLocalTable.Columns.Add("Код Дополнительной Формы", typeof(int));
            pLocalTable.Columns.Add("Код типа Образца", typeof(int));
            pLocalTable.Columns.Add("Название Формы", typeof(string));
            pLocalTable.Columns.Add("Значение Формы", typeof(string));

            string pSqlStr = string.Format(@"SELECT *
                        FROM AdditionFormObjects, SpecimentTypes
                WHERE AdditionFormObjects.[SpecimentTypeCode] =  SpecimentTypes.[SpencimentTypeId]");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.CommandText = pSqlStr;
                mySqlCommand.Connection = pSqlConnection;

                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int pAddiitionalFormCode = Convert.ToInt32(mySqlDataReader["AddtionalFormObjectCode"].ToString());
                        int pSpecimentTypeCode = Convert.ToInt32(mySqlDataReader["SpecimentTypeCode"].ToString());
                        int pValueId = Convert.ToInt32(mySqlDataReader["ValueId"].ToString());
                        string pSpecimentTypeName = mySqlDataReader["SpecimentName"].ToString();
                        float pFormValue = float.Parse(mySqlDataReader["Value"].ToString());

                        AdditionalFormObjectClass pAdditionalFormObjectClass = new AdditionalFormObjectClass(
                            pAddiitionalFormCode,
                            pSpecimentTypeCode,
                            pSpecimentTypeName,
                            pValueId,
                            pFormValue);

                        pAdditionalFormObjectList.Add(pAdditionalFormObjectClass);

                        pLocalTable.Rows.Add(pAdditionalFormObjectClass.AdditionalFormCode,
                            pAdditionalFormObjectClass.SpecimenTypeCode,
                            pAdditionalFormObjectClass.SpecimenTypeName,
                            pAdditionalFormObjectClass.FormValue);
                        
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    mySqlDataReader.Close();
                }
            }
            pAdditionaFormObjectListOutput = pAdditionalFormObjectList;
            return pLocalTable;
        }



        public DataTable DownloadDataAboutSpecimentTypes(out List<SpecimentTypeObject> pAdditionaFormObjectListOutput)
        {

            DataTable pLocalTable = new DataTable();
            pAdditionalFormObjectList = new List<AdditionalFormObjectClass>();
            pLocalTable.Columns.Add("Код типа Образца", typeof(int));
            pLocalTable.Columns.Add("Название типа Образца", typeof(string));
            pLocalTable.Columns.Add("Описание типа Образца", typeof(string));
   
            string pSqlStr = string.Format(@"SELECT *
                        FROM SpecimentTypes");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.CommandText = pSqlStr;
                mySqlCommand.Connection = pSqlConnection;

                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                         int pSpecimentTypeCode = Convert.ToInt32(mySqlDataReader["SpecimentTypeCode"].ToString());
                        string pSpecimentTypeName = mySqlDataReader["SpecimentTypeName"].ToString();
                        string pSpecimentTypeDescription = mySqlDataReader["SpecimentTypeDescription"].ToString();
                        SpecimentTypeObject pSpecimentTypeObject = new SpecimentTypeObject(
                            pSpecimentTypeCode,
                            pSpecimentTypeName,
                             pSpecimentTypeDescription);

                        pSpecimentTypeList.Add(pSpecimentTypeObject);

                        pLocalTable.Rows.Add(pSpecimentTypeObject.SpecimentTypeId,
                            pSpecimentTypeName,
                            pSpecimentTypeDescription);

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                    mySqlDataReader.Close();
                }
            }
            pAdditionaFormObjectListOutput = pSpecimentTypeList;
            return pLocalTable;
        }



    }
}


