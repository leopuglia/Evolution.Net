/*
 * Based on Lev Danielyan's article at http://www.codeproject.com/KB/graphics/exiftagcol.aspx.
 * His article is based on Asim Goheer's article at http://www.codeproject.com/KB/graphics/exifextractor.aspx
 */

using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;

namespace EvolutionNet.Util.Web
{
	public class MultipleFileUpload : Control
	{
		private const string FLASH_SWF = "EvolutionNet.Util.Web.FlashFileUpload.swf";

		#region Public Properties

		[Category("Behavior")]
		[Description("The page to upload files to.")]
		[DefaultValue("")]
		public string UploadPage
		{
			get
			{
				object o = ViewState["UploadPage"];
				return o == null ? "" : o.ToString();
			}
			set { ViewState["UploadPage"] = value; }
		}

		[Category("Behavior")]
		[Description("Query Parameters to pass to the Upload Page.")]
		[DefaultValue("")]
		public string QueryParameters
		{
			get
			{
				object o = ViewState["QueryParameters"];
				return o == null ? "" : o.ToString();
			}
			set { ViewState["QueryParameters"] = value; }
		}

		[Category("Behavior")]
		[Description("Javascript function to call when all files are uploaded.")]
		[DefaultValue("")]
		public string OnUploadComplete
		{
			get
			{
				object o = ViewState["OnUploadComplete"];
				return o == null ? "" : o.ToString();
			}
			set { ViewState["OnUploadComplete"] = value; }
		}

		[Category("Behavior")]
		[Description("The maximum file size that can be uploaded, in bytes (0 for no limit).")]
		public decimal UploadFileSizeLimit
		{
			get
			{
				object o = ViewState["UploadFileSizeLimit"];
				return o == null ? 0 : (decimal) o;
			}
			set { ViewState["UploadFileSizeLimit"] = value; }
		}

		[Category("Behavior")]
		[Description("The total number of bytes that can be uploaded (0 for no limit).")]
		public decimal TotalUploadSizeLimit
		{
			get
			{
				object o = ViewState["TotalUploadSizeLimit"];
				return o == null ? 0 : (decimal) o;
			}
			set { ViewState["TotalUploadSizeLimit"] = value; }
		}

		[Category("Behavior")]
		[Description("The description of file types that you want uploads restricted to (ex. Images (*.JPG;*.JPEG;*.JPE;*.GIF;*.PNG;))")]
		[DefaultValue("")]
		public string FileTypeDescription
		{
			get
			{
				object o = ViewState["FileTypeDescription"];
				return o == null ? "" : o.ToString();
			}
			set { ViewState["FileTypeDescription"] = value; }
		}

		[Category("Behavior")]
		[Description("The file types to restrict uploads to (ex. *.jpg; *.jpeg; *.jpe; *.gif; *.png;)")]
		[DefaultValue("")]
		public string FileTypes
		{
			get
			{
				object o = ViewState["FileTypes"];
				return o == null ? "" : o.ToString();
			}
			set { ViewState["FileTypes"] = value; }
		}

		#endregion

		#region Overriden Methods

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Page.Form.Enctype = "multipart/form-data";
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);

			if (GetType().Assembly.GetManifestResourceInfo(FLASH_SWF) == null)
				throw new ApplicationException(string.Format("The specified resource {0} doesn't exist", FLASH_SWF));

			string url = Page.ClientScript.GetWebResourceUrl(GetType(), FLASH_SWF);
			string obj = string.Format("<object classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\"" +
									   "codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0\"" +
									   "width=\"575\" height=\"375\" id=\"fileUpload\" align=\"middle\">" +
									   "<param name=\"allowScriptAccess\" value=\"sameDomain\" />" +
									   "<param name=\"movie\" value=\"{0}\" />" +
									   "<param name=\"quality\" value=\"high\" />" +
									   "<param name=\"wmode\" value=\"transparent\">" +
									   "<param name=FlashVars value='{3}{4}{5}{6}{7}&uploadPage={1}?{2}'>" +
									   "<embed src=\"{0}\"" +
									   "FlashVars='{3}{4}{5}{6}{7}&uploadPage={1}?{2}'" +
									   "quality=\"high\" wmode=\"transparent\" width=\"575\" height=\"375\" " +
									   "name=\"fileUpload\" align=\"middle\" allowScriptAccess=\"sameDomain\" " +
									   "type=\"application/x-shockwave-flash\" " +
									   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />" +
									   "</object>", 
									   url, 
									   ResolveUrl(UploadPage),
									   HttpContext.Current.Server.UrlEncode(QueryParameters), 
//									   QueryParameters,
									   string.IsNullOrEmpty(OnUploadComplete) ? "" : "&completeFunction=" + OnUploadComplete,
									   string.IsNullOrEmpty(FileTypes) ? "" : "&fileTypes=" + HttpContext.Current.Server.UrlEncode(FileTypes),
									   string.IsNullOrEmpty(FileTypeDescription) ? "" : "&fileTypeDescription=" + HttpContext.Current.Server.UrlEncode(FileTypeDescription),
									   TotalUploadSizeLimit > 0 ? "&totalUploadSize=" + TotalUploadSizeLimit : "",
									   UploadFileSizeLimit > 0 ? "&fileSizeLimit=" + UploadFileSizeLimit : ""
				);
			writer.Write(obj);
		}

		#endregion
	}
}