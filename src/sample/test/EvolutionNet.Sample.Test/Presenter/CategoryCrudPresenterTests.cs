using System;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Business;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Sample.UI.Windows;
using NUnit.Framework;

namespace EvolutionNet.Sample.Test.Presenter
{
	[TestFixture]
	public class CategoryCrudPresenterTests
	{
//		private DynamicMock view;
		private CategoryCrudView view;
		private CategoryCrudPresenterTest presenter;

		[TestFixtureSetUp]
		public void SetUp()
		{
			view = new CategoryCrudView();
			presenter = new CategoryCrudPresenterTest(view);
		}

		[Test]
		public void TestAddCategory()
		{
			var category = presenter.Facade.To.MainModel;
			category.CategoryName = "Teste";
			category.Description = "Testando";
			category.Picture = null;

			var id = category.ID;

			presenter.view_Save(null, new CrudEventArgs(-1));

			Assert.AreNotEqual(id, category.ID);

			var count = presenter.Facade.To.List.Count;

			presenter.Facade.Delete();
			presenter.Facade.FindAll();

			Assert.AreEqual(count - 1, presenter.Facade.To.List.Count);
		}
/*
		[Test]
		public void mnuCategoryAddTabClick()
		{
			var tab = (TabControl)TestHelper.GetInstanceValue(typeof(MainView), "tabControl1", view);
			var tabCount = tab.TabPages.Count;

			presenter.mnuCategoryAddTabClick(null, EventArgs.Empty);

			Assert.AreEqual(tabCount + 1, tab.TabPages.Count);
		}

		[Test]
		public void mnuFileRemoveTab()
		{
			var tab = (TabControl) TestHelper.GetInstanceValue(typeof(MainView), "tabControl1", view);
			var tabCount = tab.TabPages.Count;
			
			presenter.mnuFileRemoveTab(null, EventArgs.Empty);

			Assert.AreEqual(tabCount - 1, tab.TabPages.Count);
		}
*/

		#region MainPresenterTest

		private class CategoryCrudPresenterTest : CategoryCrudPresenter
		{
			public CategoryCrudPresenterTest(ICategoryCrudView view) : base(view)
			{
			}

			public new ICategoryCrudContract Facade
			{
				get { return base.Facade; }
			}

			public new void view_Save(object sender, CrudEventArgs e)
			{
				base.view_Save(sender, e);
			}

			public new void view_Delete(object sender, CrudEventArgs e)
			{
				base.view_Delete(sender, e);
			}

			public new void view_Edit(object sender, CrudEventArgs e)
			{
				base.view_Edit(sender, e);
			}

			public new void view_Cancel(object sender, CrudEventArgs e)
			{
				base.view_Cancel(sender, e);
			}

		}

		#endregion
	}
}