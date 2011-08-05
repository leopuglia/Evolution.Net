using System.ComponentModel;

namespace EvolutionNet.MVP.Data.Definition
{
	public interface IModel<IdT> : IBaseModel, INotifyPropertyChanged
	{
		IdT ID { get; set; }
	}
}