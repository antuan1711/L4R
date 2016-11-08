using System;
using System.Data;
using System.Data.SqlClient;   
using System.IO;
using Microsoft.ApplicationBlocks.Data;

namespace Admin
{
	/// <summary>
	/// Summary description for RestaurantDB.
	/// </summary>
	public class RestaurantDB
	{
		/// <summary>
		/// Add Photo Details to dbo.TBL_RestaurantGallerys
		/// </summary>
		/// <param name="ResturantID"></param>
		/// <param name="filname"></param>
		/// <param name="filepos"></param>
		/// <param name="imagedate"></param>
		/// <returns>if successful return Photo_ID</returns>
		public string addPhotoDetails(int ResturantID,string filname,int filepos,string imagedate)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("RestaurantGallerys_insertImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurant_ID",ResturantID));
			command.Parameters.Add(new SqlParameter("@Gallary_filename",filname));
			command.Parameters.Add(new SqlParameter("@Gallary_filepos",filepos));
			command.Parameters.Add(new SqlParameter("@Gallary_fileDate",imagedate));

			SqlParameter pmResult = new SqlParameter("@Result_id",SqlDbType.Int);
			pmResult.Direction=ParameterDirection.Output;
			command.Parameters.Add(pmResult);   

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				return pmResult.Value.ToString();  
				   
			}		
			catch (Exception ex)
			{
				return ex.Message;  	
			}
			finally
			{
				connection.Close(); 
			}
     
		}

		public static DataTable CreateRestaurantDetailsDataSource(string state,string city) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_getRestaurantList", connection );
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@State",state));
			command.Parameters.Add(new SqlParameter("@City",city));


			SqlDataReader sreader;
			connection.Open();  
			DataTable dt = new DataTable("RestDetails");  
			DataRow dr ;

			dt.Columns.Add(new DataColumn("Restaurants_ID"));  
			dt.Columns.Add(new DataColumn("Restaurants_name"));  
			dt.Columns.Add(new DataColumn("Restaurants_street"));
			dt.Columns.Add(new DataColumn("Restaurants_city"));
			dt.Columns.Add(new DataColumn("Restaurants_state"));
			dt.Columns.Add(new DataColumn("Restaurants_zip"));
			dt.Columns.Add(new DataColumn("Restaurants_phone"));
			dt.Columns.Add(new DataColumn("Restaurants_email"));
			dt.Columns.Add(new DataColumn("Restaurants_cuisinetype"));
			dt.Columns.Add(new DataColumn("Restaurants_url"));
			dt.Columns.Add(new DataColumn("Restaurants_pricerange"));
			dt.Columns.Add(new DataColumn("filename"));
			dt.Columns.Add(new DataColumn("Restaurant_Member"));


			sreader=command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(0).ToString();
				dr[1] = sreader.GetValue(1).ToString();
				dr[2] = sreader.GetValue(2).ToString();
				dr[3] = sreader.GetValue(3).ToString();
				dr[4] = sreader.GetValue(4).ToString();
				dr[5] = sreader.GetValue(5).ToString();
				dr[6] = sreader.GetValue(6).ToString();
				dr[7] = sreader.GetValue(7).ToString();
				dr[8] = sreader.GetValue(8).ToString().Replace(",",", ");
				if (sreader.GetValue(9).ToString().Length > 12)
				{
					dr[9] = sreader.GetValue(9).ToString();
				}
				else
				{
					dr[9]="<br>";
				}

				dr[10] = sreader.GetValue(10).ToString();

				if (sreader.GetValue(11).ToString().ToUpper()   == "NONE.JPG" ) 
				{
					dr[11] = "no_photo.gif";
				}
				else
				{
					dr[11]=sreader.GetValue(11).ToString(); 

				}

				if (sreader.GetValue(12).ToString().ToUpper() == "TRUE") 
				{
					//  Code Modified by Krupakar to get Transperent Logo
					//dr[12] = @"<a href='FAQS.aspx' target=_blank><img src='images\couple.gif' align=absmiddle ></a>";
					dr[12] = @"<a href='FAQS.aspx' target=_blank><img src='Images\meet_logo1.gif' align=absmiddle ></a>";  
										
				}

				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}
      /*  public static DataTable CreateRestaurantDetailsDataSource(string state,string city) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_getRestaurantList", connection );
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@State",state));
			command.Parameters.Add(new SqlParameter("@City",city));


			SqlDataReader sreader;
			connection.Open();  
			DataTable dt = new DataTable("RestDetails");  
			DataRow dr ;

			dt.Columns.Add(new DataColumn("Restaurants_ID"));  
			dt.Columns.Add(new DataColumn("Restaurants_name"));  
			dt.Columns.Add(new DataColumn("Restaurants_street"));
			dt.Columns.Add(new DataColumn("Restaurants_city"));
			dt.Columns.Add(new DataColumn("Restaurants_state"));
			dt.Columns.Add(new DataColumn("Restaurants_zip"));
			dt.Columns.Add(new DataColumn("Restaurants_phone"));
			dt.Columns.Add(new DataColumn("Restaurants_email"));
			dt.Columns.Add(new DataColumn("Restaurants_cuisinetype"));
			dt.Columns.Add(new DataColumn("Restaurants_url"));
			dt.Columns.Add(new DataColumn("Restaurants_pricerange"));
			dt.Columns.Add(new DataColumn("filename"));
			dt.Columns.Add(new DataColumn("Restaurant_Member"));


			sreader=command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(0).ToString();
				dr[1] = sreader.GetValue(1).ToString();
				dr[2] = sreader.GetValue(2).ToString();
				dr[3] = sreader.GetValue(3).ToString();
				dr[4] = sreader.GetValue(4).ToString();
				dr[5] = sreader.GetValue(5).ToString();
				dr[6] = sreader.GetValue(6).ToString();
				dr[7] = sreader.GetValue(7).ToString();
				dr[8] = sreader.GetValue(8).ToString().Replace(",",", ");
				if (sreader.GetValue(9).ToString().Length > 12)
				{
					dr[9] = sreader.GetValue(9).ToString();
				}
				else
				{
					dr[9]="<br>";
				}

				dr[10] = sreader.GetValue(10).ToString();

				if (sreader.GetValue(11).ToString().ToUpper()   == "NONE.JPG" ) 
				{
					dr[11] = "no_photo.gif";
				}
				else
				{
					dr[11]=sreader.GetValue(11).ToString(); 

				}

				if (sreader.GetValue(12).ToString().ToUpper() == "TRUE") 
				{
					//  Code Modified by Krupakar to get Transperent Logo
					//dr[12] = @"<a href='FAQS.aspx' target=_blank><img src='images\couple.gif' align=absmiddle ></a>";
					dr[12] = @"<a href='FAQS.aspx' target=_blank><img src='Images\meet_logo1.gif' align=absmiddle ></a>";  
										
				}

				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}*/
		public SqlDataReader getPhotoDetails(int RestaurantID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("RestaurantGallerys_getPhotoDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurant_ID",RestaurantID));
			try
			{
				connection.Open();  
				SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);    
				return sda;
			}
			catch
			{
				return null;
			}
		}

        /// <summary>
        /// This method will fetch the Value of a single column, where the Table Name, Column Name and Condition is specified. The value will be returned in the form of a String
        /// </summary>
        /// <param name="prmTableName"></param>
        /// <param name="prmColumnName"></param>
        /// <param name="prmCondition"></param>
        /// <returns></returns>
        public static string GetSingleColumnValueFromTable(string prmTableName, string prmColumnName, string prmCondition)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
                SqlCommand Command = new SqlCommand("sp_GetSingleColumnValueFromTable", Connection);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.Add(new SqlParameter("@TableName", prmTableName));
                Command.Parameters.Add(new SqlParameter("@ColumnName", prmColumnName));
                Command.Parameters.Add(new SqlParameter("@Condition", prmCondition));

                string result = "";
                Connection.Open();
                result= Command.ExecuteScalar().ToString();
                Connection.Close();
                return result;                
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }

		public static string  insertMailingdata1(int Rest_id, string fname,string lname,string gender,string orient,string status,string birthdate,string ethnicity,string email,string companyname,string city,string zip,string phone,string fax)
		{
			SqlConnection Connection=new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand Command=new SqlCommand("Restaurant_mailing1",Connection);
			Command.CommandType=CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@Rest_id",Rest_id));
			Command.Parameters.Add(new SqlParameter("@First_Name",fname));
			Command.Parameters.Add(new SqlParameter("@Last_Name",lname));
			Command.Parameters.Add(new SqlParameter("@Gender",gender));
			Command.Parameters.Add(new SqlParameter("@Orientation",orient));
			Command.Parameters.Add(new SqlParameter("@Status",status));
			Command.Parameters.Add(new SqlParameter("@BirthDate",birthdate));
			Command.Parameters.Add(new SqlParameter("@Ethnicity",ethnicity));
			Command.Parameters.Add(new SqlParameter("@Email",email));
			Command.Parameters.Add(new SqlParameter("@CompanyName",companyname));
			Command.Parameters.Add(new SqlParameter("@City",city));
			Command.Parameters.Add(new SqlParameter("@Zip",zip));
			Command.Parameters.Add(new SqlParameter("@Phone",phone));
			Command.Parameters.Add(new SqlParameter("@Fax",fax));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close(); 
				return "Added Successfully";
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
        public static string insertMailingdata1(int Rest_id, string fname, string lname, string gender,  string status, string birthdate,  string email, string companyname, string city, string zip, string phone, string fax,string faith)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("Restaurant_mailing2", Connection);
            Command.CommandType = CommandType.StoredProcedure;

            Command.Parameters.Add(new SqlParameter("@Rest_id", Rest_id));
            Command.Parameters.Add(new SqlParameter("@First_Name", fname));
            Command.Parameters.Add(new SqlParameter("@Last_Name", lname));
            Command.Parameters.Add(new SqlParameter("@Gender", gender));
            Command.Parameters.Add(new SqlParameter("@Status", status));
            Command.Parameters.Add(new SqlParameter("@BirthDate", birthdate));
            Command.Parameters.Add(new SqlParameter("@Email", email));
            Command.Parameters.Add(new SqlParameter("@CompanyName", companyname));
            Command.Parameters.Add(new SqlParameter("@City", city));
            Command.Parameters.Add(new SqlParameter("@Zip", zip));
            Command.Parameters.Add(new SqlParameter("@Phone", phone));
            Command.Parameters.Add(new SqlParameter("@Fax", fax));
            Command.Parameters.Add(new SqlParameter("@Faith", faith));
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                return "Added Successfully";
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

		public static string DeleteImage(int Gallary_ID,string strPath)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("RestaurantGallerys_DeletePhotoDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Gallary_ID",Gallary_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				if (strPath != "")
				{
					File.Delete( strPath);  
				}
				return "Image Deleted";
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
		public  SqlDataReader getPhotoDetails(int RestaurantID,int filepos)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("RestaurantGallerys_getPhotoDetailsbyfilepos", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurant_ID",RestaurantID));
			command.Parameters.Add(new SqlParameter("@FilePos",filepos));
			try
			{
				connection.Open();  
				SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);    
				return sda;
			}
			catch
			{
				return null;
			}
		}

		public static SqlDataReader getStatusDetails(int RestaurantID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("get_RestaurantsPayamentStatusDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Rest_ID",RestaurantID));
			try
			{
				connection.Open();  
				SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);    
				return sda;
			}
			catch
			{
				return null;
			}
		}
        public static int checkEmail(string email)
        {
            int pid = 0;
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("RestaurantRegister_checkEmail", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@email", email));
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    pid = Int16.Parse(reader.GetValue(0).ToString());
                }

                return pid;
            }
            catch
            {
                return 1;
            }

        }
        public static string Restaurantinsertdata(string Rest_name, string street, string city, string state, string zip, string Rest_phone, string Rest_cell,
        string Rest_email, string Rest_Hours, string password, Int32 restUserID, out string restCode)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Restaurants_InsertfromRegistereduser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Restaurants_name", Rest_name));
            command.Parameters.Add(new SqlParameter("@Restaurants_street", street));
            command.Parameters.Add(new SqlParameter("@Restaurants_city", city));
            command.Parameters.Add(new SqlParameter("@Restaurants_state", state));
            command.Parameters.Add(new SqlParameter("@Restaurants_zip", zip));
            command.Parameters.Add(new SqlParameter("@Restaurants_phone", Rest_phone));
            command.Parameters.Add(new SqlParameter("@Restaurants_CellPhone", Rest_cell));
            command.Parameters.Add(new SqlParameter("@Restaurants_email", Rest_email));
            command.Parameters.Add(new SqlParameter("@Restaurants_hours", Rest_Hours));
            command.Parameters.Add(new SqlParameter("@Restaurants_Password", password));
            command.Parameters.Add(new SqlParameter("@restUserID", restUserID));
            SqlParameter parameterRestaurants_id = new SqlParameter("@Restaurants_id", SqlDbType.Int, 4);
            parameterRestaurants_id.Direction = ParameterDirection.Output;


            command.Parameters.Add(parameterRestaurants_id);
            SqlParameter parameterRestCode = new SqlParameter("@RestCode", SqlDbType.VarChar, 20);
            parameterRestCode.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameterRestCode);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            restCode = parameterRestCode.Value.ToString();
            return parameterRestaurants_id.Value.ToString();

        }
        public static int Rest_InsertMissingCity(int UserID, string UserType, int StateID, string CityName, string Site)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Insert_MissingCityDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@User_Id", UserID));
            command.Parameters.Add(new SqlParameter("@User_Type", UserType));
            command.Parameters.Add(new SqlParameter("@state_Id", StateID));
            command.Parameters.Add(new SqlParameter("@Missing_City", CityName));
            command.Parameters.Add(new SqlParameter("@Site", Site));
            SqlParameter intSuccess = new SqlParameter("@intSuccess", SqlDbType.Int, 4);
            intSuccess.Direction = ParameterDirection.Output;
            command.Parameters.Add(intSuccess);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                if (intSuccess.Value != DBNull.Value)
                {
                    return int.Parse(intSuccess.Value.ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public static string insertdata(string Rest_Title, string person_Name, string street, string city, string state, string zip, string phone,
            string phone1, string email, string pass, string contacttime, int rest_id)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("RestaurantUser", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Rest_Title", Rest_Title));
            command.Parameters.Add(new SqlParameter("@Person_Name", person_Name));
            command.Parameters.Add(new SqlParameter("@Restaurants_street", street));
            command.Parameters.Add(new SqlParameter("@Restaurants_city", city));
            command.Parameters.Add(new SqlParameter("@Restaurants_state", state));
            command.Parameters.Add(new SqlParameter("@Restaurants_zip", zip));
            command.Parameters.Add(new SqlParameter("@phone", phone));
            command.Parameters.Add(new SqlParameter("@phone1", phone1));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@pass", pass));
            command.Parameters.Add(new SqlParameter("@ContactTime", contacttime));
            command.Parameters.Add(new SqlParameter("@Rest_ID", rest_id));


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return "Infomation Added";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }
        }
        public static DataTable GetSelCity(int state_Id)
        {
            SqlConnection connection2 = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command2 = new SqlCommand("getSelectedCity", connection2);
            command2.CommandType = CommandType.StoredProcedure;
            command2.Parameters.Add(new SqlParameter("@state_Id", state_Id));
            connection2.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(command2);
            da.Fill(ds);
            connection2.Close();
            DataTable dTable = ds.Tables[0];
            return dTable;
        }
        public static string getRestaurantName(int RestaurantID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_getRestaurantsDetails", connection );
			
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurants_id",RestaurantID));

			SqlParameter restname= new SqlParameter("@Restaurantname",SqlDbType.NVarChar,100);
			restname.Direction = ParameterDirection.Output;
			command.Parameters.Add(restname);
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return restname.Value.ToString(); 
			}
			catch(Exception ex)
			{
				return ex.Message; 
			}
			finally
			{
				connection.Close();  
			}
		}
		public static string updateRestaurantStatusDetails(int Resturant_ID,string rest_status,int FeeType, decimal fees,string restNote)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("update_RestaurantsPayamentStatus", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@rest_id",Resturant_ID));
			command.Parameters.Add(new SqlParameter("@Rest_Status",rest_status ));
            command.Parameters.Add(new SqlParameter("@FeeType", FeeType));
            command.Parameters.Add(new SqlParameter("@Fees", fees));
            command.Parameters.Add(new SqlParameter("@RestNote", restNote));
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return "Restaurants Status  Updated..";
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

		public string updatePhotoDetails(int Resturant_GallaryID,int fiiepos,string filname)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("RestaurantGallerys_updateImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurant_GallaryID",Resturant_GallaryID));
			command.Parameters.Add(new SqlParameter("@Gallary_pos",fiiepos));
			command.Parameters.Add(new SqlParameter("@Gallary_filename",filname));

			SqlParameter pmResult = new SqlParameter("@Result_id",SqlDbType.Int);
			pmResult.Direction=ParameterDirection.Output;
			command.Parameters.Add(pmResult);   

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return pmResult.Value.ToString();  
				   
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
		public static string updatePhotoDetails(int Resturant_GallaryID,string ShowHome)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("RestaurantGallerys_updateHomeImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurant_GallaryID",Resturant_GallaryID));
			command.Parameters.Add(new SqlParameter("@ShowHome",ShowHome));
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return "Photo Status Updated.."; 
				   
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
        public static int UpdataRestaurantCredentials(int restID, string restEmail, string restPassword)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UpdataRestaurantCredentials_Sp", connection);
            command.CommandType=CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@restID", restID));
            command.Parameters.Add(new SqlParameter("@restEmail", restEmail));
            command.Parameters.Add(new SqlParameter("@restPassword", restPassword));
            SqlParameter pmResult = new SqlParameter("@Output", SqlDbType.Int);
            pmResult.Direction = ParameterDirection.Output;
            command.Parameters.Add(pmResult);  
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return Convert.ToInt32(pmResult.Value.ToString());

            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }

        }
		public string addRestaurnatDetails(string  Restaurants_name,string Restaurants_address,string Restaurants_City,string Restaurants_state,string Restaurants_zip,string Restaurants_phone,string Restaurants_fax,string Restaurants_email,string Restaurants_url,string Restaurants_specialty,string Restaurants_cuisinetype,string Restaurants_atmosphere,string Restaurants_amenities,string Restaurants_activities,string Restaurants_timeserved,string Restaurants_servicetype,string Restaurants_capacity,string Restaurants_attire,string Restaurants_bar,string Restaurants_pricerange,string Restaurants_hours,string Restaurants_reservation,string Restaurants_payment,string Restaurants_parking,string Restaurants_status,string Restaurants_signupdate,string Restaurants_password,string Restaurants_description,string Restaurants_contactTime)
		{

			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_AddRestaurantsDetails", connection );
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Restaurants_name",Restaurants_name ));
			command.Parameters.Add(new SqlParameter("@Restaurants_address",Restaurants_address));
			command.Parameters.Add(new SqlParameter("@Restaurants_city",Restaurants_City ));
			command.Parameters.Add(new SqlParameter("@Restaurants_state",Restaurants_state ));
			command.Parameters.Add(new SqlParameter("@Restaurants_zip",Restaurants_zip  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_phone",Restaurants_phone  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_fax",Restaurants_fax  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_email",Restaurants_email ));
			command.Parameters.Add(new SqlParameter("@Restaurants_url",Restaurants_url));
			command.Parameters.Add(new SqlParameter("@Restaurants_specialty" ,Restaurants_specialty ));
			command.Parameters.Add(new SqlParameter("@Restaurants_cuisinetype",Restaurants_cuisinetype  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_atmosphere",Restaurants_atmosphere  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_amenities",Restaurants_amenities ));
			command.Parameters.Add(new SqlParameter("@Restaurants_activities",Restaurants_activities ));
			command.Parameters.Add(new SqlParameter("@Restaurants_timeserved",Restaurants_timeserved  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_servicetype",Restaurants_servicetype  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_capacity",Restaurants_capacity  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_attire",Restaurants_attire ));
			command.Parameters.Add(new SqlParameter("@Restaurants_bar",Restaurants_bar  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_pricerange",Restaurants_pricerange  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_hours",Restaurants_hours  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_reservation",Restaurants_reservation));
			command.Parameters.Add(new SqlParameter("@Restaurants_payment",Restaurants_payment ));
			command.Parameters.Add(new SqlParameter("@Restaurants_parking",Restaurants_parking  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_status",Restaurants_status));
			command.Parameters.Add(new SqlParameter("@Restaurants_signupdate",Restaurants_signupdate));
			command.Parameters.Add(new SqlParameter("@Restaurants_Password",Restaurants_password ));
			command.Parameters.Add(new SqlParameter("@Resturant_ContactTime",Restaurants_contactTime));
			command.Parameters.Add(new SqlParameter("@Restaurants_description",Restaurants_description));
			
			
			SqlParameter result = new SqlParameter("@Restaurants_id",SqlDbType.Int);
			result.Direction= ParameterDirection.Output;
			command.Parameters.Add(result);  

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return result.Value.ToString();  
			}
			catch(Exception ex)
			{
				return ex.Message; 
			}
			finally
			{
				connection.Close();  
			}
 

		}
		
		public static DataTable CreateRestaurantPaymentDetailDataSource() 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("ClassifiedTransactionDetails_getTransactionDetailsOfUser", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("ClassifiedDetails");  
			DataRow dr ;

			dt.Columns.Add(new DataColumn("Transaction_id"));  
			dt.Columns.Add(new DataColumn("Classified_Title"));  
			dt.Columns.Add(new DataColumn("Classified_PostedDate"));
			dt.Columns.Add(new DataColumn("Classified_ExpiryDate"));
			dt.Columns.Add(new DataColumn("Classified_Status"));
			dt.Columns.Add(new DataColumn("Classified_AmountPaid"));
			dt.Columns.Add(new DataColumn("Classified_Type"));

			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr[0] = sreader.GetValue(1).ToString();
				dr[1] = sreader.GetValue(0).ToString();
				dr[2] = sreader.GetDateTime(2).ToString("dd-MMM-yyyy");
				dr[3] = sreader.GetDateTime(3).ToString("dd-MMM-yyyy");
				dr[4] = sreader.GetValue(4).ToString();
				dr[5] = sreader.GetValue(5).ToString();
				dr[6] = sreader.GetValue(6).ToString();

				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}
		public string updateRestaurnatDetails(string restid, string  Restaurants_name,string Restaurants_address,string Restaurants_City,string Restaurants_state,string Restaurants_zip,string Restaurants_phone,string Restaurants_fax,string Restaurants_email,string Restaurants_url,string Restaurants_specialty,string Restaurants_cuisinetype,string Restaurants_atmosphere,string Restaurants_amenities,string Restaurants_activities,string Restaurants_timeserved,string Restaurants_servicetype,string Restaurants_capacity,string Restaurants_attire,string Restaurants_bar,string Restaurants_pricerange,string Restaurants_hours,string Restaurants_reservation,string Restaurants_payment,string Restaurants_parking,string Restaurants_status,string Restaurants_signupdate,string Restaurants_password,string Restaurants_description,string Restaurants_contactTime)
		{

			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_UpdateRestaurantsDetails", connection );
			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Restaurants_ID",restid ));
			command.Parameters.Add(new SqlParameter("@Restaurants_name",Restaurants_name ));
			command.Parameters.Add(new SqlParameter("@Restaurants_address",Restaurants_address));
			command.Parameters.Add(new SqlParameter("@Restaurants_city",Restaurants_City ));
			command.Parameters.Add(new SqlParameter("@Restaurants_state",Restaurants_state ));
			command.Parameters.Add(new SqlParameter("@Restaurants_zip",Restaurants_zip  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_phone",Restaurants_phone  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_fax",Restaurants_fax  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_email",Restaurants_email ));
			command.Parameters.Add(new SqlParameter("@Restaurants_url",Restaurants_url));
			command.Parameters.Add(new SqlParameter("@Restaurants_specialty" ,Restaurants_specialty ));
			command.Parameters.Add(new SqlParameter("@Restaurants_cuisinetype",Restaurants_cuisinetype  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_atmosphere",Restaurants_atmosphere  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_amenities",Restaurants_amenities ));
			command.Parameters.Add(new SqlParameter("@Restaurants_activities",Restaurants_activities ));
			command.Parameters.Add(new SqlParameter("@Restaurants_timeserved",Restaurants_timeserved  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_servicetype",Restaurants_servicetype  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_capacity",Restaurants_capacity  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_attire",Restaurants_attire ));
			command.Parameters.Add(new SqlParameter("@Restaurants_bar",Restaurants_bar  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_pricerange",Restaurants_pricerange  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_hours",Restaurants_hours  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_reservation",Restaurants_reservation));
			command.Parameters.Add(new SqlParameter("@Restaurants_payment",Restaurants_payment ));
			command.Parameters.Add(new SqlParameter("@Restaurants_parking",Restaurants_parking  ));
			command.Parameters.Add(new SqlParameter("@Restaurants_status",Restaurants_status));
			command.Parameters.Add(new SqlParameter("@Restaurants_signupdate",Restaurants_signupdate));
			command.Parameters.Add(new SqlParameter("@Restaurants_Password",Restaurants_password ));
			command.Parameters.Add(new SqlParameter("@Resturant_ContactTime",Restaurants_contactTime));
			command.Parameters.Add(new SqlParameter("@Restaurants_description",Restaurants_description));
			
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return "S";
			}
				//			catch(Exception Ex)
				//
				//			{
				//				
				//				return Ex.Message;	
				//				
				//			}
			finally
			{
				connection.Close();  
			}
 

		}
		
		public static string DeleteRestaurantDetails(int RestaurantID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Restaurants_DeleteUser", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Restaurants_id",RestaurantID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Restaurant Deleted..";
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
		public SqlDataReader getRestaurantDetails(int RestaurantID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_getDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Restaurants_id",RestaurantID));
			try
			{
				connection.Open();  
				SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);    
				return sda;
			}
			catch
			{
				return null;
			}
			finally
			{
			}

		}

		/// <summary>
		/// if status = "A" then status = "Active"
		///	if status = "P" then status = "Pending"
		///	if status = "I" then status = "Inactive"
		/// </summary>
		/// <param name="userid"></param>
		/// <param name="password"></param>
		/// <returns></returns>

		public string RestaurantLogin(string userid,string password)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_checkLoginDetails", connection );
			command.CommandType=CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Username",userid));
			command.Parameters.Add(new SqlParameter("@password",password));
			connection.Open();  
			SqlDataReader sreader=command.ExecuteReader(CommandBehavior.CloseConnection );
			if (sreader.Read())
			{
				if (sreader.GetValue(2).ToString() != "A")
				{
					return "Not Paid";
				}
				else
				{
					return sreader.GetValue(0).ToString() + "#" + sreader.GetValue(1).ToString();     
				}
			}
			else
			{
				return "Login Failed";
			}

		}
        public static string Restaurnat_ChangePassword(int userID,string Password,string OldPassword)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_updatePasswordDetails", connection );
			command.CommandType=CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@UserID",userID));
			command.Parameters.Add(new SqlParameter("@password",Password));
			command.Parameters.Add(new SqlParameter("@OldPassword",OldPassword));

			SqlParameter result = new SqlParameter("@Result_id",SqlDbType.Int);
			result.Direction =ParameterDirection.Output;
			command.Parameters.Add(result);
			try
			{
				connection.Open();
				command.ExecuteNonQuery(); 
				connection.Close();
				return result.Value.ToString();
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
        public static string Restaurnat_updateStatus(int Rest_id,string status)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Restaurants_checkLoginDetails", connection );
			command.CommandType=CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Rest_ID",Rest_id ));
			command.Parameters.Add(new SqlParameter("@Rest_status",status ));
			try
			{
				connection.Open();
                
				command.ExecuteNonQuery(); 
				connection.Close();
				return "Done";
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
        public static DataSet GetAllRestaurants()
        {
            try
            {
                
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "GetAllRestaurants_sp");
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable GetAllRestaurants_AutoComplete(string filter, bool isActive)
        {
            try
            {
                Parameters objParameters = new Parameters(9);
                objParameters.SetParameter("@Filter", filter, SqlDbType.VarChar, 200, ParameterDirection.Input);
                objParameters.SetParameter("@IsActive", isActive, SqlDbType.Bit, 1, ParameterDirection.Input);
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "sp_GetRestaurants_autocomplete",arrParams).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static DataTable CreatePaidRestaurantDetails(String restaurant,String zip,String telephone,String fromDate,String toDate, String state, String city, String status, String email,String SortField, String SortOrder)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			
			SqlCommand Command = new SqlCommand("RestaurantPaymentDetails_getAllDetails", Connection);

			Command.Parameters.Add(new SqlParameter("@restaurant",restaurant.Trim()));
			Command.Parameters.Add(new SqlParameter("@zip",zip.Trim()));
			Command.Parameters.Add(new SqlParameter("@telephone",telephone.Trim()));
			Command.Parameters.Add(new SqlParameter("@fromDate",fromDate.Trim()));
			Command.Parameters.Add(new SqlParameter("@toDate",toDate.Trim()));
            Command.Parameters.Add(new SqlParameter("@state", state));
            Command.Parameters.Add(new SqlParameter("@city", city));
            Command.Parameters.Add(new SqlParameter("@status", status));
            Command.Parameters.Add(new SqlParameter("@email", email));

            Command.Parameters.Add(new SqlParameter("@SortField", SortField));
            Command.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));
            
			
			
			Command.CommandType = CommandType.StoredProcedure;
			SqlDataReader sreader;
			Connection.Open();  
			DataTable dt = new DataTable("User");  
			DataRow dr ;
			dt.Columns.Add(new DataColumn("Rest_ID"));  
			dt.Columns.Add(new DataColumn("Rest_Name"));
			dt.Columns.Add(new DataColumn("Rest_Seat"));
			dt.Columns.Add(new DataColumn("Rest_PaymentPlan"));
			dt.Columns.Add(new DataColumn("Rest_FeesPaid"));
			dt.Columns.Add(new DataColumn("Rest_Doit"));
			dt.Columns.Add(new DataColumn("Rest_Amount"));
			dt.Columns.Add(new DataColumn("Rest_PaymentStatus"));
			dt.Columns.Add(new DataColumn("Rest_Date"));
			dt.Columns.Add(new DataColumn("promotioncode"));
			dt.Columns.Add(new DataColumn("Restaurants_signupdate"));
			dt.Columns.Add(new DataColumn("Restaurants_city"));
			dt.Columns.Add(new DataColumn("Restaurants_state"));
			dt.Columns.Add(new DataColumn("Restaurants_zip"));
			dt.Columns.Add(new DataColumn("Restaurants_phone"));
			dt.Columns.Add(new DataColumn("Restaurants_email"));
			dt.Columns.Add(new DataColumn("Restaurants_status"));


			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
			while (sreader.Read())
			{
				dr = dt.NewRow();
				dr["Rest_ID"] = sreader.GetValue(0).ToString();
				dr["Rest_Name"] = sreader.GetValue(1).ToString();
				dr["Rest_Seat"] = sreader.GetValue(2).ToString();
				dr["Rest_PaymentPlan"] =	sreader.GetValue(3).ToString();
				dr["Rest_FeesPaid"] =	sreader.GetValue(4).ToString();
				dr["Rest_Doit"] =	sreader.GetValue(5).ToString();
				dr["Rest_Amount"] =	sreader.GetValue(6).ToString();
				dr["Rest_PaymentStatus"] =	sreader.GetValue(7).ToString();
				if(sreader.GetValue(8) != DBNull.Value)
				{
					dr["Rest_Date"] =	sreader.GetDateTime(8).ToString("MMM-dd-yy");
				}
				else
				{
					dr["Rest_Date"]=null;
				}
				dr["promotioncode"]=sreader.GetValue(9).ToString();
				dr["Restaurants_signupdate"] = sreader["Restaurants_signupdate"].ToString();
				dr["Restaurants_city"] = sreader["Restaurants_city"].ToString();
				dr["Restaurants_state"] = sreader["Restaurants_state"].ToString();
				dr["Restaurants_zip"] = sreader["Restaurants_zip"].ToString();
				dr["Restaurants_phone"] = sreader["Restaurants_phone"].ToString();
				dr["Restaurants_email"] = sreader["Restaurants_email"].ToString();
				dr["Restaurants_status"] = sreader["Restaurants_status"].ToString();

				//--------30-06-2010--------------
				
				//         -----------------------------------   
				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}
        public static DataSet CreatePaidRestaurantDetails1(String restaurant, String zip, String telephone, String fromDate, String toDate, String state, String city, String status, String email, int pageNo, int pageSize,string sortField,string sortOrder)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);

            SqlCommand Command = new SqlCommand("RestaurantPaymentDetails_getAllDetailsNew", Connection);

            Command.Parameters.Add(new SqlParameter("@restaurant", restaurant.Trim()));
            Command.Parameters.Add(new SqlParameter("@zip", zip.Trim()));
            Command.Parameters.Add(new SqlParameter("@telephone", telephone.Trim()));
            Command.Parameters.Add(new SqlParameter("@fromDate", fromDate.Trim()));
            Command.Parameters.Add(new SqlParameter("@toDate", toDate.Trim()));
            Command.Parameters.Add(new SqlParameter("@state", state));
            Command.Parameters.Add(new SqlParameter("@city", city));
            Command.Parameters.Add(new SqlParameter("@status", status));
            Command.Parameters.Add(new SqlParameter("@email", email));
           
            Command.Parameters.Add(new SqlParameter("@PageNo", pageNo));
            Command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
            Command.Parameters.Add(new SqlParameter("@SortField", sortField));
            Command.Parameters.Add(new SqlParameter("@SortOrder", sortOrder));
            Command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds= new DataSet();
            sda.SelectCommand = Command;
            sda.Fill(ds);
            Connection.Open();
            return ds;
        }
        public static string DeleteDinersPayment(int DinersID)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("DinersPaymentLog_Delete", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@Restaurants_id", DinersID));
            try
            {
                Connection.Open();
                Command.ExecuteNonQuery();
                Connection.Close();
                return "Diners Payment Log Deleted..";
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
        public static DataTable CreateDinersPaymentLogDetails(String Dinners, String zip, String telephone, String fromDate, String toDate, String state, String city, String status, String email, String SortField, String SortOrder)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("DinersPaymentDetails_getAllDetails", Connection);

            Command.Parameters.Add(new SqlParameter("@Dinners_name", Dinners.Trim()));
            Command.Parameters.Add(new SqlParameter("@zip", zip.Trim()));
            Command.Parameters.Add(new SqlParameter("@telephone", telephone.Trim()));
            Command.Parameters.Add(new SqlParameter("@fromDate", fromDate.Trim()));
            Command.Parameters.Add(new SqlParameter("@toDate", toDate.Trim()));
            Command.Parameters.Add(new SqlParameter("@state", state));
            Command.Parameters.Add(new SqlParameter("@city", city));
            Command.Parameters.Add(new SqlParameter("@status", status));
            Command.Parameters.Add(new SqlParameter("@email", email));

            Command.Parameters.Add(new SqlParameter("@SortField", SortField));
            Command.Parameters.Add(new SqlParameter("@SortOrder", SortOrder));



            Command.CommandType = CommandType.StoredProcedure;
            SqlDataReader sreader;
            Connection.Open();
            DataTable dt = new DataTable("User");
            DataRow dr;
            dt.Columns.Add(new DataColumn("Rest_ID"));
            dt.Columns.Add(new DataColumn("Rest_Name"));
            dt.Columns.Add(new DataColumn("LastFourDigits"));
            dt.Columns.Add(new DataColumn("ExpirationDate"));
            dt.Columns.Add(new DataColumn("Dinners_city"));
            dt.Columns.Add(new DataColumn("Dinners_state"));
            dt.Columns.Add(new DataColumn("Dinners_zip"));
            dt.Columns.Add(new DataColumn("Dinners_phone"));


            sreader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            while (sreader.Read())
            {
                dr = dt.NewRow();
                dr["Rest_ID"] = sreader.GetValue(0).ToString();
                dr["Rest_Name"] = sreader.GetValue(1).ToString();
                dr["LastFourDigits"] = sreader["LastFourDigits"].ToString();
                if (sreader["ExpirationDate"] != DBNull.Value)
                {

                    DateTime rdt = (DateTime)sreader["ExpirationDate"];
                    dr["ExpirationDate"] = rdt.ToString("MMM-dd-yy");
                }
                else
                {
                    dr["ExpirationDate"] = null;
                }

                string sss = sreader["Dinners_city"].ToString();
                dr["Dinners_city"] = sreader["Dinners_city"].ToString();                   
                dr["Dinners_state"] = sreader["Dinners_state"].ToString();
                dr["Dinners_zip"] = sreader["Dinners_zip"].ToString();
                dr["Dinners_phone"] = sreader["Dinners_phone"].ToString();


                //--------30-06-2010--------------

                //         -----------------------------------   
                dt.Rows.Add(dr);
            }
            sreader.Close();
            return dt;
        }
        public static clsDinersPayer GetDinersPaymentLogDetails(int UserID)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);

            SqlCommand Command = new SqlCommand("DinersPaymentDetails_getDetails", Connection);

            Command.Parameters.Add(new SqlParameter("@UserID", UserID));

            Command.CommandType = CommandType.StoredProcedure;
            SqlDataReader sreader;
            Connection.Open();
            clsDinersPayer dt = new clsDinersPayer();

            sreader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            while (sreader.Read())
            {
                dt.ID = (int)sreader.GetValue(0);
                dt.Name = sreader.GetValue(1).ToString();
                dt.LastFourDigits  = sreader["LastFourDigits"].ToString();
                if (sreader["ExpirationDate"] != DBNull.Value)
                {

                    DateTime rdt = (DateTime)sreader["ExpirationDate"];
                    dt.ExpirationDate  = rdt.ToString("MMM-dd-yy");
                }
                else
                {
                    dt.ExpirationDate = null;
                }

                dt.City = sreader["Dinners_city"].ToString();
                dt.State = sreader["Dinners_state"].ToString();
                dt.Zip = sreader["Dinners_zip"].ToString();
                dt.TelNo = sreader["Dinners_phone"].ToString();

            }

            sreader.Close();
            return dt;


        }
        public static int SetDinersPaymentLog(int ID, String Name, String zip, String telephone, String ExpDate, String state, String city, String LastFour)
        {
            int intSuccess = 0;
            try
            {
                //@PayeeID int,
                //@Name NvarChar(100), 
                //@zip NvarChar(100), 
                //@telephone NvarChar(100), 
                //@ExpDate NvarChar(100), 
                //@state NvarChar(100), 
                //@city NvarChar(100), 
                //@LastFour NvarChar(100),
                DateTime dt = System.Convert.ToDateTime(ExpDate);
                Parameters objParameters = new Parameters(9);
                objParameters.SetParameter("@PayeeID", ID, SqlDbType.Int, 4, ParameterDirection.Input);
                objParameters.SetParameter("@Name", Name.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@zip", zip.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@telephone", telephone.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@ExpDate", dt, SqlDbType.DateTime, 20, ParameterDirection.Input);
                objParameters.SetParameter("@state", state.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@city", city.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@LastFour", LastFour.Trim(), SqlDbType.NVarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@intSuccess", intSuccess, SqlDbType.Int, 4, ParameterDirection.Output);


                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "DinersPaymentLog_InsertUpdate", arrParams);

                //Retrieve Output Variables
                if (arrParams[8].Value != DBNull.Value)
                {
                    intSuccess = Convert.ToInt32(arrParams[8].Value.ToString());
                }

                //Return the Value
            }
            catch (Exception ex)
            {
            }
            return intSuccess;
        }
		public static string Restaurnat_updatePromoCode(string Code)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("update TBL_PromotionCode set promo='"+Code+"'", connection );
			command.CommandType=CommandType.Text;
			try
			{
				connection.Open();
				command.ExecuteNonQuery(); 
				connection.Close();
				return "Done";
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
        public static DataTable GetRestMenuLog(string toDate, string fromDate,string customerName,string restName)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("GetALLRestMenuLog_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ToDate", toDate));
            command.Parameters.Add(new SqlParameter("@FromDate", fromDate));
            command.Parameters.Add(new SqlParameter("@CustomerName", customerName));
            command.Parameters.Add(new SqlParameter("@RestName", restName));
            try
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = command;
                sda.Fill(ds);
                return ds.Tables[0];


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
        public static DataTable getSelectedMailingList(string idlist)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("getSelectedMailingList_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@idlist", idlist));
            try
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = command;
                sda.Fill(ds);
                return ds.Tables[0];


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
        public static DataSet GetMenuOrderDetail(int menuOrderID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("GetMenuOrderDetail_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@MenuOrderID", menuOrderID));
            try
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = command;
                sda.Fill(ds);
                return ds;
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
        public static DataSet GetMenuOrderItemsDetail(int menuOrderID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Select * from tbl_MenuOrderItemsDetails where MenuOrderID=@MenuOrderID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@MenuOrderID", menuOrderID));
            try
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = command;
                sda.Fill(ds);
                return ds;


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
        public static int DeleteMenuOrder(int menuOrderID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("DeleteMenuOrder_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@MenuOrderID", menuOrderID));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return 0;

            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }


        }
        public static DataSet GetAllRestCoupanDetail(string dinerName, string coupanStartDate, string coupanToDate, string coupanusedDate, string personID, string coupanCode, int amount,string restName, string sortField, string sortOrder)
        {

            try
            {
                SqlParameter[] sqlparam = new SqlParameter[10];
                sqlparam[0] = new SqlParameter("@DinerName", dinerName);
                sqlparam[1] = new SqlParameter("@CoupanStartDate", coupanStartDate);
                sqlparam[2] = new SqlParameter("@CoupanToDate", coupanToDate);
                sqlparam[3] = new SqlParameter("@CoupanusedDate", coupanusedDate);
                sqlparam[4] = new SqlParameter("@PersonID", personID);
                sqlparam[5] = new SqlParameter("@CoupanCode", coupanCode);
                sqlparam[6] = new SqlParameter("@Amount", amount);
                sqlparam[7] = new SqlParameter("@restName", restName);
                sqlparam[8] = new SqlParameter("@SortField", sortField);
                sqlparam[9] = new SqlParameter("@SortOrder", sortOrder);
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, "GetAllRestCoupanDetail_SP", sqlparam);
            }
            catch
            {
                return null;
            }
        }

        public static int UpdateRestServiceFeeType(int ServiceFeeTypeID, decimal ServiceFeeAmount)
        {
           string query=string.Empty;
           query = "Update tbl_RestServiceFeeType set ServiceFeeTypeID=@ServiceFeeTypeID , ServiceFeeAmount=@ServiceFeeAmount";
           SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
           SqlCommand command = new SqlCommand(query, connection);
           command.CommandType = CommandType.Text;
           command.Parameters.Add(new SqlParameter("@ServiceFeeTypeID", ServiceFeeTypeID));
           command.Parameters.Add(new SqlParameter("@ServiceFeeAmount", ServiceFeeAmount));
           try
           {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return 0;

            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }
     
        public static decimal GetRestaurnatFlatFees()
        {
            string query = "Select ServiceFeeAmount from tbl_RestServiceFeeType";
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                decimal fees =Convert.ToDecimal(command.ExecuteScalar().ToString());
                connection.Close();
                return fees;

            }
            catch
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }


        }
        public static DataTable GetRestServiceFeeTypeDetail()
        {
            string query = "Select * from tbl_RestServiceFeeType";
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sda.SelectCommand = command;
                sda.Fill(ds);
                return ds.Tables[0];


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
        public static void UpdateRestaurantMontlyServiceFees(decimal serviceFees, string startDate, string endDate, int feePlanID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UpdateRestServiceFeesPlan_sp", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@ServiceFees", serviceFees));
            command.Parameters.Add(new SqlParameter("@StartDate", startDate));
            command.Parameters.Add(new SqlParameter("@EndDate", endDate));
            command.Parameters.Add(new SqlParameter("@FeePlanID", feePlanID));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
              
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }
        }
        public SqlDataReader getRestaurantDetails1(int RestaurantID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Restaurants_getDetails1", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Restaurants_id", RestaurantID));
            try
            {
                connection.Open();
                SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);
                return sda;
            }
            catch
            {
                return null;
            }
            finally
            {
            }

        }
        public string updateRestaurnatDetails1(string restid, string Restaurants_name, string Restaurants_address, string Restaurants_City, string Restaurants_state, string Restaurants_zip, string Restaurants_phone, string Restaurants_fax, string Restaurants_email, string Restaurants_url, string Restaurants_specialty, string Restaurants_cuisinetype, string Restaurants_atmosphere, string Restaurants_amenities, string Restaurants_activities, string Restaurants_timeserved, string Restaurants_servicetype, string Restaurants_capacity, string Restaurants_attire, string Restaurants_bar, string Restaurants_pricerange, string Restaurants_hours, string Restaurants_reservation, string Restaurants_payment, string Restaurants_parking, string Restaurants_status, string Restaurants_signupdate, string Restaurants_password, string Restaurants_description, string Restaurants_contactTime, string meetmemember, string operation, decimal saleTax, int restFeeType)
        {

            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Restaurants_UpdateRestaurantsDetailsfromUser1", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Restaurants_ID", restid));
            command.Parameters.Add(new SqlParameter("@Restaurants_name", Restaurants_name));
            command.Parameters.Add(new SqlParameter("@Restaurants_address", Restaurants_address));
            command.Parameters.Add(new SqlParameter("@Restaurants_city", Restaurants_City));
            command.Parameters.Add(new SqlParameter("@Restaurants_state", Restaurants_state));
            command.Parameters.Add(new SqlParameter("@Restaurants_zip", Restaurants_zip));
            command.Parameters.Add(new SqlParameter("@Restaurants_phone", Restaurants_phone));
            command.Parameters.Add(new SqlParameter("@Restaurants_fax", Restaurants_fax));
            command.Parameters.Add(new SqlParameter("@Restaurants_email", Restaurants_email));
            command.Parameters.Add(new SqlParameter("@Restaurants_url", Restaurants_url));
            command.Parameters.Add(new SqlParameter("@Restaurants_specialty", Restaurants_specialty));
            command.Parameters.Add(new SqlParameter("@Restaurants_cuisinetype", Restaurants_cuisinetype));
            command.Parameters.Add(new SqlParameter("@Restaurants_atmosphere", Restaurants_atmosphere));
            command.Parameters.Add(new SqlParameter("@Restaurants_amenities", Restaurants_amenities));
            command.Parameters.Add(new SqlParameter("@Restaurants_activities", Restaurants_activities));
            command.Parameters.Add(new SqlParameter("@Restaurants_timeserved", Restaurants_timeserved));
            command.Parameters.Add(new SqlParameter("@Restaurants_servicetype", Restaurants_servicetype));
            command.Parameters.Add(new SqlParameter("@Restaurants_capacity", Restaurants_capacity));
            command.Parameters.Add(new SqlParameter("@Restaurants_attire", Restaurants_attire));
            command.Parameters.Add(new SqlParameter("@Restaurants_bar", Restaurants_bar));
            command.Parameters.Add(new SqlParameter("@Restaurants_pricerange", Restaurants_pricerange));
            command.Parameters.Add(new SqlParameter("@Restaurants_hours", Restaurants_hours));
            command.Parameters.Add(new SqlParameter("@Restaurants_reservation", Restaurants_reservation));
            command.Parameters.Add(new SqlParameter("@Restaurants_payment", Restaurants_payment));
            command.Parameters.Add(new SqlParameter("@Restaurants_parking", Restaurants_parking));
            command.Parameters.Add(new SqlParameter("@Restaurants_status", Restaurants_status));
            command.Parameters.Add(new SqlParameter("@Restaurants_signupdate", Restaurants_signupdate));
            command.Parameters.Add(new SqlParameter("@Restaurants_Password", Restaurants_password));
            command.Parameters.Add(new SqlParameter("@Resturant_ContactTime", Restaurants_contactTime));
            command.Parameters.Add(new SqlParameter("@Restaurants_description", Restaurants_description));
            command.Parameters.Add(new SqlParameter("@Restaurant_Member", meetmemember));
            //command.Parameters.Add(new SqlParameter("@Restaurants_Diner",dinerYesorNo));
            command.Parameters.Add(new SqlParameter("@Restaurant_HrsOperation", operation));
            command.Parameters.Add(new SqlParameter("@SaleTax", saleTax));
            command.Parameters.Add(new SqlParameter("@ServiceFeeType", restFeeType));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return "S";
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
        public static DataSet GetAllServicesByRestID(int restid)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@RestID", restid);
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, "GetAllServicesByRestID_SP", sqlparam);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static DataTable GetAllRestReviews(string restName, string userName,string rating,string fromDate, string toDate)
        {
            try
            {
                string strQuery = string.Empty;
                SqlParameter[] sqlparam = new SqlParameter[5];
                sqlparam[0] = new SqlParameter("@RestName", restName);
                sqlparam[1] = new SqlParameter("@UserName", userName);
                sqlparam[2] = new SqlParameter("@Rating", rating);
                sqlparam[3] = new SqlParameter("@FromDate", fromDate);
                sqlparam[4] = new SqlParameter("@ToDate", toDate);
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure,"GetAllRestReviews_Sp", sqlparam).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static DataSet GetAllRestReviews(string restName, string userName, string rating, string fromDate, string toDate,int pageNo, int pageSize)
        {
            try
            {
                string strQuery = string.Empty;
                SqlParameter[] sqlparam = new SqlParameter[7];
                sqlparam[0] = new SqlParameter("@RestName", restName);
                sqlparam[1] = new SqlParameter("@UserName", userName);
                sqlparam[2] = new SqlParameter("@Rating", rating);
                sqlparam[3] = new SqlParameter("@FromDate", fromDate);
                sqlparam[4] = new SqlParameter("@ToDate", toDate);
                sqlparam[5] = new SqlParameter("@PageNo", pageNo);
                sqlparam[6] = new SqlParameter("@PageSize", pageSize);
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "GetAllPagedRestReviews_Sp", sqlparam);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static string GetRestReviewsDetail(int blogID)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@BlogID", blogID);
                return Convert.ToString(SqlHelper.ExecuteScalar(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Select Description from tbl_Blogs where intblogID=@BlogID", sqlparam));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int UpdateRestReview(string reviewText,int blogID)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@BlogID", blogID);
                sqlparam[1] = new SqlParameter("@ReviewText", reviewText);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Update tbl_Blogs set Description =@ReviewText where intblogID=@BlogID", sqlparam);
                 return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static int DeleteReview(int blogID)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@BlogID", blogID);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Delete from tbl_Blogs where intBlogID=@BlogID", sqlparam);
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static int UpdateRestBlogStatus(int blogID)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@BlogID", blogID);
            SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Update tbl_Blogs set isReviewByAdmin =1 where intblogID=@BlogID", sqlparam);
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static DataTable GetAllRestNotes(int restID)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@restID", restID);
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Select * from tbl_RestNotes where RestID=@restID ORDER BY PostedDate DESC", sqlparam).Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static int AddAdminServiceFeesComment(string adminComment)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@AdminComment", adminComment);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Update tbl_RestServiceFeeType set AdminComment =@AdminComment", sqlparam);
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static int UpdateActivationMailStauts(string sentMailStatus)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@SentMailStatus", sentMailStatus);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "UpdateActivationMailStauts_SP", sqlparam);
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static DataTable GetAllAdminPemissionType()
        {
            try
            {
                return SqlHelper.ExecuteDataset(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.Text, "Select * from Tbl_AdminPermissions").Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static int InsertRestPaymentDetail(int restID, decimal fees, string subject, string message,string linkID,string email)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@RestID", restID);
                sqlparam[1] = new SqlParameter("@Fees", fees);
                sqlparam[2] = new SqlParameter("@Subject", subject);
                sqlparam[3] = new SqlParameter("@Message", message);
                sqlparam[4] = new SqlParameter("@LinkID", linkID);
                sqlparam[5] = new SqlParameter("@Email", email);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "InsertRestSetUpPaymentDetail_sp", sqlparam);
                return 0;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public static int InsertRestPaymentDetailNew(int restID, decimal fees, string subject, string message, string linkID,string email)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[7];
                sqlparam[0] = new SqlParameter("@RestID", restID);
                sqlparam[1] = new SqlParameter("@Fees", fees);
                sqlparam[2] = new SqlParameter("@Subject", subject);
                sqlparam[3] = new SqlParameter("@Message", message);
                sqlparam[4] = new SqlParameter("@LinkID", linkID);
                sqlparam[5] = new SqlParameter("@Email", email);
                sqlparam[6] = new SqlParameter("@Output", SqlDbType.Int);
                sqlparam[6].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "InsertRestSetUpPaymentDetailNew_sp", sqlparam);
                if (sqlparam[6].Value != DBNull.Value)
                {
                    return (Convert.ToInt32(sqlparam[6].Value));
                }
                else
                {
                    return -1;
                }
                
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public static int AddRestNotes(int RestID,string Notes)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@RestID", RestID);
                sqlparam[1] = new SqlParameter("@RestNote", Notes);
                SqlHelper.ExecuteNonQuery(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString, CommandType.StoredProcedure, "AddRestNotes", sqlparam);
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
    }
}
   			

public class clsDinersPayer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string LastFourDigits { get; set; }
    public string ExpirationDate { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public string TelNo { get; set; }
    public string State { get; set; }
}




