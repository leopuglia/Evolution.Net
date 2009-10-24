using System;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class TO<T, IdT> where T : Model<IdT>
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
				// Instancia o tipo se n�o for um tipo nulo
				if (typeof(T) != typeof(NullModel))
				{
					// Instancia o TO. Aqui � chamado o m�todo construtor do TO, no caso o BaseTO, que � quem inicializa tamb�m o Dao
					mainModel = (T)Activator.CreateInstance(typeof(T));
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("N�o foi poss�vel instanciar o Model no TO.", ex);
			}
		}
		
	}
}
