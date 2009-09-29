using System;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;

namespace EvolutionNet.MVP.Data.Definition
{
	[Serializable]
	public abstract class BaseTo<T, IdT> : ITo<T, IdT> where T : IModel<IdT>
	{
		private T mainModel;

		public T MainModel
		{
			get { return mainModel; }
			set { mainModel = value;  }
		}

		protected BaseTo()
		{
			try
			{
				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					mainModel = DaoAbstractFactory.Instance.GetDao<T, IdT>();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Dao no TO.", ex);
			}
		}
		
	}
}
