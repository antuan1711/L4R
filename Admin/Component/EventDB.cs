using System;
using System.Data;
using System.Data.SqlClient;   
using Admin.Common; 
using System.Text;
using LoveForRestaurants.BizLayer;
namespace Admin.Calendar
{
	
	//*******************************************************
	//
	// EventDetails Class
	//
	// A simple data class that encapsulates details about
	// a particular Events inside the AdminDB
	// database.
	//
	//*******************************************************

	public class EventDetails
	{
		public string Event_ID;
        public string Event_Name;
        public string Event_StartDate;
        public string Event_StartTime;
        public string Event_EndDate;
        public string Event_EndTime;
        public string Event_Location;
        public string Event_Description;
        public string Event_LastModifiedDate;
        public string Event_Cost;
        public string Event_Organizer;
        public string Event_State;
        public string Event_Address = "";
        public string Event_Contactno = "";
        public string Event_Events = "";
        public string Event_ZipCode = "";
        public Boolean Event_RSVP = false;
        public Boolean IsRecurring = false;
        public string RecurringType = "";
        public int RelatedEventID = 0;
        public int EventLocationID = 0;
        public int EventCoupan = 0;
        public int Event_OrganizerID;
	}


	public class EventDB
	{
		/// <summary>
		/// The getEventDetails method returns a DataReader that exposes all 
		/// Events within the AdminDB database. 
		///  The SQLDataReaderResult struct also returns the
		/// SQL connection, which must be explicitly closed after the
		/// data from the DataReader is bound into the controls.
		/// </summary>
		/// <returns>Data Table -Return the Event details</returns>
		public DataTable GetEventDetails() 
		{
			// Create Instance of Connection and Command Object
			SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand Com = new SqlCommand("Events_GetEventDetails", Con);

			// Mark the Command as a SPROC
			Com.CommandType = CommandType.StoredProcedure;

			// Execute the command
			Con.Open();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(Com);  
			da.Fill(ds); 
			Con.Close();
			DataTable dTable=ds.Tables[0]; 
			return dTable;
		}

    
        public static DataSet SelectAcitvityByID(int activityID)
        {
            // Create Instance of Connection and Command Object
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("Select *  from TBL_Activities where intActivityID=@activityID", Con);
            Com.Parameters.Add(new SqlParameter("@activityID", activityID));

            // Mark the Command as a SPROC
            Com.CommandType = CommandType.Text;
            // Execute the command
            try
            {
                Con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Com);
                da.Fill(ds);
                Con.Close();
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                Con.Close();
            }
            
     
        }
        public static int DeleteSelectedActivity(int activityID)
        {
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("Delete from TBL_Activities where intActivityID=@activityID", Con);
            Com.Parameters.Add(new SqlParameter("@activityID",activityID));
            // Mark the Command as a SPROC
            Com.CommandType = CommandType.Text;
            try
            {
                // Execute the command
                Con.Open();
                Com.ExecuteNonQuery();
                return 1;
                Con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                Con.Close();
            }
       

        }

