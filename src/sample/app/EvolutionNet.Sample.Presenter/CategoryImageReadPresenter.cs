using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Presenter
{
	public class CategoryImageReadPresenter
		: BaseReadPresenter<ICategoryImageReadView, ICategoryImageReadContract, CategoryImageReadTO, Category, int>
	{
		public CategoryImageReadPresenter(ICategoryImageReadView view) : base(view)
		{
		}

		public override void Find()
		{
//			To.ID = View.ModelID;
			To.CurrentModel.ID = View.Model.ID;
			Bo.Find();
			View.Model = To.CurrentModel;
		}
	}
}