using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class CategoryEditDlg : ModalFrmView
	{
		public CategoryEditDlg(Category category)
		{
			InitializeComponent();

			baseUC = categoryEditUC1;
			categoryEditUC1.Model = category;
		}
	}
}
