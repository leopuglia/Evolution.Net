using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.UI.Windows.Common;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseUCView : UserControl
	{
		public event AfterLoadDelegate AfterLoad;

		#region Vari�veis Protegidas

		protected BackgroundWorker backgroundWorker1;
		protected bool workerEnabledOnLoad;
		protected bool showProgressDlgFrm = true;
		protected ProgressDlgFrm frm;
		protected double progress;

		protected delegate void DoWorkDelegate(BackgroundWorker bw, DoWorkEventArgs e);
		protected delegate void WorkerCompletedDelegate(BackgroundWorker bw, RunWorkerCompletedEventArgs e);

		#endregion

		#region Vari�veis Privadas

		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;
		private bool doWorkAdded;
		private bool workerCompletedAdded;

		#endregion

		#region Propriedades Protegidas

/*
		protected DoWorkDelegate Work
		{
			get { return doWork; }
			set { doWork = value; }
		}

		protected WorkerCompletedDelegate WorkCompleted
		{
			get { return workerCompleted; }
			set { workerCompleted = value; }
		}
*/

		#endregion

		#region Construtor

		public BaseUCView() : this(null)
		{
		}

		public BaseUCView(Control parent)
		{
			InitializeComponent();
			Parent = parent;
			backgroundWorker1 = new BackgroundWorker();
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
		}

		#endregion

		#region M�todos Protegidos

/*
		/// <summary>
		/// Presenter, cont�m a refer�ncia ao presenter da funcionalidade atual.
		/// </summary>
		protected PresenterT GetPresenter<PresenterT, TO, T, IdT>()
			where PresenterT : BasePresenter<TO, T, IdT>
			where TO : TO<T, IdT>
			where T : class, IModel<IdT>
		{
			try
			{
				return (PresenterT)PresenterAbstractFactory.Instance.GetPresenter<TO, T, IdT>((IView)this);
			}
			catch (Exception ex)
			{
				throw new FrameworkException("N�o foi poss�vel instanciar o Presenter.", ex);
			}
		}
*/

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

		#region M�todos Virtuais Protegidos

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

		protected virtual void ShowMessage(string caption, string msg, params object[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			MessageBox.Show(
				this,
				msg,
				caption,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1);
		}

		protected virtual bool ShowMessageOKCancel(string caption, string msg, params object[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				this,
				msg,
				caption,
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1) == DialogResult.OK;
		}

		protected virtual bool ShowMessageYesNo(string caption, string msg, params object[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				this,
				msg,
				caption,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1) == DialogResult.OK;
		}

		protected virtual DialogResult ShowMessageYesNoCancel(string caption, string msg, params object[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				this,
				msg,
				caption,
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1);
		}

		protected virtual void ShowMessageErro(string caption, string msg, params object[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			MessageBox.Show(
				this,
				msg,
				caption,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1);
		}

		#endregion

		#region M�todos P�blicos

		public void DoAfterLoad(EventArgs e)
		{
			if (workerEnabledOnLoad)
			{
				RunWorker();
			}

			if (AfterLoad != null)
				AfterLoad(this, e);
		}

		#endregion

		#region M�todos de Eventos

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
			ProgressChanged((BackgroundWorker) sender, e);
		}

		#endregion

		#region Bot�es

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();

			if (showProgressDlgFrm)
				frm.btnCancelar.Enabled = false;
		}

		#endregion

		#endregion

	}
}