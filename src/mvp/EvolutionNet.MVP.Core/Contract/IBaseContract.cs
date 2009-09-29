using System;

namespace EvolutionNet.MVP.Core.Contract
{
	public interface IBaseContract : IDisposable
	{
		/// <summary>
		/// Reporta o progresso da requisição atual
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;

		/// <summary>
		/// Realiza toda a inicialização necessária
		/// </summary>
		void Initialize();
	}
}