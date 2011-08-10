using EvolutionNet.MVP.Business.ProgressReporting;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public interface IContract : IProgressReport
	{
		IPresenter Presenter { get; }
//		ProgressReportHelper ProgressHelper { get; }

/*
		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;
*/
	}
}