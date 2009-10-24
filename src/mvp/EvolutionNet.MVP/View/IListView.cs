using System;

namespace EvolutionNet.MVP.View
{
	public interface IListView : IDisposable
	{
		/// <summary>
		/// Transfer Object, contém a referência ao To, que é criado automaticamente pelo framework.
		/// </summary>
//		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializações necessárias.
		/// </summary>
		void Initialize();

	}
}