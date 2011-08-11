using System;
using System.Drawing;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.Imaging;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryEditUC : BaseUCView, ICategoryEditView
	{
		private Category model = new Category();
		private int modelID;

		#region Public Properties

		public CategoryEditUC()
		{
			InitializeComponent();
		}

		public int ModelID
		{
			get { return modelID; }
			set { modelID = value; }
		}

		public Category Model
		{
			get
			{
				model.CategoryName = TxtCategoryName.Text;
				model.Description = TxtDescription.Text;
				model.PictureImage = ImgPicture.Image;

				return model;
			}
			set
			{
				model = value;

				if (model.ID != 0)
				{
					modelID = model.ID;
					TxtCategoryName.Text = model.CategoryName;
					TxtDescription.Text = model.Description;
					ImgPicture.Image = model.PictureImage;
				}
			}
		}

		#endregion

		#region Public Methods

		public void Clear()
		{
			modelID = 0;
			TxtCategoryName.Text = "";
			TxtDescription.Text = "";
			ImgPicture.Image = null;
		}

		#endregion

		#region Event Methods

		private void BtnBrowsePicture_Click(object sender, EventArgs e)
		{
			if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				// TODO: Mover para o BO
				Bitmap img = (Bitmap) Bitmap.FromFile(OpenFileDialog1.FileName);
				ImgPicture.Image =
					ImageProcessing.Resize(img, new Size(160, 120));
			}
		}

		#endregion
	}
}
