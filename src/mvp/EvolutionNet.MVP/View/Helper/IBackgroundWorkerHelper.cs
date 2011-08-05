using System;
using System.ComponentModel;
using EvolutionNet.MVP.View.BackgroundWork;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IBackgroundWorkerHelper
	{
		event EventHandler<ProgressChangedEventArgs> ProgressChanged;
		DoWorkDelegate DoWork { get; set; }
		WorkerCompletedDelegate WorkerCompleted { get; set; }

		void Initialize(IControlView view, bool workerEnabledOnLoad, bool showProgressDlgFrm);
		void RunWorker(IControlView view, bool showProgressDlgFrm);
//		void AddDoWork(DoWorkDelegate worker);
//		void RemoveDoWork(DoWorkDelegate worker);
//		void AddWorkerCompleted(WorkerCompletedDelegate completed);
//		void RemoveWorkerCompleted(WorkerCompletedDelegate completed);
		void StepProgress(double step);
		void SetProgress(double value);
//		void ProgressChanged(ProgressChangedEventArgs e);
	}
}