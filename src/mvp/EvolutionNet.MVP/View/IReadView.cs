using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.View
{
	public interface IReadView<T, IdT> : IControlView where T : class, IModel<IdT>
	{
		IdT ModelID { get; set; }
		T Model { get; set; }
	}
}