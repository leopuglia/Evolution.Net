using System;
using System.Collections.Generic;
using EvolutionNet.Util.Collection;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class CrudTO<T, IdT> : ITO where T : class, IModel<IdT>
	{
		private IdT id;
		private T mainModel;

		public IdT ID
		{
			get { return id; }
			set { id = value; }
		}

		public T MainModel
		{
			get { return mainModel; }
			set { mainModel = value;  }
		}

		private IList<T> list;
		public IList<T> List
		{
			get { return list; }
			set { list = value; }
		}

		protected CrudTO()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					// Instancia o TO. Aqui é chamado o método construtor do TO, no caso o BaseTO, que é quem inicializa também o Dao
					mainModel = (T)Activator.CreateInstance(typeof(T));

					// Cria a lista vazia
					list = new SortableBindingList<T>();
				}
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Não foi possível instanciar o Model no TO.", ex);
			}
		}
		
	}
}
