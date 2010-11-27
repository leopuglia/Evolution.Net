
using System.Windows.Forms;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class ModalDialogUC : BaseUCView
	{
		#region Construtor

		public ModalDialogUC() : this(null)
		{
		}

		public ModalDialogUC(Form parent) : base(parent)
		{
			InitializeComponent();
		}

		#endregion

	}
}
