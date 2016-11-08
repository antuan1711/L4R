using System;
using System.Data; 
using System.Data.SqlClient;  
using Admin.Common; 

namespace Admin
{
	/// <summary>
	/// Summary description for GallaryDB.
	/// </summary>
	public class GallaryDB
	{
		public static string addPhotoDetails(int EventID,string filname,int filepos,string imagedate)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Gallerys_insertImageDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Gallary_EventID",EventID));
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

		public static SqlDataReader getPhotoDetails(int EventID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Gallerys_getPhotoDetails", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Event_ID",EventID));
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
		public static string CountPhoto(int EventID)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Gallerys_getCountImageforEvent", connection );
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@Gallary_EventID",EventID));
			string strResult ="";
			try
			{
				connection.Open();  
				SqlDataReader sda = command.ExecuteReader(CommandBehavior.CloseConnection);    
				if (sda.Read())
				{
				
					strResult =  sda.GetValue(0).ToString();
				}
				return strResult; 
			}
			catch(Exception ex)
			{
				return strResult = ex.Message.ToString();   
			}
		}


		public static DataTable GetEventDetails() 
		{
			SqlConnection Con = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand Com = new SqlCommand("Gallarys_GetEventDetails", Con);

			Com.CommandType = CommandType.StoredProcedure;
			Con.Open();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(Com);  
			da.Fill(ds); 
			Con.Close();
			DataTable dTable=ds.Tables[0]; 
			return dTable;
		}
		public static string DeleteImage(int Gallary_ID)
		{
			SqlConnection Connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);   
			SqlCommand Command = new SqlCommand("Gallerys_DeletePhotoDetails", Connection);
			Command.CommandType = CommandType.StoredProcedure;
			Command.Parameters.Add(new SqlParameter("@Gallary_ID",Gallary_ID));
			try
			{
				Connection.Open();
				Command.ExecuteNonQuery();
				Connection.Close();
				return "Image deleted successfully";
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
	}
}
