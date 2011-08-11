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
				model.CategoryName = txtCategoryName.Text;
				model.Description = txtDescription.Text;
				model.PictureImage = imgPicture.Image;

				return model;
			}
			set
			{
				model = value;

				if (model.ID != 0)
				{
					modelID = model.ID;
					txtCategoryName.Text = model.CategoryName;
					txtDescription.Text = model.Description;
					imgPicture.Image = model.PictureImage;
				}
			}
		}

		public void Clear()
		{
//			model = new Category();

			txtCategoryName.Text = "";
			txtDescription.Text = "";
			imgPicture.Image = null;
		}

		private void btnBrowsePicture_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				//TODO: Mover para o BO
				Bitmap img = (Bitmap) Bitmap.FromFile(openFileDialog1.FileName);
				imgPicture.Image =
					ImageProcessing.Resize(img, new Size(imgPicture.Width, imgPicture.Height));
			}
		}
	}
}
