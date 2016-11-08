using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 
using Microsoft.ApplicationBlocks.Data;  
   
namespace Admin
{
	/// <summary>
	/// Summary description for clsLocations.
	/// </summary>
	public class clsLocations
	{
		public clsLocations()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For CatLocDiscounts Table--------------------------------
		#region Private CatLocDiscounts Members
		private int intDiscountID;
		private string vcDiscountFor;
		private decimal dcDiscount;
		#endregion
		
		#region Public CatLocDiscounts Properties
		/// <summary>
		/// Gets or sets the IntDiscountID value.
		/// </summary>
		public int IntDiscountID 
		{
			get { return intDiscountID; }
			set { intDiscountID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcDiscountFor value.
		/// </summary>
		public string VcDiscountFor 
		{
			get { return vcDiscountFor; }
			set { vcDiscountFor = value; }
		}
		
		/// <summary>
		/// Gets or sets the DcDiscount value.
		/// </summary>
		public decimal DcDiscount 
		{
			get { return dcDiscount; }
			set { dcDiscount = value; }
		}
		#endregion

		#region Public CatLocDiscounts Methods

		public int TBL_CatLocDiscountsSelectByID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intDiscountID Value To The Parameter(0)
				objParameters.SetParameter("@intDiscountID",intDiscountID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing dcDiscount Value To The Parameter(1)
				objParameters.SetParameter("@dcDiscount",dcDiscount, SqlDbType.Decimal,5,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatLocDiscountsSelectByID", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					dcDiscount = decimal.Parse(arrParams[1].Value.ToString());
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


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For RestServices Table-----------------------------------
		#region Private RestService Members		
		private string vcServiceName;
		#endregion

		#region Public  RestService Properties		
		
		/// <summary>
		/// Gets or sets the VcServiceName value.
		/// </summary>
		public string VcServiceName 
		{
			get { return vcServiceName; }
			set { vcServiceName = value; }
		}
		#endregion

		#region Public RestService Methods

		public DataSet TBL_RestServicesSelectAll()
		{
			try
			{
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestServicesSelectAll");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Locations Table--------------------------------------
		#region Private Location Members
		private int intLocId;
		private int intRestId;
		private string vcLoc_Name;
		private string vcOwner_Name;
		private string vcAddress;
		private string vcCity;
		private string vcZip;
		private string vcState;
		private string vcBuisnessTime;
		private int intParties;
		private string vcEmail;
		private string vcFax;
		private string vcTelephone;
		private string vcReferences;
		private string vcSpaceType;
		private string vcProvide;
		private string vcAtmosphere;
		private string vcParking;
		private string vcCapacity;
		private string vcPartySpace;
		private string vcOperationHours;
		private string vcOperationTimes;
		private string vcSpaceFee;
		private decimal smFoodFee;
		private decimal smAperitif;
		private decimal smBuffet;
		private decimal smFullService;
		private decimal smBeer_WineFee;
		private decimal smLiquorBarFee;
		private decimal smOtherFee;
		private string vcOtherFeeExplain;
		private decimal smRentalFee;
		private string vcLocDesc;
		private string vcHold;
		private string vcReserveTime;
		private string vcPhoto1;
		private string vcPhoto2;
		private string vcPhoto3;
		private string vcDiscount;
		private string vcErrorMsg = string.Empty;	
		private int intSuccess;
		#endregion

		#region Public  Location Properties
		/// <summary>
		/// Gets or sets the IntLocId value.
		/// </summary>
		public int IntLocId 
		{
			get { return intLocId; }
			set { intLocId = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntRestId value.
		/// </summary>
		public int IntRestId 
		{
			get { return intRestId; }
			set { intRestId = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLoc_Name value.
		/// </summary>
		public string VcLoc_Name 
		{
			get { return vcLoc_Name; }
			set { vcLoc_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcOwner_Name value.
		/// </summary>
		public string VcOwner_Name 
		{
			get { return vcOwner_Name; }
			set { vcOwner_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcAddress value.
		/// </summary>
		public string VcAddress 
		{
			get { return vcAddress; }
			set { vcAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcCity value.
		/// </summary>
		public string VcCity 
		{
			get { return vcCity; }
			set { vcCity = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcZip value.
		/// </summary>
		public string VcZip 
		{
			get { return vcZip; }
			set { vcZip = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcState value.
		/// </summary>
		public string VcState 
		{
			get { return vcState; }
			set { vcState = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcBuisnessTime value.
		/// </summary>
		public string VcBuisnessTime 
		{
			get { return vcBuisnessTime; }
			set { vcBuisnessTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntParties value.
		/// </summary>
		public int IntParties 
		{
			get { return intParties; }
			set { intParties = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcEmail value.
		/// </summary>
		public string VcEmail 
		{
			get { return vcEmail; }
			set { vcEmail = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcFax value.
		/// </summary>
		public string VcFax 
		{
			get { return vcFax; }
			set { vcFax = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcTelephone value.
		/// </summary>
		public string VcTelephone 
		{
			get { return vcTelephone; }
			set { vcTelephone = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcReferences value.
		/// </summary>
		public string VcReferences 
		{
			get { return vcReferences; }
			set { vcReferences = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcSpaceType value.
		/// </summary>
		public string VcSpaceType 
		{
			get { return vcSpaceType; }
			set { vcSpaceType = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcProvide value.
		/// </summary>
		public string VcProvide 
		{
			get { return vcProvide; }
			set { vcProvide = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcAtmosphere value.
		/// </summary>
		public string VcAtmosphere 
		{
			get { return vcAtmosphere; }
			set { vcAtmosphere = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcParking value.
		/// </summary>
		public string VcParking 
		{
			get { return vcParking; }
			set { vcParking = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcCapacity value.
		/// </summary>
		public string VcCapacity 
		{
			get { return vcCapacity; }
			set { vcCapacity = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPartySpace value.
		/// </summary>
		public string VcPartySpace 
		{
			get { return vcPartySpace; }
			set { vcPartySpace = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcOperationHours value.
		/// </summary>
		public string VcOperationHours 
		{
			get { return vcOperationHours; }
			set { vcOperationHours = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcOperationTimes value.
		/// </summary>
		public string VcOperationTimes 
		{
			get { return vcOperationTimes; }
			set { vcOperationTimes = value; }
		}

		/// <summary>
		/// Gets or sets the VcSpaceFee value.
		/// </summary>
		public string VcSpaceFee 
		{
			get { return vcSpaceFee; }
			set { vcSpaceFee = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmFoodFee value.
		/// </summary>
		public decimal SmFoodFee 
		{
			get { return smFoodFee; }
			set { smFoodFee = value; }
		}

		/// <summary>
		/// Gets or sets the SmAperitif value.
		/// </summary>
		public decimal SmAperitif 
		{
			get { return smAperitif; }
			set { smAperitif = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmBuffet value.
		/// </summary>
		public decimal SmBuffet 
		{
			get { return smBuffet; }
			set { smBuffet = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmFullService value.
		/// </summary>
		public decimal SmFullService 
		{
			get { return smFullService; }
			set { smFullService = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmBeer_WineFee value.
		/// </summary>
		public decimal SmBeer_WineFee 
		{
			get { return smBeer_WineFee; }
			set { smBeer_WineFee = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmLiquorBarFee value.
		/// </summary>
		public decimal SmLiquorBarFee 
		{
			get { return smLiquorBarFee; }
			set { smLiquorBarFee = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmOtherFee value.
		/// </summary>
		public decimal SmOtherFee 
		{
			get { return smOtherFee; }
			set { smOtherFee = value; }
		}

		/// <summary>
		/// Gets or sets the VcOtherFeeExplain value.
		/// </summary>
		public string VcOtherFeeExplain 
		{
			get { return vcOtherFeeExplain; }
			set { vcOtherFeeExplain = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmRentalFee value.
		/// </summary>
		public decimal SmRentalFee 
		{
			get { return smRentalFee; }
			set { smRentalFee = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLocDesc value.
		/// </summary>
		public string VcLocDesc 
		{
			get { return vcLocDesc; }
			set { vcLocDesc = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcHold value.
		/// </summary>
		public string VcHold 
		{
			get { return vcHold; }
			set { vcHold = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcReserveTime value.
		/// </summary>
		public string VcReserveTime 
		{
			get { return vcReserveTime; }
			set { vcReserveTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPhoto1 value.
		/// </summary>
		public string VcPhoto1 
		{
			get { return vcPhoto1; }
			set { vcPhoto1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPhoto2 value.
		/// </summary>
		public string VcPhoto2 
		{
			get { return vcPhoto2; }
			set { vcPhoto2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPhoto3 value.
		/// </summary>
		public string VcPhoto3 
		{
			get { return vcPhoto3; }
			set { vcPhoto3 = value; }
		}

		/// <summary>
		/// Gets or sets the VcPhoto3 value.
		/// </summary>
		public string VcDiscount 
		{
			get { return vcDiscount; }
			set { vcDiscount = value; }
		}

		/// <summary>
		/// Gets or sets the VcErrorMsg value.
		/// </summary>
		public string VcErrorMsg 
		{
			get { return vcErrorMsg; }
			set { vcErrorMsg = value; }
		}

		/// <summary>
		/// Gets or sets the IntSuccess value.
		/// </summary>
		public int IntSuccess 
		{
			get { return intSuccess; }
			set { intSuccess = value; }
		}
		#endregion

		#region Public Location Methods

		public SqlDataReader RestaurantLocations_GetLocationsDetails()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestId Value To The Parameter(0)
				objParameters.SetParameter("@intRestId",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
  
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"RestaurantLocations_GetLocationsDetails", arrParams);
 	
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}


		public int TBL_LocationsInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(39);
 
				//Passing intRestId Value To The Parameter(0)
				objParameters.SetParameter("@intRestId",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcLoc_Name Value To The Parameter(1)
				objParameters.SetParameter("@vcLoc_Name",vcLoc_Name, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcOwner_Name Value To The Parameter(2)
				objParameters.SetParameter("@vcOwner_Name",vcOwner_Name, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcAddress Value To The Parameter(3)
				objParameters.SetParameter("@vcAddress",vcAddress, SqlDbType.VarChar,200,ParameterDirection.Input);
 
				//Passing vcCity Value To The Parameter(4)
				objParameters.SetParameter("@vcCity",vcCity, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcZip Value To The Parameter(5)
				objParameters.SetParameter("@vcZip",vcZip, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcState Value To The Parameter(6)
				objParameters.SetParameter("@vcState",vcState, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcBuisnessTime Value To The Parameter(7)
				objParameters.SetParameter("@vcBuisnessTime",vcBuisnessTime, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing intParties Value To The Parameter(8)
				objParameters.SetParameter("@intParties",intParties, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcEmail Value To The Parameter(9)
				objParameters.SetParameter("@vcEmail",vcEmail, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcFax Value To The Parameter(10)
				objParameters.SetParameter("@vcFax",vcFax, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcTelephone Value To The Parameter(11)
				objParameters.SetParameter("@vcTelephone",vcTelephone, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcReferences Value To The Parameter(12)
				objParameters.SetParameter("@vcReferences",vcReferences, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcSpaceType Value To The Parameter(13)
				objParameters.SetParameter("@vcSpaceType",vcSpaceType, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcProvide Value To The Parameter(14)
				objParameters.SetParameter("@vcProvide",vcProvide, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcAtmosphere Value To The Parameter(15)
				objParameters.SetParameter("@vcAtmosphere",vcAtmosphere, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcParking Value To The Parameter(16)
				objParameters.SetParameter("@vcParking",vcParking, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcCapacity Value To The Parameter(17)
				objParameters.SetParameter("@vcCapacity",vcCapacity, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcPartySpace Value To The Parameter(18)
				objParameters.SetParameter("@vcPartySpace",vcPartySpace, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcOperationHours Value To The Parameter(19)
				objParameters.SetParameter("@vcOperationHours",vcOperationHours, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcOperationTimes Value To The Parameter(20)
				objParameters.SetParameter("@vcOperationTimes",vcOperationTimes, SqlDbType.VarChar,500,ParameterDirection.Input);
 
				//Passing vcSpaceFee Value To The Parameter(21)
				objParameters.SetParameter("@vcSpaceFee",vcSpaceFee, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing smFoodFee Value To The Parameter(22)
				objParameters.SetParameter("@smFoodFee",smFoodFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smAperitif Value To The Parameter(23)
				objParameters.SetParameter("@smAperitif",smAperitif, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smBuffet Value To The Parameter(24)
				objParameters.SetParameter("@smBuffet",smBuffet, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smFullService Value To The Parameter(25)
				objParameters.SetParameter("@smFullService",smFullService, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smBeer_WineFee Value To The Parameter(26)
				objParameters.SetParameter("@smBeer_WineFee",smBeer_WineFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smLiquorBarFee Value To The Parameter(27)
				objParameters.SetParameter("@smLiquorBarFee",smLiquorBarFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smOtherFee Value To The Parameter(28)
				objParameters.SetParameter("@smOtherFee",smOtherFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing vcOtherFeeExplain Value To The Parameter(29)
				objParameters.SetParameter("@vcOtherFeeExplain",vcOtherFeeExplain, SqlDbType.VarChar,150,ParameterDirection.Input);
 
				//Passing smRentalFee Value To The Parameter(30)
				objParameters.SetParameter("@smRentalFee",smRentalFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing vcLocDesc Value To The Parameter(31)
				objParameters.SetParameter("@vcLocDesc",vcLocDesc, SqlDbType.VarChar,250,ParameterDirection.Input);
 
				//Passing vcHold Value To The Parameter(32)
				objParameters.SetParameter("@vcHold",vcHold, SqlDbType.VarChar,250,ParameterDirection.Input);
 
				//Passing vcReserveTime Value To The Parameter(33)
				objParameters.SetParameter("@vcReserveTime",vcReserveTime, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcPhoto1 Value To The Parameter(34)
				objParameters.SetParameter("@vcPhoto1",vcPhoto1, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPhoto2 Value To The Parameter(35)
				objParameters.SetParameter("@vcPhoto2",vcPhoto2, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPhoto3 Value To The Parameter(36)
				objParameters.SetParameter("@vcPhoto3",vcPhoto3, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing vcPhoto3 Value To The Parameter(37)
				objParameters.SetParameter("@vcDiscount",vcDiscount, SqlDbType.VarChar,150,ParameterDirection.Input);

				//Passing intSuccess Value To The Parameter(38)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocationsInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[38].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[38].Value.ToString());
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


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Location Orders Table--------------------------------

		#region Private LocationOrders Members
		private int intOrderID;
		private int intRestID;
		private int intRUserID;
		private bool bSpace;
		private bool bFood;		
		private bool bLiquorBar;
		private int intGuests;
		private string vcFoodType;
		private decimal smSpaceFee;	
		private decimal smLiquorFee;
		private string vcDayTime;
		private DateTime dtOrderDate;
		private DateTime dtStartDate;
		private DateTime dtEndDate;
		private decimal smDiscount;
		private decimal smTotalAmount;
		private decimal dcPointsRedeemed;
		private decimal smAmountPaid;
		private DateTime dtDate;		
		#endregion

		#region Public  LocationOrders Properties
		/// <summary>
		/// Gets or sets the IntOrderID value.
		/// </summary>
		public int IntOrderID 
		{
			get { return intOrderID; }
			set { intOrderID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntRestID value.
		/// </summary>
		public int IntRestID 
		{
			get { return intRestID; }
			set { intRestID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntRUserID value.
		/// </summary>
		public int IntRUserID 
		{
			get { return intRUserID; }
			set { intRUserID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BSpace value.
		/// </summary>
		public bool BSpace 
		{
			get { return bSpace; }
			set { bSpace = value; }
		}
		
		/// <summary>
		/// Gets or sets the BFood value.
		/// </summary>
		public bool BFood 
		{
			get { return bFood; }
			set { bFood = value; }
		}
			
		/// <summary>
		/// Gets or sets the BLiquorBar value.
		/// </summary>
		public bool BLiquorBar 
		{
			get { return bLiquorBar; }
			set { bLiquorBar = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntGuests value.
		/// </summary>
		public int IntGuests 
		{
			get { return intGuests; }
			set { intGuests = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcFoodType value.
		/// </summary>
		public string VcFoodType 
		{
			get { return vcFoodType; }
			set { vcFoodType = value; }
		}
		

		/// <summary>
		/// Gets or sets the SmSpaceFee value.
		/// </summary>
		public decimal SmSpaceFee 
		{
			get { return smSpaceFee; }
			set { smSpaceFee = value; }
		}				
		
		/// <summary>
		/// Gets or sets the SmLiquorFee value.
		/// </summary>
		public decimal SmLiquorFee 
		{
			get { return smLiquorFee; }
			set { smLiquorFee = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcDayTime value.
		/// </summary>
		public string VcDayTime 
		{
			get { return vcDayTime; }
			set { vcDayTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the DtOrderDate value.
		/// </summary>
		public DateTime DtOrderDate 
		{
			get { return dtOrderDate; }
			set { dtOrderDate = value; }
		}
        
		/// <summary>
		/// Gets or sets the DtStartDate value.
		/// </summary>
		public DateTime DtStartDate 
		{
			get { return dtStartDate; }
			set { dtStartDate = value; }
		}

		/// <summary>
		/// Gets or sets the DtEndDate value.
		/// </summary>
		public DateTime DtEndDate 
		{
			get { return dtEndDate; }
			set { dtEndDate = value; }
		}

		/// <summary>
		/// Gets or sets the SmDiscount value.
		/// </summary>
		public decimal SmDiscount 
		{
			get { return smDiscount; }
			set { smDiscount = value; }
		}

		/// <summary>
		/// Gets or sets the SmTotalAmount value.
		/// </summary>
		public decimal SmTotalAmount 
		{
			get { return smTotalAmount; }
			set { smTotalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the DcPointsRedeemed value.
		/// </summary>
		public decimal DcPointsRedeemed 
		{
			get { return dcPointsRedeemed; }
			set { dcPointsRedeemed = value; }
		}

		/// <summary>
		/// Gets or sets the SmAmountPaid value.
		/// </summary>
		public decimal SmAmountPaid 
		{
			get { return smAmountPaid; }
			set { smAmountPaid = value; }
		}
		
		/// <summary>
		/// Gets or sets the DtDate value.
		/// </summary>
		public DateTime DtDate 
		{
			get { return dtDate; }
			set { dtDate = value; }
		}		
		#endregion

		#region Public LocationOrders Methods
		
		public DataSet TBL_LocOrdersCheckAvailablity()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing dtOrderDate Value To The Parameter(0)
				objParameters.SetParameter("@dtOrderDate",dtOrderDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(1)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersCheckAvailablity", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_LocOrdersInsert()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(22);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRUserID Value To The Parameter(1)
				objParameters.SetParameter("@intRUserID",intRUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing bSpace Value To The Parameter(2)
				objParameters.SetParameter("@bSpace",bSpace, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bFood Value To The Parameter(3)
				objParameters.SetParameter("@bFood",bFood, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bBeerWine Value To The Parameter(4)
				objParameters.SetParameter("@bBeerWine",bBeerWine, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bLiquorBar Value To The Parameter(5)
				objParameters.SetParameter("@bLiquorBar",bLiquorBar, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing intGuests Value To The Parameter(6)
				objParameters.SetParameter("@intGuests",intGuests, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcFoodType Value To The Parameter(7)
				objParameters.SetParameter("@vcFoodType",vcFoodType, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing smSpaceFee Value To The Parameter(8)
				objParameters.SetParameter("@smSpaceFee",smSpaceFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smFoodFee Value To The Parameter(9)
				objParameters.SetParameter("@smFoodFee",smFoodFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smBeerWine Value To The Parameter(10)
				objParameters.SetParameter("@smBeerWine",smBeer_WineFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smLiquorFee Value To The Parameter(11)
				objParameters.SetParameter("@smLiquorFee",smLiquorFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing vcDayTime Value To The Parameter(12)
				objParameters.SetParameter("@vcDayTime",vcDayTime, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing dtOrderDate Value To The Parameter(13)
				objParameters.SetParameter("@dtOrderDate",dtOrderDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing smDiscount Value To The Parameter(14)
				objParameters.SetParameter("@smDiscount",smDiscount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smTotalAmount Value To The Parameter(15)
				objParameters.SetParameter("@smTotalAmount",smTotalAmount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dcPointsRedeemed Value To The Parameter(16)
				objParameters.SetParameter("@dcPointsRedeemed",dcPointsRedeemed, SqlDbType.Decimal,9,ParameterDirection.Input);
 
				//Passing smAmountPaid Value To The Parameter(17)
				objParameters.SetParameter("@smAmountPaid",smAmountPaid, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dtDate Value To The Parameter(18)
				objParameters.SetParameter("@dtDate",dtDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intStatus Value To The Parameter(19)
				objParameters.SetParameter("@intStatus",intStatus, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intOrderID Value To The Parameter(20)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intSuccess Value To The Parameter(21)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersInsert", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[20].Value != DBNull.Value)
				{
					intOrderID = int.Parse(arrParams[20].Value.ToString());
				}
				//Retrieve Output Variables
				if (arrParams[21].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[21].Value.ToString());
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


		public DataSet TBL_LocOrdersSelectByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersSelectByRestID", arrParams);
 			
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public SqlDataReader TBL_LocOrdersSelectByOrderID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersSelectByOrderID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_RestUsersLocOrderHistory()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRUserID Value To The Parameter(0)
				objParameters.SetParameter("@intRUserID",intRUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersLocOrderHistory", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_LocOrdersUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(22);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRUserID Value To The Parameter(1)
				objParameters.SetParameter("@intRUserID",intRUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing bSpace Value To The Parameter(2)
				objParameters.SetParameter("@bSpace",bSpace, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bFood Value To The Parameter(3)
				objParameters.SetParameter("@bFood",bFood, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bBeerWine Value To The Parameter(4)
				objParameters.SetParameter("@bBeerWine",bBeerWine, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bLiquorBar Value To The Parameter(5)
				objParameters.SetParameter("@bLiquorBar",bLiquorBar, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing intGuests Value To The Parameter(6)
				objParameters.SetParameter("@intGuests",intGuests, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcFoodType Value To The Parameter(7)
				objParameters.SetParameter("@vcFoodType",vcFoodType, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing smSpaceFee Value To The Parameter(8)
				objParameters.SetParameter("@smSpaceFee",smSpaceFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smFoodFee Value To The Parameter(9)
				objParameters.SetParameter("@smFoodFee",smFoodFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smBeerWine Value To The Parameter(10)
				objParameters.SetParameter("@smBeerWine",smBeer_WineFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smLiquorFee Value To The Parameter(11)
				objParameters.SetParameter("@smLiquorFee",smLiquorFee, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing vcDayTime Value To The Parameter(12)
				objParameters.SetParameter("@vcDayTime",vcDayTime, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing dtOrderDate Value To The Parameter(13)
				objParameters.SetParameter("@dtOrderDate",dtOrderDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing smDiscount Value To The Parameter(14)
				objParameters.SetParameter("@smDiscount",smDiscount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smTotalAmount Value To The Parameter(15)
				objParameters.SetParameter("@smTotalAmount",smTotalAmount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dcPointsRedeemed Value To The Parameter(16)
				objParameters.SetParameter("@dcPointsRedeemed",dcPointsRedeemed, SqlDbType.Decimal,9,ParameterDirection.Input);
 
				//Passing smAmountPaid Value To The Parameter(17)
				objParameters.SetParameter("@smAmountPaid",smAmountPaid, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dtDate Value To The Parameter(18)
				objParameters.SetParameter("@dtDate",dtDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intStatus Value To The Parameter(19)
				objParameters.SetParameter("@intStatus",intStatus, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intOrderID Value To The Parameter(20)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(21)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[21].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[21].Value.ToString());
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


		public int TBL_LocOrdersDeleteByOrderID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(1)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersDeleteByOrderID", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[1].Value.ToString());
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


		public DataSet TBL_LocOrdersSearchByDate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing dtStartDate Value To The Parameter(0)
				objParameters.SetParameter("@dtStartDate",dtStartDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing dtEndDate Value To The Parameter(1)
				objParameters.SetParameter("@dtEndDate",dtEndDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(2)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_LocOrdersSearchByDate", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}
		#endregion
        

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Catering Table---------------------------------------
		#region Private Catering Members
		private int intCaterID;		
		private string vcCusineType;
		private int intOrdPeriod;
		private string vcOrdPeriod;
		private bool bKosher;
		private string vcKosherType;
		private bool bKosherStyle;
		private bool bOrganic;
		private bool bMSG;
		private bool bLowSodium;
		private bool bLowFat;
		private bool bPickUpOnly;
		private bool bDelivery;
		private bool bDeliverySetup;
		private bool bFullService;
		private bool bBeerWine;
		private bool bFullLiquor;
		private int intFullTrayServes;
		private int intHalfTrayServes;
		private string txtComments;
		#endregion

		#region Public Catering Properties
		/// <summary>
		/// Gets or sets the IntCaterID value.
		/// </summary>
		public int IntCaterID 
		{
			get { return intCaterID; }
			set { intCaterID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcCusineType value.
		/// </summary>
		public string VcCusineType 
		{
			get { return vcCusineType; }
			set { vcCusineType = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntOrdPeriod value.
		/// </summary>
		public int IntOrdPeriod 
		{
			get { return intOrdPeriod; }
			set { intOrdPeriod = value; }
		}

		/// <summary>
		/// Gets or sets the VcOrdPeriod value.
		/// </summary>
		public string VcOrdPeriod 
		{
			get { return vcOrdPeriod; }
			set { vcOrdPeriod = value; }
		}
		
		/// <summary>
		/// Gets or sets the BKosher value.
		/// </summary>
		public bool BKosher 
		{
			get { return bKosher; }
			set { bKosher = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcKosherType value.
		/// </summary>
		public string VcKosherType 
		{
			get { return vcKosherType; }
			set { vcKosherType = value; }
		}
		
		/// <summary>
		/// Gets or sets the BKosherStyle value.
		/// </summary>
		public bool BKosherStyle 
		{
			get { return bKosherStyle; }
			set { bKosherStyle = value; }
		}
		
		/// <summary>
		/// Gets or sets the BOrganic value.
		/// </summary>
		public bool BOrganic 
		{
			get { return bOrganic; }
			set { bOrganic = value; }
		}
		
		/// <summary>
		/// Gets or sets the BMSG value.
		/// </summary>
		public bool BMSG 
		{
			get { return bMSG; }
			set { bMSG = value; }
		}
		
		/// <summary>
		/// Gets or sets the BLowSodium value.
		/// </summary>
		public bool BLowSodium 
		{
			get { return bLowSodium; }
			set { bLowSodium = value; }
		}
		
		/// <summary>
		/// Gets or sets the BLowFat value.
		/// </summary>
		public bool BLowFat 
		{
			get { return bLowFat; }
			set { bLowFat = value; }
		}
		
		/// <summary>
		/// Gets or sets the BPickUpOnly value.
		/// </summary>
		public bool BPickUpOnly 
		{
			get { return bPickUpOnly; }
			set { bPickUpOnly = value; }
		}
		
		/// <summary>
		/// Gets or sets the BDelivery value.
		/// </summary>
		public bool BDelivery 
		{
			get { return bDelivery; }
			set { bDelivery = value; }
		}
		
		/// <summary>
		/// Gets or sets the BDeliverySetup value.
		/// </summary>
		public bool BDeliverySetup 
		{
			get { return bDeliverySetup; }
			set { bDeliverySetup = value; }
		}
		
		/// <summary>
		/// Gets or sets the BFullService value.
		/// </summary>
		public bool BFullService 
		{
			get { return bFullService; }
			set { bFullService = value; }
		}
		
		/// <summary>
		/// Gets or sets the BBeerWine value.
		/// </summary>
		public bool BBeerWine 
		{
			get { return bBeerWine; }
			set { bBeerWine = value; }
		}
		
		/// <summary>
		/// Gets or sets the BFullLiquor value.
		/// </summary>
		public bool BFullLiquor 
		{
			get { return bFullLiquor; }
			set { bFullLiquor = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntFullTrayServes value.
		/// </summary>
		public int IntFullTrayServes 
		{
			get { return intFullTrayServes; }
			set { intFullTrayServes = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntHalfTrayServes value.
		/// </summary>
		public int IntHalfTrayServes 
		{
			get { return intHalfTrayServes; }
			set { intHalfTrayServes = value; }
		}
		
		/// <summary>
		/// Gets or sets the TxtComments value.
		/// </summary>
		public string TxtComments 
		{
			get { return txtComments; }
			set { txtComments = value; }
		}
		#endregion

		#region Public Catering Methods

		public int TBL_CateringsInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(22);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcCusineType Value To The Parameter(1)
				objParameters.SetParameter("@vcCusineType",vcCusineType, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing intOrdPeriod Value To The Parameter(2)
				objParameters.SetParameter("@intOrdPeriod",intOrdPeriod, SqlDbType.Int,4,ParameterDirection.Input);

				//Passing vcOrdPeriod Value To The Parameter(3)
				objParameters.SetParameter("@vcOrdPeriod",vcOrdPeriod, SqlDbType.VarChar,10,ParameterDirection.Input); 
 
				//Passing bKosher Value To The Parameter(4)
				objParameters.SetParameter("@bKosher",bKosher, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing vcKosherType Value To The Parameter(5)
				objParameters.SetParameter("@vcKosherType",vcKosherType, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing bKosherStyle Value To The Parameter(6)
				objParameters.SetParameter("@bKosherStyle",bKosherStyle, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bOrganic Value To The Parameter(7)
				objParameters.SetParameter("@bOrganic",bOrganic, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bMSG Value To The Parameter(8)
				objParameters.SetParameter("@bMSG",bMSG, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bLowSodium Value To The Parameter(9)
				objParameters.SetParameter("@bLowSodium",bLowSodium, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bLowFat Value To The Parameter(10)
				objParameters.SetParameter("@bLowFat",bLowFat, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bPickUpOnly Value To The Parameter(11)
				objParameters.SetParameter("@bPickUpOnly",bPickUpOnly, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bDelivery Value To The Parameter(12)
				objParameters.SetParameter("@bDelivery",bDelivery, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bDeliverySetup Value To The Parameter(13)
				objParameters.SetParameter("@bDeliverySetup",bDeliverySetup, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bFullService Value To The Parameter(14)
				objParameters.SetParameter("@bFullService",bFullService, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bBeerWine Value To The Parameter(15)
				objParameters.SetParameter("@bBeerWine",bBeerWine, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bFullLiquor Value To The Parameter(16)
				objParameters.SetParameter("@bFullLiquor",bFullLiquor, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing intFullTrayServes Value To The Parameter(17)
				objParameters.SetParameter("@intFullTrayServes",intFullTrayServes, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intHalfTrayServes Value To The Parameter(18)
				objParameters.SetParameter("@intHalfTrayServes",intHalfTrayServes, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing txtComments Value To The Parameter(19)
				objParameters.SetParameter("@txtComments",txtComments, SqlDbType.Text,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(20)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);

				//Passing intCaterID Value To The Parameter(21)
				objParameters.SetParameter("@intCaterID",intCaterID, SqlDbType.Int,4,ParameterDirection.Output);
  
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CateringsInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[20].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[20].Value.ToString());
				}
				//Retrieve Output Variables
				if (arrParams[21].Value != DBNull.Value)
				{
					intCaterID = int.Parse(arrParams[21].Value.ToString());
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


		public SqlDataReader TBL_CateringsSelectByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CateringsSelectByRestID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Catering Orders Table--------------------------------

		#region Private CateringOrders Members
		private string vcOrderType;		
		private string vcCateringTime;
		private decimal smOrderAmount;				
		#endregion

		#region Public CateringOrders Properties
		/// <summary>
		/// Gets or sets the VcOrderType value.
		/// </summary>
		public string VcOrderType 
		{
			get { return vcOrderType; }
			set { vcOrderType = value; }
		}
					
		/// <summary>
		/// Gets or sets the VcCateringTime value.
		/// </summary>
		public string VcCateringTime 
		{
			get { return vcCateringTime; }
			set { vcCateringTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmOrderAmount value.
		/// </summary>
		public decimal SmOrderAmount 
		{
			get { return smOrderAmount; }
			set { smOrderAmount = value; }
		}		
		#endregion

		#region Public CateringOrders Methods

		public int TBL_CatOrdersInsert()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(14);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRUserID Value To The Parameter(1)
				objParameters.SetParameter("@intRUserID",intRUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcOrderType Value To The Parameter(2)
				objParameters.SetParameter("@vcOrderType",vcOrderType, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing intGuests Value To The Parameter(3)
				objParameters.SetParameter("@intGuests",intGuests, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing dtOrderDate Value To The Parameter(4)
				objParameters.SetParameter("@dtOrderDate",dtOrderDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing vcCateringTime Value To The Parameter(5)
				objParameters.SetParameter("@vcCateringTime",vcCateringTime, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing smDiscount Value To The Parameter(6)
				objParameters.SetParameter("@smDiscount",smDiscount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smOrderAmount Value To The Parameter(7)
				objParameters.SetParameter("@smOrderAmount",smOrderAmount, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dcPointsRedeemed Value To The Parameter(8)
				objParameters.SetParameter("@dcPointsRedeemed",dcPointsRedeemed, SqlDbType.Decimal,9,ParameterDirection.Input);
 
				//Passing smAmountPaid Value To The Parameter(9)
				objParameters.SetParameter("@smAmountPaid",smAmountPaid, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing dtDate Value To The Parameter(10)
				objParameters.SetParameter("@dtDate",dtDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intStatus Value To The Parameter(11)
				objParameters.SetParameter("@intStatus",intStatus, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intOrderID Value To The Parameter(12)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intSuccess Value To The Parameter(13)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersInsert", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[12].Value != DBNull.Value)
				{
					intOrderID = int.Parse(arrParams[12].Value.ToString());
				}

				//Retrieve Output Variables
				if (arrParams[13].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[13].Value.ToString());
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


		public DataSet TBL_CatOrdersSelectByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersSelectByRestID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public SqlDataReader TBL_CatOrdersSelectByOrderID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersSelectByOrderID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_CatOrdersDeleteByOrderID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(1)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersDeleteByOrderID", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[1].Value.ToString());
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


		public DataSet TBL_RestUsersCatOrderHistory()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRUserID Value To The Parameter(0)
				objParameters.SetParameter("@intRUserID",intRUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersCatOrderHistory", arrParams);
 			
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}

		public DataSet TBL_CatOrdersSearchByDate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing dtStartDate Value To The Parameter(0)
				objParameters.SetParameter("@dtStartDate",dtStartDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing dtEndDate Value To The Parameter(1)
				objParameters.SetParameter("@dtEndDate",dtEndDate, SqlDbType.DateTime,8,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(2)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersSearchByDate", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}
		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Catering OrderDetails Table--------------------------

		#region Private CateringOrderDetails Members
		private int intOrderDetailsID;		
		private string vcDish;
		private bool bFullTray;
		private bool bHalfTray;
		private bool bPerPerson;
		private int intFullTrays;
		private int intHalfTrays;
		private int intNoPeople;
		#endregion

		#region Public CateringOrderDetails Properties
		/// <summary>
		/// Gets or sets the IntOrderDetailsID value.
		/// </summary>
		public int IntOrderDetailsID 
		{
			get { return intOrderDetailsID; }
			set { intOrderDetailsID = value; }
		}		
		
		/// <summary>
		/// Gets or sets the VcDish value.
		/// </summary>
		public string VcDish 
		{
			get { return vcDish; }
			set { vcDish = value; }
		}
		
		/// <summary>
		/// Gets or sets the BFullTray value.
		/// </summary>
		public bool BFullTray 
		{
			get { return bFullTray; }
			set { bFullTray = value; }
		}
		
		/// <summary>
		/// Gets or sets the BHalfTray value.
		/// </summary>
		public bool BHalfTray 
		{
			get { return bHalfTray; }
			set { bHalfTray = value; }
		}
		
		/// <summary>
		/// Gets or sets the BPerPerson value.
		/// </summary>
		public bool BPerPerson 
		{
			get { return bPerPerson; }
			set { bPerPerson = value; }
		}

		/// <summary>
		/// Gets or sets the IntFullTrays value.
		/// </summary>
		public int IntFullTrays 
		{
			get { return intFullTrays; }
			set { intFullTrays = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntHalfTrays value.
		/// </summary>
		public int IntHalfTrays 
		{
			get { return intHalfTrays; }
			set { intHalfTrays = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntNoPeople value.
		/// </summary>
		public int IntNoPeople 
		{
			get { return intNoPeople; }
			set { intNoPeople = value; }
		}
		#endregion

		#region Public CateringOrderDetails Methods

		public int TBL_CatOrderDetailsInsert()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(10);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcDish Value To The Parameter(1)
				objParameters.SetParameter("@vcDish",vcDish, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing bFullTray Value To The Parameter(2)
				objParameters.SetParameter("@bFullTray",bFullTray, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bHalfTray Value To The Parameter(3)
				objParameters.SetParameter("@bHalfTray",bHalfTray, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing bPerPerson Value To The Parameter(4)
				objParameters.SetParameter("@bPerPerson",bPerPerson, SqlDbType.Bit,1,ParameterDirection.Input);
 
				//Passing intFullTrays Value To The Parameter(5)
				objParameters.SetParameter("@intFullTrays",intFullTrays, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intHalfTrays Value To The Parameter(6)
				objParameters.SetParameter("@intHalfTrays",intHalfTrays, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intNoPeople Value To The Parameter(7)
				objParameters.SetParameter("@intNoPeople",intNoPeople, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intOrderDetailsID Value To The Parameter(8)
				objParameters.SetParameter("@intOrderDetailsID",intOrderDetailsID, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intSuccess Value To The Parameter(9)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrderDetailsInsert", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[8].Value != DBNull.Value)
				{
					intOrderDetailsID = int.Parse(arrParams[8].Value.ToString());
				}
				//Retrieve Output Variables
				if (arrParams[9].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[9].Value.ToString());
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


		public SqlDataReader TBL_CatOrdersDetailsSelectByOrderID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersDetailsSelectByOrderID", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_CatOrdersDetailsSelectByOrderIDDataSet()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intOrderID Value To The Parameter(0)
				objParameters.SetParameter("@intOrderID",intOrderID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_CatOrdersDetailsSelectByOrderID", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Dishes Table-----------------------------------------
		#region Private Dishes Members

		private int intDishID;
		private int intServiceID;
		private string vcName;

		#endregion

		#region Public Dishes Properties

		/// <summary>
		/// Gets or sets the IntDishID value.
		/// </summary>
		public int IntDishID 
		{
			get { return intDishID; }
			set { intDishID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntServiceID value.
		/// </summary>
		public int IntServiceID 
		{
			get { return intServiceID; }
			set { intServiceID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcName value.
		/// </summary>
		public string VcName 
		{
			get { return vcName; }
			set { vcName = value; }
		}

		#endregion

		#region Public Dishes Methods

		public SqlDataReader TBL_DishesSelectByServiceID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intServiceID Value To The Parameter(0)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesSelectByServiceID", arrParams);
 	
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_DishesSelectALL()
		{
			try
			{
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesSelectALL");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public SqlDataReader TBL_DishesSelectByServiceIDAndRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intServiceID Value To The Parameter(0)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(1)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesSelectByServiceIDAndRestID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}
        

		public DataSet TBL_DishesSelectALLByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesSelectALLByRestID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_DishesServicesSelectALLByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesServicesSelectALLByRestID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_DishesDeleteByDishIDAndRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing intDishID Value To The Parameter(0)
				objParameters.SetParameter("@intDishID",intDishID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(1)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(2)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesDeleteByDishIDAndRestID", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[2].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[2].Value.ToString());
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


		public SqlDataReader TBL_DishSelectByDishID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intDishID Value To The Parameter(0)
				objParameters.SetParameter("@intDishID",intDishID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishSelectByDishID", arrParams);
 			
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_DishesInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(6);
 
				//Passing intDishID Value To The Parameter(0)
				objParameters.SetParameter("@intDishID",intDishID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(1)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(2)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcName Value To The Parameter(3)
				objParameters.SetParameter("@vcName",vcName, SqlDbType.VarChar,100,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(4)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intDishIDOut Value To The Parameter(5)
				objParameters.SetParameter("@intDishIDOut",intDishID, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_DishesInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[4].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[4].Value.ToString());
				}
				//Retrieve Output Variables
				if (arrParams[5].Value != DBNull.Value)
				{
					intDishID = int.Parse(arrParams[5].Value.ToString());
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


		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Pricing Table----------------------------------------
		#region Private Pricing Members
		private int intPriceID;		
		private decimal smFullTray;
		private decimal smHalfTray;
		private decimal smPerPerson;
		private decimal smDeliveryCharges;
		private decimal smSetup;
		#endregion

		#region Public Pricing Properties
		/// <summary>
		/// Gets or sets the IntPriceID value.
		/// </summary>
		public int IntPriceID 
		{
			get { return intPriceID; }
			set { intPriceID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmFullTray value.
		/// </summary>
		public decimal SmFullTray 
		{
			get { return smFullTray; }
			set { smFullTray = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmHalfTray value.
		/// </summary>
		public decimal SmHalfTray 
		{
			get { return smHalfTray; }
			set { smHalfTray = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmPerPerson value.
		/// </summary>
		public decimal SmPerPerson 
		{
			get { return smPerPerson; }
			set { smPerPerson = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmDeliveryCharges value.
		/// </summary>
		public decimal SmDeliveryCharges 
		{
			get { return smDeliveryCharges; }
			set { smDeliveryCharges = value; }
		}
		
		/// <summary>
		/// Gets or sets the SmSetup value.
		/// </summary>
		public decimal SmSetup 
		{
			get { return smSetup; }
			set { smSetup = value; }
		}
		#endregion

		#region Public Pricing Methods

		public int TBL_PricesInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(11);
 
				//Passing intPriceID Value To The Parameter(0)
				objParameters.SetParameter("@intPriceID",intPriceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intCaterID Value To The Parameter(1)
				objParameters.SetParameter("@intCaterID",intCaterID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(2)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(3)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intDishID Value To The Parameter(4)
				objParameters.SetParameter("@intDishID",intDishID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing smFullTray Value To The Parameter(5)
				objParameters.SetParameter("@smFullTray",smFullTray, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smHalfTray Value To The Parameter(6)
				objParameters.SetParameter("@smHalfTray",smHalfTray, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smPerPerson Value To The Parameter(7)
				objParameters.SetParameter("@smPerPerson",smPerPerson, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smDeliveryCharges Value To The Parameter(8)
				objParameters.SetParameter("@smDeliveryCharges",smDeliveryCharges, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing smSetup Value To The Parameter(9)
				objParameters.SetParameter("@smSetup",smSetup, SqlDbType.SmallMoney,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(10)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[10].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[10].Value.ToString());
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


		public SqlDataReader TBL_PricesSelectByRestIDAndServiceID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",IntRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(1)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesSelectByRestIDAndServiceID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_PricesSelectByRestIDAndServiceIDDataSet()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(2);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",IntRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(1)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesSelectByRestIDAndServiceID", arrParams);
 				
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public DataSet TBL_PricesSelectByRestID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesSelectByRestID", arrParams);
 			
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}


		public int TBL_PricesDeleteByRestIDAndServiceID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing intRestID Value To The Parameter(0)
				objParameters.SetParameter("@intRestID",intRestId, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(1)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intSuccess Value To The Parameter(2)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesDeleteByRestIDAndServiceID", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[2].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[2].Value.ToString());
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


		public SqlDataReader TBL_PricesSelectByCtrIDRestIDSrvIDDshID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(4);
 
				//Passing intCaterID Value To The Parameter(0)
				objParameters.SetParameter("@intCaterID",intCaterID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intRestID Value To The Parameter(1)
				objParameters.SetParameter("@intRestID",intRestID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intServiceID Value To The Parameter(2)
				objParameters.SetParameter("@intServiceID",intServiceID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing intDishID Value To The Parameter(3)
				objParameters.SetParameter("@intDishID",intDishID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_PricesSelectByCtrIDRestIDSrvIDDshID", arrParams);
			
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}

		}

		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Users Table------------------------------------------

		#region Private Users Members
		private int intRestUserID;
		private string vcFirstName;
		private string vcLastName;
		private string vcCompany;
		private string vcPhone;		
		private string vcPassword;
		private string vcAddress1;
		private string vcAddress2;		
		private string vcCountry;		
		private string chRole;
		private int intStatus;
		private DateTime dtCreated;
		#endregion

		#region Public Users Properties
		/// <summary>
		/// Gets or sets the IntRestUserID value.
		/// </summary>
		public int IntRestUserID 
		{
			get { return intRestUserID; }
			set { intRestUserID = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcFirstName value.
		/// </summary>
		public string VcFirstName 
		{
			get { return vcFirstName; }
			set { vcFirstName = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcLastName value.
		/// </summary>
		public string VcLastName 
		{
			get { return vcLastName; }
			set { vcLastName = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcCompany value.
		/// </summary>
		public string VcCompany 
		{
			get { return vcCompany; }
			set { vcCompany = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPhone value.
		/// </summary>
		public string VcPhone 
		{
			get { return vcPhone; }
			set { vcPhone = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcPassword value.
		/// </summary>
		public string VcPassword 
		{
			get { return vcPassword; }
			set { vcPassword = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcAddress1 value.
		/// </summary>
		public string VcAddress1 
		{
			get { return vcAddress1; }
			set { vcAddress1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcAddress2 value.
		/// </summary>
		public string VcAddress2 
		{
			get { return vcAddress2; }
			set { vcAddress2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the VcCountry value.
		/// </summary>
		public string VcCountry 
		{
			get { return vcCountry; }
			set { vcCountry = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChRole value.
		/// </summary>
		public string ChRole 
		{
			get { return chRole; }
			set { chRole = value; }
		}
		
		/// <summary>
		/// Gets or sets the IntStatus value.
		/// </summary>
		public int IntStatus 
		{
			get { return intStatus; }
			set { intStatus = value; }
		}
		
		/// <summary>
		/// Gets or sets the DtCreated value.
		/// </summary>
		public DateTime DtCreated 
		{
			get { return dtCreated; }
			set { dtCreated = value; }
		}
		#endregion

		#region Public Users Methods

		public int TBL_RestUsersInsertUpdate()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(18);
 
				//Passing intSuccess Value To The Parameter(0)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intRestUserIDOut Value To The Parameter(1)
				objParameters.SetParameter("@intRestUserIDOut",intRestUserID, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intRestUserID Value To The Parameter(2)
				objParameters.SetParameter("@intRestUserID",intRestUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcFirstName Value To The Parameter(3)
				objParameters.SetParameter("@vcFirstName",vcFirstName, SqlDbType.VarChar,15,ParameterDirection.Input);
 
				//Passing vcLastName Value To The Parameter(4)
				objParameters.SetParameter("@vcLastName",vcLastName, SqlDbType.VarChar,15,ParameterDirection.Input);
 
				//Passing vcCompany Value To The Parameter(5)
				objParameters.SetParameter("@vcCompany",vcCompany, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcPhone Value To The Parameter(6)
				objParameters.SetParameter("@vcPhone",vcPhone, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcEmail Value To The Parameter(7)
				objParameters.SetParameter("@vcEmail",vcEmail, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcPassword Value To The Parameter(8)
				objParameters.SetParameter("@vcPassword",vcPassword, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcAddress1 Value To The Parameter(9)
				objParameters.SetParameter("@vcAddress1",vcAddress1, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcAddress2 Value To The Parameter(10)
				objParameters.SetParameter("@vcAddress2",vcAddress2, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcCity Value To The Parameter(11)
				objParameters.SetParameter("@vcCity",vcCity, SqlDbType.VarChar,25,ParameterDirection.Input);
 
				//Passing vcState Value To The Parameter(12)
				objParameters.SetParameter("@vcState",vcState, SqlDbType.VarChar,25,ParameterDirection.Input);
 
				//Passing vcCountry Value To The Parameter(13)
				objParameters.SetParameter("@vcCountry",vcCountry, SqlDbType.VarChar,25,ParameterDirection.Input);
 
				//Passing vcZipCode Value To The Parameter(14)
				objParameters.SetParameter("@vcZipCode",vcZip, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing chRole Value To The Parameter(15)
				objParameters.SetParameter("@chRole",chRole, SqlDbType.Char,1,ParameterDirection.Input);
 
				//Passing intStatus Value To The Parameter(16)
				objParameters.SetParameter("@intStatus",intStatus, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing dtCreated Value To The Parameter(17)
				objParameters.SetParameter("@dtCreated",dtCreated, SqlDbType.DateTime,8,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersInsertUpdate", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[0].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[0].Value.ToString());
				}

				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intRestUserID = int.Parse(arrParams[1].Value.ToString());
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


		public int TBL_RestUsersLoginCheck()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(4);
 
				//Passing intSuccess Value To The Parameter(0)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intRestUserID Value To The Parameter(1)
				objParameters.SetParameter("@intRestUserID",intRestUserID, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing vcEmail Value To The Parameter(2)
				objParameters.SetParameter("@vcEmail",vcEmail, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcPassword Value To The Parameter(3)
				objParameters.SetParameter("@vcPassword",vcPassword, SqlDbType.VarChar,50,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersLoginCheck", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[0].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[0].Value.ToString());
				}

				//Retrieve Output Variables
				if (arrParams[1].Value != DBNull.Value)
				{
					intRestUserID = int.Parse(arrParams[1].Value.ToString());
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


		public SqlDataReader TBL_RestUsersSelectByID()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(1);
 
				//Passing intRestUserID Value To The Parameter(0)
				objParameters.SetParameter("@intRestUserID",intRestUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersSelectByID", arrParams);
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}

		public int TBL_RestUsersRetrievePwd()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing intSuccess Value To The Parameter(0)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing vcEmail Value To The Parameter(1)
				objParameters.SetParameter("@vcEmail",vcEmail, SqlDbType.VarChar,50,ParameterDirection.Input);
 
				//Passing vcPassword Value To The Parameter(2)
				objParameters.SetParameter("@vcPassword",vcPassword, SqlDbType.VarChar,50,ParameterDirection.Output);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersRetrievePwd", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[0].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[0].Value.ToString());
				}
				//Retrieve Output Variables
				if (arrParams[2].Value != DBNull.Value)
				{
					vcPassword = arrParams[2].Value.ToString();
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

		public int TBL_RestUsersChangePwd()
		{
			try
			{
				//Declare The Parameters Array of Parameters Class
				Parameters   objParameters = new Parameters(3);
 
				//Passing intSuccess Value To The Parameter(0)
				objParameters.SetParameter("@intSuccess",intSuccess, SqlDbType.Int,4,ParameterDirection.Output);
 
				//Passing intRestUserID Value To The Parameter(1)
				objParameters.SetParameter("@intRestUserID",intRestUserID, SqlDbType.Int,4,ParameterDirection.Input);
 
				//Passing vcPassword Value To The Parameter(2)
				objParameters.SetParameter("@vcPassword",vcPassword, SqlDbType.VarChar,50,ParameterDirection.Input);
 
 
				//Passing ParameterArray Values To The SqlParameters Array 
				SqlParameter[] arrParams = objParameters.ReturnParamArray();
 
				//Open the connection and execute the Command
				SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_RestUsersChangePwd", arrParams);
 
				//Retrieve Output Variables
				if (arrParams[0].Value != DBNull.Value)
				{
					intSuccess = int.Parse(arrParams[0].Value.ToString());
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

		#endregion

		//--------------------------------------------------------------------------------------------------------
		//--------------------Members,Properties,Methods For Activities Table-------------------------------------

		public SqlDataReader TBL_ActivitiesSelectAll()
		{
			try
			{
				//Open the connection and execute the Command
				return (SqlDataReader)SqlHelper.ExecuteReader(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure,"TBL_ActivitiesSelectAll");
 
			}
			catch (Exception ex)
			{
				//Passing the Error Message
				vcErrorMsg = ex.Message;
 
				//Return the Value
				return null;
			}
		}

        public static int UpdateCuisineInfo(int cuisineID,string cuisineName )
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(2);

                //Passing intSuccess Value To The Parameter(0)
                objParameters.SetParameter("@cuisineID", cuisineID, SqlDbType.Int, 4, ParameterDirection.Input);

               
                objParameters.SetParameter("@cuisineName", cuisineName, SqlDbType.VarChar, 100, ParameterDirection.Input);


                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "UpdateCuisineInfo_sp", arrParams);

                //Retrieve Output Variables
                
                //Return the Value
                return 0;
            }
            catch (Exception ex)
            {
                //Passing the Error Message
               

                //Return the Value
                return 1;
            }

        }
        public static int DeleteCuisineInfo(int cuisineID)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(1);

                //Passing intSuccess Value To The Parameter(0)
                objParameters.SetParameter("@cuisineID", cuisineID, SqlDbType.Int, 4, ParameterDirection.Input);

                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "DeleteCuisineInfo_sp", arrParams);

                //Retrieve Output Variables

                //Return the Value
                return 0;
            }
            catch (Exception ex)
            {
                //Passing the Error Message
               

                //Return the Value
                return 1;
            }

        }
        public static int InsertNewCuisineType(string cuisineName)
        {
            try
            {
                //Declare The Parameters Array of Parameters Class
                Parameters objParameters = new Parameters(1);

                //Passing intSuccess Value To The Parameter(0)
                objParameters.SetParameter("@cuisineName", cuisineName, SqlDbType.VarChar, 100, ParameterDirection.Input);

                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                //Open the connection and execute the Command
                SqlHelper.ExecuteNonQuery(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "InsertNewCuisineType_sp", arrParams);

                //Retrieve Output Variables

                //Return the Value
                return 0;
            }
            catch (Exception ex)
            {
                //Passing the Error Message
                

                //Return the Value
                return 1;
            }

        }
        public DataSet TBL_AllCatOrders(string restName,string startDate,string endDate)
        {
            try
            {
                Parameters objParameters = new Parameters(3);

                //Passing intSuccess Value To The Parameter(0)
                objParameters.SetParameter("@RestName", restName, SqlDbType.VarChar, 100, ParameterDirection.Input);
                objParameters.SetParameter("@StartDate", startDate, SqlDbType.VarChar, 20, ParameterDirection.Input);
                objParameters.SetParameter("@EndDate", endDate, SqlDbType.VarChar, 20, ParameterDirection.Input);

                //Passing ParameterArray Values To The SqlParameters Array 
                SqlParameter[] arrParams = objParameters.ReturnParamArray();

                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "TBL_AllCatOrders_SP", arrParams);

            }
            catch (Exception ex)
            {
                //Passing the Error Message
                vcErrorMsg = ex.Message;

                //Return the Value
                return null;
            }

        }
        public DataSet TBL_AllLocOrders( string customerName, string telephone, string reservationDate, string orderDate, string totalOrder, string status)
        {
            try
            {
                
                Parameters objParameters = new Parameters(6);
                objParameters.SetParameter("@customerName", customerName, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@telephone", telephone, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@reservationDate", reservationDate, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@orderDate", orderDate, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@totalOrder", totalOrder, SqlDbType.VarChar, ParameterDirection.Input);
                objParameters.SetParameter("@status", status, SqlDbType.VarChar, ParameterDirection.Input);
                SqlParameter[] arrParams = objParameters.ReturnParamArray();
                return (DataSet)SqlHelper.ExecuteDataset(ConfigurationSettings.AppSettings["ConnectionString"], CommandType.StoredProcedure, "TBL_AllLocOrders_sp", arrParams);

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
