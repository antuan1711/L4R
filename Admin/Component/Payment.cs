using System;
using System.Data;
using System.Data.SqlClient;    

namespace Admin
{
	/// <summary>
	/// Summary description for Payment.
	/// </summary>
	/// 
	public class PaymentDiscDetails
	{
		public int Setupfees =0;
		public int Paidmonth =0;
		public int Freemonth =0;
		public int Discount =0;
			
    }

	public class Payment
	{
		public static void AddPaymentseat(string seat,string rate,string periodid,string type) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("Monthly_PaymentSeatdetils", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@seat",seat));
			command.Parameters.Add(new SqlParameter("@rate",rate ));
			command.Parameters.Add(new SqlParameter("@periodid",periodid));
			command.Parameters.Add(new SqlParameter("@type",type));

			try 
			{
				connection.Open();
				command.ExecuteNonQuery();
				connection.Close();
				return;
			}
			catch (Exception ex)
			{
				return;
			}
			finally
			{
				connection.Close();  
			}
		}
		//This is the function used to get the rate value by sending the seats and perioid

		public static string GetseatRate(string seat,string periodid,string type) 
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("get_PaymentRatedetils", connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@seat",seat));
			command.Parameters.Add(new SqlParameter("@periodid",periodid));
			command.Parameters.Add(new SqlParameter("@type",type));
			SqlParameter id = new SqlParameter("@rate", SqlDbType.NVarChar, 80);
			id.Direction = ParameterDirection.Output;
			command.Parameters.Add(id);
			string err="";

				try 
				{
					connection.Open();
					command.ExecuteNonQuery();
					string rate =id.Value.ToString();
					return rate;

				}
				catch (Exception ex)
				{
				
			
					err=ex.Message.ToString() ; 
					return err;
				}
			
				finally
				{
					connection.Close();  
				}
		}
		
		//This is the function which is used to get the setupfee,paidmonth and freemonth details
		public PaymentDiscDetails GetPaymentDiscDetails(string period,string type)
		{
			SqlConnection connection = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command = new SqlCommand("get_PaymentPeriodDetils", connection);
			
			// Mark the Command as a SPROC
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add(new SqlParameter("@period",period));
			command.Parameters.Add(new SqlParameter("@type",type));

			connection.Open();
			SqlDataReader Data = command.ExecuteReader(CommandBehavior.CloseConnection);
			if (Data.Read()  )
			{
				PaymentDiscDetails pDet = new PaymentDiscDetails();
				pDet.Setupfees =Int16.Parse(Data.GetValue(0).ToString()) ;
				pDet.Paidmonth =Int16.Parse(Data.GetValue(1).ToString()) ;
				pDet.Freemonth = Int16.Parse(Data.GetValue(2).ToString()) ;
				pDet.Discount=  Int16.Parse(Data.GetValue(3).ToString());				
				return pDet;
			}
			else
			{
				PaymentDiscDetails pDet = new PaymentDiscDetails();
				return pDet;
			}
		}

	
	}
}
