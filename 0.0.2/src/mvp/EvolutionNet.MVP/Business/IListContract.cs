using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	public interface IListContract<TO, T, IdT> : IContract
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