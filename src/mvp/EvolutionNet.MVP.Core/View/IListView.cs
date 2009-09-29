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
		/// Transfer Object, cont�m a refer�ncia ao To, que � criado automaticamente pelo framework.
		/// </summary>
		TO To { get; /*set;*/ }

		/// <summary>
		/// Realiza todas as inicializa��es necess�rias.
		/// </summary>
		void Initialize();

	}
}