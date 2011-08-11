using System;
using System.Collections.Generic;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class CrudListTO<T, IdT> : ListTO<T, IdT> where T : class, IModel<IdT>
	{
		private IList<T> currentList;
		public IList<T> CurrentList
		{
			get { return currentList; }
			set { currentList = value; }
		}

		protected CrudListTO()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					// TODO: Adicionei aqui. Verificar como buscar os dados.
//					deleteList = new SortableBindingList<T>();
					currentList = new List<T>();
				}
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Não foi possível instanciar o Model no TO.", ex);
			}
		}
		
	}
}
