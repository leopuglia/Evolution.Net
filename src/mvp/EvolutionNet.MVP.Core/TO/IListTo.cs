using System.Collections.Generic;
using EvolutionNet.MVP.Core.Data.Definition;

namespace EvolutionNet.MVP.Core.TO
{
	public interface IListTo<T, IdT> where T : IModel<IdT>
	{
		IList<T> List { get; set; }
	}
}