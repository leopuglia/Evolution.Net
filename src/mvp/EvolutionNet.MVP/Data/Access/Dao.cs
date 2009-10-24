using Castle.ActiveRecord;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Data.Access
{
	public class Dao<T, IdT> : ActiveRecordMediator<T> where T : Model<IdT>
	{
		/*
		public T MainModel { get; set; }

		public void SaveAndFlush()
		{
			SaveAndFlush(MainModel);
		}

		public void DeleteAndFlush()
		{
			SaveAndFlush(MainModel);
		}
		*/
	}
}