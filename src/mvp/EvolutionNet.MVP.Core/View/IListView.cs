using System;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Core.View
{
	public interface IListView<TO, T, IdT> : IDisposable
		where TO : IListTo<T, IdT>
		where T : IModel<IdT>
	{
		/// <summary>
		/// Transfer Object, contém a referência ao To, que é criado automaticamente pelo framework.
		/// </summary>
		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializações necessárias.
		/// </summary>
		void Initialize();

	}
}