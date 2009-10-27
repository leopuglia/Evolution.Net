using System;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class TO<T, IdT> where T : class, IModel<IdT>
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

		protected TO()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					// Instancia o TO. Aqui é chamado o método construtor do TO, no caso o BaseTO, que é quem inicializa também o Dao
					mainModel = (T)Activator.CreateInstance(typeof(T));
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Model no TO.", ex);
			}
		}
		
	}
}
