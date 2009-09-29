using System;
using System.ComponentModel;
using System.Windows.Forms;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.UI.Windows.Common;

namespace EvolutionNet.MVP.UI.Windows
{
	public partial class BaseUC : UserControl
	{
		public event AfterLoadDelegate AfterLoad;

		#region Variáveis Protegidas

		protected BackgroundWorker backgroundWorker1;
		protected bool workerEnabledOnLoad = false;
		protected bool showProgressDlgFrm = true;
		protected ProgressDlgFrm frm;
		protected double progress;

		protected delegate void DoWorkDelegate(BackgroundWorker bw, DoWorkEventArgs e);
		protected delegate void WorkerCompletedDelegate(BackgroundWorker bw, RunWorkerCompletedEventArgs e);

		#endregion

		#region Variáveis Privadas

		private DoWorkDelegate doWork;
		private WorkerCompletedDelegate workerCompleted;
		private bool doWorkAdded = false;
		private bool workerCompletedAdded = false;

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

		public BaseUC() : this(null)
		{
		}

		public BaseUC(Form parent)
		{
			InitializeComponent();
			Parent = parent;
			backgroundWorker1 = new BackgroundWorker();
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.WorkerSupportsCancellation = true;
			backgroundWorker1.DoWork += this.backgroundWorker1_DoWork;
			backgroundWorker1.RunWorkerCompleted += this.backgroundWorker1_RunWorkerCompleted;
			backgroundWorker1.ProgressChanged += this.backgroundWorker1_ProgressChanged;
		}

		#endregion

		#region Métodos Públicos

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
				ParentForm.Close();

			else if (e.Error != null)
			{
				MessageBox.Show(this, e.Error.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error,
				                MessageBoxDefaultButton.Button1);
				if (workerEnabledOnLoad)
					ParentForm.Close();
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

		#region Botões

		private void frmProgresso_BtnCancelar_OnClick(object sender, EventArgs e)
		{
			backgroundWorker1.CancelAsync();

			if (showProgressDlgFrm)
				frm.btnCancelar.Enabled = false;
		}

		#endregion

		#endregion

		#region Métodos Virtuais Protegidos

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

		#region Métodos Protegidos

		protected static T GetNewDao<T, IdT>() where T : IModel<IdT>
		{
			return DaoAbstractFactory.Instance.GetDao<T, IdT>();
		}

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

/*
		protected void DoBasicWorkCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e)
		{
		}

*/
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

	}
}
