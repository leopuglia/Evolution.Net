using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public interface ICrudListPresenter<TO, T, IdT> : IListPresenter<TO, T, IdT> 
		where TO : CrudListTO<T, IdT>
		where T : class, IModel<IdT>
	{
		void Add();
		void Edit();
		void Save();
		void SaveList();
		void Delete();
		void DeleteList();
		void Clear();
	}
}