using Castle.ActiveRecord;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Data.Access
{
	public abstract class Dao<T, IdT> : ActiveRecordMediator<T> where T : class, IModel<IdT>
	{
/*
		protected Dao()
		{
			Initialize();
		}

//		~Dao()
//		{
//			Dispose();
//		}

		public void Initialize()
		{
			DaoInitializer.Initialize();
		}

		public void Dispose()
		{
			DaoInitializer.Dispose();
		}
*/
	}
}