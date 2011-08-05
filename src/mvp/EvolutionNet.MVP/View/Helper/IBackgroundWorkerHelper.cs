using System;
using EvolutionNet.MVP.View.BackgroundWork;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IBackgroundWorkerHelper
	{
//		event EventHandler<ProgressChangedEventArgs> ProgressReported;
		event EventHandler WorkerCanceled;

		DoWorkDelegate DoWork { get; set; }
		WorkerCompletedDelegate WorkerCompleted { get; set; }
		string Caption { set; }
		string Text { set; }

		void Initialize(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm);
		void RunWorker(IControlView view, bool showProgressDlgFrm);
		void ReportProgressStep(int step);
		void ReportProgress(int value);
	}
}