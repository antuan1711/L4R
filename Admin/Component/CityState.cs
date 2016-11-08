using System;
using System.Configuration;
using System.Data; 
using System.Data.SqlClient;
using Admin.Common; 
using Microsoft.ApplicationBlocks.Data;  

namespace Admin.Component
{
	/// <summary>
	/// Summary description for CityState.
	/// </summary>
	public class CityState
	{
		#region Fields
		private decimal city_Id;
		private decimal state_Id;
		private string city_Name;
		private string vcErrorMsg;		
		private int intSuccess;
		#endregion		
		
		#region Properties
		/// <summary>
		/// Gets or sets the City_Id value.
		/// </summary>
		public decimal City_Id 
		{
			get { return city_Id; }
			set { city_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the State_Id value.
		/// </summary>
		public decimal State_Id 
		{
			get { return state_Id; }
			set { state_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_Name value.
		/// </summary>
		public string City_Name 
		{
			get { return city_Name; }
			set { city_Name = value; }
		}

		public string VcErrorMsg 
		{
			get { return vcErrorMsg; }
			set { vcErrorMsg = value; }
		}

		public int IntSuccess 
		{
			get { return intSuccess; }
			set { intSuccess = value; }
		}

		#endregion

		public static DataTable GetSelCity(int state_Id)
		{
			SqlConnection connection2 = new SqlConnection(LoveForRestaurants.BizLayer.ConfigHelper.ConnectionString);
			SqlCommand command2 = new SqlCommand("getSelectedCity", connection2);
			command2.CommandType = CommandType.StoredProcedure;
			command2.Parameters.Add(new SqlParameter("@state_Id",state_Id));
			connection2.Open();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter(command2);  
			da.Fill(ds); 
			connection2.Close();
			DataTable dTable=ds.Tables[0]; 
			return dTable;
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
			DataTable dTable=ds0.Tables[0]; 
			return dTable;
		}

		public int City_InfoInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(4);
 
				//Passing city_Id Value To The Parameter(0)
				objParameters.SetParameter("@city_Id",city_Id, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing state_Id Value To The Parameter(1)
				objParameters.SetParameter("@state_Id",state_Id, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing city_Name Value To The Parameter(2)
				objParameters.SetParameter("@city_Name",city_Name, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(3)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"City_InfoInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[3].Value != DBNull.Value)
				{
					intSuccess = Convert.ToInt32(arrParams[3].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}

		}


		public SqlDataReader City_Info_Select()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing city_Id Value To The Parameter(0)
				objParameters.SetParameter("@city_Id",city_Id, SqlDbType.Int,4,ParameterDirection.Input); 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"City_InfoSelect", arrParams); 
	
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}


		public int City_InfoDelete()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing city_Id Value To The Parameter(0)
				objParameters.SetParameter("@city_Id",city_Id, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(1)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"City_InfoDelete", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intSuccess = Convert.ToInt32(arrParams[1].Value.ToString());
				}
 
				//Return the Value
				return 0;
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return 1;
			}
		}

		public DataSet City_InfoSelectAll()
		{
			try
			{
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"City_InfoSelectAll");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}

        public DataSet AllCity_InfoSelectAll(string state, string city)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(2);

                //Passing city_Id Value To The Parameter(0)
                objParameters.SetParameter("@state", state, SqlDbType.VarChar, ParameterDirection.Input);

                //Passing intSuccess Value To The Parameter(1)
                objParameters.SetParameter("@city", city, SqlDbType.VarChar, ParameterDirection.Input);
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "City_AllInfoSelectAll", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }
        }

	}
}
