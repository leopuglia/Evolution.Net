using System;
using System.Collections.Generic;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class ListTO<T, IdT> : ITO where T : class, IModel<IdT>
	{
		private IdT currentID;
		private T currentModel;
		private IList<T> list;

		public IdT CurrentID
		{
			get { return currentID; }
			set { currentID = value; }
		}

		public T CurrentModel
		{
			get { return currentModel; }
			set { currentModel = value; }
		}

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
//					list = new SortableBindingList<T>();
					list = new List<T>();
				}
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Não foi possível instanciar o IList<Model> no TO.", ex);
			}
		}
		
	}
}
