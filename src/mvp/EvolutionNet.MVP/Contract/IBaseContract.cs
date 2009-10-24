using System;

namespace EvolutionNet.MVP.Contract
{
	public interface IBaseContract// : IDisposable
	{
		/// <summary>
		/// Reporta o progresso da requisi��o atual
		/// </summary>
		event EventHandler<ProgressEventArgs> ProgressReported;

		/// <summary>
		/// Realiza toda a inicializa��o necess�ria
		/// </summary>
//		void Initialize();
	}
}