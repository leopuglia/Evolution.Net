using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows.Common;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Windows
{
	//TODO: Fazer ainda mais um refactoring nessa classe, pra utilizar a interface IProgress e, possivelmente, o ProgressReportHelper
	public class WinBackgroundWorkerHelper : BaseSingleton<WinBackgroundWorkerHelper>, IBackgroundWorkerHelper
	{
		#region Local Attributes

		private BackgroundWorker backgroundWorker;

		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;

		private IWinControl view;
		private bool workerEnabledOnLoad;
		private bool showProgressDlgFrm;
		
		private static ProgressDlgFrm frm;
		private bool doWorkAdded;
		private bool workerCompletedAdded;
		private int progress;
		private IBackgroundWorkerControl backgroundWorkerView;

		private string caption;
		private string text;

		#endregion

		#region Event Definition

//		public event EventHandler<ProgressChangedEventArgs> ProgressReported;
		public event EventHandler WorkerCanceled;

		#endregion

		#region Public Properties

		public DoWorkDelegate DoWork
		{
			get { return doWork; }
			set { doWork = value; }
		}

		public WorkerCompletedDelegate WorkerCompleted
		{
			get { return workerCompleted; }
			set { workerCompleted = value; }
		}

		// Aten��o: essas duas propriedades devem ser setadas antes da chamada do BackgroundWorker;
		public string Caption
		{
			set { caption = value; }
		}

		public string Text
		{
			set { text = value; }
		}

		#endregion

		#region Event Methods

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = (BackgroundWorker)sender;

			try
			{
				if (!doWorkAdded)
				{
					doWork += backgroundWorkerView.DoBackgroundWork;
					doWorkAdded = true;
				}
				doWork(bw, e);
			}
			catch (WorkerCanceledException)
			{
//				if (WorkerCanceled != null)
//					WorkerCanceled(this, new EventArgs());
			}
			finally
			{
				// If the operation was canceled by the user, 
				// set the DoWorkEventArgs.Cancel property to true.
				if (bw.CancellationPending)
				{
					e.Cancel = true;

					if (WorkerCanceled != null)
						WorkerCanceled(this, new EventArgs());
				}
			}
		}

		//TODO: Revisar esse m�todo com uso real! Verificar se realmente preciso da vari�vel workerEnabledOnLoad...
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = (BackgroundWorker)sender;

			if (workerEnabledOnLoad && (e.Cancelled || e.Error != null)) 
				view.Close();

			if (frm != null && frm.Visible)
				frm.StopTimeDisplay();

			if (!workerCompletedAdded)
			{
				workerCompleted += backgroundWorkerView.BackgroundWorkCompleted;
				workerCompletedAdded = true;
			}
			workerCompleted(bw, e);
			progress = 0;

			if (frm != null && frm.Visible)
			{
				frm.Close();
			}
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			OnProgressChanged(e);
		}

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker.CancelAsync();

			if (showProgressDlgFrm)
				frm.btnCancelar.Enabled = false;
		}

		#endregion

		#region Public Methods

		public void Initialize(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			if (workerEnabledOnLoad)
				DoRunWorker(view, true, showProgressDlgFrm);
			else
				DoInitialize(view, false, showProgressDlgFrm);
		}

		public void RunWorker(IControlView view, bool showProgressDlgFrm)
		{
			DoRunWorker(view, false, showProgressDlgFrm);
		}

		public void ReportProgressStep(int step)
		{
			progress += step;

			ReportProgress(progress);
		}

		public void ReportProgress(int value)
		{
			progress = value;

			if (backgroundWorker.CancellationPending)
				throw new WorkerCanceledException();

			backgroundWorker.ReportProgress(progress);
		}

		#endregion

		#region Private Methods

		private void DoInitialize(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			this.view = (IWinControl)view;
			backgroundWorkerView = (IBackgroundWorkerControl)view;

			this.workerEnabledOnLoad = workerEnabledOnLoad;
			this.showProgressDlgFrm = showProgressDlgFrm;

//			if (backgroundWorker == null)
//			{
			backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;
			backgroundWorker.DoWork += backgroundWorker_DoWork;
			backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
			backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
//			}
		}

		private void DoRunWorker(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			DoInitialize(view, workerEnabledOnLoad, showProgressDlgFrm);

			if (backgroundWorkerView.BeforeRunWorker())
			{
				backgroundWorker.RunWorkerAsync();

				if (showProgressDlgFrm)
				{
					frm = ProgressDlgFrm.Show(((Control)view).FindForm(), caption, text);
					frm.btnCancelar.Click += frmProgresso_BtnCancelar_OnClick;
				}
			}
		}

		private void OnProgressChanged(ProgressChangedEventArgs e)
		{
			if (showProgressDlgFrm)
				frm.Progress = e.ProgressPercentage;

//			if (ProgressReported != null)
//				ProgressReported(sender, e);
		}

		#endregion

	}
}