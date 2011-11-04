using System;
using System.Threading;
using System.Web.Caching;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebBackgroundWorkerHelper2 : IBackgroundWorkerHelper
	{
		private Thread workerThread;
		private bool doWorkAdded;
		private Guid taskID;

		private IBackgroundWork backgroundWork;

		private int progress
		{
			get
			{
//				HttpContext context = HttpContext.Current;
//				if (context != null)
//					return context.Cache[taskID.ToString()] != null ? (int)context.Cache[taskID.ToString()] : 0;

//				return progressUC.Cache[taskID.ToString()] != null ? (int)progressUC.Cache[taskID.ToString()] : 0;

				if (backgroundWork != null)
				{
					var cache = (Cache) backgroundWork.Cache;
					return cache[taskID.ToString()] != null ? (int) cache[taskID.ToString()] : 0;
				}
				return 0;
			}
			set
			{
//				HttpContext context = HttpContext.Current;
//				if (context != null)
//					context.Cache[taskID.ToString()] = value;
//				progressUC.Cache[taskID.ToString()] = value;
				if (backgroundWork != null)
				{
					var cache = (Cache) backgroundWork.Cache;
					cache[taskID.ToString()] = value;
				}
			}
		}

		private DoWorkDelegate doWorkDelegate;

		public event EventHandler WorkerCanceled;
		public event EventHandler<WorkerErrorEventArgs> WorkerError;
		public event EventHandler WorkerCompleted;

		public DoWorkDelegate DoWorkDelegate
		{
			get { return doWorkDelegate; }
			set
			{
				doWorkAdded = true;
				doWorkDelegate = value;
			}
		}

		public bool SuportsCancellation { get; set; }

		public Guid TaskID
		{
			get { return taskID; }
			set { taskID = value; }
		}

		public void RunWorker(IBackgroundWork backgroundWork)
		{
//			taskID = backgroundWork.TaskID;
			workerThread = new Thread(new ParameterizedThreadStart(DoWork));
			workerThread.Start(backgroundWork);
		}

		private void DoWork(object data)
		{
			backgroundWork = (IBackgroundWork) data;
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
				if (WorkerCanceled != null)
					WorkerCanceled(backgroundWork, new EventArgs());
			}
			catch(Exception ex)
			{
				if (WorkerError != null)
					WorkerError(backgroundWork, new WorkerErrorEventArgs(ex));
			}
			finally
			{
				if (WorkerCompleted != null)
					WorkerCompleted(backgroundWork, new EventArgs());
				// If the operation was canceled by the user, 
				// set the DoWorkEventArgs.Cancel property to true.
//				if (bw.CancellationPending)
//					e.Cancel = true;
			}
		}

		public void RunWorkerWithProgressDialog(IBackgroundWork backgroundWork, IControlView view, string caption, string text)
		{
			RunWorker(backgroundWork);
		}

		public void ShowProgressDialog(IControlView view, string caption, string text)
		{
//			progressUC.TaskID = taskID;
//			progressUC.Show();

//			progressUC.CancelEnabled = suportsCancellation;
//			progressUC.CancelButtonClick += progressUC_CancelButton_Clicked;
		}

		public void ReportProgressStep(int step)
		{
			ReportProgress(progress + step);
		}

		public void ReportProgress(int value)
		{
			progress = value;

//			if (backgroundWorker.CancellationPending)
//				throw new WorkerCanceledException();

//			backgroundWorker.ReportProgress(progress);
		}

	}
}