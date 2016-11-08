using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security; 
using System.Security.Principal;
using Admin.Common;
using System.Data;

namespace Admin.Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        public string adminPassword = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoveForRestaurants.BizLayer.CookieHelper.GetEncryptedCookieValue(LoveForRestaurants.BizLayer.CookieKeys.AdminPassword) != null)
            {
                txtPassword.Text = LoveForRestaurants.BizLayer.CookieHelper.GetEncryptedCookieValue(LoveForRestaurants.BizLayer.CookieKeys.AdminPassword);   
            }

            if (!(Page.IsPostBack))
            {
                Common.Common_function.SetFocus(txtUsername);
            }
        }
        public void LoginPermissionCheck()
        {
            clsGeneral objGeneral = new clsGeneral();
            objGeneral.Admin_UserName = txtUsername.Text;
            objGeneral.Admin_Password = txtPassword.Text;
            int Result = objGeneral.Admin_LoginCheck();
            if (Result == 0)
            {
                Session["Permission"] = objGeneral.Admin_Per.ToString();
            }
            else
            {
                lblerror.Text = objGeneral.VcErrorMsg;
            }
            objGeneral = null;
        }

        protected void btnLogin_Click(object sender, System.EventArgs e)
        {
            string result = null;
            DataTable dt = AdminDB.AdminLogin(txtUsername.Text, txtPassword.Text);
            if (dt.Rows.Count == 0)
            {
                lblerror.Text = "Invalid username or password";
            }

            else
            {

                LoveForRestaurants.BizLayer.CookieHelper.SetEncryptedCookie(LoveForRestaurants.BizLayer.CookieKeys.SuperAdmin, dt.Rows[0]["Admin_ID"].ToString());
                Session["UserId"] = dt.Rows[0]["Admin_ID"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["IsSuperAdmin"].ToString()))
                {
                    LoveForRestaurants.BizLayer.CookieHelper.SetEncryptedCookie(LoveForRestaurants.BizLayer.CookieKeys.AdminType, "True");
                }
                else
                {
                    LoveForRestaurants.BizLayer.CookieHelper.SetEncryptedCookie(LoveForRestaurants.BizLayer.CookieKeys.AdminType, "False");
                }
                LoginPermissionCheck();
               
                if (SavePassword.Checked == true)
                {
                    LoveForRestaurants.BizLayer.CookieHelper.SetEncryptedCookie(LoveForRestaurants.BizLayer.CookieKeys.AdminPassword, txtPassword.Text);
                }
                if (LoveForRestaurants.BizLayer.CookieHelper.AdminType == "True")
                {
                    Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + "AllOrderLog.aspx");

                }
                else
                {
                    string defaultPage=Admin.Component.AdminPermissions.GetUserDefaultPage();
                    Response.Redirect(LoveForRestaurants.BizLayer.ConfigHelper.RootUrl + defaultPage);
                    Session["DefaultPage"] = defaultPage;
                }
                

            }
        }
    }
}
