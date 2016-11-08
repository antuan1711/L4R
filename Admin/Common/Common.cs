using System;
using System.Configuration; 
using System.Text; 
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
namespace Admin.Common
{
	/// <summary>
	/// Contain the Common Class used in the application
	/// </summary>
	public class Common_function
	{
		/// <summary>
		/// This function return the connection String for Database Adminme.The connection
		/// Specified in Web.Config File in the node ConnectionString   
		/// </summary>
		/// <returns>String Connectiong String </returns>

        public static String L4RRootUrl
        {
            get
            {
                return ConfigurationSettings.AppSettings["L4RRootUrl"];
            }
        }
        public static String RootUrl
        {
            get
            {
                return ConfigurationSettings.AppSettings["RootUrl"];
            }
        }

		public static string connect_string()
		{
			return ConfigurationSettings.AppSettings["ConnectionString"];  
		}
        
        public static List<KeyValuePair<int, string>> getFaithInfo()
        {

            List<KeyValuePair<int, string>> ListState = new List<KeyValuePair<int, string>>();


            using (IDataReader ireader = SqlHelper.ExecuteReader(connect_string(), "getfaithinfo"))
            {
                while (ireader.Read())
                {
                    ListState.Add(new KeyValuePair<int, string>(Convert.ToInt32(ireader[0]), ireader[1].ToString()));

                }

            }

            return ListState;
        }
		public static void DisplayMessage(string MessageTitle,string MessageDetails ,string PageTitle, int DelayInSeconds)
			   {
				   //Core HTML, with refresh
				   string strResponse = @"<html><head><title>%page-title%</title><META HTTP-EQUIV="" RefreshCONTENT=""%delay%; url=javascript:history.back();"">" + @"</head><body><div align=""center""><center>" + @"<table border=""0"" cellpadding=""0"" 
		cellspacing=""0"" " + @"width=""100%"" height=""100%""><tr><td width=""100%"">" + @"<p align=""center""><b> <font face=""Arial"" size=""6"">" + @"%message-title%</font></b></p><p align=""center"">" + @"<font face=""Arial"" size=""3""> <b>%message-details%</b>" +	@"</font></td></tr></table></center></div></body></html>";

				   //Replace defaults
					strResponse = strResponse.Replace("%page-title%", PageTitle);
					strResponse = strResponse.Replace("%message-title%", MessageTitle);
					strResponse = strResponse.Replace("%message-details%",MessageDetails);
					strResponse = strResponse.Replace("%delay%",DelayInSeconds.ToString());
						   // Display response
					HttpContext.Current.Response.Write(strResponse);    
					HttpContext.Current.Response.Close();   
					HttpContext.Current.Response.End();
					
			   }

		public static void SetFocus(System.Web.UI.Control control)
		{
			StringBuilder sb = new StringBuilder();
 
			sb.Append("\r\n<script language='JavaScript'>\r\n");
			sb.Append("<!--\r\n"); 
			sb.Append("function SetFocus()\r\n"); 
			sb.Append("{\r\n"); 
			sb.Append("\tdocument.");
 
			System.Web.UI.Control p = control.Parent;
			while (!(p is System.Web.UI.HtmlControls.HtmlForm)) p = p.Parent; 
 
			sb.Append(p.ClientID);
			sb.Append("['"); 
			sb.Append(control.UniqueID); 
			sb.Append("'].focus();\r\n"); 
			sb.Append("}\r\n"); 
			sb.Append("window.onload = SetFocus;\r\n"); 
			sb.Append("// -->\r\n"); 
			sb.Append("</script>");
 
			control.Page.RegisterClientScriptBlock("SetFocus", sb.ToString());
		}

		private Common_function() {}
		
	}
}
