using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.UI.Windows.Common;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseUCView : UserControl, IControlView, IWinControl
	{
		#region Definição de Eventos

		[Category("Behavior"), Description("Event fired after all the form and controls are loaded.")]
		public event EventHandler LoadComplete;

		#endregion

		#region Variáveis Locais

		private IControlHelper controlHelper;
		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;
		private bool doWorkAdded;
		private bool workerCompletedAdded;
		private bool isVSDesigner = true;
		protected readonly BackgroundWorker backgroundWorker1;
		protected bool workerEnabledOnLoad;
		protected bool showProgressDlgFrm = true;
		protected ProgressDlgFrm frm;
		protected double progress;
		protected bool IsVSDesigner
		{
//			get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
			get { return isVSDesigner; }
		}

		protected delegate void DoWorkDelegate(BackgroundWorker bw, DoWorkEventArgs e);
		protected delegate void WorkerCompletedDelegate(BackgroundWorker bw, RunWorkerCompletedEventArgs e);

		#endregion

		#region Propriedades Publicas

		public IPathHelper PathHelper
		{
			get { return WinPathHelper.Instance; }
		}

		public IControlHelper ControlHelper
		{
			get { return controlHelper ?? (controlHelper = new WinControlHelper(this)); }
		}

		public IMessageHelper MessageHelper
		{
			get { return WinMessageHelper.Instance; }
		}

		public IRedirectHelper RedirectHelper
		{
			get { return WinRedirectHelper.Instance; }
		}

//		public IControlView ParentView
//		{
//			get { return (IControlView)Parent; }
//		}

		#endregion

		#region Construtor

		protected BaseUCView()
		{
			isVSDesigner = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

			InitializeComponent();

			backgroundWorker1 = new BackgroundWorker();
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;

//			ControlHelper.Initialize(this);
			WinMessageHelper.Instance.Initialize(this);

//			DoLoad();
		}

		#endregion

		#region Métodos Públicos

/*
		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}
*/

		public void Close()
		{
			if (ParentForm != null) ParentForm.Close();
		}

		public void OnLoadComplete(EventArgs e)
		{
			if (workerEnabledOnLoad)
			{
				RunWorker();
			}

			if (LoadComplete != null)
				LoadComplete(this, e);

//			DoLoadComplete();
		}

		#endregion

		#region Métodos de Eventos

		#region BackGroundWorker

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = (BackgroundWorker)sender;

			try
			{
				if (!doWorkAdded)
				{
					doWork += DoWork;
					doWorkAdded = true;
				}
				doWork(bw, e);
			}
			catch (WorkerCanceledException)
			{
			}
			finally
			{
				// If the operation was canceled by the user, 
				// set the DoWorkEventArgs.Cancel property to true.
				if (bw.CancellationPending)
				{
					e.Cancel = true;
				}
			}
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = (BackgroundWorker)sender;

			if (e.Cancelled && workerEnabledOnLoad)
			{
				if (ParentForm != null)
					ParentForm.Close();
			}

			else if (e.Error != null)
			{
				MessageBox.Show(this, e.Error.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error,
								MessageBoxDefaultButton.Button1);
				if (workerEnabledOnLoad)
					if (ParentForm != null) ParentForm.Close();
			}
			else
			{
				if (!workerCompletedAdded)
				{
					workerCompleted += WorkerCompleted;
					workerCompletedAdded = true;
				}
				workerCompleted(bw, e);
				progress = 0;
			}

			if (frm != null && frm.Visible)
			{
				frm.Close();
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProgressChanged((BackgroundWorker)sender, e);
		}

		#endregion

		#region Botões

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();

			if (showProgressDlgFrm)
				frm.btnCancelar.Enabled = false;
		}

		#endregion

		#endregion

		#region Métodos Protegidos

		#region Métodos do BackgroundWorker

		protected void RunWorker()
		{
			if (BeforeRunWorker())
			{
				backgroundWorker1.RunWorkerAsync();

				if (showProgressDlgFrm)
				{
					frm = ProgressDlgFrm.Show(ParentForm);
					frm.btnCancelar.Click += frmProgresso_BtnCancelar_OnClick;
				}
			}
		}

		protected void AddDoWork(DoWorkDelegate worker)
		{
			doWork += worker;
		}

		protected void RemoveDoWork(DoWorkDelegate worker)
		{
			doWork -= worker;
		}

		protected void AddWorkerCompleted(WorkerCompletedDelegate completed)
		{
			workerCompleted += completed;
		}

		protected void RemoveWorkerCompleted(WorkerCompletedDelegate completed)
		{
			workerCompleted -= completed;
		}

		protected void StepProgress(BackgroundWorker bw, double step)
		{
			progress += step;

			SetProgress(bw, progress);
		}

		protected void SetProgress(BackgroundWorker bw, double value)
		{
			progress = value;

			if (bw.CancellationPending)
				throw new WorkerCanceledException();

			bw.ReportProgress((int)progress);
		}

		#endregion

		#region Métodos Úteis (Virtuais)

		protected virtual bool BeforeRunWorker()
		{
			return true;
		}

		protected virtual void AfterRunWorker()
		{
		}

		protected virtual void DoWork(BackgroundWorker bw, DoWorkEventArgs e)
		{
		}

		protected virtual void WorkerCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e)
		{
		}

		protected virtual void ProgressChanged(BackgroundWorker bw, ProgressChangedEventArgs e)
		{
			if (showProgressDlgFrm)
				frm.Progress = e.ProgressPercentage;
		}

		#endregion

		#endregion

	}
}
