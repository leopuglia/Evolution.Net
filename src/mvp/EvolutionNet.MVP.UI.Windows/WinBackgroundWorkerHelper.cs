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
	public class WinBackgroundWorkerHelper : BaseSingleton<WinBackgroundWorkerHelper>, IBackgroundWorkerHelper
	{
		private BackgroundWorker backgroundWorker;

		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;

		private IWinControl view;
		private bool workerEnabledOnLoad;
		private bool showProgressDlgFrm;
		
		private ProgressDlgFrm frm;
		private bool doWorkAdded;
		private bool workerCompletedAdded;
		private double progress;
		private IBackgroundWorkerControl backgroundWorkerView;

		#region Event Definition

		public event EventHandler<ProgressChangedEventArgs> ProgressChanged;

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
			OnProgressChanged(sender, e);
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
			this.workerEnabledOnLoad = workerEnabledOnLoad;

			if (workerEnabledOnLoad)
				RunWorker(view, showProgressDlgFrm);
			else
				DoInitialize(view, showProgressDlgFrm);
		}

		public void RunWorker(IControlView view, bool showProgressDlgFrm)
		{
			DoInitialize(view, showProgressDlgFrm);

			if (backgroundWorkerView.BeforeRunWorker())
			{
				backgroundWorker.RunWorkerAsync();

				if (showProgressDlgFrm)
				{
					frm = ProgressDlgFrm.Show(((Control)view).FindForm());
					frm.btnCancelar.Click += frmProgresso_BtnCancelar_OnClick;
				}
			}
		}

/*
		// Excluí esses métodos, pois coloquei os delegates como públicos, assim posso adicionar ou remover métodos usando += ou -= ao invés dos métodos abaixo
		// Achei que fica mais claro
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
*/

		public void StepProgress(double step)
		{
			progress += step;

			SetProgress(progress);
		}

		public void SetProgress(double value)
		{
			progress = value;

			if (backgroundWorker.CancellationPending)
				throw new WorkerCanceledException();

			backgroundWorker.ReportProgress((int)progress);
		}

		#endregion

		#region Private Methods

		private void DoInitialize(IControlView view, bool showProgressDlgFrm)
		{
			this.view = (IWinControl)view;
			backgroundWorkerView = (IBackgroundWorkerControl)view;

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

		private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (showProgressDlgFrm)
				frm.Progress = e.ProgressPercentage;

			if (ProgressChanged != null)
				ProgressChanged(sender, e);
		}

		#endregion

	}
}