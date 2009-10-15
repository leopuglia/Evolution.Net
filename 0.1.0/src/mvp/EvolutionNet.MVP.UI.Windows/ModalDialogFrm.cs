
namespace EvolutionNet.MVP.UI.Windows
{
	public partial class ModalDialogFrm : BaseFrm
	{
		public ModalDialogFrm()
		{
			InitializeComponent();
		}

        private void ModalDialogFrm_Load(object sender, System.EventArgs e)
        {
        }

        private void ModalDialogFrm_AfterLoad(object sender, System.EventArgs e)
        {
            AcceptButton = ((ModalDialogUC)baseUC).btnOK;
            CancelButton = ((ModalDialogUC)baseUC).btnCancelar;
        }
	}
}