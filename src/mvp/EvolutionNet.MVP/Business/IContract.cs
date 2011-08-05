using EvolutionNet.MVP.Core.ProgressReporting;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public interface IContract
	{
		IPresenter Presenter { get; }
		ProgressReportHelper ProgressHelper { get; }

/*
		/// <summary>
		/// Reporta o progresso da requisi��o atual.
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;
*/
	}
}