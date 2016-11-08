using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Handler
{
    /// <summary>
    /// Summary description for Uploadify
    /// </summary>
    public class Uploadify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files["Filedata"];

                //string savepath = "";//string tempPath = "";
                //tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"];                 //savepath = context.Server.MapPath(tempPath);            
                string filename = postedFile.FileName;
                string Newfilename = postedFile.FileName;
                Newfilename = Guid.NewGuid().ToString().Replace("-","") + "_" + filename;
                string GCImagePath = "";
                if (context.Session["handlerType"] != null && context.Session["handlerType"].ToString() == "AddEvent")
                    GCImagePath = LoveForRestaurants.BizLayer.ConfigHelper.EventPhotosPath + Newfilename;
                else
                    GCImagePath = LoveForRestaurants.BizLayer.ConfigHelper.GiftCertificateImagePath + Newfilename;
                //if (!Directory.Exists(savepath))
                //    Directory.CreateDirectory(savepath);

                //postedFile.SaveAs(savepath + @"\" + filename);
                postedFile.SaveAs(GCImagePath);
                context.Response.Write(GCImagePath);
                context.Response.StatusCode = 200;
                context.Session["GCImage"] = (context.Session["GCImage"] == null ? Newfilename + "," : context.Session["GCImage"].ToString() + Newfilename + ",");                
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
                context.Session["GCImage"] = "";
            }
            //HttpPostedFile uploadFiles = context.Request.Files["Filedata"];
            //string pathToSave = HttpContext.Current.Server.MapPath("~/UploadFiles/") + uploadFiles.FileName;
            //uploadFiles.SaveAs(pathToSave);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}