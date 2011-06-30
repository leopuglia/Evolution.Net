using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryEditView : BaseUCView, ICategoryEditView
	{
		private Category model = new Category();

		public CategoryEditView()
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
	}
}
