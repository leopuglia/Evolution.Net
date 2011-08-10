using System;
using EvolutionNet.MVP.View.BackgroundWork;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IBackgroundWorkerHelper
	{
		event EventHandler WorkerCanceled;
		event EventHandler<WorkerErrorEventArgs> WorkerError;
		event EventHandler WorkerCompleted;

		DoWorkDelegate DoWorkDelegate { get; set; }
//		WorkerCompletedDelegate WorkerCompletedDelegate { get; set; }

		bool SuportsCancellation { get; set; }

//		void Initialize(IControlView view/*, bool workerEnabledOnLoad, bool showProgressDlgFrm*/);
		void RunWorker(IBackgroundWork backgroundWork);
		void RunWorkerWithProgressDialog(IBackgroundWork backgroundWork, IControlView view, string caption, string text);
		void ReportProgressStep(int step);
		void ReportProgress(int value);
		void ShowProgressDialog(IControlView view, string caption, string text);
	}
}