using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using Microsoft.ApplicationBlocks.Data;  

namespace Admin
{
	/// <summary>
	/// Summary description for clsGeneral.
	/// </summary>
	public class clsGeneral
	{
		public clsGeneral()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region Fields 
		private string vcErrorMsg;		
		private int intSuccess;
		private int intResponseID;
		private int intBlogID;
		private int admin_ID;
		private string admin_UserName;
		private string admin_OldPassword;
        private string admin_Permissions;
		private string admin_Password;
		private string admin_Per;
		private int intMailingID;
		private string site;
		private int user_Id;
		private string user_Type;
		private string missing_City;
		private int missingID;
		private int state_Id;
		private string city_Name;

		//-------------New Fields Added------
		private int intHomePageID;
		private string vcPicture1;
		private string vcPicture2;
		private string vcPicture3;
		private string vcPicture4;
		private string vcPicture5;
		private string vcLink1;
		private string vcLink2;
		private string vcLink3;
		private string vcLink4;
		private string vcLink5;
		//-------------New Fields Added------

		#endregion

		#region Properties	

		public int State_Id 
		{
			get { return state_Id; }
			set { state_Id = value; }
		}

		public string City_Name 
		{
			get { return city_Name; }
			set { city_Name = value; }
		}

		public int MissingID 
		{
			get { return missingID; }
			set { missingID = value; }
		}

		public int User_Id 
		{
			get { return user_Id; }
			set { user_Id = value; }
		}

		public string User_Type 
		{
			get { return user_Type; }
			set { user_Type = value; }
		}

		public string Missing_City 
		{
			get { return missing_City; }
			set { missing_City = value; }
		}

		public string VcErrorMsg 
		{
			get { return vcErrorMsg; }
			set { vcErrorMsg = value; }
		}

		public int IntSuccess 
		{
			get { return intSuccess; }
			set { intSuccess = value; }
		}

		public int IntMailingID 
		{
			get { return intMailingID; }
			set { intMailingID = value; }
		}

		public int IntResponseID 
		{
			get { return intResponseID; }
			set { intResponseID = value; }
		}


		public int IntBlogID 
		{
			get { return intBlogID; }
			set { intBlogID = value; }
		}

		public int Admin_ID 
		{
			get { return admin_ID; }
			set { admin_ID = value; }
		}

		public string Admin_UserName 
		{
			get { return admin_UserName; }
			set { admin_UserName = value; }
		}

		public string Admin_OldPassword 
		{
			get { return admin_OldPassword; }
			set { admin_OldPassword = value; }
		}
        public string Admin_Permissions
        {
            get {return admin_Permissions ;}
            set { admin_Permissions = value; }
        }
		public string Admin_Password 
		{
			get { return admin_Password; }
			set { admin_Password = value; }
		}

		public string Admin_Per 
		{
			get { return admin_Per; }
			set { admin_Per = value; }
		}

		public string Site 
		{
			get { return site; }
			set { site = value; }
		}

