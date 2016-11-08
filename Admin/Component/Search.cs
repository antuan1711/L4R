using System;
using System.Data;
using Admin.Common; 
using System.Data.SqlClient;   

namespace Admin.EMail
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>
	public class Search
	{
		public DataTable getMembersEmail(string screenName,string firstName,string lastname,string gender,string sexorient,string status,int age1,int age2,string birthdate,string relegion,string ethnicity,string height) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Member_SearchMember", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@screenname",screenName));
			command.Parameters.Add(new SqlParameter("@firstname",firstName)); 
			command.Parameters.Add(new SqlParameter("@lastname",lastname));
			command.Parameters.Add(new SqlParameter("@sexorient",sexorient));
			command.Parameters.Add(new SqlParameter("@status",status));
			command.Parameters.Add(new SqlParameter("@gender",gender));
			command.Parameters.Add(new SqlParameter("@age1",age1));
			command.Parameters.Add(new SqlParameter("@age2",age2));
			command.Parameters.Add(new SqlParameter("@birthdate",birthdate ));
			command.Parameters.Add(new SqlParameter("@relegion",relegion));
			command.Parameters.Add(new SqlParameter("@ethnicity",ethnicity ));
			command.Parameters.Add(new SqlParameter("@height",height ));
			connection.Open();
			
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);

			return dset.Tables[0]  ;
		}	

		public DataTable getRestaurantEmail(string screenName,string firstName,string lastname,string gender,string sexorient,string status,int age1,int age2,string birthdate,string relegion,string ethnicity,string height) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Member_SearchRestaurantMember", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@screenname",screenName));
			command.Parameters.Add(new SqlParameter("@firstname",firstName)); 
			command.Parameters.Add(new SqlParameter("@lastname",lastname));
			command.Parameters.Add(new SqlParameter("@sexorient",sexorient));
			command.Parameters.Add(new SqlParameter("@status",status));
			command.Parameters.Add(new SqlParameter("@gender",gender));
			command.Parameters.Add(new SqlParameter("@age1",age1));
			command.Parameters.Add(new SqlParameter("@age2",age2));
			command.Parameters.Add(new SqlParameter("@birthdate",birthdate ));
			command.Parameters.Add(new SqlParameter("@relegion",relegion));
			command.Parameters.Add(new SqlParameter("@ethnicity",ethnicity ));
			command.Parameters.Add(new SqlParameter("@height",height ));
			connection.Open();
			
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);

			return dset.Tables[0]  ;
		}	
		public DataTable getSiteUserEmail(string screenName,string firstName,string lastname,string gender,string sexorient,string status,int age1,int age2,string birthdate,string relegion,string ethnicity,string height) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Member_SearchRegisteredMember", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@screenname",screenName));
			command.Parameters.Add(new SqlParameter("@firstname",firstName)); 
			command.Parameters.Add(new SqlParameter("@lastname",lastname));
			command.Parameters.Add(new SqlParameter("@sexorient",sexorient));
			command.Parameters.Add(new SqlParameter("@status",status));
			command.Parameters.Add(new SqlParameter("@gender",gender));
			command.Parameters.Add(new SqlParameter("@age1",age1));
			command.Parameters.Add(new SqlParameter("@age2",age2));
			command.Parameters.Add(new SqlParameter("@birthdate",birthdate ));
			command.Parameters.Add(new SqlParameter("@relegion",relegion));
			command.Parameters.Add(new SqlParameter("@ethnicity",ethnicity ));
			command.Parameters.Add(new SqlParameter("@height",height ));
			connection.Open();
			
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);

			return dset.Tables[0]  ;
		}	






		public DataTable getMembersEmail(string screenName,string firstName,string lastname,string gender,string sexorient,int age1,int age2,string birthdate,string relegion,string ethnicity,string height) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Member_SearchMember", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@screenname",screenName));
			command.Parameters.Add(new SqlParameter("@firstname",firstName)); 
			command.Parameters.Add(new SqlParameter("@lastname",lastname));
			command.Parameters.Add(new SqlParameter("@sexorient",sexorient));
			command.Parameters.Add(new SqlParameter("@gender",gender));
			command.Parameters.Add(new SqlParameter("@age1",age1));
			command.Parameters.Add(new SqlParameter("@age2",age2));
			command.Parameters.Add(new SqlParameter("@birthdate",birthdate ));
			command.Parameters.Add(new SqlParameter("@relegion",relegion));
			command.Parameters.Add(new SqlParameter("@ethnicity",ethnicity ));
			command.Parameters.Add(new SqlParameter("@height",height ));
			connection.Open();
			
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);

			return dset.Tables[0]  ;
		}	

		public static DataTable getAdvertisersEmail()
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Email_AdvertisersSearch", connection);
			command.CommandType = CommandType.StoredProcedure;
			connection.Open();
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);      
			return dset.Tables[0]  ;
		}



		public static DataTable getRestaurantEmail(string RestName,string state,string city,string Staus) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Email_RestaurantSearch", connection);

			command.CommandType = CommandType.StoredProcedure;

			command.Parameters.Add(new SqlParameter("@Restname",RestName));
			command.Parameters.Add(new SqlParameter("@State",state)); 
			command.Parameters.Add(new SqlParameter("@City",city));
			command.Parameters.Add(new SqlParameter("@Status",Staus ));

			connection.Open();
			SqlDataAdapter sda = new SqlDataAdapter(command);
			DataSet dset = new DataSet(); 
			sda.Fill(dset);      

			return dset.Tables[0]  ;
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
	}
}
