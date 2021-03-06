using EvolutionNet.MVP.Business;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Core.Business
{
	public interface ICategoryCrudContract : ICrudListContract<CategoryCrudTO, Category, int>
	{
//		void SlowWork(BackgroundWorker bw);
		void SlowWork();
	}
}