        public static int UpdateAcitvityByID(int intactivityID,string vcActivity, int intStatus, DateTime dtDate)
        {
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("Update  TBL_Activities Set vcActivity=@vcActivity,intStatus=@intStatus,dtDate=@dtDate where intActivityID=@intActivityID", Con);
            Com.Parameters.Add(new SqlParameter("@intActivityID", intactivityID));
            Com.Parameters.Add(new SqlParameter("@vcActivity", vcActivity));
            Com.Parameters.Add(new SqlParameter("@intStatus", intStatus));
            Com.Parameters.Add(new SqlParameter("@dtDate", dtDate));

            // Mark the Command as a SPROC
            Com.CommandType = CommandType.Text;
            try
            {
                // Execute the command
                Con.Open();
                Com.ExecuteNonQuery();
                return 1;
                Con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                Con.Close();
            }


        }
        public static int InsertActivity( string vcActivity, int intStatus, DateTime dtDate)
        {
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("INSERT INTO  TBL_Activities ( vcActivity,intStatus,dtDate) values(@vcActivity,@intStatus,@dtDate)", Con);
            
            Com.Parameters.Add(new SqlParameter("@vcActivity", vcActivity));
            Com.Parameters.Add(new SqlParameter("@intStatus", intStatus));
            Com.Parameters.Add(new SqlParameter("@dtDate", dtDate));

            // Mark the Command as a SPROC
            Com.CommandType = CommandType.Text;
            try
            {
                // Execute the command
                Con.Open();
                Com.ExecuteNonQuery();
                return 1;
                Con.Close();
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                Con.Close();
            }


        }
        public static DataSet SelectAllActivity( string activityName, string activityStatus, string activityDate,string sortfield,string sortorder)
        {
            // Create Instance of Connection and Command Object
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("TBL_SelectAllActivities", Con);
            Com.Parameters.Add(new SqlParameter("@activityName", activityName));
            Com.Parameters.Add(new SqlParameter("@activityStatus", activityStatus));
            Com.Parameters.Add(new SqlParameter("@activityDate", activityDate));
            Com.Parameters.Add(new SqlParameter("@sortfield", sortfield));
            Com.Parameters.Add(new SqlParameter("@sortorder", sortorder));


            // Mark the Command as a SPROC
            Com.CommandType = CommandType.StoredProcedure;

            // Execute the command
            Con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(Com);
            da.Fill(ds);
            Con.Close();
            return ds;
        }


