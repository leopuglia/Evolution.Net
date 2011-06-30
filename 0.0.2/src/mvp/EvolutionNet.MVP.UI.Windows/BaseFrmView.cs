using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseFrmView : Form, IControlView, IWinControl
	{
		#region Variáveis Locais

		private bool isInitialized;
		protected BaseUCView baseUC;
//		protected BaseMessageUC messageUC;

		#endregion

		#region Definição de Eventos

		[Category("Behavior"), Description("Event fired after all the controls are loaded.")]
		public event EventHandler LoadComplete;

		#endregion

		#region Propriedades Públicas

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Construtor

		protected BaseFrmView()
		{
			InitializeComponent();

//			ControlHelper.Initialize(this);
			// O WinMessageHelper Helper é um singleton, então deve existir apenas uma instância dele.
			// Portanto, ele só deve ser inicializado uma vez!
			// TODO: Estou inicializando no BaseUCView, portanto todos os Presenter's devem ser feitos com WebControls
//			WinMessageHelper.Instance.Initialize(this);

//			DoLoad();
		}

		#endregion

		#region Implementação de Eventos

		private void BaseFrm_Activated(object sender, EventArgs e)
		{
			if (!isInitialized)
			{
				isInitialized = true;

				if (LoadComplete != null)
					LoadComplete(this, e);

				if (baseUC != null)
					baseUC.OnLoadComplete(e);
			}

//			DoLoadComplete();
		}

		#endregion

		#region Métodos Públicos (IControlView)

/*
		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}
*/

		#endregion

	}
}
