using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Admin.Component
{
    public enum PermissionType
    {
        Restaurants = 1,
        PurchasesLog = 2,
        ManageMembers = 3,
        ManageEvents = 4,
        ManageReviews = 5,
        ManageCalendar = 6,
        Categories = 7,
        Classifieds = 8,
        ManageCities = 9,
        ManageServices = 10,
        ManagePharses = 11,
        Administrators = 12
    }
    public class AdminPermissions
    {
        #region Variable declaration
       	private Int32 _isSuperAdmin;
		private Boolean _isRestaurantsAccessible;
        private Boolean _isPurchaseLoggAccessible;
        private Boolean _isMemberAccessible;
		private Boolean _isEventAccessible;
        private Boolean _isReviewsAccessible;
        private Boolean _isCalendarAccessible;
		private Boolean _isCategoriesAccessible;
		private Boolean _isClassifiedsAccessible;
		private Boolean _isCitiesAccessible;
        private Boolean _isServicesAccessible;
        private Boolean _isPharsesAccessible;
	    private Boolean _isAdminAccessible;
		#endregion
		#region Properties
		public Int32 IsSuperAdmin
		{
			get
			{
				return _isSuperAdmin;
			}
			set
			{
				_isSuperAdmin = value;
			}
        }
      	
		public Boolean IsRestaurantsAccessible
		{
			get
			{
				return _isRestaurantsAccessible;
			}
			set
			{
				_isRestaurantsAccessible = value;
			}
		}
		public Boolean IsPurchaseLoggAccessible
		{
			get
			{
				return _isPurchaseLoggAccessible;
			}
			set
			{
				_isPurchaseLoggAccessible = value;
			}
		}
		public Boolean IsMemberAccessible
		{
			get
			{
				return _isMemberAccessible;
			}
			set
			{
				_isMemberAccessible = value;
			}
		}
		public Boolean IsReviewsAccessible
		{
			get
			{
				return _isReviewsAccessible;
			}
			set
			{
				_isReviewsAccessible = value;
			}
		}
		public Boolean IsEventAccessible
		{
			get
			{
				return _isEventAccessible;
			}
			set
			{
				_isEventAccessible = value;
			}
		}
        public Boolean IsCalendarAccessible
        {
            get
            {
                return _isCalendarAccessible;
            }
            set
            {
                _isCalendarAccessible = value;
            }
        }
		public Boolean IsCategoriesAccessible
		{
			get
			{
				return _isCategoriesAccessible;
			}
			set
			{
				_isCategoriesAccessible = value;
			}
		}
		public Boolean IsClassifiedsAccessible
		{
			get
			{
				return _isClassifiedsAccessible;
			}
			set
			{
				_isClassifiedsAccessible = value;
			}
		}
		public Boolean IsCitiesAccessible
		{
			get
			{
                return _isCitiesAccessible;
			}
			set
			{
                _isCitiesAccessible = value;
			}
		}
        public Boolean IsServicesAccessible
        {
            get
            {
                return _isServicesAccessible;
            }
            set
            {
                _isServicesAccessible = value;
            }
        }
		public Boolean IsPharsesAccessible
		{
			get
			{
				return _isPharsesAccessible;
			}
			set
			{
				_isPharsesAccessible = value;
			}
		}
		public Boolean IsAdminAccessible
		{
			get
			{
				return _isAdminAccessible;
			}
			set
			{
				_isAdminAccessible = value;
			}
		}
		

      	#endregion

		#region Constructor
        public AdminPermissions()
        {
            _isSuperAdmin = 0;
            _isRestaurantsAccessible = false;
            _isPurchaseLoggAccessible = false;
            _isMemberAccessible = false;
            _isEventAccessible = false;
            _isReviewsAccessible = false;
            _isCalendarAccessible = false;
            _isCategoriesAccessible = false;
            _isClassifiedsAccessible = false;
            _isCitiesAccessible = false;
            _isServicesAccessible = false;
            _isPharsesAccessible = false;
            _isAdminAccessible = false;

        }
		#endregion

		#region LoadServiceSetting
		public void LoadPermissionsSetting()
		{
            if (LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin!=null)
			{
                clsGeneral objGeneral = new clsGeneral();
                objGeneral.Admin_ID = Convert.ToInt32(LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin);
                DataSet dsPermissions = objGeneral.Admin_InAdminDetails();
                if (dsPermissions.Tables[1].Rows.Count > 0)
				{
                    foreach (DataRow drPermission in dsPermissions.Tables[1].Rows)
					{
                        switch ((PermissionType)Convert.ToInt32(drPermission["PermissionID"]))
						{
							case PermissionType.Restaurants:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
								{
									IsRestaurantsAccessible= true;
								}
								else
								{
                                    IsRestaurantsAccessible = false;
								}
								break;
							case PermissionType.PurchasesLog:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsPurchaseLoggAccessible = true;
								}
								else
								{
                                    IsPurchaseLoggAccessible = false;
								}
								break;
							case PermissionType.ManageMembers:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsMemberAccessible = true;
								}
								else
								{
                                    IsMemberAccessible = false;
								}
								break;
							case PermissionType.ManageEvents:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsEventAccessible = true;
								}
								else
								{
                                    IsEventAccessible = false;
								}
								break;
							case PermissionType.ManageReviews :
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsReviewsAccessible = true;
								}
								else
								{
                                    IsReviewsAccessible = false;
								}
								break;
							case PermissionType.ManageCalendar:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsCalendarAccessible = true;
								}
								else
								{
                                    IsCalendarAccessible = false;
								}
								break;
							case PermissionType.Categories:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsCategoriesAccessible = true;
								}
								else
								{
                                    IsCategoriesAccessible = false;
								}
								break;
							case PermissionType.Classifieds:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsClassifiedsAccessible = true;
								}
								else
								{
                                    IsClassifiedsAccessible = false;
								}
								break;
                            case PermissionType.ManageCities:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    IsCitiesAccessible = true;
                                }
                                else
                                {
                                    IsCitiesAccessible = false;
                                }
                                break;
							case PermissionType.ManageServices:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsServicesAccessible = true;
								}
								else
								{
                                    IsServicesAccessible = false;
								}
								break;
                            case PermissionType.ManagePharses:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    IsPharsesAccessible = true;
                                }
                                else
                                {
                                    IsPharsesAccessible = false;
                                }
                                break;
							case PermissionType.Administrators:
								if(Convert.ToInt32(drPermission["PermissionStatus"])==1 )
								{
									IsAdminAccessible = true;
								}
								else
								{
                                    IsAdminAccessible = false;
								}
								break;
							default:
								//nothing to do
								break;
						}
					}
				}
			}
			else
			{
				throw new Exception("Error");
			}
		}
        public static string GetUserDefaultPage()
        {
            string defaultPage=string.Empty;
            if (LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin != null)
            {
                clsGeneral objGeneral = new clsGeneral();
                objGeneral.Admin_ID = Convert.ToInt32(LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin);
                DataSet dsPermissions = objGeneral.Admin_InAdminDetails();
                if (dsPermissions.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow drPermission in dsPermissions.Tables[1].Rows)
                    {
                        switch ((PermissionType)Convert.ToInt32(drPermission["PermissionID"]))
                        {
                            case PermissionType.Restaurants:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "ManageRestaurants.aspx";
                                }
                                break;
                            case PermissionType.PurchasesLog:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "AllOrderLog.aspx";
                                }
                                break;
                            case PermissionType.ManageMembers:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "Member_search.aspx";
                                }
                                break;
                            case PermissionType.ManageEvents:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "Calendar.aspx";
                                }
                                break;
                            case PermissionType.ManageReviews:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "UserReviews.aspx";
                                }
                                break;
                            case PermissionType.ManageCalendar:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "Calendar.aspx";
                                }
                                break;
                            case PermissionType.Categories:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "Advt.aspx?mid=2";
                                }
                                break;
                            case PermissionType.Classifieds:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "freeClassifiedCategoryDetais.aspx";
                                }
                                break;
                            case PermissionType.ManageCities:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "ManageCities.aspx";
                                }
                                break;
                            case PermissionType.ManageServices:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "ManageService.aspx";
                                }
                                break;
                            case PermissionType.ManagePharses:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "AddPhrase.aspx";
                                }
                                break;
                            case PermissionType.Administrators:
                                if (Convert.ToInt32(drPermission["PermissionStatus"]) == 1)
                                {
                                    defaultPage = "Administrators.aspx";
                                }
                                break;
                            default:
                                defaultPage = "Calendar.aspx";
                                break;
                        }
                    }
                }
                else
                {
                    defaultPage = "Calendar.aspx";
                }
            }
            return defaultPage;
           
        }
		#endregion
    }
}
