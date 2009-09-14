
using System.Windows.Forms;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class ModalDialogUC : BaseUC
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