		//-----------New Properties Added--------
		/// <summary>
		/// Gets or sets the IntHomePageID value.
		/// </summary>
		public int IntHomePageID 
		{
			get { return intHomePageID; }
			set { intHomePageID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPicture1 value.
		/// </summary>
		public string VcPicture1 
		{
			get { return vcPicture1; }
			set { vcPicture1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPicture2 value.
		/// </summary>
		public string VcPicture2 
		{
			get { return vcPicture2; }
			set { vcPicture2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPicture3 value.
		/// </summary>
		public string VcPicture3 
		{
			get { return vcPicture3; }
			set { vcPicture3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPicture4 value.
		/// </summary>
		public string VcPicture4 
		{
			get { return vcPicture4; }
			set { vcPicture4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPicture5 value.
		/// </summary>
		public string VcPicture5 
		{
			get { return vcPicture5; }
			set { vcPicture5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLink1 value.
		/// </summary>
		public string VcLink1 
		{
			get { return vcLink1; }
			set { vcLink1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLink2 value.
		/// </summary>
		public string VcLink2 
		{
			get { return vcLink2; }
			set { vcLink2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLink3 value.
		/// </summary>
		public string VcLink3 
		{
			get { return vcLink3; }
			set { vcLink3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLink4 value.
		/// </summary>
		public string VcLink4 
		{
			get { return vcLink4; }
			set { vcLink4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLink5 value.
		/// </summary>
		public string VcLink5 
		{
			get { return vcLink5; }
			set { vcLink5 = value; }
		}
		//-----------New Properties Added--------
        
		#endregion

		#region Methods
		
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET ALL BLOGS DETAILS---------------------------------------------------
		public DataSet Blogs_List()
		{
			try
			{
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Blogs_List");
			 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
			 
				//Return the Value
				return null;
			}

		}
        public DataSet ALLBlogs_List(string userName, string restName)
        {
            try
            {

                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(2);

                //Passing intBlogID Value To The Parameter(0)
                objParameters.SetParameter("@userName", userName, SqlDbType.VarChar, ParameterDirection.Input);
                
                objParameters.SetParameter("@restName", restName, SqlDbType.VarChar, ParameterDirection.Input);


                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                //Open the connection and execute the Command
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "ALLBlogs_List", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }

        }
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------VIEW BLOGS DETAILS------------------------------------------------------
		public SqlDataReader Blogs_ViewDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intBlogID Value To The Parameter(0)
				objParameters.SetParameter("@intBlogID",intBlogID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Blogs_ViewDetails", arrParams);				
				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}
        public DataSet Restaurants_getCusines()
        {
            try
            {
                //Open the connection and execute the Command
                return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Restaurants_getCusines");

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }
        }

		//--------------------------------------------------------------------------------------------------------
		//--------------------------------DELETE BLOGS DETAILS---------------------------------------------------
		public int Blogs_DeleteDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
				
				//Passing intBlogID Value To The Parameter(0)
				objParameters.SetParameter("@intBlogID",intBlogID, SqlDbType.Int,4,ParameterDirection.Input);
				
				
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
				
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Blogs_DeleteDetails", arrParams);
				
				
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
				
				//Return the Value
				return 1;
			}

		}

		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET ALL ADITIONAL ADMINISTRATORS----------------------------------------
		public DataSet Admin_AdminList()
		{
			try
			{
				
                //Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_AdminList");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}
        public DataSet Admin_GetAdminList(string userName,string userPassword)
        {
            try
            {

                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(2);

                //Passing intBlogID Value To The Parameter(0)
                objParameters.SetParameter("@userName", userName, SqlDbType.VarChar ,ParameterDirection.Input);

                objParameters.SetParameter("@userPassword", userPassword, SqlDbType.VarChar, ParameterDirection.Input);


                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                //Open the connection and execute the Command
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Admin_GetAdminList", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }
        }
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------DELETE ADITIONAL ADMINISTRATORS-----------------------------------------
		public int Admin_DeleteAdmin()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
			 
				//Passing admin_ID Value To The Parameter(0)
				objParameters.SetParameter("@Admin_ID",admin_ID, SqlDbType.Int,4,ParameterDirection.Input);
			 
			 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
			 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_DeleteAdmin", arrParams);
			 
				
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
			 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET INDIVIDUAL ADITIONAL ADMINISTRATORS DETAILS-------------------------
		public DataSet Admin_InAdminDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);

				//Passing admin_ID Value To The Parameter(0)
				objParameters.SetParameter("@Admin_ID",admin_ID, SqlDbType.Int,4,ParameterDirection.Input);


				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();

				//Open the connection and execute the Command
				return SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_InAdminDetails", arrParams);			
				 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;

				//Return the Value
				return null;
			}
		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------INSERT NW  INDIVIDUAL ADITIONAL ADMINISTRATORS DETAILS------------------
		public int Admin_InsertInAdminDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing admin_UserName Value To The Parameter(0)
				objParameters.SetParameter("@Admin_UserName",admin_UserName, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing admin_Password Value To The Parameter(1)
				objParameters.SetParameter("@Admin_Password",admin_Password, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(2)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_InsertInAdminDetails", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[2].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[2].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------UPDATE INDIVIDUAL ADITIONAL ADMINISTRATORS DETAILS----------------------
		public int Admin_UpdateInAdminDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(6);
 
				//Passing admin_ID Value To The Parameter(0)
				objParameters.SetParameter("@Admin_ID",admin_ID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing admin_OldPassword Value To The Parameter(1)
				objParameters.SetParameter("@Admin_OldPassword",admin_OldPassword, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing admin_UserName Value To The Parameter(2)
				objParameters.SetParameter("@Admin_UserName",admin_UserName, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing admin_Password Value To The Parameter(3)
				objParameters.SetParameter("@Admin_Password",admin_Password, SqlDbType.VarChar,50,ParameterDirection.Input);
                objParameters.SetParameter("@Admin_Permissions", admin_Permissions, SqlDbType.VarChar, 5000, ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(4)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_UpdateInAdminDetails", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[5].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[5].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------UPDATE INDIVIDUAL ADITIONAL ADMINISTRATORS DETAILS----------------------
		public int Admin_LoginCheck()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
			 
				//Passing admin_Per Value To The Parameter(0)
				objParameters.SetParameter("@Admin_Per",admin_Per, SqlDbType.VarChar,10,ParameterDirection.Output);
			 
				//Passing admin_UserName Value To The Parameter(1)
				objParameters.SetParameter("@Admin_UserName",admin_UserName, SqlDbType.NVarChar,100,ParameterDirection.Input);
			 
				//Passing admin_Password Value To The Parameter(2)
				objParameters.SetParameter("@Admin_Password",admin_Password, SqlDbType.NVarChar,120,ParameterDirection.Input);
			 
			 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
			 
				//Open the connection and execute the Command
				SqlHelper.ExecuteScalar(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_LoginCheck", arrParams);
			 
				//Retrieve Output Variables
				if (arrParams[0].Value != DBNull.Value)
				{
					admin_Per = arrParams[0].Value.ToString();
				}
			 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
			 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET BLOGS RESPONSES LIST -----------------------------------------------
		public DataSet Admin_BlogResponsesList()
		{
			try
			{
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Admin_BlogResponsesList");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}
        public DataSet Admin_AllBlogResponsesList(string userName,string restName, string postedDate)
        {
            try
            {
                Parameters objParameters = new Parameters(3);

                //Passing admin_Per Value To The Parameter(0)
                objParameters.SetParameter("@userName", userName, SqlDbType.VarChar,  ParameterDirection.Input);

                //Passing admin_UserName Value To The Parameter(1)
                objParameters.SetParameter("@restName", restName, SqlDbType.VarChar, ParameterDirection.Input);

                //Passing admin_Password Value To The Parameter(2)
                objParameters.SetParameter("@postedDate", postedDate, SqlDbType.VarChar, ParameterDirection.Input);
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                //Open the connection and execute the Command
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "Admin_AllBlogResponsesList", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }
        }
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------DELETE BLOGS RESPONSES -------------------------------------------------
		public int Blog_DeleteBlogResponses()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
			 
				//Passing intResponseID Value To The Parameter(0)
				objParameters.SetParameter("@intResponseID",intResponseID, SqlDbType.Int,4,ParameterDirection.Input);
			 
			 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
			 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Blog_DeleteBlogResponses", arrParams);
			 
				 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
			 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET INDIVIDUAL BLOGS RESPONSES -----------------------------------------
		public SqlDataReader Blogs_BlogResponsesDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intResponseID Value To The Parameter(0)
				objParameters.SetParameter("@intResponseID",intResponseID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Blogs_BlogResponsesDetails", arrParams);
 
				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}

		//--------------------------------------------------------------------------------------------------------
		//--------------------------------DELETE RESTAURANTS MAILING LIST-----------------------------------------
		public int DeleteRestaurantMailingListByID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
			 
				//Passing mailingID Value To The Parameter(0)
				objParameters.SetParameter("@MailingID",intMailingID, SqlDbType.Int,4,ParameterDirection.Input);
			 
			 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
			 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"DeleteRestaurantMailingListByID", arrParams);
			 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
			 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------GET MISSING CITIES DETAILS----------------------------------------------
		public DataSet Get_MissingCityDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing site Value To The Parameter(0)
				objParameters.SetParameter("@Site",site, SqlDbType.VarChar,10,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Get_MissingCityDetails", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------UPDATE MISSING CITIES DETAILS-------------------------------------------
		public int Update_MissingCityDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(4);
 
				//Passing user_Id Value To The Parameter(0)
				objParameters.SetParameter("@User_Id",user_Id, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing user_Type Value To The Parameter(1)
				objParameters.SetParameter("@User_Type",user_Type, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing missing_City Value To The Parameter(2)
				objParameters.SetParameter("@Missing_City",missing_City, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(3)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Update_MissingCityDetails", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[3].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[3].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}
            
		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------DELETE MISSING CITIES DETAILS-------------------------------------------
		public int Delete_MissingCityDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing missingID Value To The Parameter(0)
				objParameters.SetParameter("@MissingID",missingID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(1)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"Delete_MissingCityDetails", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[1].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}

		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------------------INSERT MISSING CITIES DETAILS-------------------------------------------
		public int City_InsertNewCity()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing state_Id Value To The Parameter(0)
				objParameters.SetParameter("@state_Id",state_Id, SqlDbType.Int,9,ParameterDirection.Input);
 
				//Passing city_Name Value To The Parameter(1)
				objParameters.SetParameter("@city_Name",city_Name, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(2)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"City_InsertNewCity", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[2].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[2].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}

		}


		//--------------------------------------------------------------------------------------------------------
		//--------------------------------SELECT HOMEPAGE IMAGES AND LINKS----------------------------------------
		public SqlDataReader TBL_HomePageSelect()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intHomePageID Value To The Parameter(0)
				objParameters.SetParameter("@intHomePageID",intHomePageID, SqlDbType.Int,4,ParameterDirection.Input);
  
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_HomePageSelect", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}

		//--------------------------------------------------------------------------------------------------------
		//--------------------------------INSERT AND UPDATE HOMPAGE IMAGES AND LINKS -----------------------------

		public int TBL_HomePageUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(12);
 
				//Passing intHomePageID Value To The Parameter(0)
				objParameters.SetParameter("@intHomePageID",intHomePageID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcPicture1 Value To The Parameter(1)
				objParameters.SetParameter("@vcPicture1",vcPicture1, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPicture2 Value To The Parameter(2)
				objParameters.SetParameter("@vcPicture2",vcPicture2, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPicture3 Value To The Parameter(3)
				objParameters.SetParameter("@vcPicture3",vcPicture3, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPicture4 Value To The Parameter(4)
				objParameters.SetParameter("@vcPicture4",vcPicture4, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPicture5 Value To The Parameter(5)
				objParameters.SetParameter("@vcPicture5",vcPicture5, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcLink1 Value To The Parameter(6)
				objParameters.SetParameter("@vcLink1",vcLink1, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing vcLink2 Value To The Parameter(7)
				objParameters.SetParameter("@vcLink2",vcLink2, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing vcLink3 Value To The Parameter(8)
				objParameters.SetParameter("@vcLink3",vcLink3, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing vcLink4 Value To The Parameter(9)
				objParameters.SetParameter("@vcLink4",vcLink4, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing vcLink5 Value To The Parameter(10)
				objParameters.SetParameter("@vcLink5",vcLink5, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(11)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_HomePageUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[11].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[11].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}
		}

        public static int AddAdminInfo(string userName, string password, string permissionInfo)
        {
            try
            {
                Parameters objParameters = new Parameters(4);
                objParameters.SetParameter("@UserName", userName, SqlDbType.VarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@Password", password, SqlDbType.VarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@PermissionInfo", permissionInfo, SqlDbType.VarChar, 5000, ParameterDirection.Input);
                objParameters.SetParameter("@intSuccess", 0, SqlDbType.Int, 4, ParameterDirection.Output);
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "InsertNewAdmin_sp", arrParams);
                if (arrParams[3].Value != DBNull.Value)
                {
                    return int.Parse(arrParams[11].Value.ToString());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

		#endregion

	}
}
