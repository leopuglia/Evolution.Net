using System.ComponentModel;

namespace EvolutionNet.MVP.View
{
	public interface IBackgroundWorkerControl
	{
		bool BeforeRunWorker();
		void AfterRunWorker();
		void DoBackgroundWork(BackgroundWorker bw, DoWorkEventArgs e);
		void BackgroundWorkCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e);
		void BackgroundWorkCanceled();
	}
}