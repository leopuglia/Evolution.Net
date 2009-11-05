using System;
using System.Collections.Generic;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class ListTO<T, IdT> where T : class, IModel<IdT>
	{
	    private IList<T> list;
	    public IList<T> List
	    {
            get { return list; }
            set { list = value; }
	    }

		protected ListTO()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					//TODO: Adicionei aqui. Verificar como buscar os dados.
					list = new SortableBindingList<T>();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Model no TO.", ex);
			}
		}
		
	}
}
