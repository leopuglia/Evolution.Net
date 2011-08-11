using System;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.BackgroundWork;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	// TODO: Implementar
	public class WebBackgroundWorkerHelper : IBackgroundWorkerHelper
	{
		public event EventHandler WorkerCanceled;
		public event EventHandler<WorkerErrorEventArgs> WorkerError;
		public event EventHandler WorkerCompleted;
		public DoWorkDelegate DoWorkDelegate { get; set; }
		public bool SuportsCancellation { get; set; }
		public void RunWorker(IBackgroundWork backgroundWork)
		{
			throw new NotImplementedException();
		}

		public void RunWorkerWithProgressDialog(IBackgroundWork backgroundWork, IControlView view, string caption, string text)
		{
			throw new NotImplementedException();
		}

		public void ReportProgressStep(int step)
		{
			throw new NotImplementedException();
		}

		public void ReportProgress(int value)
		{
			throw new NotImplementedException();
		}

		public void ShowProgressDialog(IControlView view, string caption, string text)
		{
			throw new NotImplementedException();
		}
	}
}