using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using AjaxControlToolkit;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Sample.UI.Web.Base;
using EvolutionNet.Util.Imaging;

namespace EvolutionNet.Sample.UI.Web
{
	public partial class CategoryEditUC : BaseSampleView, ICategoryEditView
	{
		private const string UploadTempPath = "Uploads";

		private CategoryCrudPresenter presenter;
		private Category model = new Category();

		#region Local Properties

		// I use this property to save the Image uploaded to the Session (the ViewState doesn't work on this page)
		// TODO: descobrir porque o ViewState não funciona no edit view
		private Image img
		{
			get { return (Image)Session["Img"]; }
			set { Session["Img"] = value; }
		}

		#endregion

		#region Public Properties

		// This method exists to get a reference to the presenter, set on the CategoryCrudView
		public CategoryCrudPresenter Presenter
		{
			set { presenter = value; }
		}

		public int ModelID
		{
			get { return Session["ModelID"] == null ? 0 : (int)Session["ModelID"]; }
			set { Session["ModelID"] = value; }
		}

		public Category Model
		{
			get
			{
				model.ID = ModelID;
				model.CategoryName = TxtCategoryName.Text;
				model.Description = TxtDescription.Text;
				model.PictureImage = img;

				return model;
			}
			set
			{
				model = value;

				if (model.ID != 0)
				{
					ModelID = model.ID;
					TxtCategoryName.Text = model.CategoryName;
					TxtDescription.Text = model.Description;
					img = model.PictureImage;

					ImgFilePicture.ImageUrl = "CategoryImageReadHandlerView.ashx?ID=" + model.ID;
				}
			}
		}

		#endregion

		#region Event Methods

		// TODO: Aqui ou eu crio um edit presenter, que pode servir só pra chamar o crud presenter
		// Ou defino eventos que serão implementados pelo presenter, ou coisa do gênero
		// No método CreateModalDialog, eu posso usar o CrudView pra retornar o EditView
		protected void Page_Load(object sender, EventArgs e)
		{
			// This method sets the focus to the TxtCategoryName when the popup is shown, using the client ID of the PopupExtender and of the TextBox
			SetFocusJavascript(UpdatePanelEdit, "ModalPopupNew", TxtCategoryName.ClientID);

			// This methods show the Image when its uploaded
			RegisterControlOnClientStartup("imgFilePicture", ImgFilePicture.ClientID);
			RegisterStartupScript(UpdatePanelEdit, "UploadComplete", @"
				function UploadComplete(sender, args) {
					//var imgFilePicture = $get('imgFilePicture');
					//var imgFilePicture = document.getElementById('imgFilePicture');
					imgFilePicture.src = '/" + UploadTempPath + @"/' + args.get_fileName();
				}");
		}

		protected void BtnSave_Click(object sender, EventArgs e)
		{
			presenter.Save();
		}

		protected void BtnCancel_Click(object sender, EventArgs e)
		{
			presenter.Clear();
		}

		protected void FilePicture_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
		{
			var i = 0;
			while (!filePicture.HasFile && i < 50)
			{
				Thread.Sleep(100);
				i++;
			}

			// TODO: Mover isso para o Presenter/BO?
			string relativeFileName = "~/" + UploadTempPath + "/" + e.FileName;
			if (filePicture.HasFile)
			{
				Bitmap bmp = (Bitmap)Bitmap.FromStream(filePicture.PostedFile.InputStream);
				bmp = ImageProcessing.Resize(bmp, new Size(160, 120));
				SaveImageTemp(bmp, relativeFileName);
			}
		}

		#endregion

		#region Public Methods

		// TODO: Ver direitinho em qual interface esse método deve ficar
		public void Clear()
		{
//			model = new Category();

			ModelID = 0;
			TxtCategoryName.Text = "";
			TxtDescription.Text = "";
//			imgPath = "";
			img = null;
			ImgFilePicture.ImageUrl = "";
		}

		#endregion

		#region Local Methods

		private void SaveImageTemp(Bitmap img, string relativeFileName)
		{
			string fileName = MapPath(relativeFileName);
			img.Save(fileName, ImageFormat.Jpeg);

			this.img = img;
		}

//		private Image GetImageFromPath(string fileName)
//		{
//			return new Bitmap(fileName);
//		}

		#endregion
	}
}