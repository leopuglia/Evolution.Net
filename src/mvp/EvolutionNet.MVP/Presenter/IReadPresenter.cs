using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public interface IReadPresenter<TO, T, IdT> : IPresenter
		where TO : ReadTO<T, IdT>
		where T : class, IModel<IdT>
	{
		TO To { get; }

		void Find();
	}
}