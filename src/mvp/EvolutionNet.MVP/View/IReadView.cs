using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.View
{
	public interface IReadView<T, IdT> : IControlView where T : class, IModel<IdT>
	{
		T Model { get; set; }
	}
}