using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Business
{
	public interface IReadContract<TO, T, IdT> : IContract
		where TO : ReadTO<T, IdT>
		where T : class, IModel<IdT>
	{
		TO To { get; }

		void Find();
	}
}