using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using BregisDigitalConverterServiceObject.SystemObjects;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BregisDigitalConverterServiceObject.ManagementClasses
{
   public class MedicalStaffManagementClass : DatabaseManagementClass
    {
        public List<DoctorsObjectClass> pListOfAvailableDoctors;
        public GlobalVariablesClass pGlobalVariablesClass;
        public DatabaseManagementClass myDatabaseManagementClass;
        public SqlConnection mySqlConnection;
        public MedicalStaffManagementClass()
        {
            pGlobalVariablesClass = Program.pGlobalVariablesClass;
            myDatabaseManagementClass = GlobalVariablesClass.pDatabaseManagementClass;
            mySqlConnection = myDatabaseManagementClass.mySqlConnection;
            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["pizzaString"].ConnectionString;
                mySqlConnection.Open();
            }
            pListOfAvailableDoctors = new List<DoctorsObjectClass>();
        }


       
        public List<DoctorsObjectClass> GetListOfDoctors()
        {
            pListOfAvailableDoctors = new List<DoctorsObjectClass>();
            string sqlStr = string.Format(@"Select * From DoctorsTable, DoctorSpecialities
                    WHERE DoctorsTable.[SpecialityCode] = DoctorSpecialities.[SpecialityCode]");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;

                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["PatientSurname"].ToString();
                        string secondName = mySqlDataReader["PatientSecondName"].ToString();
                        DateTime pDateOfBirth = Convert.ToDateTime(mySqlDataReader["DateOfBirth"].ToString());
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        int pInsuranceId = Convert.ToInt32(mySqlDataReader["InsuranceId"]);
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsername = mySqlDataReader["UserName"].ToString();
               
                    
                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                            doctorName,
                            doctorSurname,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsername);

                        pListOfAvailableDoctors.Add(pDoctorObjectClass);

                       
                            
                    }
                    
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    mySqlDataReader.Close();
                }
            }


                
                return  pListOfAvailableDoctors;


            }




        public DataTable DownloadInformationAboutDoctors(out List<DoctorsObjectClass> pListOfClients)
        {
           DataTable individualClientTable = new DataTable();
            individualClientTable = new DataTable();
            individualClientTable.Columns.Add("Id Доктора", typeof(int));
            individualClientTable.Columns.Add("Фамилия", typeof(string));
            individualClientTable.Columns.Add("Имя", typeof(string));
             individualClientTable.Columns.Add("Отчество", typeof(string));
            individualClientTable.Columns.Add("Aдрес", typeof(string));
            individualClientTable.Columns.Add("Серия Паспорта", typeof(string));
            individualClientTable.Columns.Add("Номер Паспорта", typeof(string));
            individualClientTable.Columns.Add("Код Подразделения", typeof(string));
            individualClientTable.Columns.Add("Дата Выдачи", typeof(string));
            individualClientTable.Columns.Add("Email", typeof(string));
            individualClientTable.Columns.Add("Номер Телефона", typeof(string));
            individualClientTable.Columns.Add("Специальность", typeof(string));
            individualClientTable.Columns.Add("Имя Пользователя", typeof(string));

            string sqlStr = string.Format(@"
USE DentalClinicsManagementDatabase
Select * From DoctorTable, DoctorSpecialities
                    WHERE DoctorTable.[SpecialityCode] = DoctorSpecialities.[SpecialityCode]");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;

                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["DoctorSurname"].ToString();
                        string secondName = mySqlDataReader["DoctorSecondName"].ToString();
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsername = mySqlDataReader["UserName"].ToString();
               
                    
                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                             doctorSurname,
                            doctorName,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsername);

                        pListOfAvailableDoctors.Add(pDoctorObjectClass);

                        individualClientTable.Rows.Add(
                          pDoctorObjectClass.DoctorId,
                           pDoctorObjectClass.DoctorSurname,
                          pDoctorObjectClass.DoctorName,
                          pDoctorObjectClass.DoctorSecondName,
                          pDoctorObjectClass.PostalAddress,
                          pDoctorObjectClass.PassportSeries,
                          pDoctorObjectClass.PassportNumber,
                          pDoctorObjectClass.IssurerCode,
                          pDoctorObjectClass.DateOfIssue,
                          pDoctorObjectClass.ContactEmail,
                          pDoctorObjectClass.ContactPhone,
                          pDoctorObjectClass.SpecialityCode,
                          pDoctorObjectClass.UserName);
                            
                    }
                    
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    mySqlDataReader.Close();
                }
            }


                pListOfClients = pListOfAvailableDoctors;
                return individualClientTable;


            }





       public void CreateNewWorkingSessionAndSaveToDatabase(int pSessionId, int pDoctorId,
           DateTime pDateOfSession)
        {

        }



        public void CreateDoctorRecordAndSaveTotDatabase(int pDoctorId,
            string pDoctorSurname, string pDoctorName, string pDoctorSecondName,
            string pPostalAddress, string pPassportSeries, string pPassportNumber,
            string pIssuerCode, DateTime pDateOfIssue, string pContactEmail, string pContactPhone,
            int pSpecialityCode, string pUserName)
        {
            if (pDoctorId == null)
            {
                MessageBox.Show("Поле Id не может быть пустым");
                return;
            }
            else
            {
                DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(pDoctorId,
                    pDoctorSurname, pDoctorName, pDoctorSecondName,
                    pPostalAddress, pPassportSeries, pPassportNumber, pIssuerCode, pDateOfIssue,
                    pContactEmail, pContactPhone, pSpecialityCode, pUserName);
                pListOfAvailableDoctors.Add(pDoctorObjectClass);
                InsertDoctorRecordToDatabase(pDoctorObjectClass);
            }

        }



    public string GetDoctorInitialsFromFile(string pSessionFile)
        {
            string pInitialsValue = null;
            Newtonsoft.Json.Linq.JObject pCurrentJsonRecord = new Newtonsoft.Json.Linq.JObject();

            using (StreamReader pReader = File.OpenText(pSessionFile))
            {
                pCurrentJsonRecord = (JObject)JToken.ReadFrom(new JsonTextReader(pReader));

                string pDoctorSurname = pCurrentJsonRecord["DoctorSurname"].ToString();
                string pDoctorName = pCurrentJsonRecord["DoctorName"].ToString();
                string pDoctorSecondName = pCurrentJsonRecord["DoctorSecondName"].ToString();

                pInitialsValue = pDoctorSurname + " " + pDoctorName + " " + pDoctorSecondName;
            }
            return pInitialsValue;
        }   


       public void CreateDoctorSessionObject(string pDoctorUsername, string pDoctorSessionFile)
        {
            List<DoctorsObjectClass> pMedicalStaffManagementList = new List<DoctorsObjectClass>();
            pMedicalStaffManagementList = GetDoctorObjectByUsername(pDoctorUsername);

            if (pMedicalStaffManagementList.Count == 0)
            {
                MessageBox.Show("Указанный Пользователь не проходил регистрацию в системе");
                return;
            }
            DoctorsObjectClass pCurrentDoctor = pMedicalStaffManagementList[0];

            Newtonsoft.Json.Linq.JObject pCurrentJsonRecord = new Newtonsoft.Json.Linq.JObject();
            pCurrentJsonRecord.Add("DoctorId", pCurrentDoctor.DoctorId);
            pCurrentJsonRecord.Add("DoctorSurname", pCurrentDoctor.DoctorSurname);
            pCurrentJsonRecord.Add("DoctorName", pCurrentDoctor.DoctorName);
            pCurrentJsonRecord.Add("DoctorSecondName", pCurrentDoctor.DoctorSecondName);
            pCurrentJsonRecord.Add("SessionDate", System.DateTime.Today.ToString());

            string pCurrentSessionString = pCurrentJsonRecord.ToString();
            System.IO.File.WriteAllText(pDoctorSessionFile, pCurrentSessionString);



        }


       public List<DoctorsObjectClass> GetDoctorObjectByName(string pName)
       {
           List<DoctorsObjectClass> pDoctorObjectListData = new List<DoctorsObjectClass>();
           string sqlStr = string.Format(@"Select * From DoctorTable WHERE
                   [DoctorName] LIKE @DoctorName");

           using (mySqlCommand = new SqlCommand())
           {
               mySqlCommand.Connection = mySqlConnection;
               mySqlCommand.CommandText = sqlStr;


               SqlParameter pDoctorNameParam = new SqlParameter();
               pDoctorNameParam.ParameterName = "@DoctorName";
               pDoctorNameParam.SourceColumn = "DoctorName";
               pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
               pDoctorNameParam.SqlValue = pName;
               mySqlCommand.Parameters.Add(pDoctorNameParam);



               try
               {
                   mySqlDataReader = mySqlCommand.ExecuteReader();
                   while (mySqlDataReader.Read())
                   {
                       int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                       string doctorName = mySqlDataReader["DoctorName"].ToString();
                       string doctorSurname = mySqlDataReader["DoctorSurname"].ToString();
                       string secondName = mySqlDataReader["DoctorSecondName"].ToString();
                       string postalAddress = mySqlDataReader["Address"].ToString();
                       string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                       string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                       string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                       string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                       string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                       DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                       int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                       string pUsername = mySqlDataReader["UserName"].ToString();


                       DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                           doctorInn,
                           doctorName,
                           doctorSurname,
                           secondName,
                           postalAddress,
                           pPassportSeries,
                           pPassportNumber,
                           pIssuerCode,
                           pDateOfIssue,
                           contactEmail,
                           contactPhone,
                           pSpecialityCode,
                           pUsername);
                       pDoctorObjectListData.Add(pDoctorObjectClass);

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
           return pDoctorObjectListData;
       }


        public List<DoctorsObjectClass> GetDoctorObjectByNameOnly(string pName)
        {
            List<DoctorsObjectClass> pDoctorObjectListData = new List<DoctorsObjectClass>();
            string sqlStr = string.Format(@"Select * From DoctorTable WHERE
                   [DoctorName] LIKE @DoctorName");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;


               SqlParameter pDoctorNameParam = new SqlParameter();
                pDoctorNameParam.ParameterName = "@DoctorName";
                pDoctorNameParam.SourceColumn = "DoctorName";
                pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorNameParam.SqlValue = pName;
                mySqlCommand.Parameters.Add(pDoctorNameParam);



                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["DoctorSurname"].ToString();
                        string secondName = mySqlDataReader["DoctorSecondName"].ToString();
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsername = mySqlDataReader["UserName"].ToString();


                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                            doctorName,
                            doctorSurname,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsername);
                        pDoctorObjectListData.Add(pDoctorObjectClass);

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
            return pDoctorObjectListData;
        }



        public List<DoctorsObjectClass> GetDoctorObjectByUsername(string pUsername)
        {
            List<DoctorsObjectClass> pDoctorObjectListData = new List<DoctorsObjectClass>();
            string sqlStr = string.Format(@"Select * From DoctorTable WHERE [UserName] LIKE @UserName");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;


                SqlParameter pDoctorNameParam = new SqlParameter();
                pDoctorNameParam.ParameterName = "@UserName";
                pDoctorNameParam.SourceColumn = "UserName";
                pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorNameParam.SqlValue = pUsername;
                mySqlCommand.Parameters.Add(pDoctorNameParam);



                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["DoctorSurname"].ToString();
                        string secondName = mySqlDataReader["DoctorSecondName"].ToString();
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsernameVar = mySqlDataReader["UserName"].ToString();


                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                            doctorSurname,
                            doctorName,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsernameVar);
                        pDoctorObjectListData.Add(pDoctorObjectClass);

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    mySqlDataReader.Close();
                }
            }
            return pDoctorObjectListData;
        }




        public List<DoctorsObjectClass> GetDoctorObjectByName(string pSurname, string pName, string pSecondName)
        {
            List<DoctorsObjectClass> pDoctorObjectListData = new List<DoctorsObjectClass>();
            string sqlStr = string.Format(@"Select * From DoctorsTable WHERE
                    [DoctorSurname] LIKE @DoctorSurname AND [DoctorName] LIKE @DoctorName 
                    AND [DoctorSecondName] LIKE @DoctorSecondName");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;


                SqlParameter pDoctorSurnameParam = new SqlParameter();
                pDoctorSurnameParam.ParameterName = "@DoctorSurname";
                pDoctorSurnameParam.SourceColumn = "DoctorSurname";
                pDoctorSurnameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorSurnameParam.SqlValue = pSurname;
                mySqlCommand.Parameters.Add(pDoctorSurnameParam);

                SqlParameter pDoctorNameParam = new SqlParameter();
                pDoctorNameParam.ParameterName = "@DoctorName";
                pDoctorNameParam.SourceColumn = "DoctorName";
                pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorNameParam.SqlValue = pName;
                mySqlCommand.Parameters.Add(pDoctorNameParam);


                SqlParameter pDoctorSecondNameParam = new SqlParameter();
                pDoctorSecondNameParam.ParameterName = "@DoctorSecondName";
                pDoctorSecondNameParam.SourceColumn = "DoctorSecondName";
                pDoctorSecondNameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorSecondNameParam.SqlValue = pSecondName;
                mySqlCommand.Parameters.Add(pDoctorSecondNameParam);



                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["PatientSurname"].ToString();
                        string secondName = mySqlDataReader["PatientSecondName"].ToString();
                        DateTime pDateOfBirth = Convert.ToDateTime(mySqlDataReader["DateOfBirth"].ToString());
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        int pInsuranceId = Convert.ToInt32(mySqlDataReader["InsuranceId"]);
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsername = mySqlDataReader["UserName"].ToString();

                        string pUsernameVar = mySqlDataReader["UserName"].ToString();


                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                            doctorSurname,
                            doctorName,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsernameVar);
                        pDoctorObjectListData.Add(pDoctorObjectClass);

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
            return pDoctorObjectListData;
        }



        public List<DoctorsObjectClass> GetDoctorObjectByNameParam(string pName)
        {
            List<DoctorsObjectClass> pDoctorObjectListData = new List<DoctorsObjectClass>();
            string sqlStr = string.Format(@"Select * From DoctorsTable WHERE
                   [DoctorName] LIKE @DoctorName 
                    ");

            using (mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = sqlStr;


                SqlParameter pDoctorNameParam = new SqlParameter();
                pDoctorNameParam.ParameterName = "@DoctorName";
                pDoctorNameParam.SourceColumn = "DoctorName";
                pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
                pDoctorNameParam.SqlValue = pName;
                mySqlCommand.Parameters.Add(pDoctorNameParam);




                try
                {
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    while (mySqlDataReader.Read())
                    {
                        int doctorInn = Convert.ToInt32(mySqlDataReader["DoctorId"]);
                        string doctorName = mySqlDataReader["DoctorName"].ToString();
                        string doctorSurname = mySqlDataReader["PatientSurname"].ToString();
                        string secondName = mySqlDataReader["PatientSecondName"].ToString();
                        DateTime pDateOfBirth = Convert.ToDateTime(mySqlDataReader["DateOfBirth"].ToString());
                        string postalAddress = mySqlDataReader["Address"].ToString();
                        int pInsuranceId = Convert.ToInt32(mySqlDataReader["InsuranceId"]);
                        string contactEmail = mySqlDataReader["ContactEmail"].ToString();
                        string contactPhone = mySqlDataReader["ContactPhone"].ToString();
                        string pPassportSeries = mySqlDataReader["PassportSeries"].ToString();
                        string pPassportNumber = mySqlDataReader["PassportNumber"].ToString();
                        string pIssuerCode = mySqlDataReader["IssuerCode"].ToString();
                        DateTime pDateOfIssue = Convert.ToDateTime(mySqlDataReader["DateOfIssue"].ToString());
                        int pSpecialityCode = Convert.ToInt32(mySqlDataReader["SpecialityCode"].ToString());
                        string pUsername = mySqlDataReader["UserName"].ToString();

                        string pUsernameVar = mySqlDataReader["UserName"].ToString();


                        DoctorsObjectClass pDoctorObjectClass = new DoctorsObjectClass(
                            doctorInn,
                            doctorSurname,
                            doctorName,
                            secondName,
                            postalAddress,
                            pPassportSeries,
                            pPassportNumber,
                            pIssuerCode,
                            pDateOfIssue,
                            contactEmail,
                            contactPhone,
                            pSpecialityCode,
                            pUsernameVar);
                        pDoctorObjectListData.Add(pDoctorObjectClass);

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
            return pDoctorObjectListData;
        }
            public void InsertDoctorRecordToDatabase(DoctorsObjectClass pDoctorObjectClass)
            {
                string pSqlStr = string.Format(@"Insert Into DoctorTable
                                 VALUES (@DoctorId,
                @DoctorSurname,  @DoctorName, @DoctorSecondName,
                @PostalAddress, @PassportSeries,
                @PassportNumber, @IssuerCode,
                @DateOfIssue, @ContactEmail, @ContactPhone,
                @SpecialityCode, @UserName)");


             using (mySqlCommand = new SqlCommand())
             {
                 mySqlCommand.Connection = mySqlConnection;
                 mySqlCommand.CommandText = pSqlStr;
                
                SqlParameter pDoctorIdParam = new SqlParameter();
                 pDoctorIdParam.ParameterName = "@DoctorId";
                 pDoctorIdParam.SourceColumn = "DoctorId";
                 pDoctorIdParam.SqlDbType = SqlDbType.Int;
                 pDoctorIdParam.SqlValue = pDoctorObjectClass.DoctorId;
                 mySqlCommand.Parameters.Add(pDoctorIdParam);

                 SqlParameter pDoctorNameParam = new SqlParameter();
                 pDoctorNameParam.ParameterName = "@DoctorName";
                 pDoctorNameParam.SourceColumn = "DoctorName";
                 pDoctorNameParam.SqlDbType = SqlDbType.NVarChar;
                 pDoctorNameParam.SqlValue = pDoctorObjectClass.DoctorName;
                 mySqlCommand.Parameters.Add(pDoctorNameParam);

                 
                 SqlParameter pDoctorSurnameParam = new SqlParameter();
                 pDoctorSurnameParam.ParameterName = "@DoctorSurname";
                 pDoctorSurnameParam.SourceColumn = "DoctorSurname";
                 pDoctorSurnameParam.SqlDbType = SqlDbType.NVarChar;
                 pDoctorSurnameParam.SqlValue = pDoctorObjectClass.DoctorSurname;
                 mySqlCommand.Parameters.Add(pDoctorSurnameParam);

                 SqlParameter pDoctorSecondNameParam = new SqlParameter();
                 pDoctorSecondNameParam.ParameterName = "@DoctorSecondName";
                 pDoctorSecondNameParam.SourceColumn = "DoctorSecondName";
                 pDoctorSecondNameParam.SqlDbType = SqlDbType.NVarChar;
                 pDoctorSecondNameParam.SqlValue = pDoctorObjectClass.DoctorSecondName;
                 mySqlCommand.Parameters.Add(pDoctorSecondNameParam);

                 SqlParameter pPostalAddressParam = new SqlParameter();
                 pPostalAddressParam.ParameterName = "@PostalAddress";
                 pPostalAddressParam.SourceColumn = "PostalAddress";
                 pPostalAddressParam.SqlDbType = SqlDbType.NVarChar;
                 pPostalAddressParam.SqlValue = pDoctorObjectClass.PostalAddress;
                 mySqlCommand.Parameters.Add(pPostalAddressParam);


                 SqlParameter pPassportSeriesParam = new SqlParameter();
                 pPassportSeriesParam.ParameterName = "@PassportSeries";
                 pPassportSeriesParam.SourceColumn = "PassportSeries";
                 pPassportSeriesParam.SqlDbType = SqlDbType.NVarChar;
                 pPassportSeriesParam.SqlValue = pDoctorObjectClass.PassportSeries;
                 mySqlCommand.Parameters.Add(pPassportSeriesParam);


                 SqlParameter pPassportNumberParam = new SqlParameter();
                 pPassportNumberParam.ParameterName = "@PassportNumber";
                 pPassportNumberParam.SourceColumn = "PassportNumber";
                 pPassportNumberParam.SqlDbType = SqlDbType.NVarChar;
                 pPassportNumberParam.SqlValue = pDoctorObjectClass.PassportNumber;
                 mySqlCommand.Parameters.Add(pPassportNumberParam);

                 SqlParameter pIssuerCodeParam = new SqlParameter();
                 pIssuerCodeParam.ParameterName = "@IssuerCode";
                 pIssuerCodeParam.SourceColumn = "IssuerCode";
                 pIssuerCodeParam.SqlDbType = SqlDbType.NVarChar;
                 pIssuerCodeParam.SqlValue = pDoctorObjectClass.IssurerCode;
                 mySqlCommand.Parameters.Add(pIssuerCodeParam);

                  SqlParameter pDateOfIssueParam = new SqlParameter();
                 pDateOfIssueParam.ParameterName = "@DateOfIssue";
                 pDateOfIssueParam.SourceColumn = "DateOfIssue";
                 pDateOfIssueParam.SqlDbType = SqlDbType.DateTime;
                 pDateOfIssueParam.SqlValue = pDoctorObjectClass.DateOfIssue;
                 mySqlCommand.Parameters.Add(pDateOfIssueParam);

                
                  SqlParameter pContactEmailParam = new SqlParameter();
                 pContactEmailParam.ParameterName = "@ContactEmail";
                 pContactEmailParam.SourceColumn = "ContactEmail";
                 pContactEmailParam.SqlDbType = SqlDbType.NVarChar;
                 pContactEmailParam.SqlValue = pDoctorObjectClass.ContactEmail;
                 mySqlCommand.Parameters.Add(pContactEmailParam);

                 
                
                  SqlParameter pContactPhoneParam = new SqlParameter();
                 pContactPhoneParam.ParameterName = "@ContactPhone";
                 pContactPhoneParam.SourceColumn = "ContactPhone";
                 pContactPhoneParam.SqlDbType = SqlDbType.NVarChar;
                 pContactPhoneParam.SqlValue = pDoctorObjectClass.ContactPhone;
                 mySqlCommand.Parameters.Add(pContactPhoneParam);

                                 
                  SqlParameter pSpecialityCodeParam = new SqlParameter();
                 pSpecialityCodeParam.ParameterName = "@SpecialityCode";
                 pSpecialityCodeParam.SourceColumn = "SpecialityCode";
                 pSpecialityCodeParam.SqlDbType = SqlDbType.Int;
                 pSpecialityCodeParam.SqlValue = pDoctorObjectClass.SpecialityCode;
                 mySqlCommand.Parameters.Add(pSpecialityCodeParam);

                                          
                  SqlParameter pUserNameParam = new SqlParameter();
                 pUserNameParam.ParameterName = "@UserName";
                 pUserNameParam.SourceColumn = "UserName";
                 pUserNameParam.SqlDbType = SqlDbType.NVarChar;
                 pUserNameParam.SqlValue = pDoctorObjectClass.UserName;
                 mySqlCommand.Parameters.Add(pUserNameParam);


                 try
                 {
                     mySqlCommand.ExecuteNonQuery();
                 }
                 catch (SqlException ex)
                 {
                     throw ex;
                 }



             }
            }



        }


    }
