using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryEditDlg : ModalFrmView
	{
		public CategoryEditDlg(Category category)
		{
			InitializeComponent();

			baseUC = categoryEditView1;
			categoryEditView1.Model = category;
		}
	}
}
