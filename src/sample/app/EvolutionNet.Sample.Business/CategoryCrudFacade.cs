using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Business
{
	public class CategoryCrudFacade : BaseCrudFacade<CategoryCrudTO, Category, int>, ICategoryCrudContract
	{
		public CategoryCrudFacade(IPresenter presenter) : base(presenter)
		{
		}

		protected override bool ThrowException
		{
			get { return false; }
		}
	}
}