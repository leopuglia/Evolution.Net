using System;

namespace EvolutionNet.Util.ProgressReporting
{
	public interface IProgressReportHelper
	{
		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;
		
	}
}