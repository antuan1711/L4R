using System;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Web;
using System.Drawing.Imaging;

namespace Admin
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
			public class ImageUtility 
		{

			//*********************************************************************
			//
			// IsImageFile Method
			//
			// Returns true or false depending on whether the filename 
			// ends with an image file extension. 
			//
			//*********************************************************************

			public static bool IsImageFile(string fileName) 
			{
				string fileext, allowedImages;

				fileName = fileName.ToLower();
				fileext=Path.GetExtension(fileName);
				allowedImages =ConfigurationSettings.AppSettings["AllowedImages"].ToString();
				allowedImages= allowedImages.ToLower();
 
				if(fileName != null || fileext != null)			
				{
					if (allowedImages.IndexOf(fileext) == -1)
					{
						return false;
					}
				}
				return true;
			} 


			//*********************************************************************
			//
			// ModifyImage Method
			//
			// Modifies the width or height of an image. 
			//
			//*********************************************************************

				public static string giveFileName(string fullname)
				{
				return Path.GetFileName(fullname);
				}

			public static Bitmap CreateThumbnail(string lcFilename,int lnWidth, int lnHeight)
			{
				System.Drawing.Bitmap bmpOut = null;
				try 
				{
					Bitmap loBMP = new Bitmap(lcFilename);
					ImageFormat loFormat = loBMP.RawFormat;
					decimal lnRatio;
					int lnNewWidth = 0;
					int lnNewHeight = 0;

					//*** If the image is smaller than a thumbnail just return it
					if (loBMP.Width < lnWidth && loBMP.Height < lnHeight) 
						return loBMP;
					if (loBMP.Width > loBMP.Height)
					{
						lnRatio = (decimal) lnWidth / loBMP.Width;
						lnNewWidth = lnWidth;
						decimal lnTemp = loBMP.Height * lnRatio;
						lnNewHeight = (int)lnTemp;
					}
					else 
					{
						lnRatio = (decimal) lnHeight / loBMP.Height;
						lnNewHeight = lnHeight;
						decimal lnTemp = loBMP.Width * lnRatio;
						lnNewWidth = (int) lnTemp;
					}

 
					// *** This code creates cleaner (though bigger) thumbnails and properly
					// *** and handles GIF files better by generating a white background for
					// *** transparent images (as opposed to black)
					bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
					Graphics g = Graphics.FromImage(bmpOut);
					g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
					g.FillRectangle( Brushes.White,0,0,lnNewWidth,lnNewHeight);
					g.DrawImage(loBMP,0,0,lnNewWidth,lnNewHeight);
					loBMP.Dispose();
				}
				catch 
				{
					return null;
				}
				return bmpOut;
			}

		//****This code gets the name of the file and uploads to the specified path.
				//If the directory dosent exists it creates new directory and uploads the file.
			public static Boolean saveFile(System.Web.UI.HtmlControls.HtmlInputFile fUpload )
			{
				string fileName; 
				string directoryPath;
				fileName = Path.GetFileName(fUpload.PostedFile.FileName);
				if (fileName=="")
					return false;
				directoryPath = HttpContext.Current.Server.MapPath("Galleries/");
				if (!Directory.Exists(directoryPath)) 
				{
					Directory.CreateDirectory(directoryPath);
				}
				Image objThumbnail=null;
				try
				{
					fUpload.PostedFile.SaveAs(directoryPath + fileName );

					string ImageName =directoryPath + fileName;
					string fWidth =ConfigurationSettings.AppSettings["fwidth"].ToString();
					string fHight =ConfigurationSettings.AppSettings["fhight"].ToString();

					int fw =32,fh =32;
					fw = Int32.Parse(fWidth);
					fh = Int32.Parse(fHight); 

				
					objThumbnail = CreateThumbnail(ImageName,fw,fh);
					if (!(Directory.Exists(directoryPath + "ThumbNails")))
						Directory.CreateDirectory(directoryPath + "ThumbNails");
					
					objThumbnail.Save(directoryPath + "ThumbNails/" + fileName);
					objThumbnail.Dispose();  
					return true;
				}
				catch
				{
					return false;
				}
				finally
				{
					objThumbnail.Dispose(); 
				}

			}
					  

				public static string saveFile(System.Web.UI.HtmlControls.HtmlInputFile fUpload,int id )
				{
					string fileName; 
					string directoryPath="";
					Image objThumbnail=null;
					
					fileName = Path.GetFileName(fUpload.PostedFile.FileName);
					if (fileName=="")
						return "Select File";
					directoryPath = HttpContext.Current.Server.MapPath("Galleries/");
					try
					{

					if (!Directory.Exists(directoryPath)) 
					{
						Directory.CreateDirectory(directoryPath);
					}
					
						fUpload.PostedFile.SaveAs(directoryPath + fileName );

						string ImageName =directoryPath + fileName;
						string fWidth =ConfigurationSettings.AppSettings["fwidth"].ToString();
						string fHight =ConfigurationSettings.AppSettings["fhight"].ToString();

						int fw =32,fh =32;
						fw = Int32.Parse(fWidth);
						fh = Int32.Parse(fHight); 

				
						objThumbnail = CreateThumbnail(ImageName,fw,fh);
						if (!(Directory.Exists(directoryPath + "ThumbNails")))
							Directory.CreateDirectory(directoryPath + "ThumbNails");
					
						objThumbnail.Save(directoryPath + "ThumbNails/" + fileName);
						objThumbnail.Dispose(); 
						return "done here" + directoryPath ;
					}
					catch(Exception ex) 
					{
						return ex.Message.ToString() + ":" + directoryPath.ToString() ; 
					}
					finally
					{
						objThumbnail.Dispose();
						
					}

				}
					  

				public static Boolean saveFile(string fname,System.Web.UI.HtmlControls.HtmlInputFile fUpload,int imgheight,int imgWidth)
				{
					string fileName; 
					string directoryPath;
					fileName = fname;
					if (fileName=="")
						return false;

					directoryPath = HttpContext.Current.Server.MapPath(@"Galleries\");
					if (!Directory.Exists(directoryPath)) 
					{
						Directory.CreateDirectory(directoryPath);
					}
					Image objThumbnail=null;
					try
					{
				
						fUpload.PostedFile.SaveAs(directoryPath + fileName);

						string ImageName =directoryPath + fileName;
				
						int fw =32,fh =32;
						fw = imgWidth;  
						fh = imgheight;

				
						objThumbnail = CreateThumbnail(ImageName,fw,fh);
						if (!(Directory.Exists(directoryPath + "ThumbNails")))
							Directory.CreateDirectory(directoryPath + "ThumbNails");
					
						objThumbnail.Save(directoryPath + @"ThumbNails\" + fileName);
						return true;
					}
					catch 
					{
						return false;
					}
					finally
					{
						objThumbnail.Dispose(); 
					}

				}
		}
	}
