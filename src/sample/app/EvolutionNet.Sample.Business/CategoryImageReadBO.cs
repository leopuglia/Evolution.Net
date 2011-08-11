using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Business
{
	public class CategoryImageReadBO : BaseReadBO<CategoryImageReadTO, Category, int>, ICategoryImageReadContract
	{
		public CategoryImageReadBO(IPresenter presenter) : base(presenter)
		{
		}
	}
}