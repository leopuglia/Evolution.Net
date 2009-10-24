using System;

namespace EvolutionNet.MVP.View
{
	public interface IListView : IDisposable
	{
		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
//		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		void Initialize();

	}
}