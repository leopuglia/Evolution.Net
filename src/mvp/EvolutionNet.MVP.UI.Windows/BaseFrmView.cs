using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseFrmView : Form, IControlView, IWinControl
	{
		private bool isInitialized;
		protected BaseUCView baseUC;

		#region Event Definition

		[Category("Behavior"), Description("Event fired after all the controls are loaded.")]
		public event EventHandler LoadComplete;

		#endregion

		#region Public Properties

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Constructor

		protected BaseFrmView()
		{
			InitializeComponent();

			//TODO: Aqui eu tenho que colocar um Setting pra decidir se vai usar UserControl's (UserControl as View) ou não. Se não for utilizar (Form as View), preciso inicializar o ControlHelper aqui. Deve ser inicializado apenas uma vez, pois é um "singleton".
//			WinMessageHelper.Instance.Initialize(this);
		}

		#endregion

		#region Event Calling

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
		}

		#endregion

	}
}
