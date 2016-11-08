using System;
using System.Data;
using System.Data.SqlClient;
using Admin.Common; 

namespace Admin
{
	/// <summary>
	/// Summary description for sitemngt.
	/// </summary>
	public class sitemngt
	{
		public static string updatesitefees(string monfees,string qtryfees,string yrlyfees)
		{
			SqlConnection Con=new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand Com=new SqlCommand("sitemngtfees",Con);
			Com.CommandType=CommandType.StoredProcedure;
			Com.Parameters.Add(new SqlParameter("@sitemanagementfeesmon",monfees)); 
			Com.Parameters.Add(new SqlParameter("@sitemanagementfeesqtr",qtryfees)); 
			Com.Parameters.Add(new SqlParameter("@sitemanagementfeesyrl",yrlyfees)); 

			try
			{
				Con.Open();
				Com.ExecuteNonQuery();
				Con.Close();
				return "Successfully Updated";
			}

			catch(Exception ex)
			{
				return ex.Message.ToString();
			}

			finally
			{
				Con.Close();
			}
		}
		public static string getAlldetails(string period)
		{
			SqlConnection Con=new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand Com=new SqlCommand("Sitemngmt_getalldetails",Con);
			Com.CommandType=CommandType.StoredProcedure;
			Com.Parameters.Add(new SqlParameter("@period ",period)); 
			string result ="";
			try
			{
				Con.Open();
				SqlDataReader reader = Com.ExecuteReader(CommandBehavior.CloseConnection);      
				if (reader.Read()) 
				{
					result =  reader.GetValue(0).ToString();  

				}
				reader.Close(); 
				return result;
			}
			catch(Exception ex)
			{
				return ex.Message.ToString();
			}

			finally
			{
				Con.Close();
			}
		}

    }
}
