using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Core.Business
{
	public interface IListFacade<TO, T, IdT> : IListContract
		where TO : IListTo<T, IdT>
		where T : IModel<IdT>
	{
		/// <summary>
		/// Transfer Object, cont�m a refer�ncia ao To, definido na View.
		/// </summary>
		TO To { get; }

	}
}