using System.Data;
using System.Data.SqlClient;
using System;
namespace Admin
{
	/// <summary>
	/// Summary description for Parameters.
	/// </summary>
	public class Parameters
	{
		public  SqlParameter[] paramArray;
		public int paramCnt;
		public Parameters()
		{
			
		}
		public Parameters(int ParamSize)
		{
			paramArray= new SqlParameter[ParamSize];
			paramCnt=0;
		}

		//Indexer 
		public SqlParameter this[int pos]
		{
			get
			{
				return paramArray[pos];
			}
		}

		public void SetParameter(string ParameterName, object ParamValue, SqlDbType Type, int Size, ParameterDirection  direction)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName=ParameterName;
			param.SqlDbType=Type;
			param.Size = Size;
			param.Value=ParamValue;  
			param.Direction=direction;
			paramArray[paramCnt]=param;
			paramCnt++;
		}
		public void SetParameter(string ParameterName, object ParamValue, SqlDbType Type, ParameterDirection direction)
		{
			SqlParameter param = new SqlParameter();
			param.ParameterName = ParameterName;
			param.SqlDbType = Type;            
			param.Value = ParamValue;
			param.Direction = direction;
			paramArray[paramCnt] = param;
			paramCnt++;
		}

		public SqlParameter[] ReturnParamArray()
		{
			return paramArray; 
		}
	}
}
