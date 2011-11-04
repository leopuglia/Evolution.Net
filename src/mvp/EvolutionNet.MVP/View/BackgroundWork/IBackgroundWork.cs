using System;
using System.Collections;

namespace EvolutionNet.MVP.View.BackgroundWork
{
	public interface IBackgroundWork
	{
//		Guid TaskID { get; }
		IEnumerable Cache { get; }
		void DoBackgroundWork();
//		void BackgroundWorkCompleted(BackgroundWorker bw, RunWorkerCompletedEventArgs e);
	}
}