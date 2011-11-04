using System;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class ReadTO<T, IdT> : ITO where T : class, IModel<IdT>
	{
//		private IdT id;
		private T currentModel;

/*
		public IdT ID
		{
			get { return id; }
			set { id = value; }
		}
*/

		public T CurrentModel
		{
			get { return currentModel; }
			set { currentModel = value; }
		}

		protected ReadTO()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					// Instancia o TO. Aqui é chamado o método construtor do TO, no caso o BaseTO, que é quem inicializa também o Dao
					currentModel = (T)Activator.CreateInstance(typeof(T));
				}
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("Não foi possível instanciar o Model no TO.", ex);
			}
		}
		
	}
}
