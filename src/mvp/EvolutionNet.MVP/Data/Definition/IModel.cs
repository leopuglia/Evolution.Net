using System.ComponentModel;

namespace EvolutionNet.MVP.Data.Definition
{
	public interface IModel<IdT> : INotifyPropertyChanged
	{
		IdT ID { get; set; }
//		bool IsTransient { get; }
	}
}