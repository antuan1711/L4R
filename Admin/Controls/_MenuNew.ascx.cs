namespace Admin.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Text;

	/// <summary>
	///		Summary description for __Menu.
	/// </summary>
	public partial class __MenuNew : System.Web.UI.UserControl
	{
		protected StringBuilder menu = new StringBuilder(String.Empty);
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (LoveForRestaurants.BizLayer.CookieHelper.AdminType != null)
            {
                if (LoveForRestaurants.BizLayer.CookieHelper.AdminType != "True")
                {
                    GetActiveLinks();
                    IsAccessAllowed();
                }
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			InitializeComponent();
			base.OnInit(e);
		}
		
		private void InitializeComponent()
		{
		}
        protected void GetActiveLinks()
        {
            Admin.Component.AdminPermissions _oPermissions = new Admin.Component.AdminPermissions();
            _oPermissions.LoadPermissionsSetting();
            if (_oPermissions.IsRestaurantsAccessible)
            {
                liRestaurants.Visible = true;
            }
            else
            {
                liRestaurants.Visible = false;
            }
            if (_oPermissions.IsPurchaseLoggAccessible)
            {
                liLogs.Visible = true;
            }
            else
            {
                liLogs.Visible = false;
            }
            if (_oPermissions.IsMemberAccessible)
            {
                liMember.Visible = true;
            }
            else
            {
                liMember.Visible = false;
            }
            //if (_oPermissions.IsEventAccessible)
            //{
            //    liEvents.Visible = true;
            //}
            //else
            //{
            //    liEvents.Visible = false;
            //}
            if (_oPermissions.IsReviewsAccessible)
            {
                liReview.Visible = true;
            }
            else
            {
                liReview.Visible = false;
            }
            if (_oPermissions.IsCalendarAccessible)
            {
                liCalender.Visible = true;
            }
            else
            {
                liCalender.Visible = false;
            }
            if (_oPermissions.IsCategoriesAccessible)
            {
                liCategory.Visible = true;
            }
            else
            {
                liCategory.Visible = false;
            }
            if (_oPermissions.IsClassifiedsAccessible)
            {
                liClassified.Visible = true;
            }
            else
            {
                liClassified.Visible = false;
            }
            if (_oPermissions.IsCitiesAccessible)
            {
                liCities.Visible = true;
            }
            else
            {
                liCities.Visible = false;
            }
            if (_oPermissions.IsServicesAccessible)
            {
                liServices.Visible = true;
            }
            else
            {
                liServices.Visible = false;
            }
            if (_oPermissions.IsPharsesAccessible)
            {
                liPhrase.Visible = true;
            }
            else
            {
                liPhrase.Visible = false;
            }
            if (_oPermissions.IsAdminAccessible)
            {
                liAdmin.Visible = true;
            }
            else
            {
                liAdmin.Visible = false;
            }
        }

        protected void IsAccessAllowed()
        {
            Admin.Component.AdminPermissions _oPermissions = new Admin.Component.AdminPermissions();
            _oPermissions.LoadPermissionsSetting();
            string pageName = System.IO.Path.GetFileName(Request.Url.AbsolutePath).Replace("/", "");
            string defaultPage=string.Empty;
            if(Session["DefaultPage"]!=null)
            {
                defaultPage=Session["DefaultPage"].ToString();
             
            }
            else
            {
                  defaultPage=Admin.Component.AdminPermissions.GetUserDefaultPage();
            }
            if (pageName != defaultPage)
            {
                if (pageName.ToUpper() == "MANAGERESTAURANTS.ASPX" || pageName.ToUpper() == "RESTAURANT_USERREGISTER.ASPX")
                {
                    if (!_oPermissions.IsRestaurantsAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }

                }

                if (pageName.ToUpper() == "ALLORDERLOG.ASPX" || pageName.ToUpper() == "DINERSPAYMENTLOG.ASPX" || pageName.ToUpper() == "VIEWCATORDERS.ASPX" || pageName.ToUpper() == "VIEWCATORDERDETAILS.ASPX" || pageName.ToUpper() == "RESTMENULOG.ASPX" || pageName.ToUpper() == "GIFTCARDORDERS.ASPX" || pageName.ToUpper() == "GIFTCARDORDERDETAIL.ASPX" || pageName.ToUpper() == "ADMININVENTORYMANAGE.ASPX" || pageName.ToUpper() == "LOCORDERLOG.ASPX" || pageName.ToUpper() == "VIEWLOCORDERDETAILS.ASPX" || pageName.ToUpper() == "COUPONLOG.ASPX")
                {
                    if (!_oPermissions.IsPurchaseLoggAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }

                }
                if (pageName.ToUpper() == "MEMBER_SEARCH.ASPX" || pageName.ToUpper() == "SEARCH_RESULT.ASPX" || pageName.ToUpper() == "VIEWPROFILE.ASPX" || pageName.ToUpper() == "SEARCHMAILINGLIST.ASPX" || pageName.ToUpper() == "SEARCHMAILINGLIST.ASPX" || pageName.ToUpper() == "MAILINGLISTADD.ASPX" || pageName.ToUpper() == "MAILINGLISTRESULTS.ASPX" || pageName.ToUpper() == "EMAIL.ASPX" || pageName.ToUpper() == "ALLREWARDS.ASPX" || pageName.ToUpper() == "RESTAURANTSREWARDS.ASPX" || pageName.ToUpper() == "USERREWARDS.ASPX")
                {
                    if (!_oPermissions.IsMemberAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "CALENDAR.ASPX" || pageName.ToUpper() == "ADDEVENT.ASPX" || pageName.ToUpper() == "MANAGEACTIVITIES.ASPX" || pageName.ToUpper() == "ADDEDITACTIVITY.ASPX")
                {
                    if (!_oPermissions.IsEventAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "USERREVIEWS.ASPX")
                {
                    if (!_oPermissions.IsReviewsAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }

                }
                if (pageName.ToUpper() == "ADVT.ASPX" || pageName.ToUpper() == "ADDADVT.ASPX" || pageName.ToUpper() == "MANAGECUISINE.ASPX")
                {
                    if (!_oPermissions.IsCategoriesAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "FREECLASSIFIEDCATEGORYDETAIS.ASPX" || pageName.ToUpper() == "ADDFREECLASSIFIEDTRANS.ASPX" || pageName.ToUpper() == "CLASSIFIEDUSERDETAILS.ASPX" || pageName.ToUpper() == "CLASSIFIEDS_CATEGORIES.ASPX" || pageName.ToUpper() == "CLASSIFIED_POSTINGS.ASPX" || pageName.ToUpper() == "CLASSIFIED_DISPKLAYPOSTING.ASPX")
                {
                    if (!_oPermissions.IsClassifiedsAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "MANAGECITIES.ASPX")
                {
                    if (!_oPermissions.IsCitiesAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "MANAGESERVICE.ASPX")
                {
                    if (!_oPermissions.IsServicesAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "ADDPHRASE.ASPX")
                {
                    if (!_oPermissions.IsPharsesAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
                if (pageName.ToUpper() == "ADMINISTRATORS.ASPX" || pageName.ToUpper() == "EDITADMIN.ASPX" || pageName.ToUpper() == "NEWADMIN.ASPX" || pageName.ToUpper() == "PASSWORD.ASPX")
                {
                    if (!_oPermissions.IsAdminAccessible)
                    {
                        Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    }
                }
            }
        }
		#endregion
	}
}