		/// <summary>
		/// The getEventByDate method returns a EventDetails
		/// struct containing specific details about a specified
		/// Date within the AdminDb Database
		/// </summary>
		/// <param name="Date">Date format Should be dd-MMMM-yyyy</param>
		/// <returns>SqlDataReader</returns>
		public DataTable GetEventDetails(string Event_Date) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Events_GetEventDetailsByDate", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Event_Date",Event_Date));      
			SqlDataAdapter dadapt = new SqlDataAdapter();
            dadapt.SelectCommand=Command;   
			Connection.Open(); 
			DataSet ds = new DataSet();
			dadapt.Fill(ds,"Event"); 
			Connection.Close() ; 
   			return ds.Tables["Event"]; 
  		}
        public DataTable GetEventDetails(string Event_Date,string activityName, string userType)
        {
            SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Command = new SqlCommand("Events_GetEventDetailsByDate1", Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add(new SqlParameter("@Event_Date", Event_Date));
            Command.Parameters.Add(new SqlParameter("@Event_Name", activityName));
            Command.Parameters.Add(new SqlParameter("@UserType", userType));
            SqlDataAdapter dadapt = new SqlDataAdapter();
            dadapt.SelectCommand = Command;
            Connection.Open();
            DataSet ds = new DataSet();
            dadapt.Fill(ds, "Event");
            Connection.Close();
            return ds.Tables["Event"];
        }
        public DataSet GetEventDetails(string eventType, string eventDate, string userType, string eventStatus,string restName,int pageNo, int pageSize)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
                SqlCommand Command = new SqlCommand("Events_GetAllEvents", Connection);
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.Add(new SqlParameter("@EventDate", eventDate));
                Command.Parameters.Add(new SqlParameter("@EventType", eventType));
                Command.Parameters.Add(new SqlParameter("@UserType", userType));
                if (eventStatus == "-1")
                {
                    Command.Parameters.Add(new SqlParameter("@EventStatus", DBNull.Value));
                }
                else
                {
                    Command.Parameters.Add(new SqlParameter("@EventStatus", Convert.ToBoolean(eventStatus)));
                }
                Command.Parameters.Add(new SqlParameter("@RestName", restName));
                Command.Parameters.Add(new SqlParameter("@PageNo", pageNo));
                Command.Parameters.Add(new SqlParameter("@PageSize", pageSize));
                SqlDataAdapter dadapt = new SqlDataAdapter();
                dadapt.SelectCommand = Command;
                Connection.Open();
                DataSet ds = new DataSet();
                dadapt.Fill(ds, "Event");
                Connection.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetRecurrEventDetailsByID(int Event_ID)
        {
            SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand Com = new SqlCommand("Events_GetRecurrEventDetailsByID", Con);

            // Mark the Command as a SPROC
            Com.CommandType = CommandType.StoredProcedure;
            Com.Parameters.Add(new SqlParameter("@Event_id", Event_ID));

            // Execute the command
            try
            {
                Con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(Com);
                da.Fill(ds);
                Con.Close();
                DataTable dTable = ds.Tables[0];
                return dTable;
            }
            catch
            {
                return null;
            }
            finally
            {
                Con.Close();
            }
        }
        public static DataSet GetEventByID(int Event_ID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_GetEventDetailsByIDNew", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));
            try
            {
                connection.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
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
     
		public string AddEvents(string Event_Name,string Event_StartDate,string Event_StartTime,string Event_EndDate,string Event_EndTime,string Event_Location,string Event_Desc,string Event_Cost,string Event_Organizer,string EventState,string EventAddress,string EventContactno) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Events_InsertEventData", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			Event_Name = Event_Name.Replace("'","\'");
			Event_Desc = Event_Desc.Replace("'","\'").Replace("\n","<br>");
   

			command.Parameters.Add(new SqlParameter("@Event_Name",Event_Name));
			command.Parameters.Add(new SqlParameter("@Event_StartDate",Event_StartDate));
			command.Parameters.Add(new SqlParameter("@Event_StartTime",Event_StartTime));
			command.Parameters.Add(new SqlParameter("@Event_EndTime",Event_EndTime));
			command.Parameters.Add(new SqlParameter("@Event_EndDate",Event_EndDate));
			command.Parameters.Add(new SqlParameter("@Event_Location",Event_Location ));
			command.Parameters.Add(new SqlParameter("@Event_Description",Event_Desc));
			command.Parameters.Add(new SqlParameter("@Event_Cost",Event_Cost ));
			command.Parameters.Add(new SqlParameter("@Event_Organizer",Event_Organizer));
			command.Parameters.Add(new SqlParameter("@Event_State",EventState));
			command.Parameters.Add(new SqlParameter("@Event_Address",EventAddress));
			command.Parameters.Add(new SqlParameter("@Event_ContactNo",EventContactno));
			//command.Parameters.Add(new SqlParameter("@Event_Events","EveryOne Events"));
			

			SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
			parameterEventID.Direction = ParameterDirection.Output;
			command.Parameters.Add(parameterEventID);
			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				int EventId = (int)parameterEventID.Value;
				return Event_Name + " Event added successfully";
			}
			catch(Exception ex)
			{
				return ex.Message.ToString() ;
			}
			finally
			{
				connection.Close();  
			}
		}
	

		public string EditEvents(int Event_ID,string Event_Name,string Event_StartDate,string Event_StartTime,string Event_EndDate,string Event_EndTime,string Event_Location,string Event_Desc,string Event_Cost,string Event_Organizer,string Event_State,string address,string phone) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Events_EditEventData", connection);

			command.CommandType = CommandType.StoredProcedure;
			
			Event_Name = Event_Name.Replace("'","\'");
			Event_Desc = Event_Desc.Replace("'","\'");
			Event_Location = Event_Location.Replace("'","\'");
   
			command.Parameters.Add(new SqlParameter("@Event_ID",Event_ID));
			command.Parameters.Add(new SqlParameter("@Event_Name",Event_Name));
			command.Parameters.Add(new SqlParameter("@Event_StartDate",Event_StartDate));
			command.Parameters.Add(new SqlParameter("@Event_StartTime",Event_StartTime));
			command.Parameters.Add(new SqlParameter("@Event_EndTime",Event_EndTime));
			command.Parameters.Add(new SqlParameter("@Event_EndDate",Event_EndDate));
			command.Parameters.Add(new SqlParameter("@Event_Location",Event_Location ));
			command.Parameters.Add(new SqlParameter("@Event_Description",Event_Desc));
			command.Parameters.Add(new SqlParameter("@Event_Cost",Event_Cost));
			command.Parameters.Add(new SqlParameter("@Event_Organizer",Event_Organizer));
			command.Parameters.Add(new SqlParameter("@Event_State",Event_State));
			command.Parameters.Add(new SqlParameter("@Event_Address",address));
			command.Parameters.Add(new SqlParameter("@Event_ContactNo",phone));
			

			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				return  Event_Name + " Event Updated Successfully"; 
			}
			catch(Exception ex)
			{
				return ex.Message.ToString() ;
			}
			finally
			{
				connection.Close();  
			}
		}
		
		
		public static DataTable CreateEventTransactionDataSource(int ShowEvent_id) 
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("EventDetails_getAllDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;

			Command.Parameters.Add(new SqlParameter("@Event_id",ShowEvent_id));

			SqlDataReader sreader;
			
			DataTable dt = new DataTable("EventTransaction");  
			DataRow dr ;
			
			dt.Columns.Add(new DataColumn("Trans_ID"));  
			dt.Columns.Add(new DataColumn("Event_ID"));  
			dt.Columns.Add(new DataColumn("Event_Name"));
			dt.Columns.Add(new DataColumn("Amount"));
			dt.Columns.Add(new DataColumn("Customer_Name"));
			dt.Columns.Add(new DataColumn("Customer_Email"));
			dt.Columns.Add(new DataColumn("Customer_Phone"));
			dt.Columns.Add(new DataColumn("Trans_Date"));

			
			Connection.Open(); 
			sreader=Command.ExecuteReader(CommandBehavior.CloseConnection);   
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
				dr[7] = sreader.GetDateTime(7).ToString("MMM-dd-yyyy");

				dt.Rows.Add(dr);
			}
			sreader.Close(); 
			return dt;
		}
		public static string DeleteEvnetTrans(int Trans_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("EventDetails_DeleteDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Trans_id",Trans_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return " Event Transaction are Deleted..";
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
		public static string DeleteEvents(int Event_ID) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Events_DeleteEvent", connection);
			command.CommandType =CommandType.StoredProcedure;     
			command.Parameters.Add(new SqlParameter("@Event_ID",Event_ID));   

			SqlParameter result = new SqlParameter("@Event_Name",SqlDbType.NVarChar,300);
			result.Direction = ParameterDirection.Output;
			command.Parameters.Add(result);   

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
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
        public int AddEvents3(int UserID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, Boolean IsRecurring, string RecurringType, int RelatedEventID, int EventLocationID, int EventCoupan, int EventPrivacy)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UserEvents_InsertEventData3", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");


            command.Parameters.Add(new SqlParameter("@UserID", UserID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring ", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            command.Parameters.Add(new SqlParameter("@RelatedEventID", RelatedEventID));

            SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
            parameterEventID.Direction = ParameterDirection.Output;

            command.Parameters.Add(parameterEventID);
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int EventId = (int)parameterEventID.Value;
                return EventId;
                //return Event_Name + " added successfully";
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString() ;
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AddEvents3(int UserID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, Boolean IsRecurring, string RecurringType, int RelatedEventID, int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UserEvents_InsertEventData3", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");


            command.Parameters.Add(new SqlParameter("@UserID", UserID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring ", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            command.Parameters.Add(new SqlParameter("@RelatedEventID", RelatedEventID));

            SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
            parameterEventID.Direction = ParameterDirection.Output;

            command.Parameters.Add(parameterEventID);
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int EventId = (int)parameterEventID.Value;
                return EventId;
                //return Event_Name + " added successfully";
            }
            catch (Exception ex)
            {
                //return ex.Message.ToString() ;
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AddEvents2(int UserID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UserEvents_InsertEventData2", connection);
            command.CommandType = CommandType.StoredProcedure;
            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");
            command.Parameters.Add(new SqlParameter("@UserID", UserID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
            parameterEventID.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameterEventID);
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int EventId = (int)parameterEventID.Value;
                return EventId;
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
        public static int CreateActivity(int UserID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, Boolean IsRecurring, string RecurringType,int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit,string eventschedule, bool isPassNight)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("CreateActivity_SP", connection);
            command.CommandType = CommandType.StoredProcedure;
            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");
            command.Parameters.Add(new SqlParameter("@UserID", UserID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring ", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
            parameterEventID.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameterEventID);
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));
            command.Parameters.Add(new SqlParameter("@EventSchedule", eventschedule));
            command.Parameters.Add(new SqlParameter("@IsPassNight", isPassNight));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int EventId = (int)parameterEventID.Value;
                return EventId;
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
        public static string UpdateActivity(int EventID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, Boolean IsRecurring, string RecurringType, int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit, string eventschedule, bool isPassNight)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UpdateEventActivity_SP", connection);
            command.CommandType = CommandType.StoredProcedure;
            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");
            command.Parameters.Add(new SqlParameter("@EventID", EventID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring ", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));
            command.Parameters.Add(new SqlParameter("@EventSchedule", eventschedule));
            command.Parameters.Add(new SqlParameter("@IsPassNight", isPassNight));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return "Updated";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
        public int EditEventsNew(int Event_ID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string Event_State, string address, string phone, string eventevents, string zipcode, bool Event_RSVP, bool IsRecurring, string RecurringType, int RelatedEventID, int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_EditEventDataNew", connection);
            command.CommandType = CommandType.StoredProcedure;
            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'");
            Event_Location = Event_Location.Replace("'", "\'");
            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", Event_State));
            command.Parameters.Add(new SqlParameter("@Event_Address", address));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", phone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            command.Parameters.Add(new SqlParameter("@RelatedEventID", RelatedEventID));
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return 1;
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
        public string EditEvents2(int Event_ID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string Event_State, string address, string phone, string eventevents, string zipcode, Boolean Event_RSVP, int EventLocationID, int EventCoupan, int EventPrivacy, int guestLimit)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_EditEventData2", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'");
            Event_Location = Event_Location.Replace("'", "\'");

            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", Event_State));
            command.Parameters.Add(new SqlParameter("@Event_Address", address));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", phone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            command.Parameters.Add(new SqlParameter("@GuestLimit", guestLimit));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return Event_Name + "  Updated Successfully";
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
        public string AddEvents2(int UserID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string state, string eventaddress, string eventphone, string eventevents, string zipcode, Boolean Event_RSVP, int EventLocationID, int EventCoupan, int EventPrivacy)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UserEvents_InsertEventData2", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'").Replace("\n", "<br>");


            command.Parameters.Add(new SqlParameter("@UserID", UserID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", state));
            command.Parameters.Add(new SqlParameter("@Event_Address", eventaddress));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", eventphone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));

            SqlParameter parameterEventID = new SqlParameter("@EventID", SqlDbType.Int, 4);
            parameterEventID.Direction = ParameterDirection.Output;
            command.Parameters.Add(parameterEventID);
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                int EventId = (int)parameterEventID.Value;
                return Event_Name + " added successfully";
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
        public string EditEvents2(int Event_ID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string Event_State, string address, string phone, string eventevents, string zipcode, Boolean Event_RSVP, int EventLocationID, int EventCoupan, int EventPrivacy)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_EditEventData2", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'");
            Event_Location = Event_Location.Replace("'", "\'");

            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", Event_State));
            command.Parameters.Add(new SqlParameter("@Event_Address", address));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", phone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@EventLocationID", EventLocationID));
            command.Parameters.Add(new SqlParameter("@EventCoupan", EventCoupan));
            command.Parameters.Add(new SqlParameter("@EventPrivacy", EventPrivacy));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return Event_Name + "  Updated Successfully";
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
        public string EditEvents3(int Event_ID, string Event_Name, string Event_StartDate, string Event_StartTime, string Event_EndDate, string Event_EndTime, string Event_Location, string Event_Desc, string Event_Cost, string Event_Organizer, string Event_State, string address, string phone, string eventevents, string zipcode, Boolean Event_RSVP, Boolean IsRecurring, string RecurringType, int RelatedEventID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_EditEventData3", connection);

            command.CommandType = CommandType.StoredProcedure;

            Event_Name = Event_Name.Replace("'", "\'");
            Event_Desc = Event_Desc.Replace("'", "\'");
            Event_Location = Event_Location.Replace("'", "\'");

            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));
            command.Parameters.Add(new SqlParameter("@Event_Name", Event_Name));
            command.Parameters.Add(new SqlParameter("@Event_StartDate", Event_StartDate));
            command.Parameters.Add(new SqlParameter("@Event_StartTime", Event_StartTime));
            command.Parameters.Add(new SqlParameter("@Event_EndTime", Event_EndTime));
            command.Parameters.Add(new SqlParameter("@Event_EndDate", Event_EndDate));
            command.Parameters.Add(new SqlParameter("@Event_Location", Event_Location));
            command.Parameters.Add(new SqlParameter("@Event_Description", Event_Desc));
            command.Parameters.Add(new SqlParameter("@Event_Cost", Event_Cost));
            command.Parameters.Add(new SqlParameter("@Event_Organizer", Event_Organizer));
            command.Parameters.Add(new SqlParameter("@Event_State", Event_State));
            command.Parameters.Add(new SqlParameter("@Event_Address", address));
            command.Parameters.Add(new SqlParameter("@Event_ContactNo", phone));
            command.Parameters.Add(new SqlParameter("@Event_Events", eventevents));
            command.Parameters.Add(new SqlParameter("@Event_ZipCode", zipcode));
            command.Parameters.Add(new SqlParameter("@Event_RSVP", Event_RSVP));
            command.Parameters.Add(new SqlParameter("@IsRecurring", IsRecurring));
            command.Parameters.Add(new SqlParameter("@RecurringType", RecurringType));
            command.Parameters.Add(new SqlParameter("@RelatedEventID", RelatedEventID));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return Event_Name + "  Updated Successfully";
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
        public static string DeleteRecurrEvents(int Event_ID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("Events_DeleteUserRecurrEvent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Event_ID", Event_ID));

            SqlParameter result = new SqlParameter("@Event_Name", SqlDbType.NVarChar, 300);
            result.Direction = ParameterDirection.Output;
            command.Parameters.Add(result);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return result.Value.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                connection.Close();
            }
        }
        public static DataTable getStateInfo()
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("getstate", connection);
            command.CommandType = CommandType.StoredProcedure;
            connection.Open();
            DataSet ds0 = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds0);
            connection.Close();
            DataTable dTable = ds0.Tables[0];
            return dTable;
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
        public static int DeleteSelectedEvents(string eventID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("DeleteSelectedEvent_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Event_ID", eventID));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return 1;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string DeleteEventsPhoto(int eventID, string eventPhotoName)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("DeleteEventsPhoto_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EventID", eventID));
            command.Parameters.Add(new SqlParameter("@EventPhotoName", eventPhotoName));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return "ok";
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
        public static DataTable GetEventInvites(int eventID)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("GetEventInvites_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EventID", eventID));
            try
            {
                connection.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds);
                connection.Close();
                DataTable dTable = ds.Tables[0];
                return dTable;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        public static string UpdateEventStatus(int eventID, Boolean eventStatus)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("UpdateEventStatus_sp", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@EventID", eventID));
            command.Parameters.Add(new SqlParameter("@EventStatus", eventStatus));
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return "ok";
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
	}
}

