using System;
using System.Data;
using Admin.Common;  
using System.Data.SqlClient;   

namespace Admin
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>
	public class Search
	{
        public DataTable SearchResult(string userType, string userID, string firstname, string lastname, string gender, string city, string state, string zip, string status, int age1, int age2, string birthdate, string faith, string email, string phoneNumber) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Person_Search1", connection);
			command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userType", userType));
            command.Parameters.Add(new SqlParameter("@userID", userID));
            command.Parameters.Add(new SqlParameter("@firstname", firstname));
            command.Parameters.Add(new SqlParameter("@lastname", lastname));
            command.Parameters.Add(new SqlParameter("@gender", gender));
            command.Parameters.Add(new SqlParameter("@city", city));
            command.Parameters.Add(new SqlParameter("@state", state));
            command.Parameters.Add(new SqlParameter("@zip", zip));
            command.Parameters.Add(new SqlParameter("@status", status));
            command.Parameters.Add(new SqlParameter("@age1", age1));
            command.Parameters.Add(new SqlParameter("@age2", age2));
            command.Parameters.Add(new SqlParameter("@birthdate", birthdate));
            command.Parameters.Add(new SqlParameter("@faith", faith));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@phoneNumber", phoneNumber));

			connection.Open();
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);
			return dset.Tables[0];
			
		}	
		public DataTable RestSearch()
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Rest_Details", connection);
			command.CommandType = CommandType.StoredProcedure;
			connection.Open();
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);
    		return  dset.Tables[0];
		
			
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
        public static DataTable GetAllSearchPerson(string screenName, string realName, string userEmail)
        {
     
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("GetAllSearchPerson_SP", connection);
            command.Parameters.Add("@ScreenName", screenName);
            command.Parameters.Add("@RealName",realName);
            command.Parameters.Add("@UserEmail",userEmail);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet dset = new DataSet();
                sda.Fill(dset);
                return dset.Tables[0];
                
            }
            finally
            {
                connection.Close();
            }		

        }
        public static DataTable GetAllSearchPersonNew(string screenName, string realName, string userEmail)
        {

            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("GetAllSearchPersonNew_SP", connection);
            command.Parameters.Add("@ScreenName", screenName);
            command.Parameters.Add("@RealName", realName);
            command.Parameters.Add("@UserEmail", userEmail);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataSet dset = new DataSet();
                sda.Fill(dset);
                return dset.Tables[0];

            }
            finally
            {
                connection.Close();
            }

        }
		public DataTable getMembersEmail1(int rest_id, string firstName,string lastname,string gender,string sexorient,string status,string birthdate,string ethnicity,string companyname,string city,string zip) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("MailingListSearchMembers", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@rest_id",rest_id ));
			command.Parameters.Add(new SqlParameter("@firstname",firstName)); 
			command.Parameters.Add(new SqlParameter("@lastname",lastname));
			command.Parameters.Add(new SqlParameter("@gender",gender));
			command.Parameters.Add(new SqlParameter("@orientation",sexorient));
			command.Parameters.Add(new SqlParameter("@status",status));
			command.Parameters.Add(new SqlParameter("@birthdate",birthdate ));
			command.Parameters.Add(new SqlParameter("@ethnicity",ethnicity ));
			command.Parameters.Add(new SqlParameter("@CompanyName",companyname ));
			command.Parameters.Add(new SqlParameter("@City",city));
			command.Parameters.Add(new SqlParameter("@Zip",zip ));
			
			connection.Open();
			
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);

			return dset.Tables[0]  ;
		}	
		        public DataTable getMembersEmail1(int rest_id, string firstName, string lastname, string gender, string status, string birthdate, string companyname, string city, string zip,string faith)
        {
            SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
            SqlCommand command = new SqlCommand("MailingListSearchMembersnew", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@rest_id", rest_id));
            command.Parameters.Add(new SqlParameter("@firstname", firstName));
            command.Parameters.Add(new SqlParameter("@lastname", lastname));
            command.Parameters.Add(new SqlParameter("@gender", gender));
            command.Parameters.Add(new SqlParameter("@status", status));
            command.Parameters.Add(new SqlParameter("@birthdate", birthdate));
            command.Parameters.Add(new SqlParameter("@CompanyName", companyname));
            command.Parameters.Add(new SqlParameter("@City", city));
            command.Parameters.Add(new SqlParameter("@Zip", zip));
            command.Parameters.Add(new SqlParameter("@faith", faith));

            connection.Open();

            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataSet dset = new DataSet();
            sda.Fill(dset);

            return dset.Tables[0];
        }	

		public DataTable RestUpdate(string stat)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Rest_Update", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@stat",stat));

			connection.Open();
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);
			return dset.Tables[0];			
		}

		public string insertdata(string screenname,string person_FirstName,string person_LastName,string Person_gender,string Person_sexorient,
			string Person_status,string Person_birthdate,string person_ethnicity,string person_email,string person_phone,string person_phone2,
			string person_EnableNewsLetter)
		{
			SqlConnection connection=new SqlConnection(Common_function.connect_string());
			SqlCommand command=new SqlCommand("Person_Notification",connection);
			command.CommandType=CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@person_screenName",screenname));
			command.Parameters.Add(new SqlParameter("@person_FirstName",person_FirstName));
			command.Parameters.Add(new SqlParameter("@person_LastName",person_LastName));
			command.Parameters.Add(new SqlParameter("@Person_gender",Person_gender));
			command.Parameters.Add(new SqlParameter("@Person_sexorient",Person_sexorient));
			command.Parameters.Add(new SqlParameter("@Person_status",Person_status));
			command.Parameters.Add(new SqlParameter("@Person_birthdate",Person_birthdate));
			command.Parameters.Add(new SqlParameter("@Person_ethnicity",person_ethnicity));
			command.Parameters.Add(new SqlParameter("@Person_email",person_email));
			command.Parameters.Add(new SqlParameter("@Person_phone",person_phone));
			command.Parameters.Add(new SqlParameter("@Person_phone2",person_phone2));
			command.Parameters.Add(new SqlParameter("@Person_EnableNewsLetter",person_EnableNewsLetter));

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close(); 
				return "Thank you for subscribing to our Mailing List";
				
			}
			catch(Exception ex)
			{
				return ex.Message.ToString()  ;
				 
			}
			finally
			{
				connection.Close(); 
			}

		}

		
		
	}
}
