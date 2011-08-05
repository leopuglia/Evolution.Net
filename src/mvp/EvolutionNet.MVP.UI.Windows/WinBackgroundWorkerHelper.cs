using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows.Common;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinBackgroundWorkerHelper : BaseSingleton<WinBackgroundWorkerHelper>, IBackgroundWorkerHelper
	{
		private IWinControl view;
		private bool workerEnabledOnLoad;
		private bool showProgressDlgFrm;
		private BackgroundWorker backgroundWorker1;

		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;
		private ProgressDlgFrm frm;
		private bool doWorkAdded;
		private bool workerCompletedAdded;
		private double progress;

		#region Contructor

/*
		public WinBackgroundWorkerHelper(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			Initialize(view, workerEnabledOnLoad, showProgressDlgFrm);
		}
*/

		#endregion

		#region Thread Safe "Singleton"

/*
		// This is not exactly a singleton, but has to be created from a static method
		public static WinBackgroundWorkerHelper CreateInstance(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			return Nested.CreateLocalInstance(view, workerEnabledOnLoad, showProgressDlgFrm);
		}

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static WinBackgroundWorkerHelper CreateLocalInstance(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
			{
				return new WinBackgroundWorkerHelper(view, workerEnabledOnLoad, showProgressDlgFrm);
			}
		}
*/

		#endregion

		#region Event Methods

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

		//TODO: Revisar esse método com uso real! Verificar se realmente preciso da variável workerEnabledOnLoad...
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = (BackgroundWorker)sender;

			if (e.Cancelled && workerEnabledOnLoad)
			{
				view.Close();
			}

			else if (e.Error != null)
			{
				view.HelperFactory.MessageHelper.ShowErrorMessage("Error", e.Error.Message);

				if (workerEnabledOnLoad)
					view.Close();
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

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();

			if (showProgressDlgFrm)
				frm.btnCancelar.Enabled = false;
		}

		#endregion

		#region Public Methods

		public void Initialize(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm)
		{
			//TODO: Atenção aqui neste CAST, não foi testado
			this.view = (IWinControl)view;
			this.workerEnabledOnLoad = workerEnabledOnLoad;
			this.showProgressDlgFrm = showProgressDlgFrm;

			backgroundWorker1 = new BackgroundWorker();
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
		}

		public void RunWorker()
		{
			if (BeforeRunWorker())
			{
				backgroundWorker1.RunWorkerAsync();

				if (showProgressDlgFrm)
				{
					frm = ProgressDlgFrm.Show(((Control)view).FindForm());
					frm.btnCancelar.Click += frmProgresso_BtnCancelar_OnClick;
				}
			}
		}

		public void AddDoWork(DoWorkDelegate worker)
		{
			doWork += worker;
		}

		public void RemoveDoWork(DoWorkDelegate worker)
		{
			doWork -= worker;
		}

		public void AddWorkerCompleted(WorkerCompletedDelegate completed)
		{
			workerCompleted += completed;
		}

		public void RemoveWorkerCompleted(WorkerCompletedDelegate completed)
		{
			workerCompleted -= completed;
		}

		public void StepProgress(BackgroundWorker bw, double step)
		{
			progress += step;

			SetProgress(bw, progress);
		}

		public void SetProgress(BackgroundWorker bw, double value)
		{
			progress = value;

			if (bw.CancellationPending)
				throw new WorkerCanceledException();

			bw.ReportProgress((int)progress);
		}

		#endregion

		#region Public Virtual Methods (Hooks)

		public virtual bool BeforeRunWorker()
		{
			return true;
		}

		public virtual void AfterRunWorker()
		{
		}

		public virtual void DoWork(BackgroundWorker bw, DoWorkEventArgs e)
		{
		}

		public virtual void WorkerCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e)
		{
		}

		public virtual void ProgressChanged(BackgroundWorker bw, ProgressChangedEventArgs e)
		{
			if (showProgressDlgFrm)
				frm.Progress = e.ProgressPercentage;
		}

		#endregion

	}
}