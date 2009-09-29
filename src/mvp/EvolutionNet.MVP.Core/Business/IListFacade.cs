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
		/// Transfer Object, contém a referência ao To, definido na View.
		/// </summary>
		TO To { get; }

	}
}