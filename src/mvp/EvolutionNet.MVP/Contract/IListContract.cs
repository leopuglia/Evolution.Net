using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Contract
{
	public interface IListContract<TO, T, IdT> : IBaseContract
		where TO : ListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		TO To { get; }

		/// <summary>
		/// Lista todos os elementos do model
		/// </summary>
		void FindAll();

	}
}