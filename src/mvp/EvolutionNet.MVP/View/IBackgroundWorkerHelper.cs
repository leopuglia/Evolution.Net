using System.ComponentModel;

namespace EvolutionNet.MVP.View
{
	public interface IBackgroundWorkerHelper
	{
		void RunWorker();
		void AddDoWork(DoWorkDelegate worker);
		void RemoveDoWork(DoWorkDelegate worker);
		void AddWorkerCompleted(WorkerCompletedDelegate completed);
		void RemoveWorkerCompleted(WorkerCompletedDelegate completed);
		void StepProgress(BackgroundWorker bw, double step);
		void SetProgress(BackgroundWorker bw, double value);
		bool BeforeRunWorker();
		void AfterRunWorker();
		void DoWork(BackgroundWorker bw, DoWorkEventArgs e);
		void WorkerCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e);
		void ProgressChanged(BackgroundWorker bw, ProgressChangedEventArgs e);
	}
}