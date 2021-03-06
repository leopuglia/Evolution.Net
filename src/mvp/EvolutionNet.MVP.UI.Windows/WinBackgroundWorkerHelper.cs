using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinBackgroundWorkerHelper : IBackgroundWorkerHelper
	{
		#region Local Attributes

		private DoWorkDelegate doWorkDelegate;

		private ProgressDlgFrm frm;
		private BackgroundWorker backgroundWorker;
		private IBackgroundWork backgroundWork;

		private bool suportsCancellation;
		private bool doWorkAdded;
		private int progress;

		#endregion

		#region Event Definition

		public event EventHandler<CancelEventArgs> BeforeRunWorker;
		public event EventHandler WorkerCanceled;
		public event EventHandler<WorkerErrorEventArgs> WorkerError;
		public event EventHandler WorkerCompleted;

		#endregion

//		protected WinBackgroundWorkerHelper() {}

		#region Public Properties

		public ProgressDlgFrm ProgressForm
		{
			get { return frm; }
			set { frm = value; }
		}

		public DoWorkDelegate DoWorkDelegate
		{
			get { return doWorkDelegate; }
			set
			{
				doWorkAdded = true;
				doWorkDelegate = value;
			}
		}

		public bool SuportsCancellation
		{
			get { return suportsCancellation; }
			set { suportsCancellation = value; }
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
					doWorkDelegate += backgroundWork.DoBackgroundWork;
					doWorkAdded = true;
				}
				doWorkDelegate();
			}
			catch (WorkerCanceledException)
			{
				// This exception is throw only to stop the execution of the method delegated to doWorkDelegate
			}
			finally
			{
				// If the operation was canceled by the user, 
				// set the DoWorkEventArgs.Cancel property to true.
				if (bw.CancellationPending)
					e.Cancel = true;
			}
		}

		// TODO: Revisar esse método com uso real! Verificar se realmente preciso da variável workerEnabledOnLoad...
		private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
//			BackgroundWorker bw = (BackgroundWorker)sender;

			if (frm != null && frm.Visible)
				frm.StopTimeDisplay();

			if (e.Cancelled)
			{
				if (WorkerCanceled != null)
					WorkerCanceled(this, new EventArgs());
			}
			else if (e.Error != null)
			{
				if (WorkerError != null)
					WorkerError(this, new WorkerErrorEventArgs(e.Error));
			}
			else
			{
				if (WorkerCompleted != null)
					WorkerCompleted(this, new EventArgs());
			}

			progress = 0;

			if (frm != null && frm.Visible)
				frm.Close();

			backgroundWorker.Dispose();
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (frm != null && frm.Visible)
				frm.Progress = e.ProgressPercentage;
		}

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker.CancelAsync();

			frm.btnCancelar.Enabled = false;
		}

		#endregion

		#region Public Methods

		public void RunWorker(IBackgroundWork backgroundWork)
		{
			this.backgroundWork = backgroundWork;

			backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;
			backgroundWorker.DoWork += backgroundWorker_DoWork;
			backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
			backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;

			if (BeforeRunWorker != null)
			{
				CancelEventArgs e = new CancelEventArgs();
				BeforeRunWorker(this, e);

				if (e.Cancel)
					return;
			}

			backgroundWorker.RunWorkerAsync();
		}

		public void RunWorkerWithProgressDialog(IBackgroundWork backgroundWork, IControlView view, string caption, string text)
		{
			RunWorker(backgroundWork);
			ShowProgressDialog(view, caption, text);
		}

		public void ShowProgressDialog(IControlView view, string caption, string text)
		{
			frm = ProgressDlgFrm.Show(((Control)view).FindForm(), caption, text);

			frm.btnCancelar.Visible = suportsCancellation;
			frm.btnCancelar.Click += frmProgresso_BtnCancelar_OnClick;
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

	}
}