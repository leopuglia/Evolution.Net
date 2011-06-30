using System;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	public interface IContract
	{
		IPresenter Presenter { get; }

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;
	}
}