using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Admin.Component;
using System.Web.Services;
using System.Data;
using LoveForRestaurants.BizLayer;

namespace Admin.actionpages
{
    public partial class AjaxActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DictionaryEntry de in HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Remove(Convert.ToString(de.Key));
            }
        }
        [WebMethod]
        public static void UpdateBlogStatus(int blogID)
        {
            RestaurantDB.UpdateRestBlogStatus(blogID);

        }
        [WebMethod]
        public static string PayToRestaurants(string checkNO, decimal amount, string comment, string orderDetail)
        {
            DataSet dsRestPayment = new DataSet();
            DataTable dtRestPayment = new DataTable();
            dtRestPayment.Columns.Add("OrderID");
            dtRestPayment.Columns.Add("OrderType");
            dtRestPayment.Columns.Add("RestID");
            string[] arrOrderDetial = orderDetail.Split(',');
            string restaurantIDs = "";
            for (int i = 0; i < arrOrderDetial.Length; i++)
            {
                string[] arrOrderDetail1 = arrOrderDetial[i].Split('_');
                DataRow drRestPayment = dtRestPayment.NewRow();
                drRestPayment["OrderID"] = arrOrderDetail1[0];
                drRestPayment["OrderType"] = arrOrderDetail1[1];
                drRestPayment["RestID"] = arrOrderDetail1[2];
                if (restaurantIDs == "")
                    restaurantIDs = arrOrderDetail1[2];
                else
                    restaurantIDs += "_" + arrOrderDetail1[2];

                dtRestPayment.Rows.Add(drRestPayment);
            }

            #region add confirmation number
            DataView dv = new DataView(dtRestPayment);            
            DataTable distinctValues = dv.ToTable(true, "RestID");
            bool flag1stTimeGetFromDB = true;
            string oldConfirmationNo = "";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (DataRow row in distinctValues.Rows)
            {
                if (flag1stTimeGetFromDB)
                {
                    oldConfirmationNo = LoveForRestaurants.BizLayer.clsAllOrderLog.GetConfirmationNumber();
                    dictionary.Add(row["RestID"].ToString(), oldConfirmationNo);
                    flag1stTimeGetFromDB = false;
                }
                else
                {
                    oldConfirmationNo = LoveForRestaurants.BizLayer.Utility.GetConfirmationNumber(oldConfirmationNo);
                    dictionary.Add(row["RestID"].ToString(), oldConfirmationNo);
                }
            }

            dtRestPayment.Columns.Add("CnfmNo");
            foreach (DataRow row in dtRestPayment.Rows)
            {
                if (dictionary.ContainsKey((row["RestID"].ToString())))
                {
                    row["CnfmNo"] = dictionary[row["RestID"].ToString()];
                }
            }
            dtRestPayment.AcceptChanges();
            #endregion

            dsRestPayment.Tables.Add(dtRestPayment);
            string restPaymentDetail = dsRestPayment.GetXml();
            string result = LoveForRestaurants.BizLayer.clsAllOrderLog.PayToRestaurants(restPaymentDetail, checkNO, amount, comment, restaurantIDs);
            return result;
        }

        //[WebMethod]
        //public static string PayToSingleRestaurant(string checkNO, decimal amount, string comment, string orderDetail)
        //{           
        //    DataSet dsRestPayment = new DataSet();
        //    DataTable dtRestPayment = new DataTable();
        //    dtRestPayment.Columns.Add("OrderID");
        //    dtRestPayment.Columns.Add("OrderType");
        //    dtRestPayment.Columns.Add("RestID");
        //    string[] arrOrderDetial = orderDetail.Split(',');
        //    for (int i = 0; i < arrOrderDetial.Length; i++)
        //    {
        //        string[] arrOrderDetail1 = arrOrderDetial[i].Split('_');
        //        DataRow drRestPayment = dtRestPayment.NewRow();
        //        drRestPayment["OrderID"] = arrOrderDetail1[0];
        //        drRestPayment["OrderType"] = arrOrderDetail1[1];
        //        drRestPayment["RestID"] = arrOrderDetail1[2];
        //        dtRestPayment.Rows.Add(drRestPayment);
        //    }
        //    dsRestPayment.Tables.Add(dtRestPayment);
        //    string restPaymentDetail = dsRestPayment.GetXml();
        //    string result = LoveForRestaurants.BizLayer.clsAllOrderLog.PayToSingleRestaurant(restPaymentDetail, checkNO, amount, comment);
        //    return result;
        //}

        [WebMethod]
        public static string DeleteEventPhoto(string EventID, string EventPhotoName)
        {
            if (LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin != null)
            {
                string result = Admin.Calendar.EventDB.DeleteEventsPhoto(Convert.ToInt32(EventID), EventPhotoName);
                try
                {
                    System.IO.File.Delete(ConfigHelper.EventPhotosPath + EventPhotoName);
                }
                catch (Exception ex) { }
                return "ok";
            }
            else
            {
                return "";
            }

        }
        [WebMethod]
        public static string UpdateResumeStatus(string resumeID, string resumeStatus)
        {
            if (LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin != null)
            {
                try
                {
                    string result = Admin.Advertisement.ClassifiedDB.UpdateResumeStatus(Convert.ToInt32(resumeID), Convert.ToBoolean(resumeStatus));
                    return "ok";
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "Please login";
            }

        }
        [WebMethod]
        public static string UpdateEventStatus(string eventID, string eventStatus)
        {
            if (LoveForRestaurants.BizLayer.CookieHelper.SuperAdmin != null)
            {
                try
                {
                    string result = Admin.Calendar.EventDB.UpdateEventStatus(Convert.ToInt32(eventID), Convert.ToBoolean(eventStatus));
                    return "ok";
                }
                catch
                {
                    return "";
                }
            }
            else
            {
                return "Please login";
            }

        }

        [WebMethod]
        public static string[] GetRestaurants(string filter, string isActive)
        {
            DataTable dt = RestaurantDB.GetAllRestaurants_AutoComplete(filter,Convert.ToBoolean(isActive));

            List<string> list_rest = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list_rest.Add(row["Restaurants_name"].ToString());
            }
            return list_rest.ToArray();
        }

    }
}
