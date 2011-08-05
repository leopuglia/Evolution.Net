using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseUCView : UserControl, IWinControl, IBackgroundWorkerControl
	{
		#region Local Attributes

		private readonly bool isVSDesigner = true;

		//TODO: Essas variáveis existem pra inicializar, ou não, o backgroundworker no OnLoadComplete. 
		// Provavelmente essas definições devem ser feitas de uma outra maneira, talvez decorando a classe com atributos. 
		// Isso é um tipo de configuração, mas deve ser feita em view, pois eu posso querer utilizar, ou não, o BackgroundWorker.
		// Deixei o padrão como false
		protected bool workerEnabledOnLoad;
		protected bool showProgressDlgFrm;

		protected bool IsVSDesigner
		{
//			get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
			get { return isVSDesigner; }
		}

		#endregion

		#region Event Defitition

		[Category("Behavior"), Description("Event fired after all the form and controls are loaded.")]
		public event EventHandler LoadComplete;

		#endregion

		#region Public Properties

		public IHelperFactory HelperFactory
		{
			get { return AbstractIoCFactory<IHelperFactory>.Instance; }
		}

		#endregion

		#region Constructor

		protected BaseUCView()
		{
			isVSDesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

			InitializeComponent();

			WinMessageHelper.Instance.Initialize(this);
		}

		#endregion

		#region Public Methods

		public void Close()
		{
			if (ParentForm != null) ParentForm.Close();
		}

		public void OnLoadComplete(EventArgs e)
		{
			//TODO: ATENÇÃO: variável workerEnabledOnLoad setada em uma classe-filha só executará o Worker caso a view seja um controle
			if (workerEnabledOnLoad)
			{
				WinBackgroundWorkerHelper.Instance.Initialize(this, workerEnabledOnLoad, showProgressDlgFrm);
//				WinBackgroundWorkerHelper.Instance.RunWorker(this, showProgressDlgFrm);
//				HelperFactory.BackgroundWorkerHelper.Initialize(workerEnabledOnLoad, showProgressDlgFrm);
//				HelperFactory.BackgroundWorkerHelper.RunWorker(this);
			}

			if (LoadComplete != null)
				LoadComplete(this, e);

			EvokeLoadCompleteOnChild(Controls, e);
		}

		#endregion

		#region Public Virtual Methods (IBackgroundWorkerControl)

		public virtual bool BeforeRunWorker()
		{
			return true;
		}

		public virtual void AfterRunWorker()
		{
		}

		public virtual void DoBackgroundWork(BackgroundWorker bw, DoWorkEventArgs e)
		{
		}

		public virtual void BackgroundWorkCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e)
		{
		}

		#endregion

		#region Métodos Auxiliares

		private void EvokeLoadCompleteOnChild(ControlCollection controls, EventArgs e)
		{
			foreach (Control control in controls)
			{
				var view = control as BaseUCView;
				if (view != null && view.LoadComplete != null)
					view.LoadComplete(view, e);

				if (control.Controls.Count != 0)
					EvokeLoadCompleteOnChild(control.Controls, e);
			}
		}

		#endregion

	}
}
