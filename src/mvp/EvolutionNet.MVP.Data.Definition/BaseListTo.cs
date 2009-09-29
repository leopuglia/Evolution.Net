using System;
using System.Collections.Generic;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.Util;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class BaseListTo<T, IdT> : IListTo<T, IdT> where T : IModel<IdT>
	{
//		private IDao<IdT> dao;

	    private IList<T> list;
	    public IList<T> List
	    {
            get { return list; }
            set { list = value; }
	    }

		protected BaseListTo()
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
				throw new ApplicationException("Não foi possível instanciar o Dao no TO.", ex);
			}
		}
		
	}
}
