using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Admin.Component
{
    public class clsrewardsDef
    {

        public int RewardQuestionID { get; set; }
        public int CustomerID { get; set; }
        public int DinedInRestaurantID { get; set; }
        public DateTime? DiningDate { get; set; }
        public int NumberOfGuests { get; set; }
        public float TotalbillWithoutGratuities { get; set; }
        public string DishOrdered { get; set; }
        public string FavouriteDish { get; set; }
        public string IsInitialCustomer { get; set; }
        public string PaymentType { get; set; }
        public int VerificationStatusID { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string ReceiptOrCCNO { get; set; }
        public string Dining { get; set; }
        public string RestaurantDailyCode { get; set; }


        public clsrewardsDef()
        {
            RewardQuestionID = 0;
            CustomerID = 0;
            DinedInRestaurantID = 0;
            DiningDate = DateTime.Now;
            NumberOfGuests = 0;
            TotalbillWithoutGratuities = 0;
            DishOrdered = "";
            FavouriteDish = "";
            IsInitialCustomer = "";
            PaymentType = "";
            VerificationStatusID = 0;
            CreationDateTime = DateTime.Now;
            ReceiptOrCCNO = "";
            RestaurantDailyCode = "";
        }
    }

    public class clsrewards
    {
        public static int fnInsert_QuestionRewards(clsrewardsDef objclsrewards)
        {
            int val = 0;
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@RewardQuestionID", objclsrewards.RewardQuestionID);
            param[1] = new SqlParameter("CustomerID", objclsrewards.CustomerID);
            param[2] = new SqlParameter("ReceiptOrCCNO", objclsrewards.ReceiptOrCCNO);
            param[3] = new SqlParameter("DinedInRestaurantID", objclsrewards.DinedInRestaurantID);
            param[4] = new SqlParameter("DiningDate", objclsrewards.DiningDate);
            param[5] = new SqlParameter("NumberOfGuests", objclsrewards.NumberOfGuests);
            param[6] = new SqlParameter("TotalbillWithoutGratuities", objclsrewards.TotalbillWithoutGratuities);
            param[7] = new SqlParameter("DishOrdered", objclsrewards.DishOrdered);
            param[8] = new SqlParameter("FavouriteDish", objclsrewards.FavouriteDish);
            param[9] = new SqlParameter("IsInitialCustomer", objclsrewards.IsInitialCustomer);
            param[10] = new SqlParameter("PaymentType", objclsrewards.PaymentType);
            param[11] = new SqlParameter("VerificationStatusID", objclsrewards.VerificationStatusID);
            param[12] = new SqlParameter("CreationDateTime", objclsrewards.CreationDateTime);
            param[13] = new SqlParameter("@ReturnRewardQuestionID", SqlDbType.Int);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@Dining", objclsrewards.Dining);
            param[15] = new SqlParameter("@RestaurantDailyCode", objclsrewards.RestaurantDailyCode);
            SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Reward_SetValue", param);
            val = Convert.ToInt32(param[13].Value.ToString());
            return val;
        }
        //Get Rewards Points.................................................................
        public static DataTable GetRewards(int intCustomerID)
        {

            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetRewaardsPoint", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@CustomerID", intCustomerID));
            //Command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_LastDate));

            SqlDataAdapter dadapt = new SqlDataAdapter();
            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "RewardQuestion1");
                Connection.Close();
                return ds.Tables["RewardQuestion1"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public static DataTable GetAllRewards()
        {

            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetAllRewaards", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dadapt = new SqlDataAdapter();
            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "RewardQuestion");
                Connection.Close();
                return ds.Tables["RewardQuestion"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public static DataTable GetRewardsByRestaurant(int intRestaurantsID)
        {

            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetRewardsByRestaurant", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@DinedInRestaurantID", intRestaurantsID));
            //Command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_LastDate));

            SqlDataAdapter dadapt = new SqlDataAdapter();
            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "RewardQuestion");
                Connection.Close();
                return ds.Tables["RewardQuestion"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public static DataTable GetRewardsPointByCustomer(int intCustomerID)
        {

            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetRewardsPointByCustomer", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@CustomerID", intCustomerID));
            SqlDataAdapter dadapt = new SqlDataAdapter();

            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "RewardQuestion");
                Connection.Close();
                return ds.Tables["RewardQuestion"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }

        //Generate Number for Restaurant
        public static int AddDinnerCode(string strDinnerCode, int intRestaurantID, string strPeriod, string strStatus, DateTime dtEntryDate, string strDescriptionLog)
        {
            SqlParameter[] sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@DinnerCode", strDinnerCode);
            sqlparam[1] = new SqlParameter("@intRestUserID", intRestaurantID);
            sqlparam[2] = new SqlParameter("@EntryDate", dtEntryDate);
            sqlparam[3] = new SqlParameter("@DinnerCodeLog", strDescriptionLog);
            sqlparam[4] = new SqlParameter("@Period", strPeriod);
            sqlparam[5] = new SqlParameter("@Status", strStatus);
            // sqlparam[4].Direction = ParameterDirection.Output;
            int j = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "MyDinnerCodeInsert", sqlparam));
            return j;
        }

        //DinnerCode, RestaurantID, EntryDate, DinnerCodeLog
        public static int CountDinnerCode(int intRestUserID)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT Count(DinnerLogID) as Expr1  FROM tbl_DinnerCode WHERE intRestUserID=@intRestUserID";
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@intRestUserID", intRestUserID);

            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        //SELECT Count(DinnerLogID)  FROM tbl_DinnerCode WHERE RestaurantID='1'
        public static DataTable GetDinnerCode(int intRestUserID, DateTime dtStartDate, DateTime dtEndDate)
        {

            string strQuery = string.Empty;
            strQuery = "  Select TOP(1)  DINNERCODE ,EntryDate,Period,Status  from tbl_DinnerCode WHERE intRestUserID=@intRestUserID and EntryDate between @StartDate and @EndDate  order by EntryDate desc";
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand(strQuery, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add(new SqlParameter("@intRestUserID", intRestUserID));
            Command.Parameters.Add(new SqlParameter("@StartDate", dtStartDate));
            Command.Parameters.Add(new SqlParameter("@EndDate", dtEndDate));
            SqlDataAdapter dadapt = new SqlDataAdapter();

            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "DinnerCode");
                Connection.Close();
                return ds.Tables["DinnerCode"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public static DataTable GetDinnerCode(int intRestUserID)
        {

            string strQuery = string.Empty;
            strQuery = "  Select TOP(1)  DINNERCODE ,EntryDate,Period,Status  from tbl_DinnerCode WHERE intRestUserID=@intRestUserID  order by EntryDate desc";
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand(strQuery, Connection);
            Command.CommandType = CommandType.Text;
            Command.Parameters.Add(new SqlParameter("@intRestUserID", intRestUserID));
            SqlDataAdapter dadapt = new SqlDataAdapter();

            dadapt.SelectCommand = Command;
            try
            {

                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "DinnerCode");
                Connection.Close();
                return ds.Tables["DinnerCode"];
            }
            catch
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
        public static int fnSaveRewardsBalance(string strCustomerID, int intRewardPointBalance)
        {
            int val = 0;
            string strQuery = string.Empty;
            //strQuery = "Insert into tbl_Contacts(ContactEmail,ContactName,IsApproved,User_Code)values(@ContactEmail,@ContactName,@IsApproved,@User_Code)";
            SqlParameter[] objParameter = new SqlParameter[2];
            objParameter[0] = new SqlParameter("@CustomerID", strCustomerID);
            objParameter[1] = new SqlParameter("@RewardPointBalance", intRewardPointBalance);
            val = SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "spAddRewards", objParameter);
            return val;
        }// 
        public static int CustomerRewardBalance(string strCustomerID)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT isnull(sum(RewardPointBalance),0) as RewardPointBalance   FROM TBL_CustomerReward where CustomerID=@CustomerID";
            SqlParameter objParameter = new SqlParameter("@CustomerID", strCustomerID);
            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        public static int CustomerRewardBalanceRedeemed(string strCustomerID)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT isnull( sum(RewardPointBalance),0) as RedeemedPoint FROM TBL_CustomerReward where RewardPointBalance < 0 and CustomerID=@CustomerID";
            SqlParameter objParameter = new SqlParameter("@CustomerID", strCustomerID);
            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }

        public static DataTable GetGiftcertificate(int intRestoaurantID)
        {
            string strQuery = "select * from TBL_GiftCertificate where ResturantID=@ResturantID";
            SqlParameter objParameter = new SqlParameter("@ResturantID", intRestoaurantID);
            DataTable dtGiftCertificate = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).Tables[0];
            return dtGiftCertificate;
        }
        public static DataTable GetImagesRestoaurnat()
        {

            DataTable dtImages = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "getRestoaurantImages").Tables[0];
            return dtImages;

        }
        public static DataTable GetImagesRestoaurnat(int intRestoaurantID)
        {
            string strQuery = "Select gallary_filename from TBL_RestaurantGallerys where Restaurant_ID =@Restaurant_ID";
            SqlParameter objParameter = new SqlParameter("@Restaurant_ID", intRestoaurantID);
            DataTable dtImages = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).Tables[0];
            return dtImages;

        }
        public static DataTable GetRestaurants(string strZipCode)
        {
            string strQuery = "SELECT  TBL_Restaurants.Restaurants_name,Restaurants_id, TBL_Restaurants.Restaurants_zip, TBL_Restaurants.Restaurants_city, Tbl_RestServicesDetail.ServiceID  FROM  Tbl_RestServicesDetail INNER JOIN  TBL_Restaurants ON Tbl_RestServicesDetail.RestaurantID = TBL_Restaurants.Restaurants_id WHERE (Tbl_RestServicesDetail.ServiceID = 6) AND status='0' and Restaurants_zip like '" + strZipCode + "%'";
            DataTable dtRest = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery).Tables[0];
            return dtRest;
            // return 
        }
        public static DataTable GetRestaurantName(int intResturantID)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@Restid", intResturantID);

            DataTable dtRestName = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Restaurant_GetRestaurantById_sp", sqlparam).Tables[0];
            return dtRestName;

        }
        public static int saveGiftCertificate(DateTime CertificateEnteryDate, string strCertificateCode, int intResturantID, int intCertificateValue, int intCertificateStatusID, int intCertificateOwnerID, int intQuantiry)
        {
            int val = 0;
            string strQuery = string.Empty;
            strQuery = "INSERT INTO TBL_Certificate(CertificateEnteryDate,CertificateCode,ResturantID,CertificateValue,CertificateStatusID,CertificateOwnerID,CertificateQuantity) values(@CertificateEnteryDate,@CertificateCode,@ResturantID,@CertificateValue,@CertificateStatusID,@CertificateOwnerID,@CertificateQuantity)";
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@CertificateEnteryDate", CertificateEnteryDate);
            sqlparam[1] = new SqlParameter("@CertificateCode", strCertificateCode);
            sqlparam[2] = new SqlParameter("@ResturantID", intResturantID);
            sqlparam[3] = new SqlParameter("@CertificateValue", intCertificateValue);
            sqlparam[4] = new SqlParameter("@CertificateStatusID", intCertificateStatusID);
            sqlparam[5] = new SqlParameter("@CertificateQuantity", intQuantiry);
            sqlparam[6] = new SqlParameter("@CertificateOwnerID", intCertificateOwnerID);
            val = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam));
            return val;
        }
        public static DataTable GetCertificateByRestuarant(int intResturantID)
        {
            string strQuery = "SELECT CertificateEnteryDate,CertificateCode,ResturantID,CertificateValue,CertificateStatusID,CertificateOwnerID,CertificateQuantity  FROM TBL_Certificate Where ResturantID=@ResturantID";
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ResturantID", intResturantID);
            DataTable dtRestName = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtRestName;

        }

        public static DataTable GetCertificateCode(int intResturantID, int intCertifciateQuantity)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT TOP(1) TBL_Certificate.CertificateID, TBL_Certificate.CertificateEnteryDate, TBL_Certificate.CertificateCode, TBL_Certificate.ResturantID,";
            strQuery += "TBL_Certificate.CertificateValue, TBL_Certificate.CertificateStatusID, TBL_Certificate.CertificateQuantity,";
            strQuery += "isnull((select top 1 [Gallary_filename] From TBL_RestaurantGallerys where [Restaurant_id] = [Restaurants_id] and [Gallary_ShowHome]='**'";
            strQuery += "and  [Gallary_filepos]=0 order by [Gallary_fileDate]),'None.jpg') as filename ,";
            strQuery += "TBL_Restaurants.Restaurants_name FROM  TBL_Certificate INNER JOIN TBL_Restaurants ON TBL_Certificate.ResturantID = TBL_Restaurants.Restaurants_id";
            strQuery += " Where ResturantID=@ResturantID AND CertificateQuantity=@CertificateQuantity And CertificateStatusID=@CertificateStatusID ";
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@ResturantID", intResturantID);
            sqlparam[1] = new SqlParameter("CertificateQuantity", intCertifciateQuantity);
            sqlparam[2] = new SqlParameter("CertificateStatusID", 1);
            DataTable dtCertificates = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtCertificates;

        }

        public static int saveTransactionRedeemed(DateTime dtTransanctionDate, int intTransactionRecieved, int intCertificateID, int intCustomerID, string StatusID, string strSecurityNo, string strClassified, string strRewards, string strManualID)
        {
            int val = 0;
            string strQuery = string.Empty;
            strQuery = "INSERT INTO tblTransactionLog  (TransanctionDate  ,TransactionRecieved  ,CertificateID  ,CustomerID  ,Status ,SecurityNo  ,Classified ,Reward,ManualID,Sold) VALUES(@TransanctionDate  ,@TransactionRecieved,@CertificateID, @CustomerID, @Status,@SecurityNo, @Classified,@Reward,@ManualID,@Sold) SET @TransactionID = SCOPE_IDENTITY()";
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@TransanctionDate", dtTransanctionDate);
            sqlparam[1] = new SqlParameter("@TransactionRecieved", intTransactionRecieved);
            sqlparam[2] = new SqlParameter("@CertificateID", intCertificateID);
            sqlparam[3] = new SqlParameter("@CustomerID", intCustomerID);
            sqlparam[4] = new SqlParameter("@Status", StatusID);
            sqlparam[5] = new SqlParameter("@SecurityNo", strSecurityNo);
            sqlparam[6] = new SqlParameter("@Classified", strClassified);
            sqlparam[7] = new SqlParameter("@Reward", strRewards);
            sqlparam[8] = new SqlParameter("@ManualID", strManualID);
            sqlparam[9] = new SqlParameter("@TransactionID", SqlDbType.Int);
            sqlparam[9].Direction = ParameterDirection.Output;
            sqlparam[10] = new SqlParameter("@Sold", 0);
            SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam);
            val = (int)sqlparam[9].Value;

            return val;
        }
        public static int saveTransactionRewardRedeemed(DateTime dtTransanctionDate, int intTransactionRecieved, int intCertificateID, int intCustomerID, string StatusID, string strSecurityNo, string strClassified, string strRewards, string strManualID)
        {
            int val = 0;
            string strQuery = string.Empty;
            strQuery = "INSERT INTO tblTransactionLog  (TransanctionDate  ,TransactionRecieved  ,CertificateID  ,CustomerID  ,Status ,SecurityNo  ,Classified ,Reward,ManualID) VALUES(@TransanctionDate  ,@TransactionRecieved,@CertificateID, @CustomerID, @Status,@SecurityNo, @Classified,@Reward,@ManualID) SET @TransactionID = SCOPE_IDENTITY()";
            SqlParameter[] sqlparam = new SqlParameter[10];
            sqlparam[0] = new SqlParameter("@TransanctionDate", dtTransanctionDate);
            sqlparam[1] = new SqlParameter("@TransactionRecieved", intTransactionRecieved);
            sqlparam[2] = new SqlParameter("@CertificateID", intCertificateID);
            sqlparam[3] = new SqlParameter("@CustomerID", intCustomerID);
            sqlparam[4] = new SqlParameter("@Status", StatusID);
            sqlparam[5] = new SqlParameter("@SecurityNo", strSecurityNo);
            sqlparam[6] = new SqlParameter("@Classified", strClassified);
            sqlparam[7] = new SqlParameter("@Reward", strRewards);
            sqlparam[8] = new SqlParameter("@ManualID", strManualID);
            sqlparam[9] = new SqlParameter("@TransactionID", SqlDbType.Int);
            sqlparam[9].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam);
            val = (int)sqlparam[9].Value;

            return val;
        }
        public static DataTable getGiftCertificateLog()
        {
            string strQuery = "SELECT     tblTransactionLog.TransactionID, tblTransactionLog.Sold, tblTransactionLog.TransanctionDate, tblTransactionLog.TransactionRecieved, ";
            strQuery += " tblTransactionLog.CustomerID, tblTransactionLog.Status, tblTransactionLog.Classified, tblTransactionLog.SecurityNo, tblTransactionLog.Reward,";
            strQuery += " tblTransactionLog.ManualID, TBL_Restaurants.Restaurants_name, TBL_Certificate.CertificateID, TBL_Certificate.CertificateValue";
            strQuery += " FROM  TBL_Restaurants INNER JOIN ";
            strQuery += " TBL_Certificate ON TBL_Restaurants.Restaurants_id = TBL_Certificate.ResturantID LEFT OUTER JOIN";
            strQuery += " tblTransactionLog ON TBL_Certificate.CertificateID = tblTransactionLog.CertificateID";

            //strQuery += "tblTransactionLog.Status, tblTransactionLog.Classified, tblTransactionLog.SecurityNo, tblTransactionLog.Reward, tblTransactionLog.ManualID, ";
            //strQuery += "ISNULL(TBL_RestUsers.vcFirstName + ' ' + TBL_RestUsers.vcLastName, 0) AS UserName,TBL_Restaurants.Restaurants_name,TBL_Certificate.CertificateID ,";
            //strQuery += " TBL_Certificate.CertificateValue FROM   TBL_Restaurants INNER JOIN   TBL_Certificate ON TBL_Restaurants.Restaurants_id = TBL_Certificate.ResturantID LEFT OUTER JOIN";
            //strQuery += " TBL_RestUsers INNER JOIN";
            //strQuery += " tblTransactionLog ON TBL_RestUsers.intRestUserID = tblTransactionLog.CustomerID ON TBL_Certificate.CertificateID = tblTransactionLog.CertificateID ";

            DataTable dtGiftCertificateLog = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery).Tables[0];
            return dtGiftCertificateLog;


        }
        public static DataTable getGiftCertificateLog(int intResuarantID)
        {
            string strQuery = "SELECT     tblTransactionLog.TransactionID, tblTransactionLog.Sold, tblTransactionLog.TransanctionDate, tblTransactionLog.TransactionRecieved, ";
            strQuery += " tblTransactionLog.CustomerID, tblTransactionLog.Status, tblTransactionLog.Classified, tblTransactionLog.SecurityNo, tblTransactionLog.Reward,";
            strQuery += " tblTransactionLog.ManualID, TBL_Restaurants.Restaurants_name, TBL_Certificate.CertificateID, TBL_Certificate.CertificateValue";
            strQuery += " FROM  TBL_Restaurants INNER JOIN ";
            strQuery += " TBL_Certificate ON TBL_Restaurants.Restaurants_id = TBL_Certificate.ResturantID LEFT OUTER JOIN";
            strQuery += " tblTransactionLog ON TBL_Certificate.CertificateID = tblTransactionLog.CertificateID Where Restaurants_id=@Restaurants_id";

            //strQuery += " TBL_Restaurants ON TBL_Certificate.ResturantID = TBL_Restaurants.Restaurants_id where Restaurants_id=@Restaurants_id ";
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@Restaurants_id", intResuarantID);
            DataTable dtGiftCertificateLog = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtGiftCertificateLog;


        }
        public static string getUserName(string strRestUserId)
        {
            string value = "";
            string strQuery = " SELECT ISNULL(TBL_RestUsers.vcFirstName + ' ' + TBL_RestUsers.vcLastName, '') AS UserName FROM TBL_RestUsers  where intRestUserId=@intRestUserId";
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@intRestUserId", strRestUserId);
            value = SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).ToString();
            return value;
        }



        public static DataTable getGiftCertificateLog(int intResuarantID, DateTime dtToDate, DateTime dtFromDate)
        {
            string strQuery = "SELECT     tblTransactionLog.TransactionID, tblTransactionLog.Sold, tblTransactionLog.TransanctionDate, tblTransactionLog.TransactionRecieved, ";
            strQuery += " tblTransactionLog.CustomerID, tblTransactionLog.Status, tblTransactionLog.Classified, tblTransactionLog.SecurityNo, tblTransactionLog.Reward,";
            strQuery += " tblTransactionLog.ManualID, TBL_Restaurants.Restaurants_name, TBL_Certificate.CertificateID, TBL_Certificate.CertificateValue";
            strQuery += " FROM  TBL_Restaurants INNER JOIN ";
            strQuery += " TBL_Certificate ON TBL_Restaurants.Restaurants_id = TBL_Certificate.ResturantID LEFT OUTER JOIN";
            strQuery += " tblTransactionLog ON TBL_Certificate.CertificateID = tblTransactionLog.CertificateID";
            strQuery += "  where Restaurants_id=@Restaurants_id  AND  TransanctionDate between @StartDate AND @EndDate";
            //strQuery += " TBL_Restaurants ON TBL_Certificate.ResturantID = TBL_Restaurants.Restaurants_id where and TransanctionDate between @StartDate AND @EndDate";

            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@Restaurants_id", intResuarantID);
            sqlparam[1] = new SqlParameter("@StartDate", dtFromDate);
            sqlparam[2] = new SqlParameter("@EndDate", dtToDate);

            DataTable dtGiftCertificateLog = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtGiftCertificateLog;


        }
        public static DataTable getGiftCertificateLog(String dtToDate, String dtFromDate,String restName,String rewards,String status,String auction,String securityno, String dinerName,String state, String city,String zip)
        {
      
            //string strQuery = "SELECT A.* FROM (SELECT     tblTransactionLog.TransactionID, tblTransactionLog.Sold, tblTransactionLog.TransanctionDate, tblTransactionLog.TransactionRecieved, ";
            //strQuery += " tblTransactionLog.CustomerID, tblTransactionLog.Status, tblTransactionLog.Classified, tblTransactionLog.SecurityNo, tblTransactionLog.Reward,";
            //strQuery += " tblTransactionLog.ManualID, TBL_Restaurants.Restaurants_name, TBL_Certificate.CertificateID, TBL_Certificate.CertificateValue";
            //strQuery += ",(Select ISNULL(VcFirstName,'')+' '+ISNULL(VcLastName,'') from Tbl_RestUsers Where Tbl_RestUser.intRestUserID=tblTransactionLog.CustomerID) DinerName ";
            //strQuery += " FROM  TBL_Restaurants INNER JOIN ";
            //strQuery += " TBL_Certificate ON TBL_Restaurants.Restaurants_id = TBL_Certificate.ResturantID LEFT OUTER JOIN";
            //strQuery += " tblTransactionLog ON TBL_Certificate.CertificateID = tblTransactionLog.CertificateID) AS A";
            //strQuery += "  where  TransanctionDate between @StartDate AND @EndDate";
            //strQuery += "  and   Reward like @rewards" + "'%'";
            //strQuery += " and Status like @status" + "'%'";
            //strQuery += " and where  TransanctionDate like @securityno" + "'%'";
            //strQuery += " and  where  TransanctionDate like @dinerName" + "'%'";
            //strQuery += " and  where  Restaurants_name like @restName" + "'%'";
            //strQuery += " and  where  DinerName like @dinerName" + "'%'";



            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@StartDate", dtFromDate);
            sqlparam[1] = new SqlParameter("@EndDate", dtToDate);
            sqlparam[2] = new SqlParameter("@restName", restName);
            sqlparam[3] = new SqlParameter("@rewards", rewards);
            sqlparam[4] = new SqlParameter("@status", status);
            sqlparam[5] = new SqlParameter("@auction", auction);

            sqlparam[6] = new SqlParameter("@securityno", securityno);
            sqlparam[7] = new SqlParameter("@dinerName", dinerName);
            sqlparam[8] = new SqlParameter("@State", state);
            sqlparam[9] = new SqlParameter("@City", city);
            sqlparam[10] = new SqlParameter("@Zip", zip);
            DataTable dtGiftCertificateLog = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "getGiftCertificateLog_sp", sqlparam).Tables[0];
            return dtGiftCertificateLog;


        }
        /// <summary>
        /// Change status of gift Certificate...
        /// </summary>
        /// <param name="strSecurityCode"></param>
        /// <param name="intCertificateID"></param>
        /// <returns></returns>
        public static int changeStatusGift(string strSecurityCode, int intCertificateID)
        {
            int value = 0;
            string strQuery = "UPDATE TBL_Certificate    SET  CertificateStatusID = @CertificateStatusID   WHERE CertificateID=@CertificateID";
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@CertificateCode", strSecurityCode);
            sqlparam[1] = new SqlParameter("@CertificateStatusID", 2);//2 used for user by gift certificate..........
            sqlparam[2] = new SqlParameter("@CertificateID", intCertificateID);

            value = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam));
            return value;



        }
        public static int changeStatusTransaction(string strStatus, int intTransactionStatus)
        {
            int value = 0;
            string strQuery = "UPDATE tblTransactionLog SET  Status = @Status WHERE  TransactionID=@TransactionID";
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@Status", strStatus);
            sqlparam[1] = new SqlParameter("@TransactionID", intTransactionStatus);

            value = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam));
            return value;



        }

        //Gift Cerificates Bidding Module.....................
        public static int AddGiftCertificateAuction(int intGiftCertificateID, DateTime dtStartDate, DateTime dtEndDate, decimal decBidInitialPrice, decimal decWinningPrice, int intTransactionID)
        {
            int value = 0;
            string strQuery = string.Empty;
            strQuery = "INSERT INTO TBL_GiftCertificateAuction (GiftCertificateID  ,BidStartDateTime   ,BidEndDateTime   ,BidInitalPrice,BidWinningPrice ,Status,TransactionID)     VALUES   (@GiftCertificateID  ,@BidStartDateTime   ,@BidEndDateTime   ,@BidInitalPrice ,@BidWinningPrice,@Status,@TransactionID) SET @GiftCertificateAuctionID = SCOPE_IDENTITY()";
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0] = new SqlParameter("@GiftCertificateID", intGiftCertificateID);
            sqlparam[1] = new SqlParameter("@BidStartDateTime", dtStartDate);
            sqlparam[2] = new SqlParameter("@BidEndDateTime", dtEndDate);
            sqlparam[3] = new SqlParameter("@BidInitalPrice", decBidInitialPrice);
            sqlparam[4] = new SqlParameter("@BidWinningPrice", decWinningPrice);
            sqlparam[5] = new SqlParameter("@Status", "Y");
            sqlparam[6] = new SqlParameter("@TransactionID", intTransactionID);
            sqlparam[7] = new SqlParameter("@GiftCertificateAuctionID", SqlDbType.Int);
            sqlparam[7].Direction = ParameterDirection.Output;
            value = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam));
            return Convert.ToInt32(sqlparam[7].Value);
                
        }
        //find all Restuarant for bidding.....................
        public static DataTable getAuctionRestuarant(string strZipCode, string strCity)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT      TBL_GiftCertificateAuction.GiftCertificateAuctionID, TBL_GiftCertificateAuction.GiftCertificateID, TBL_GiftCertificateAuction.BidStartDateTime, ";
            strQuery += "TBL_GiftCertificateAuction.BidEndDateTime, TBL_GiftCertificateAuction.BidInitalPrice, TBL_GiftCertificateAuction.BidWinningPrice, ";
            strQuery += "TBL_GiftCertificateAuction.BidWinnerCustomerID, TBL_GiftCertificateAuction.TransactionID, TBL_GiftCertificateAuction.Status, ";
            strQuery += "TBL_Certificate.CertificateID, TBL_Certificate.ResturantID, TBL_Restaurants.Restaurants_name, TBL_Restaurants.Restaurants_id, ";
            strQuery += "TBL_Restaurants.Restaurants_city, TBL_Restaurants.Restaurants_zip, TBL_Certificate.CertificateValue, ";
            strQuery += "isnull((select top 1 [Gallary_filename] From TBL_RestaurantGallerys where [Restaurant_id] = [Restaurants_id] and [Gallary_ShowHome]='**'";
            strQuery += "and  [Gallary_filepos]=0 order by [Gallary_fileDate]),'None.jpg') as filename ";
            strQuery += "FROM TBL_GiftCertificateAuction INNER JOIN ";
            strQuery += "TBL_Certificate ON TBL_GiftCertificateAuction.GiftCertificateID = TBL_Certificate.CertificateID INNER JOIN ";
            strQuery += "TBL_Restaurants ON TBL_Certificate.ResturantID = TBL_Restaurants.Restaurants_id WHERE (Status= 'Y')";
            if (!string.IsNullOrEmpty(strZipCode))
            {
                strQuery += " AND  Restaurants_zip like '" + strZipCode + "%'";
            }
            else
            {
                strQuery += " AND  Restaurants_city like '" + strCity + "%'";
            }



            DataTable dtAuction = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery).Tables[0];
            return dtAuction;


        }
        public static DataTable getAuctionRestuarantName(int intAuctionID)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT      TBL_GiftCertificateAuction.GiftCertificateAuctionID, TBL_GiftCertificateAuction.GiftCertificateID, TBL_GiftCertificateAuction.BidStartDateTime, ";
            strQuery += "TBL_GiftCertificateAuction.BidEndDateTime, TBL_GiftCertificateAuction.BidInitalPrice, TBL_GiftCertificateAuction.BidWinningPrice, ";
            strQuery += "TBL_GiftCertificateAuction.BidWinnerCustomerID, TBL_GiftCertificateAuction.TransactionID, TBL_GiftCertificateAuction.Status, ";
            strQuery += "TBL_Certificate.CertificateID, TBL_Certificate.ResturantID, TBL_Restaurants.Restaurants_name, TBL_Restaurants.Restaurants_id, ";
            strQuery += "TBL_Restaurants.Restaurants_city, TBL_Restaurants.Restaurants_zip, TBL_Certificate.CertificateValue, ";
            strQuery += "isnull((select top 1 [Gallary_filename] From TBL_RestaurantGallerys where [Restaurant_id] = [Restaurants_id] and [Gallary_ShowHome]='**'";
            strQuery += "and  [Gallary_filepos]=0 order by [Gallary_fileDate]),'None.jpg') as filename ";
            strQuery += "FROM TBL_GiftCertificateAuction INNER JOIN ";
            strQuery += "TBL_Certificate ON TBL_GiftCertificateAuction.GiftCertificateID = TBL_Certificate.CertificateID INNER JOIN ";
            strQuery += "TBL_Restaurants ON TBL_Certificate.ResturantID = TBL_Restaurants.Restaurants_id WHERE (Status= 'Y') AND GiftCertificateAuctionID=@GiftCertificateAuctionID";
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GiftCertificateAuctionID", intAuctionID);
            DataTable dtAuction = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtAuction;


        }

        public static int addBid(int IntGiftCertificateAuctionID, int intCustomerID, int intGiftCertificateID, decimal dcCustomerBidPrice, DateTime dtBidDateTime, string strComments)
        {
            int value = 0;
            string strQuery = string.Empty;
            strQuery = "INSERT INTO TBL_GiftCertificateAuctionCustomer(GiftCertificateAuctionID ,CustomerID ,GiftCertificateID ,CustomerBidPrice ,BidDateTime  ,Comments)  VALUES(@GiftCertificateAuctionID  ,@CustomerID   ,@GiftCertificateID,@CustomerBidPrice ,@BidDateTime ,@Comments) ";
            SqlParameter[] sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@GiftCertificateAuctionID", IntGiftCertificateAuctionID);
            sqlparam[1] = new SqlParameter("@CustomerID", intCustomerID);
            sqlparam[2] = new SqlParameter("@GiftCertificateID", intGiftCertificateID);
            sqlparam[3] = new SqlParameter("@CustomerBidPrice", dcCustomerBidPrice);
            sqlparam[4] = new SqlParameter("@BidDateTime", dtBidDateTime);
            sqlparam[5] = new SqlParameter("@Comments", strComments);
            value = Convert.ToInt32(SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam));
            return value;

        }
        public static int biddingByMaximumPrice(int intGiftCertificateAuctionID)
        {
            int value = 0;
            string strQuery = "SELECT isnull( Max(CustomerBidPrice),0) As Price FROM TBL_GiftCertificateAuctionCustomer  Where GiftCertificateAuctionID=@GiftCertificateAuctionID";
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GiftCertificateAuctionID", intGiftCertificateAuctionID);
            value = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).ToString());
            return value;


        }
        public static DataTable biddingByUser(int intGiftCertificateAuctionID)
        {
            string strQuery = "SELECT     TBL_GiftCertificateAuctionCustomer.GiftCertificateAuctionCustomerID, TBL_GiftCertificateAuctionCustomer.GiftCertificateAuctionID, ";
            strQuery += "  TBL_GiftCertificateAuctionCustomer.CustomerID, TBL_GiftCertificateAuctionCustomer.GiftCertificateID, ";
            strQuery += "  TBL_GiftCertificateAuctionCustomer.CustomerBidPrice, TBL_GiftCertificateAuctionCustomer.Comments, ";
            strQuery += "  TBL_GiftCertificateAuctionCustomer.BidDateTime,ISNULL(TBL_RestUsers.vcFirstName + ' ' + TBL_RestUsers.vcLastName, 'N/A') AS  customer, CustomerBidPrice* 25/100 as Donation,TBL_RestUsers.vcImage ";
            strQuery += "  FROM TBL_GiftCertificateAuctionCustomer INNER JOIN ";
            strQuery += "  TBL_RestUsers ON TBL_GiftCertificateAuctionCustomer.CustomerID = TBL_RestUsers.intRestUserID ";
            strQuery += "   WHERE(TBL_GiftCertificateAuctionCustomer.GiftCertificateAuctionID = @GiftCertificateAuctionID) order by CustomerBidPrice desc";

            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GiftCertificateAuctionID", intGiftCertificateAuctionID);
            DataTable dtAuction = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, sqlparam).Tables[0];
            return dtAuction;
        }
        public static DateTime GetDate()
        {
            string strQuery = string.Empty;
            strQuery = "select getdate()";
            DateTime dtDate;

            dtDate = Convert.ToDateTime(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery).ToString());
            return dtDate;
        }
        public static int CountCreditInfo(int intRestUserid)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT  count(*) FROM tbl_CreditInfo where RestUserid=@RestUserid";
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@RestUserid", intRestUserid);
            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        public static DataTable creditCardInfo(int intRestUserid)
        {
            string strQuery = string.Empty;
            strQuery = "select RestUserId ,CreditCardType ,CreditCardNumber ,NameOnCard ,ExpirationDate,CreditCardCode,UserAuctionID FROM tbl_CreditInfo where RestUserid=@RestUserid";
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@RestUserid", intRestUserid);
            DataTable dtAuction = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).Tables[0];
            return dtAuction;
        }
        public static DataTable GetSecurityAuction(int intRestUserid)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT SecurityQuestionId ,SecurityAnswer,EmailAddress,UserID,Password  FROM tbl_CreateID where intRestUserID=@intRestUserID";
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@intRestUserid", intRestUserid);
            DataTable dtAuction = SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).Tables[0];
            return dtAuction;
        }
        public static int CheckGiftStatus(int intGiftCertificate)
        {
            string strQuery = string.Empty;
            strQuery = "SELECT count(*)  FROM tblTransactionLog Where CertificateID=@CertificateID AND Status ='C'";
            SqlParameter objParameter = new SqlParameter("@CertificateID", intGiftCertificate);
            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        public static int checkStatusReward(DateTime dtDiningDate, int intDinedInRestaurantID, int intCustomerID)
        {
            string strQuery = string.Empty;

            strQuery = "SELECT  count(*)TBL_RewardQuestion where DiningDate=@DiningDate and DinedInRestaurantID=@DinedInRestaurantID and CustomerID=@CustomerID";
            SqlParameter[] objParameter = new SqlParameter[3];
            objParameter[0] = new SqlParameter("@DiningDate", dtDiningDate);
            objParameter[1] = new SqlParameter("@DinedInRestaurantID", intDinedInRestaurantID);
            objParameter[2] = new SqlParameter("@CustomerID", intCustomerID);
            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        public static int getRestuarntUserID(int intRestuarantID)
        {
            string strQuery = string.Empty;

            strQuery = "SELECT  isnull( RestaurantsID,0) as RestaurantsID   FROM TBL_RestUsers where intRestUserID= @intRestUserID";
            SqlParameter[] objParameter = new SqlParameter[1];
            objParameter[0] = new SqlParameter("@DiningDate", intRestuarantID);

            int val = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, strQuery, objParameter).ToString());
            return val;
        }
        public static DataSet TBL_GiftCertificateAllOrders(string restName, string fullName, string cardType, string cardAmound, string cardOrderDate)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(5);

                //Passing intRestID Value To The Parameter(0)
                objParameters.SetParameter("@RestName", restName, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@fullName", fullName, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@cardType", cardType, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@cardAmount", cardAmound, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@cardOrderDate", cardOrderDate, SqlDbType.VarChar, ParameterDirection.Input);


                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "TBL_GiftCertificateAllOrders", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message


                //Return the Value
                return null;
            }
        }

        public static SqlDataReader TBL_GiftCertificateOrdersSelectByOrderID(int orderID)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(1);

                //Passing intRestID Value To The Parameter(0)
                objParameters.SetParameter("@intOrderID", orderID, SqlDbType.Int, 4, ParameterDirection.Input);

                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "TBL_GiftCertificateOrdersSelectByOrderID", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
               

                //Return the Value
                return null;
            }
        }
        public static DataSet GetPharases()
        {
            try
            {
                //Declare The Parameters Array of Parameters Class

                return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, "Select * from Tbl_Phrases order by PhrasesID desc ");

            }
            catch (Exception ex)
            {

                return null;
            }

        }
        public static int DeletePhrase(int pharseID)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(1);

                //Passing intRestID Value To The Parameter(0)
                objParameters.SetParameter("@pharseID", pharseID, SqlDbType.Int, 4, ParameterDirection.Input);

                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, "Delete from  Tbl_Phrases where PhrasesID=@pharseID", arrParams);
                return 0;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int InsertUpdatePhrase(int pharseID,string pharse)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                SqlParameter[] sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@pharseID", pharseID);
                sqlparam[1] = new SqlParameter("@pharse", pharse);
                sqlparam[2] = new SqlParameter("@OutPut", SqlDbType.Int,4);
                sqlparam[2].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "InsertUpdatePhrase_sp", sqlparam);
                return Convert.ToInt32(sqlparam[2].Value);
                
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static string GetPharasesName(int pharseID)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                SqlParameter[] sqlparam = new SqlParameter[1];
         
                sqlparam[0] = new SqlParameter("@pharseID", pharseID);
                return Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.Text, "Select Pharse from Tbl_Phrases where PhrasesID=@pharseID", sqlparam));

            }
            catch (Exception ex)
            {

                return "";
            }

        }
        public static void  updateRewardStatus(int rewardID,int stauts)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@RewardID", rewardID);
                sqlparam[1] = new SqlParameter("@Status", stauts);
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "updateRewardStatus_sp", sqlparam);

            }
            catch (Exception ex)
            {
                return;
            }
        }
       
    }


    public class createIDDef
    {
        public int RegisterID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string SecurityQuestionId { get; set; }
        public string SecurityAnswer { get; set; }
        public int intRestUserID { get; set; }

    }

    public class createID
    {
        public int fnCreateID(createIDDef objCreateID)
        {
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@RegisterID", objCreateID.RegisterID);
            param[1] = new SqlParameter("@FirstName", objCreateID.FirstName);
            param[2] = new SqlParameter("@LastName", objCreateID.LastName);
            param[3] = new SqlParameter("@StreetAddress", objCreateID.StreetAddress);
            param[4] = new SqlParameter("@StreetAddress1", objCreateID.StreetAddress1);
            param[5] = new SqlParameter("@City", objCreateID.City);
            param[6] = new SqlParameter("@State", objCreateID.State);
            param[7] = new SqlParameter("@Country", objCreateID.Country);
            param[8] = new SqlParameter("@PhoneNo", objCreateID.PhoneNo);
            param[9] = new SqlParameter("@MobileNo", objCreateID.MobileNo);

            param[10] = new SqlParameter("@EmailAddress", objCreateID.EmailAddress);
            param[11] = new SqlParameter("@UserID", objCreateID.UserID);
            param[12] = new SqlParameter("@Password", objCreateID.Password);
            param[13] = new SqlParameter("@SecurityQuestionId", objCreateID.SecurityQuestionId);
            param[14] = new SqlParameter("@SecurityAnswer", objCreateID.SecurityAnswer);
            param[15] = new SqlParameter("@intRestUserID", objCreateID.intRestUserID);
            param[16] = new SqlParameter();
            param[16].ParameterName = "@returnRegisterID";
            param[16].SqlDbType = SqlDbType.Int;
            param[16].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "tbl_CreateID_Insert", param);

            int val = Convert.ToInt32(param[16].Value.ToString());
            return val;




        }
        
     

    }
}