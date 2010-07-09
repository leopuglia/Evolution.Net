using System;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
    public abstract class ReadTO<T, IdT> : ITO where T : class, IModel<IdT>
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

		protected ReadTO()
		{
			try
			{
				// Instancia o tipo se n�o for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					// Instancia o TO. Aqui � chamado o m�todo construtor do TO, no caso o BaseTO, que � quem inicializa tamb�m o Dao
					mainModel = (T)Activator.CreateInstance(typeof(T));
				}
			}
			catch (Exception ex)
			{
				throw new MVPIoCException("N�o foi poss�vel instanciar o Model no TO.", ex);
			}
		}
		
	}
}
