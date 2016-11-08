using System;
using System.Data; 
using System.Data.SqlClient;  
using System.Collections;
using Microsoft.ApplicationBlocks.Data;  
namespace Admin.Advertisement
{
	/// <summary>
	/// Summary description for Classified.
	/// </summary>
	/// 
	public class ClassifiedDB
	{
		public string AddEvents(string cls_Name,string cls_Active,string cls_Details,string clsfor) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Classified_insertClassifiedDetails", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			cls_Name = cls_Name.Replace("'","\'");
			cls_Details = cls_Details.Replace("'","\'");
   

			command.Parameters.Add(new SqlParameter("@Classified_Name",cls_Name));
			command.Parameters.Add(new SqlParameter("@Classified_Active",cls_Active));
			command.Parameters.Add(new SqlParameter("@Classified_For",clsfor));
			command.Parameters.Add(new SqlParameter("@Classified_Details",cls_Details));
			
			SqlParameter parameterEventID = new SqlParameter("@Classified_ID", SqlDbType.Int, 4);
			parameterEventID.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterEventID);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				int EventId = (int)parameterEventID.Value;
				connection.Close(); 
				return EventId.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}

		public string updateEvents(int cls_id,string cls_Name,string cls_Active,string cls_Details,string clsfor) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Classified_updateClassifiedDetails", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			cls_Name = cls_Name.Replace("'","\'");
			cls_Details = cls_Details.Replace("'","\'");
   
			command.Parameters.Add(new SqlParameter("@Classified_ID",cls_id));
			command.Parameters.Add(new SqlParameter("@Classified_Name",cls_Name));
			command.Parameters.Add(new SqlParameter("@Classified_Active",cls_Active));
			command.Parameters.Add(new SqlParameter("@Classified_For",clsfor));
			command.Parameters.Add(new SqlParameter("@Classified_Details",cls_Details));
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				return cls_Name + " Information updated"; 
			}
			catch 
			{
				return null;
			}
			finally
			{
				connection.Close();  
			}
		}

		public static SqlDataReader GetClassifiedtDetails(int Classified_ID) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_selectClassifiedDetailsbyID", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Classified_ID",Classified_ID)); 
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
  		}
        public static SqlDataReader GetClassifiedListingDetails(int Classified_ID, string Classified_Name, string Classified_Active, string SortField, string SortOrder) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_getDetailsbyID1", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Classified_ID",Classified_ID));
            Command.Parameters.Add(new SqlParameter("@Classified_Name", Classified_Name));
            Command.Parameters.Add(new SqlParameter("@Classified_Active", Classified_Active));
            Command.Parameters.Add(new SqlParameter("@SortField", SortField));
            Command.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));  
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}

		public static SqlDataReader GetClassifiedListingDetailsByListID(int Listing_ID) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_getDetailsbyListingID", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ClassifiedList_ID",Listing_ID));      
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		public static string DeleteClassifiedListing(int Classified_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_DeleteListing", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Classified_ID",Classified_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Suceess";
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
		public static string DeleteClassifiedListingByClsID(int Classified_ID,int ListID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_DeleteListingName", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Classified_ID",Classified_ID));
			Command.Parameters.Add(new SqlParameter("@ListID",ListID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Suceess";
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
		public static string DeleteClassified(int Classified_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_DeleteClassified", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ClassifiedID",Classified_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Classified Deleted";
			}
			catch (Exception ex)
			{
				return ex.Message.ToString();  
			}
			finally
			{
				Connection.Close();  
			}
		}
		public static string DeleteClassifiedUser(int ClassifiedUser_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_DeleteClassifiedUser", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ClassifieduserID",ClassifiedUser_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Classified User is Deleted..";
			}
			catch (Exception ex) 
			{
				return ex.Message.ToString() ;
			}
			finally
			{
				Connection.Close();  
			}
		}
		
		public static string DeleteMainClassified(int ClassifiedMain_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("freeClassified_deleteByClassifiedCategory", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Cls_Category",ClassifiedMain_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				string class_name ="related to " + getListingName(ClassifiedMain_ID) + "are"; 
				return   "Transactions "+ class_name  +"  deleted";
			}
			catch (Exception ex) 
			{
				return ex.Message.ToString() ;
			}
			finally
			{
				Connection.Close();  
			}
		}

		public static string DeletefreeClassifiedTrans(int ClassifiedMain_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("freeClassified_deleteByClassifiedTransaction", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Cls_Category",ClassifiedMain_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return getListingName(ClassifiedMain_ID) +  " Classified Transaction are Deleted..";
			}
			catch (Exception ex) 
			{
				return ex.Message.ToString() ;
			}
			finally
			{
				Connection.Close();  
			}
		}



        public static DataTable CreateServiceDataSource(Int32 serviceID)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("Admin_GetServiceInfo", Connection);
            Command.Parameters.Add(new SqlParameter("@serviceID", serviceID));
            Command.CommandType = CommandType.StoredProcedure;
            SqlDataReader sreader;
            Connection.Open();
            DataTable dt = new DataTable("TBL_Services");
            DataRow dr;

            dt.Columns.Add(new DataColumn("ServiceID"));
            dt.Columns.Add(new DataColumn("ServiceName"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Fees"));
            dt.Columns.Add(new DataColumn("HandlingFees"));
            dt.Columns.Add(new DataColumn("IsFreeService"));

            sreader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            while (sreader.Read())
            {
                dr = dt.NewRow();

                dr["ServiceID"] = Convert.ToString(sreader["ServiceID"]);
                dr["ServiceName"] = Convert.ToString(sreader["ServiceName"]);
                dr["Description"] = Convert.ToString(sreader["Description"]);
                dr["Fees"] = Convert.ToString(sreader["Fees"]);
                dr["HandlingFees"] = Convert.ToString(sreader["HandlingFees"]);
                dr["IsFreeService"] = Convert.ToString(sreader["IsFreeService"]);

                dt.Rows.Add(dr);
            }
            sreader.Close();
            return dt;
        }

        public static string DeleteService(int ServiceID)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("sp_DeleteService", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ServiceID", ServiceID));
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                return "Sevice is Deleted..";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                Connection.Close();
            }
        }



		public static string addClassifiedListing( int classifiedId,string listingName,string status,string desc)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_insertDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@ClassifiedListing_Name",listingName));
			Command.Parameters.Add(new SqlParameter("@Classified_ID",classifiedId));
			Command.Parameters.Add(new SqlParameter("@Classified_status",status));
			Command.Parameters.Add(new SqlParameter("@ClassifiedListing_Desc",desc));
  
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();  
				return "Sucees"; 
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
		public static string updateClassifiedListing(int classifiedListingId,string listingName,string status,string desc)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedListing_updateListingDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			
			Command.Parameters.Add(new SqlParameter("@ClassifiedListingId",classifiedListingId));
			Command.Parameters.Add(new SqlParameter("@ClassifiedListing_Name",listingName));
			Command.Parameters.Add(new SqlParameter("@ClassifiedListing_Desc",desc));
			Command.Parameters.Add(new SqlParameter("@Classified_status",status));
  			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();  
				return "Succes"; 
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


        public static DataTable CreateClasifiedDataSource(int mainClassifiedID, string Classified_Name,string Classified_Active,string SortField, string SortOrder) 
		{
			
			DataTable dt = new DataTable("ClassifiedDetails");  
			DataRow dr ;
			dt.Columns.Add(new DataColumn("Classified_ID"));  
			dt.Columns.Add(new DataColumn("Classified_Name"));
			dt.Columns.Add(new DataColumn("Classified_Details"));
			dt.Columns.Add(new DataColumn("Classified_Active"));
			
			SqlDataReader sreader = GetClassifiedListingDetails(mainClassifiedID,Classified_Name,Classified_Active,SortField,SortOrder);  

			while (sreader.Read())
			{
				 dr = dt.NewRow();
		        dr[0] = sreader.GetValue(0).ToString();
		        dr[1] = sreader.GetValue(1).ToString();
				dr[2] = sreader.GetValue(3).ToString();
				if (sreader.GetValue(2).ToString() == "1")
				{
					dr[3] ="Active";
				}
				else 
				{
					dr[3] ="InActive";
				}

		        dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}

		/// <summary>
		/// DataTable for Transaction Details of the User 
		/// </summary>
		/// <param name="userID">Classified UserID</param>
		/// <param name="filter">select the value on the base of filter</param>
		/// <returns>DataTable</returns>
		public static DataTable CreateClasifiedUserDetailsDataSource(string postedBy, string postedDate, string expiryDate, string email, string  classifiedCategory, string classifiedactive,int filter,string SortField, string SortOrder) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedTransactionDetails_getTransactionDetailsOfUser", Connection);
			Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@postedBy", postedBy));
            Command.Parameters.Add(new SqlParameter("@PostedDate", postedDate));
            Command.Parameters.Add(new SqlParameter("@ExpiryDate", expiryDate));
            Command.Parameters.Add(new SqlParameter("@Email", email));
            Command.Parameters.Add(new SqlParameter("@ClassifiedCategory", classifiedCategory));

            Command.Parameters.Add(new SqlParameter("@Classifiedactive", classifiedactive));
      
			Command.Parameters.Add(new SqlParameter("@Filter",filter));

            Command.Parameters.Add(new SqlParameter("@SortField", SortField));

            Command.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));


			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("ClassifiedDetails");  
			DataRow dr ;
			dt.Columns.Add(new DataColumn("Transaction_id"));  
			dt.Columns.Add(new DataColumn("PostedBy"));  
			dt.Columns.Add(new DataColumn("Classified_PostedDate"));
			dt.Columns.Add(new DataColumn("Classified_ExpiryDate"));
			dt.Columns.Add(new DataColumn("Classified_Status"));
            

			dt.Columns.Add(new DataColumn("Classified_AmountPaid"));
			dt.Columns.Add(new DataColumn("Classified_Type"));
            dt.Columns.Add(new DataColumn("Classified_ContactEmail"));
			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(1).ToString();
				dr[1] = sreader.GetValue(9).ToString();
				dr[2] = sreader.GetDateTime(2).ToString("dd-MMM-yyyy");
				dr[3] = sreader.GetDateTime(3).ToString("dd-MMM-yyyy");
				dr[4] = sreader.GetValue(4).ToString();
				dr[5] = sreader.GetValue(5).ToString();
				dr[6] = sreader.GetValue(6).ToString();
                dr[7] = sreader.GetValue(8).ToString();


				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}
		/// <summary>
		/// get Transaction Details of the free classified from
		/// table [TBL_FreeClassified] and the stored proecedure 
		/// Classified_GetfreeClassifedDetailbyCategory
		/// </summary>
		/// <param name="CategoryID"></param>
		/// <returns></returns>
		public static DataTable CreatefreeClasifiedCategoryDetailsDataSource(int CategoryID) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_GetfreeClassifedDetailbyCategory", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@CategoryID",CategoryID));
			


			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("ClassifiedDetails");  
			DataRow dr ;

			dt.Columns.Add(new DataColumn("Classified_ID"));  
			dt.Columns.Add(new DataColumn("Classified_Title"));  
			dt.Columns.Add(new DataColumn("Restaurant_Name"));
			dt.Columns.Add(new DataColumn("Classified_PostedDate"));
			dt.Columns.Add(new DataColumn("Classified_ExpDate"));
			dt.Columns.Add(new DataColumn("Classified_ReplyEmail"));
			dt.Columns.Add(new DataColumn("Classified_Status")); 
 

			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(0).ToString();
				dr[1] = sreader.GetValue(1).ToString();
				SqlDataReader reader =null;
				int cat = Int32.Parse(sreader.GetValue(6).ToString());
				reader= GetRestaurantName(cat); 
				if (reader.Read())
				{
					dr[2] = reader.GetValue(0).ToString();
					
				}
				else
				{
					dr[2] = "";
				}
				//dr[2] = sreader.GetValue(6).ToString();
				dr[3] = sreader.GetValue(2).ToString();
				dr[4] = sreader.GetValue(3).ToString();
				dr[5] = sreader.GetValue(4).ToString();
				dr[6] = sreader.GetValue(5).ToString();
				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			Connection.Close();
			return dt;
		}

        public static DataTable CreateAllfreeClasifiedCategoryDetailsDataSource(string classifiedTitle,string restaurantName,string posteddate,string expritydate,string email,string SortField, string SortOrder)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("Classified_GetAllfreeClassifedDetail", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ClassifiedTitle", classifiedTitle));
            Command.Parameters.Add(new SqlParameter("@RestaurantName", restaurantName));
            Command.Parameters.Add(new SqlParameter("@Posteddate", posteddate));
            Command.Parameters.Add(new SqlParameter("@Expritydate", expritydate));
            Command.Parameters.Add(new SqlParameter("@Email", email));
            
            Command.Parameters.Add(new SqlParameter("@SortField", SortField));
            Command.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));


            SqlDataReader sreader;
            Connection.Open();
            DataTable dt = new DataTable("ClassifiedDetails");
            DataRow dr;

            dt.Columns.Add(new DataColumn("Classified_ID"));
            dt.Columns.Add(new DataColumn("Classified_Title"));
            dt.Columns.Add(new DataColumn("Restaurant_Name"));
            dt.Columns.Add(new DataColumn("Classified_PostedDate"));
            dt.Columns.Add(new DataColumn("Classified_ExpDate"));
            dt.Columns.Add(new DataColumn("Classified_ReplyEmail"));
            dt.Columns.Add(new DataColumn("Classified_Status"));


            sreader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            while (sreader.Read())
            {
                dr = dt.NewRow();
                dr[0] = sreader.GetValue(0).ToString();
                dr[1] = sreader.GetValue(1).ToString();
                if(sreader.GetValue(7)!=DBNull.Value)
                {

                    dr[2] = sreader.GetValue(7).ToString();

                }
                else
                {
                    dr[2] = "";
                }
                //dr[2] = sreader.GetValue(6).ToString();
                dr[3] = sreader.GetValue(2).ToString();
                dr[4] = sreader.GetValue(3).ToString();
                dr[5] = sreader.GetValue(4).ToString();
                dr[6] = sreader.GetValue(5).ToString();
                dt.Rows.Add(dr);
            }
            sreader.Close();
            Connection.Close();
            return dt;
        }

		/// <summary>
		/// return Classified User Name on Classified UserID
		/// </summary>
		/// <param name="classifiedUserID"></param>
		/// <returns></returns>
		public static string getClassifiedUserName(int classifiedUserID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("ClasifiedUserDetails_GetClassifiedUserName", connection);
			command.CommandType = CommandType.StoredProcedure;
   
			command.Parameters.Add(new SqlParameter("@User_ID",classifiedUserID));

			SqlParameter parameterEventID = new SqlParameter("@User_name", SqlDbType.NVarChar ,100);
			parameterEventID.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterEventID);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterEventID.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}

		public static string getCategoryIDByTransaction(int Trans_ID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("FreeClassified_getCategoryID", connection);
			command.CommandType = CommandType.StoredProcedure;
   

			command.Parameters.Add(new SqlParameter("@classified_id",Trans_ID));

			SqlParameter parameterName = new SqlParameter("@category_id", SqlDbType.Int  ,4);
			parameterName.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterName);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterName.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}

		}

		public static string getListingName(int ListingID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("ClassifiedListing_getListingName", connection);
			command.CommandType = CommandType.StoredProcedure;
   

			command.Parameters.Add(new SqlParameter("@ClassifiedID",ListingID));

			SqlParameter parameterName = new SqlParameter("@ClassifiedName", SqlDbType.NVarChar ,100);
			parameterName.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterName);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterName.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}

		public static string getClassifiedName(int ClassifiedID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Classified_GetClassifiedNamebyID", connection);
			command.CommandType = CommandType.StoredProcedure;
   

			command.Parameters.Add(new SqlParameter("@Classified_ID",ClassifiedID));

			SqlParameter parameterName = new SqlParameter("@Classified_name", SqlDbType.NVarChar ,50);
			parameterName.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterName);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return " " +parameterName.Value.ToString();
			}
			catch (Exception ex)
			{
				return (ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}


		public static string getCategoryID(int TransID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("ClassifiedTransactionDetails_getClasifiedUserID", connection);
			command.CommandType = CommandType.StoredProcedure;
   

			command.Parameters.Add(new SqlParameter("@trans_id",TransID));

			SqlParameter parameterName = new SqlParameter("@cls_id", SqlDbType.Int,4);
			parameterName.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterName);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterName.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}


		public static string CountListing(int classifiedID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("ClassifiedTransaction_countListingOfUser", connection);
			command.CommandType = CommandType.StoredProcedure;
   
			command.Parameters.Add(new SqlParameter("@ClassifiedUserid",classifiedID));

			SqlParameter parameterEventID = new SqlParameter("@ClassifiedCount", SqlDbType.Int, 4);
			parameterEventID.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterEventID);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterEventID.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}

		/// <summary>
		/// This CountListing is done for calculating the free category withing
		/// the subcategories fron the table tbl_freeclassified using the
		/// Stored Procedure classified_CountfreeClassifiedWithinCategory
		/// </summary>
		/// <param name="MainCategory"></param>
		/// <param name="SubCategory"></param>
		/// <returns></returns>
		public static string CountListing(int MainCategory,int SubCategory) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("classified_CountfreeClassifiedWithinCategory", connection);
			command.CommandType = CommandType.StoredProcedure;
   
			command.Parameters.Add(new SqlParameter("@Main",MainCategory));
			command.Parameters.Add(new SqlParameter("@Sub",SubCategory));

			SqlParameter parameterEventID = new SqlParameter("@Count", SqlDbType.Int, 4);
			parameterEventID.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterEventID);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return parameterEventID.Value.ToString();
			}
			catch (Exception ex)
			{
				return ("Error:" + ex.Message.ToString()); 
			}
			finally
			{
				connection.Close();  
			}
		}


		public static string DeleteTransaction(int Trans_ID) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedTransactionDetails_DeleteTransactionDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@TransID",Trans_ID)); 
			try
			{
				Connection.Open();  
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Post Deleted";
			}
			catch(Exception ex)
			{
				return ex.Message.ToString(); 
			}
			finally
			{
				Connection.Close();  
			}
			
		}

		public static SqlDataReader GetTransationDetails(int Trans_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedTransactionDetails_getTransactionDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@TransID",Trans_ID)); 
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}
		public static SqlDataReader GetFreeTransationDetails(int Classified_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("FreeClassified_getFreeTransactionDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Cls_id",Classified_ID)); 
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}

		public static SqlDataReader GetRestaurantName(int Rest_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_RestaurantName", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@RestID",Rest_ID)); 
			Connection.Open();  
			SqlDataReader reader =Command.ExecuteReader(CommandBehavior.CloseConnection);
			return reader;
		}



		public static DataTable CreatePaidClasifiedUserDataSource() 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_getAllUser", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("ClassifiedUser");  
			DataRow dr ;
			dt.Columns.Add(new DataColumn("ClassifiedUser_ID"));  
			dt.Columns.Add(new DataColumn("ClassifiedUser_Name"));
			dt.Columns.Add(new DataColumn("ClassifiedUser_ContactPerson"));
			dt.Columns.Add(new DataColumn("ClassifiedUser_Email"));
			dt.Columns.Add(new DataColumn("ClassifiedUser_Phone"));
			dt.Columns.Add(new DataColumn("ClassifiedUser_NoOfListing"));

			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(0).ToString();
				dr[1] = sreader.GetValue(1).ToString();
				dr[2] = sreader.GetValue(2).ToString();
				dr[3] =	sreader.GetValue(3).ToString();
				dr[4] =	sreader.GetValue(4).ToString();
				int id =Int32.Parse(sreader.GetValue(0).ToString());
				dr[5] = CountListing(id).ToString(); 
				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			Connection.Close();
			return dt;
		}

		public static DataTable CreateFreeClasifiedUserDataSource(out int values) 
		{
			values = 0;
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Classified_GetfreeClassifedMainDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("ClassifiedUser");  
			DataRow dr ;
			
			dt.Columns.Add(new DataColumn("Classified_ID"));
			dt.Columns.Add(new DataColumn("Classified_Cat"));
			dt.Columns.Add(new DataColumn("Classified_SubCategory"));
			dt.Columns.Add(new DataColumn("Restaurant_Name"));
			dt.Columns.Add(new DataColumn("Classified_NoOfListing"));
			
			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			
			while (sreader.Read())
			{
				dr = dt.NewRow();
				
				dr[1] = sreader.GetValue(1).ToString();
				dr[2] = sreader.GetValue(2).ToString();
				int main = Int32.Parse(sreader.GetValue(3).ToString());  
				int sub = Int32.Parse(sreader.GetValue(0).ToString());
				int cat = Int32.Parse(sreader.GetValue(4).ToString());
				dr[0] = sub;
				dr[3] = CountListing(main,sub);
				//dr[4] = Int32.Parse(sreader.GetValue(4).ToString());
				SqlDataReader reader =null;
				reader= GetRestaurantName(cat); 
				if (reader.Read())
				{
					dr[4] = reader.GetValue(0).ToString();
					
				}
				else
				{
					dr[4] = "";
				}
				//dr[4] = "Meet me";
				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}


		public static string updateFreeTransactionDetails(int cls_id,string title,string postedDate, string expdate,string status,string amount,string desc,string email) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("FreeClassified_updatefreeClassifiedDetail", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			title = title.Replace("'","\'");
			desc = desc.Replace("'","\'");
   
			command.Parameters.Add(new SqlParameter("@Classified_ID",cls_id)); 
			command.Parameters.Add(new SqlParameter("@Classified_Title",title)); 
			command.Parameters.Add(new SqlParameter("@Classified_PostedDate",postedDate));
			command.Parameters.Add(new SqlParameter("@Classified_ExpDate",expdate));
			command.Parameters.Add(new SqlParameter("@Classified_Active",status)); 
			command.Parameters.Add(new SqlParameter("@Classified_SalaryDetails",amount));
			command.Parameters.Add(new SqlParameter("@Classified_Desc",desc));
			command.Parameters.Add(new SqlParameter("@Classified_ReplyEmail",email));  
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				return title + " Classified updated successfully "; 
			}
			catch (Exception ex)
			{
				return ex.Message.ToString(); 
			}
			finally
			{
				connection.Close();  
			}
		}


		public static string updateTransactionDetails(int Tran_id,string title,string postedDate, string expdate,string status,string amount,string desc,string email,string url) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("ClassifiedTransactionDetails_UpdateTransactionDetails", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			title = title.Replace("'","\'");
			desc = desc.Replace("'","\'");
   
			command.Parameters.Add(new SqlParameter("@Transaction_id",Tran_id)); 
			command.Parameters.Add(new SqlParameter("@Classified_Title",title)); 
			command.Parameters.Add(new SqlParameter("@Classified_PostedDate",postedDate));
			command.Parameters.Add(new SqlParameter("@Classified_ExpiryDate",expdate));
			command.Parameters.Add(new SqlParameter("@Classified_Status",status)); 
			command.Parameters.Add(new SqlParameter("@Classified_AmountPaid",amount));
			command.Parameters.Add(new SqlParameter("@Classified_Desc",desc));
			command.Parameters.Add(new SqlParameter("@Classified_ContactEmail",email));  
			command.Parameters.Add(new SqlParameter("@Classified_Url",url));  
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				return title + " Information updated"; 
			}
			catch (Exception ex)
			{
				return ex.Message.ToString(); 
			}
			finally
			{
				connection.Close();  
			}
		}


        public static DataTable CreateServiceDataSource()
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("Admin_GetServiceDetails", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            SqlDataReader sreader;
            Connection.Open();
            DataTable dt = new DataTable("TBL_Services");
            DataRow dr;

            dt.Columns.Add(new DataColumn("ServiceID"));
            dt.Columns.Add(new DataColumn("ServiceName"));
            dt.Columns.Add(new DataColumn("Description"));
            dt.Columns.Add(new DataColumn("Fees"));
            dt.Columns.Add(new DataColumn("HandlingFees"));
            dt.Columns.Add(new DataColumn("IsFreeService"));

            sreader = Command.ExecuteReader(CommandBehavior.CloseConnection);

            while (sreader.Read())
            {
                dr = dt.NewRow();

                dr["ServiceID"] = Convert.ToString(sreader["ServiceID"]);
                dr["ServiceName"] = Convert.ToString(sreader["ServiceName"]);
                dr["Description"] = Convert.ToString(sreader["Description"]);
                dr["Fees"] = Convert.ToString(sreader["Fees"]);
                dr["HandlingFees"] = Convert.ToString(sreader["HandlingFees"]);
                dr["IsFreeService"] = Convert.ToString(sreader["IsFreeService"]);

                dt.Rows.Add(dr);
            }
            sreader.Close();
            return dt;
        }

        public static string UpdateService(int serviceID, string serviceName, string description, string fees, string handlingFees, Boolean isFreeService)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Admin_UpdateService", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@serviceID", serviceID));
            command.Parameters.Add(new SqlParameter("@serviceName", serviceName));
            command.Parameters.Add(new SqlParameter("@description", description));
            if (fees.Trim().Equals(String.Empty))
            {
                command.Parameters.Add(new SqlParameter("@fees", DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@fees", fees));
            }
            if (handlingFees.Trim().Equals(String.Empty))
            {
                command.Parameters.Add(new SqlParameter("@handlingFees", DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@handlingFees", handlingFees));
            }
            command.Parameters.Add(new SqlParameter("@isFreeService", isFreeService));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return "Service Information updated";
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static DataSet GetAllPostings(string postingName, string postingCategory, string postingType ,string postingExpiry, int pageNo, int pageSize)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetAllPostings_sp", Connection);
            Command.Parameters.Add(new SqlParameter("@PostingName", postingName));
            Command.Parameters.Add(new SqlParameter("@PostingCategory", postingCategory));
            Command.Parameters.Add(new SqlParameter("@PostingType", postingType));
            Command.Parameters.Add(new SqlParameter("@PostingExpiry", postingExpiry));
            Command.Parameters.Add(new SqlParameter("@PageNo", pageNo));
            Command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            Command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sda.SelectCommand = Command;
            sda.Fill(ds);
            Connection.Open();
            return ds;
        }
        public static SqlDataReader GetClassifiedListingDetails(int Classified_ID)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("ClassifiedListing_getDetailsbyID", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@Classified_ID", Classified_ID));
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static DataSet GetAllResumeList(int jobCategory, string fromDate, string toDate, int pageNo, int pageSize)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("GetResumeList_Sp", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            if (jobCategory == 0)
            {
                Command.Parameters.Add(new SqlParameter("@JobCategory", DBNull.Value));
            }
            else
            {
                Command.Parameters.Add(new SqlParameter("@JobCategory", jobCategory));
            }
            if (fromDate == "")
            {
                Command.Parameters.Add(new SqlParameter("@FromDate", DBNull.Value));
            }
            else
            {
                Command.Parameters.Add(new SqlParameter("@FromDate", fromDate));
            }
            if (toDate == "")
            {
                Command.Parameters.Add(new SqlParameter("@ToDate", DBNull.Value));
            }
            else
            {
                Command.Parameters.Add(new SqlParameter("@ToDate", toDate));
            }
            Command.Parameters.Add(new SqlParameter("@PageNo", pageNo));
            Command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            try
            {
                Connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = Command;
                sda.Fill(ds);
                return ds;
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
        public static string UpdateResumeStatus(int resumeID, Boolean resumeStatus)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("UpdateResumeStatus_SP", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@ResumeID", resumeID));
            Command.Parameters.Add(new SqlParameter("@ResumeStatus", resumeStatus));
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
                return "ok";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                Connection.Close();
            }
        }
	}

        
}
	


