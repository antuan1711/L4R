using System;
using System.Data;
using Admin.Common; 
using System.Data.SqlClient;   
using System.Text;
using System.Web.SessionState;

namespace Admin
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	//*******************************************************
	//
	// memberDetails Class
	//
	// A simple data class that encapsulates details about
	// a particular member inside the Person_details table
	// and the values is retrived with the help of person_id.
	//
	//*******************************************************
	public class  memberDetails
	{
		public string Person_ScreenName="";
		public string person_FirstName="";
		public string person_LastName="";
		public string Person_gender="";
		public string Person_sexorient="";
		public string Person_Status="";
		public string Person_zodiac="";
		public string Person_kids="";
		public string Person_birthdate="";
		public string Person_height="";
		public string Person_weight="";
		public string Person_religion="";
		public string Person_ethnicity="";
		public string Person_City="";
		public string Person_State="";
		public string Person_Zip="";
		public string Person_Activities="";
		public string Person_Beat="";
		public string Person_OnDate="";
		public string Person_LocTime="";
		public string Person_email="";
		public string Person_Password="";
		public string Person_MsgTitle="";
		public string Person_MsgSincere="";
		public string Person_Photopath="";
		public string Person_EnableNewsLetter="";
		public string Person_Phone;
		public string Person_carid;
		public string Person_Phone2;
		public string Person_Decision;
		public string Person_Message;
        public string Person_AboutMe;
	}
	public class classifiedDetails
	{
		public string postTitle="";
		public string postLoc="";
		public string postDesc="";
		public string postEmail="";
		public string postCategory="";
		public string postDate="";
		public string postExpire="";
		public string postUrl="";
		public string postfaxno="";
		public string postImage="";
		public string postCheck="";
		public string postPhone="";
		public string postingPeriod="";


	}
	public class freeclassifiedDetails
	{
		public string postTitle="";
		public string postCategory="";
		public string postLoc="";
		public string postDesc="";
		public string SalaryDetails="";
		public string postEmail="";
		public string jobtype="";
		public string postDate="";
		public string postExpire="";
		public string postOther="";
		public string postfaxno="";
		public string postPhone="";
		public string postURL="";
		public string Show="";
		public string Address="";
		
	}

	public class amount_toPaid
	{
		public int Orignal_amount=0;
		public int New_amount=0;
		public int Orignal_setupamt=0;
		public int New_setupamt=0;
		public int sitemanagement=0;
	}
	
	public class membershipDetails
		{
			public double monthly_fee=0;
			public double monthly_setup=0;

			public double quater_fee=0;
			public double quater_Setup_fee=0;

			public double year_fee=0;
			public double year_setup_fee=0;

			public double Site_setup=0;



		}


	


		public class MembDB
		{
			/// <summary>
			/// The getmemberDetails method returns a DataReader that exposes all 
			/// Events within the AdminDB database. 
			///  The SQLDataReaderResult struct also returns the
			/// SQL connection, which must be explicitly closed after the
			/// data from the DataReader is bound into the controls.
			/// </summary>
			/// <returns>Data Table -Return the Member details</returns>
			/// 
			public memberDetails GetMemberDetails(int person_id) 
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Memb_Details", connection);

				// Mark the Command as a SPROC
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@person_id",person_id));   
				// Execute the command
				connection.Open();
				SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
				if (Data.Read() )
				{
					memberDetails md = new memberDetails();
					md.Person_ScreenName = Data["Person_ScreenName"].ToString();
					md.person_FirstName = Data["person_FirstName"].ToString();
					md.person_LastName = Data["person_LastName"].ToString();
					md.Person_gender = Data["Person_gender"].ToString();
					md.Person_sexorient = Data["Person_sexorient"].ToString();
					md.Person_Status = Data["Person_Status"].ToString();
					md.Person_zodiac = Data["Person_zodiac"].ToString();
					md.Person_kids = Data["Person_kids"].ToString();
					md.Person_birthdate = Data["Person_birthdate"].ToString();
					md.Person_height = Data["Person_height"].ToString();
					md.Person_weight = Data["Person_weight"].ToString();
					md.Person_religion = Data["Person_religion"].ToString();
					md.Person_ethnicity = Data["Person_ethnicity"].ToString();
					md.Person_City = Data["Person_City"].ToString();
					md.Person_State = Data["Person_State"].ToString();
					md.Person_Zip = Data["Person_Zip"].ToString();
					md.Person_Activities = Data["Person_Activities"].ToString();
					md.Person_Beat = Data["Person_Beat"].ToString();
					md.Person_OnDate = Data["Person_OnDate"].ToString();
					md.Person_LocTime = Data["Person_LocTime"].ToString(); 
					md.Person_email = Data["Person_email"].ToString();
					md.Person_Password = Data["Person_Password"].ToString();
					md.Person_MsgTitle = Data["Person_MsgTitle"].ToString();
					md.Person_MsgSincere = Data["Person_MsgSincere"].ToString();
					md.Person_EnableNewsLetter=Data["Person_EnableNewsLetter"].ToString() ;
					md.Person_Phone=Data["Person_Phone"].ToString();
					md.Person_carid=Data["Person_carid"].ToString();
					md.Person_Phone2=Data["Person_phone2"].ToString();
					md.Person_Decision=Data["Person_Decision"].ToString();					  
					md.Person_Message =Data["Person_Message"].ToString();
					//	
					return md;
				}
				else
				{
				
					memberDetails md = new memberDetails();
					return md;
				   
				}
  
			}

			public membershipDetails GetMembershipDetails(int membership_id)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("MembershipDetails_getDetails", connection);

				// Mark the Command as a SPROC
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
				if (Data.Read()  )
				{
					membershipDetails msdet = new membershipDetails();
					msdet.monthly_fee =Double.Parse(Data.GetValue(0).ToString()) ;
					msdet.monthly_setup =Double.Parse(Data.GetValue(1).ToString()) ;
					msdet.quater_fee = Double.Parse( Data.GetValue(2).ToString()) ;
					msdet.quater_Setup_fee = Double.Parse( Data.GetValue(3).ToString()) ;
					msdet.year_fee= Double.Parse(Data.GetValue(4).ToString()) ;
					msdet.year_setup_fee= Double.Parse(Data.GetValue(5).ToString()) ;

					msdet.Site_setup= Double.Parse(Data.GetValue(6).ToString()) ;
					return msdet;
				}
				else
				{
					membershipDetails msdet = new membershipDetails();
					return msdet;
				}
			}

			public static amount_toPaid getPyamentDetailsBySeatandPerod(string noofSeat,string period_str,string doit)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Payment_getDetails", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@noofseat",noofSeat));   
				command.Parameters.Add(new SqlParameter("@period_str",period_str));
				command.Parameters.Add(new SqlParameter("@doit",doit));
   
				SqlParameter pmOrAmt = new SqlParameter("@returnamt",SqlDbType.Int);
				pmOrAmt.Direction=ParameterDirection.Output;
				command.Parameters.Add(pmOrAmt);   

				SqlParameter pmNewAmt = new SqlParameter("@returndiscamt",SqlDbType.Int);
				pmNewAmt.Direction=ParameterDirection.Output;
				command.Parameters.Add(pmNewAmt);   

				SqlParameter pmOrsetupAmt = new SqlParameter("@setupamt",SqlDbType.Int);
				pmOrsetupAmt.Direction=ParameterDirection.Output;
				command.Parameters.Add(pmOrsetupAmt);   

				SqlParameter pmNewSetupAmt = new SqlParameter("@setupDiscamt",SqlDbType.Int);
				pmNewSetupAmt.Direction=ParameterDirection.Output;
				command.Parameters.Add(pmNewSetupAmt);  

				SqlParameter pmNewSiteMng = new SqlParameter("@sitemanagement",SqlDbType.Int);
				pmNewSiteMng.Direction=ParameterDirection.Output;
				command.Parameters.Add(pmNewSiteMng);  

				amount_toPaid pid = new amount_toPaid();
				string errmsg ="";
				try
				{
					connection.Open();
					command.ExecuteNonQuery();
					connection.Close(); 
					pid.Orignal_amount  = Int16.Parse(pmOrAmt.Value.ToString());   
					pid.New_amount = Int16.Parse(pmNewAmt.Value.ToString());
					pid.Orignal_setupamt  = Int16.Parse(pmOrsetupAmt.Value.ToString());
					pid.New_setupamt  = Int16.Parse(pmNewSetupAmt.Value.ToString());
					pid.sitemanagement = 0;
					return pid;
				}
				catch(Exception ex)
				{
					errmsg = ex.Message.ToString();  
					return pid;
				}
				finally
				{
					connection.Close();  
				}
 
			}
			public classifiedDetails GetDetails(int Transaction_id) 
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("classified_PostedData", connection);
				// Mark the Command as a SPROC
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Transaction_id",Transaction_id));   
				// Execute the command
				connection.Open();
				SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
				if (Data.Read() )
				{
					classifiedDetails cd = new classifiedDetails();
					cd.postTitle = Data.GetValue(1).ToString();
					cd.postDesc = Data.GetValue(2).ToString();
					cd.postLoc = Data.GetValue(4).ToString();
					cd.postEmail = Data.GetValue(3).ToString();
					if (Data.GetValue(5).ToString().Length > 0) 															  
					{
						cd.postDate = Data.GetDateTime(5).ToString("MMM-dd-yy"); 
					}
					cd.postExpire = Data.GetValue(6).ToString();
					cd.postCategory = Data.GetValue(7).ToString();
					cd.postUrl = Data.GetValue(8).ToString();
					cd.postImage= Data.GetValue(9).ToString();
					cd.postPhone  =Data.GetValue(10).ToString();
					cd.postCheck =Data.GetValue(11).ToString();
					cd.postfaxno =Data.GetValue(12).ToString();

					return cd;
				}
				else
				{
					classifiedDetails cd = new classifiedDetails();
					return cd;
				}
			}
			public freeclassifiedDetails  GetFreeDetails(int Transaction_id) 
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("FreeClassified_getAllTransactionDetailsByID", connection);
				// Mark the Command as a SPROC
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Cls_id",Transaction_id));   
				// Execute the command
				connection.Open();
				SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
				if (Data.Read() )
				{
					freeclassifiedDetails cfd = new freeclassifiedDetails();
				
					cfd.postTitle = Data.GetValue(0).ToString();
					cfd.postDesc = Data.GetValue(1).ToString();
					cfd.postLoc = Data.GetValue(2).ToString();
					cfd.postCategory = Data.GetValue(3).ToString();
					cfd.SalaryDetails= Data.GetValue(4).ToString();
					cfd.postEmail = Data.GetValue(5).ToString();
					cfd.postOther= Data.GetValue(6).ToString();
					if (Data.GetValue(7).ToString().Length > 0) 															  
					{
						cfd.postDate = Data.GetDateTime(7).ToString("MMM-dd-yy"); 
					}
					cfd.postExpire =Data.GetValue(8).ToString();
					cfd.jobtype =Data.GetValue(9).ToString();
					cfd.postPhone =Data.GetValue(12).ToString();
					cfd.postURL =Data.GetValue(13).ToString();
					cfd.Show  =Data.GetValue(14).ToString();
					cfd.Address = Data.GetValue(15).ToString();
					cfd.postfaxno = Data.GetValue(16).ToString();

					return cfd;
				}
				else
				{
					freeclassifiedDetails cd = new freeclassifiedDetails();
					return cd;
				}
			}

			public static DataTable GetTypes() 
			{
				SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand Command = new SqlCommand("classifieds_getType", Connection);
				Command.CommandType = CommandType.StoredProcedure;
				Connection.Open();
				DataSet ds = new DataSet();
				SqlDataAdapter da = new SqlDataAdapter(Command);  
				da.Fill(ds); 
				Connection.Close();
				DataTable dTable=ds.Tables[0]; 
				return dTable;
			}

			public static DataTable GetCategory(int Classified_Id)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("classifieds_getCategories", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Classified_Id",Classified_Id));   
				connection.Open();
				DataSet ds1 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds1); 
				connection.Close();
				DataTable dTable=ds1.Tables[0]; 
				return dTable;
			}
			public static SqlDataReader GetCategoryListing(int Classified_Id)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("classifieds_getCategories", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Classified_Id",Classified_Id));   
				try
				{
					connection.Open();  
					SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);    
					return reader;
				}
				catch
				{
					connection.Close();
					return null;
				}
			
			}

            public static DataTable GetCategoryListingNew(int Classified_Id)
            {
                SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
                SqlCommand command = new SqlCommand("classifieds_getCategories", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Classified_Id", Classified_Id));
                try
                {
                    connection.Open();
                    DataSet ds1 = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    sda.Fill(ds1);
                    connection.Close();
                    DataTable dTable = ds1.Tables[0];
                    return dTable;
                }
                catch
                {
                    connection.Close();
                    return null;
                }

            }
			public static DataTable Get_RestaurantListing()
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Classified_RestaurantListings", connection);
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();
				DataSet ds4 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds4); 
				connection.Close();
				DataTable dTable=ds4.Tables[0]; 
				return dTable;
			}

			public static DataTable Get_ServiceListing()
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Classified_ServiceListings", connection);
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();
				DataSet ds5 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds5); 
				connection.Close();
				DataTable dTable=ds5.Tables[0]; 
				return dTable;
			}

			public static DataTable Get_JobListing()
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Classified_JobListings", connection);
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();
				DataSet ds6 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds6); 
				connection.Close();
				DataTable dTable=ds6.Tables[0]; 
				return dTable;
			}

			public static DataTable Get_PostedDetails(string Class_Type)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("classifieds_getPostingDetails", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Classified_Type",Class_Type));  
				
				
				connection.Open();
				DataSet ds7 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds7); 
				connection.Close();
				DataTable dTable=ds7.Tables[0]; 
				return dTable;
			}
			public static void checkExpiryDate(string trans_id)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Classified_getExpiredEmailDetails", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@trans_id",trans_id));   
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
  			}
			public static DataTable Get_FreePostedDetails(int Class_Type)
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("classifieds_getFreePostingDetails", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@Classified_ID",Class_Type));   
				connection.Open();
				DataSet ds7 = new DataSet();
				SqlDataAdapter sda = new SqlDataAdapter(command);  
				sda.Fill(ds7); 
				connection.Close();
				DataTable dTable=ds7.Tables[0]; 
				return dTable;
			}

			public string EditMember(string ScreenName,string FirstName,string LastName,string Gender,string Orientation,string Status,string Zodiac,string Kids,string BirthDate,string Height,int Weight,string Religion,string Ethnicity,string City,string State,int Zip,string Activities,string Iwill,string locDate,string LocTime,string Email,string Pwd,string MsgTitle,string MsgSin,string Person_Decision,string Person_Message) 
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("members_InsertDetails", connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@ScreenName",ScreenName));
				command.Parameters.Add(new SqlParameter("@FirstName",FirstName));
				command.Parameters.Add(new SqlParameter("@LastName",LastName));
				command.Parameters.Add(new SqlParameter("@Gender",Gender));
				command.Parameters.Add(new SqlParameter("@Orientation",Orientation));
				command.Parameters.Add(new SqlParameter("@Status",Status));
				command.Parameters.Add(new SqlParameter("@Zodiac",Zodiac));
				command.Parameters.Add(new SqlParameter("@Kids",Kids));
				command.Parameters.Add(new SqlParameter("@BirthDate",BirthDate));
				command.Parameters.Add(new SqlParameter("@Height",Height));
				command.Parameters.Add(new SqlParameter("@Weight",Weight));
				command.Parameters.Add(new SqlParameter("@Religion",Religion));
				command.Parameters.Add(new SqlParameter("@Ethnicity",Ethnicity));
				command.Parameters.Add(new SqlParameter("@City",City));
				command.Parameters.Add(new SqlParameter("@State",State));
				command.Parameters.Add(new SqlParameter("@Zip",Zip));
				command.Parameters.Add(new SqlParameter("@Activities",Activities));
				command.Parameters.Add(new SqlParameter("@Iwill",Iwill));
				command.Parameters.Add(new SqlParameter("@locDate",locDate));
				command.Parameters.Add(new SqlParameter("@LocTime",LocTime));
				command.Parameters.Add(new SqlParameter("@Email",Email));
				command.Parameters.Add(new SqlParameter("@Pwd",Pwd));
				command.Parameters.Add(new SqlParameter("@MsgTitle",MsgTitle));
				command.Parameters.Add(new SqlParameter("@MsgSin",MsgSin));
				command.Parameters.Add(new SqlParameter("@Person_Decision",Person_Decision));
				command.Parameters.Add(new SqlParameter("@Person_Message",Person_Message));
				SqlParameter parameterEventID = new SqlParameter("@Result", SqlDbType.Int, 4);
				parameterEventID.Direction = ParameterDirection.Output;
				command.Parameters.Add(parameterEventID);
				try 
				{
					connection.Open();
					command.ExecuteNonQuery();
					int EventId = (int)parameterEventID.Value;
					return EventId.ToString();
				}
				catch(Exception ex)
				{
					return ex.ToString() ;
				}
				finally
				{
					connection.Close();  
				}
			}	

			public memberDetails GetProfile(int person_id) 
			{
				SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
				SqlCommand command = new SqlCommand("Profile_Details", connection);

				// Mark the Command as a SPROC
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add(new SqlParameter("@person_id",person_id));   
				// Execute the command
				connection.Open();
				SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
				if (Data.Read() )
				{
					memberDetails md = new memberDetails();
					md.Person_ScreenName = Data.GetValue(0).ToString();
					md.Person_gender = Data.GetValue(1).ToString();
					md.Person_sexorient = Data.GetValue(2).ToString();
					md.Person_Status = Data.GetValue(3).ToString();
					md.Person_kids = Data.GetValue(4).ToString();
					md.Person_birthdate = Data.GetValue(5).ToString();
					md.Person_height = Data.GetValue(6).ToString();
					md.Person_weight = Data.GetValue(7).ToString();
					md.Person_religion = Data.GetValue(8).ToString();
					md.Person_ethnicity = Data.GetValue(9).ToString();
					md.Person_City = Data.GetValue(10).ToString();
					md.Person_State = Data.GetValue(11).ToString();
					md.Person_Zip = Data.GetValue(12).ToString();
					md.Person_Activities = Data.GetValue(13).ToString();
					md.Person_Beat = Data.GetValue(14).ToString();
					md.Person_OnDate = Data.GetValue(15).ToString();
					md.Person_LocTime = Data.GetValue(16).ToString(); 
					md.Person_email = Data.GetValue(17).ToString();
					md.Person_MsgTitle = Data.GetValue(18).ToString();
					md.Person_MsgSincere = Data.GetValue(19).ToString();
					md.Person_Photopath = Data.GetValue(20).ToString();
					md.person_FirstName = Data.GetValue(21).ToString();
					md.person_LastName= Data.GetValue(22).ToString();
					md.Person_Phone=Data.GetValue(23).ToString();
					md.Person_Phone2=Data.GetValue(24).ToString();
					md.Person_Decision=Data.GetValue(25).ToString();
					md.Person_Message =Data.GetValue(26).ToString();
					return md;
				}
				else
				{
				
					memberDetails md = new memberDetails();
					return md;
				   
				}
			}
            public memberDetails GetProfileNew(int person_id)
            {
                SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
                SqlCommand command = new SqlCommand("Profile_DetailsNew", connection);

                // Mark the Command as a SPROC
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@person_id", person_id));
                // Execute the command
                connection.Open();
                SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (Data.Read())
                {
                    memberDetails md = new memberDetails();
                    md.Person_ScreenName = Data.GetValue(0).ToString();
                    if (Data.GetValue(1) != DBNull.Value)
                    {
                        md.Person_gender = Data.GetValue(1).ToString();
                    }
                    else
                    {
                        md.Person_gender = "info not provided";
                    }
                    if (Data.GetValue(2) != DBNull.Value)
                    {
                        md.Person_Status = Data.GetValue(2).ToString();
                    }
                    else
                    {
                        md.Person_Status = "info not provided";
                    }
                    if (Data.GetValue(3) != DBNull.Value)
                    {
                        md.Person_kids = Data.GetValue(3).ToString();
                    }
                    else
                    {
                        md.Person_kids="info not provided";
                    }
                    if (Data.GetValue(4) != DBNull.Value)
                    {
                        md.Person_birthdate = Data.GetValue(4).ToString();
                    }
                    else
                    {
                        md.Person_birthdate = "info not provided";
                    }
                    if (Data.GetValue(5) != DBNull.Value)
                    {
                        md.Person_height = Data.GetValue(5).ToString();
                    }
                    else
                    {
                        md.Person_height = "info not provided";
                    }

                    if (Data.GetValue(6) != DBNull.Value)
                    {
                        md.Person_weight = Data.GetValue(6).ToString();
                    }
                    else
                    {
                        md.Person_weight = "info not provided";
                    }
                    if (Data.GetValue(7) != DBNull.Value)
                    {
                        md.Person_religion = Data.GetValue(7).ToString();
                    }
                    else
                    {
                        md.Person_religion = "info not provided";
                    }
                    if (Data.GetValue(8) != DBNull.Value)
                    {
                        md.Person_City = Data.GetValue(8).ToString();
                    }
                    else
                    {
                        md.Person_City = "info not provided";
                    }
                    if (Data.GetValue(9) != DBNull.Value)
                    {
                        md.Person_State = Data.GetValue(9).ToString();
                    }
                    else
                    {
                        md.Person_State = "info not provided";
                    }
                    if (Data.GetValue(10) != DBNull.Value)
                    {
                        md.Person_Zip = Data.GetValue(10).ToString();
                    }
                    else
                    {
                        md.Person_Zip = "info not provided";
                    }
                    if (Data.GetValue(11) != DBNull.Value)
                    {
                        md.Person_Activities = Data.GetValue(11).ToString();
                    }
                    else
                    {
                        md.Person_Activities = "info not provided";
                    }
                    if (Data.GetValue(12) != DBNull.Value)
                    {
                        md.Person_Beat = Data.GetValue(12).ToString();
                    }
                    else
                    {
                        md.Person_Beat = "info not provided";
                    }
                    if (Data.GetValue(13) != DBNull.Value)
                    {
                        md.Person_OnDate = Data.GetValue(13).ToString();
                    }
                    else
                    {
                        md.Person_OnDate = "info not provided";
                    }
                    if (Data.GetValue(14) != DBNull.Value)
                    {
                        md.Person_LocTime = Data.GetValue(14).ToString();
                    }
                    else
                    {
                        md.Person_LocTime = "info not provided";
                    }
                    if (Data.GetValue(15) != DBNull.Value)
                    {
                        md.Person_email = Data.GetValue(15).ToString();
                    }
                    else
                    {
                        md.Person_email = "info not provided";
                    }
                    if (Data.GetValue(16) != DBNull.Value)
                    {
                        md.Person_MsgTitle = Data.GetValue(16).ToString();
                    }
                    else
                    {
                        md.Person_MsgTitle = "info not provided";
                    }
                    if (Data.GetValue(17) != DBNull.Value)
                    {
                        md.Person_MsgSincere = Data.GetValue(17).ToString();
                    }
                    else
                    {
                        md.Person_MsgSincere = "info not provided";
                    }
                    if (Data.GetValue(18) != DBNull.Value)
                    {
                        md.Person_Photopath = Data.GetValue(18).ToString();
                    }
                    else
                    {
                        md.Person_Photopath = "info not provided";
                    }
                    if (Data.GetValue(20) != DBNull.Value)
                    {
                        md.person_FirstName = Data.GetValue(19).ToString();
                    }
                    else
                    {
                        md.person_FirstName = "info not provided";
                    }
                    if (Data.GetValue(20) != DBNull.Value)
                    {
                        md.person_LastName = Data.GetValue(20).ToString();
                    }
                    else
                    {
                        md.person_LastName = "info not provided";
                    }
                    if (Data.GetValue(21) != DBNull.Value)
                    {
                        md.Person_Phone = Data.GetValue(21).ToString();
                    }
                    else
                    {
                        md.Person_Phone = "info not provided";
                    }
                    if(Data.GetValue(22)!=DBNull.Value)
                    {
                        md.Person_Decision = Data.GetValue(22).ToString();
                    }
                    else
                    {
                        md.Person_Decision="info not provided";
                    }
                    if (Data.GetValue(23) != DBNull.Value)
                    {
                        md.Person_Message = Data.GetValue(23).ToString();
                    }
                    else
                    {

                    }
                    if (Data.GetValue(24) != DBNull.Value || Data.GetValue(25) != DBNull.Value)
                    {
                        if (Data.GetValue(24).ToString() != "0")
                        {
                            md.Person_Activities = "Men";
                        }
                        if (Data.GetValue(25).ToString() != "0")
                        {
                            if (md.Person_Activities != "")
                            {
                                md.Person_Activities += ", Women";
                            }
                            else
                            {
                                md.Person_Activities = "Women";
                            }
                        }
                    }
                    else
                    {
                        md.Person_Activities = "info not provided";
                    }
                    if (Data.GetValue(26) != DBNull.Value)
                    {
                        md.Person_AboutMe = Data.GetValue(26).ToString();
                    }
                    else
                    {
                        md.Person_AboutMe = "info not provided";
                    }
                    return md;
                }
                else
                {

                    memberDetails md = new memberDetails();
                    return md;

                }
            }
			

  
		}
	}  
	 

		

	
