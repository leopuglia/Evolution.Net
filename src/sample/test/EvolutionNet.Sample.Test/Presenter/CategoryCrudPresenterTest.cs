using System.Collections.Generic;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Sample.Presenter;
using NUnit.Framework;

namespace EvolutionNet.Sample.Test.Presenter
{
	// TODO: Refatorar essa classe numa classe base que eu possa utilizar pra realizar todos os meus testes com o mínimo de alterações possível
	// DICA: Usar generics
	[TestFixture]
	public class CategoryCrudPresenterTest : BaseCrudPresenterTest<ICategoryCrudView, CategoryCrudPresenter, CategoryCrudTO, Category, int>
	{
		protected override IEnumerable<string> PropertiesToCompare
		{
			get
			{
				return new List<string> { "CategoryName", "Description", "Picture"};
			}
		}

		[Test]
		public override void Add()
		{
			DoAdd();
		}

		[Test]
		public override void Edit()
		{
			DoEdit();
		}

		[Test]
		public override void Save()
		{
			DoSave();
		}

		[Test]
		public override void Delete()
		{
			DoDelete();
		}
	}
}