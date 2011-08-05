using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.Presenter
{
	public interface ICrudPresenter<TO> : IPresenter where TO : ITO
	{
		TO To { get; }

		void Add();
		void Edit();
		void Save();
		void Delete();
		void Cancel();
	}
}