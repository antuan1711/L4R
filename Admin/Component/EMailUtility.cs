using System;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using Admin.Common;
using LoveForRestaurants.BizLayer;
using System.Net.Mail;
using System.Configuration; 
 
    
namespace Admin.EMail
{
	/// <summary>
	/// Summary description for EMailUtility.
	/// </summary>
	
	public class EmailUtility 
	{
    

		//*********************************************************************
		//
		// SendEmail Method
		//
		// Sends a single email. 
		//
		//*********************************************************************
    
		public static string SendEmail(string from,string to,string subject,string body,bool bodyFormat) 
		{

            var fromAddress = new MailAddress(from, "Love4Restaurants");
            var toAddress = new MailAddress(to);
           	MailMessage message = new MailMessage(fromAddress,toAddress);
			message.Subject = subject;
			message.Body = body;
            message.IsBodyHtml = bodyFormat;
       

            try
            {
                SmtpClient theClient = new SmtpClient(LoveForRestaurants.BizLayer.ConfigHelper.SmtpServer, ConfigHelper.SmtpPort);
                //"smtp.love4restaurants.com", 25);
                theClient.UseDefaultCredentials = false;
                //theClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
                theClient.Credentials = theCredential;
                theClient.Send(message);
                return "Sent";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            } 
        
		}       


		//-------------------------CODE ADDED BY KRUPAKAR-----------------------------
		public static string SendEmailWithAttachments(string from,string to,string subject,string body,bool bodyFormat,string Attachment) 
		{
            var fromAddress = new MailAddress(from, "Love4Restaurants");
            var toAddress = new MailAddress(to);
            MailMessage message = new MailMessage(fromAddress, toAddress);
           	message.Subject = subject;
			message.Body = body;
            message.IsBodyHtml = bodyFormat;
            Attachment mt = new Attachment(Attachment);
            message.Attachments.Add(mt);
            message.Priority = MailPriority.High;


            try
            {
                SmtpClient theClient = new SmtpClient(LoveForRestaurants.BizLayer.ConfigHelper.SmtpServer, ConfigHelper.SmtpPort);
                theClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"], ConfigurationManager.AppSettings["SmtpPassword"]);
                theClient.Credentials = theCredential;
                theClient.Send(message);
                return "Sent";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
		}
		//--------------------------------------------------------------------------------
		
				
		//*********************************************************************
		//
		// EmailUtility Constructor
		//
		// Use a private constructor for a class with static methods.
		//
		//*********************************************************************

		private EmailUtility() {}
	}
}
