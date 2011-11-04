using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Services;
using EvolutionNet.MVP.UI.Web;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;

namespace EvolutionNet.Sample.UI.Web
{
	/// <summary>
	/// Summary description for CategoryImageReadHandlerView
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class CategoryImageReadHandlerView : BaseHandlerView, ICategoryImageReadView
	{
		private HttpContext context;
//		private int modelID;

/*
		public int ModelID
		{
			get
			{
				modelID = int.Parse(context.Request.QueryString["ID"]);
				return modelID;
			}
			set { modelID = value; }
		}
*/

		private Category model = new Category();
		public Category Model
		{
			get
			{
				model.ID = int.Parse(context.Request.QueryString["ID"]);
				return model;
			}
			set { model = value; }
		}

		public event EventHandler AfterLoadComplete;

		public void OnAfterLoadComplete(EventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void ProcessRequest(HttpContext context)
		{
			this.context = context;

			var presenter = new CategoryImageReadPresenter(this);
			presenter.Find();

			if (Model.PictureImage != null)
			{
				if (Model.PictureImage.RawFormat == ImageFormat.Bmp)
					context.Response.ContentType = "image/bmp";
				else if (Model.PictureImage.RawFormat == ImageFormat.Emf)
					context.Response.ContentType = "image/emf";
				else if (Model.PictureImage.RawFormat == ImageFormat.Exif)
					context.Response.ContentType = "image/exif";
				else if (Model.PictureImage.RawFormat == ImageFormat.Gif)
					context.Response.ContentType = "image/gif";
				else if (Model.PictureImage.RawFormat == ImageFormat.Icon)
					context.Response.ContentType = "image/icon";
				else if (Model.PictureImage.RawFormat == ImageFormat.Jpeg)
					context.Response.ContentType = "image/jpeg";
				else if (Model.PictureImage.RawFormat == ImageFormat.MemoryBmp)
					context.Response.ContentType = "image/bmp";
				else if (Model.PictureImage.RawFormat == ImageFormat.Png)
					context.Response.ContentType = "image/png";
				else if (Model.PictureImage.RawFormat == ImageFormat.Tiff)
					context.Response.ContentType = "image/tiff";
				else if (Model.PictureImage.RawFormat == ImageFormat.Wmf)
					context.Response.ContentType = "image/wmf";
				else
				{
					context.Response.ContentType = "image/bmp";

					Bitmap bmp = new Bitmap(Model.PictureImage);
					bmp.Save(context.Response.OutputStream, ImageFormat.Bmp);

					context.Response.Flush();

					return;
				}

				context.Response.BinaryWrite(Model.Picture);
				context.Response.Flush();
			}
		}

		public override bool IsReusable
		{
			get { return false; }
		}

	}
}
