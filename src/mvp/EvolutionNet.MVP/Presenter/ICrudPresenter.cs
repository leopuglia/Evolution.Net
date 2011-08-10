using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public interface ICrudPresenter<TO, T, IdT> : IListPresenter<TO, T, IdT> 
		where TO : CrudTO<T, IdT>
		where T : class, IModel<IdT>
	{
		void Add();
		void Edit();
		void Save();
		void Delete();
		void Clear();
	}
}