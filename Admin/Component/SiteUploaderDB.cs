using System;
using System.Data;
using System.Data.SqlClient;   

namespace Admin.Component
{
	/// <summary>
	/// Summary description for SiteUploaderDB.
	/// </summary>
	public class SiteUploaderDB
	{
		
		public static SqlDataReader getPhotoDetails(string filepos)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("siteContent_getsiteimgaeall", connection );
			command.CommandType = CommandType.StoredProcedure;
			
			command.Parameters.Add(new SqlParameter("@Site_Location",filepos));
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
		public static string insertphotoDetails(string filepos,string filename)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("SiteContent_insertSiteImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Site_Location",filepos));
			command.Parameters.Add(new SqlParameter("@Site_ImageName",filename));
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return filename + " Uploaded Successfully"; 
			}
			catch(Exception ex)
			{
				return ex.Message.ToString();  
		
			}
			
		}
		public static string updatephotoDetails(int siteid,string showHome)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("SiteContent_updateSiteImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Site_id",siteid));
			command.Parameters.Add(new SqlParameter("@Show_Home",showHome));
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return "Image Uploaded Successfully"; 
			}
			catch(Exception ex)
			{
				return ex.Message.ToString();  
		
			}
			
		}
		public static string deletePhotoDetails(int siteid)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("SiteContent_DeletePhotoDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Site_id",siteid));
			
			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();  
				return "Image Deleted Successfully"; 
			}
			catch(Exception ex)
			{
				return ex.Message.ToString();  
		
			}
			
		}
	}
}
