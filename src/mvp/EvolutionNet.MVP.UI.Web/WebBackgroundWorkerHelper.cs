using System;
using System.ComponentModel;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	// TODO: Implementar
	public class WebBackgroundWorkerHelper : IBackgroundWorkerHelper
	{
		#region Local Attributes

		private DoWorkDelegate doWorkDelegate;

		private BaseProgressUC progressUC;
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

		#region Public Properties

		public BaseProgressUC ProgressUC
		{
			get { return progressUC; }
			set { progressUC = value; }
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

//			if (progressUC != null && progressUC.Visible)
//				progressUC.StopTimeDisplay();

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

			if (progressUC != null && progressUC.Visible)
				progressUC.Close();

			backgroundWorker.Dispose();
		}

		private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (progressUC != null && progressUC.Visible)
				progressUC.Progress = e.ProgressPercentage;
		}

		private void progressUC_CancelButton_Clicked(object sender, EventArgs e)
		{
			backgroundWorker.CancelAsync();

			progressUC.CancelEnabled = false;
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
			progressUC.Show();

			progressUC.CancelEnabled = suportsCancellation;
			progressUC.CancelButtonClick += progressUC_CancelButton_Clicked;
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