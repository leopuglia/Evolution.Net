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

		public CategoryEditUC()
		{
			InitializeComponent();
		}
		
		public Category Model
		{
			get
			{
				model.CategoryName = txtName.Text;
				model.Description = txtDescription.Text;
				model.PictureImage = imgPicture.Image;

				return model;
			}
			set
			{
				model = value;

				if (model.ID != 0)
				{
					txtName.Text = model.CategoryName;
					txtDescription.Text = model.Description;
					imgPicture.Image = model.PictureImage;
				}
			}
		}

		private void btnBrowsePicture_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				Bitmap img = (Bitmap) Bitmap.FromFile(openFileDialog1.FileName);
				imgPicture.Image =
					ImageProcessing.Resize(img, new Size(imgPicture.Width, imgPicture.Height));
			}
		}
	}
}
