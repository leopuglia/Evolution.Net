using System;
using System.Windows.Forms;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;
using EvolutionNet.Sample.UI.Windows;
using NUnit.Framework;

namespace EvolutionNet.Sample.Test.Presenter
{
	[TestFixture]
	public class MainPresenterTest
	{
//		private DynamicMock view;
		private MainView view;
		private MainPresenterTestInt presenter;

		[TestFixtureSetUp]
		public void SetUp()
		{
//			view = new DynamicMock("MainView", typeof(IWinMainView));
			view = new MainView();
			presenter = new MainPresenterTestInt(view);
		}

		[Test]
		public void mnuCategoryAddTabClick()
		{
			var tab = (TabControl)ReflectionHelper.GetInstanceValue(typeof(MainView), "tabControl1", view);
			var tabCount = tab.TabPages.Count;

			presenter.mnuCategoryAddTabClick(null, EventArgs.Empty);

			Assert.AreEqual(tabCount + 1, tab.TabPages.Count);
		}

		[Test]
		public void mnuFileRemoveTab()
		{
			var tab = (TabControl) ReflectionHelper.GetInstanceValue(typeof(MainView), "tabControl1", view);
			var tabCount = tab.TabPages.Count;
			
//			TestHelper.RunInstanceMethod(typeof (MainPresenter), "mnuFileRemoveTab", presenter, new object[] {null, EventArgs.Empty});
			presenter.mnuFileRemoveTab(null, EventArgs.Empty);

			Assert.AreEqual(tabCount - 1, tab.TabPages.Count);
		}

		[Test]
		public void mnuCategoryShowDialogClick()
		{
			presenter.mnuCategoryShowDialogClick(null, EventArgs.Empty);
		}

//		[Test]
//		public void mnuFileExitClick()
//		{
//			presenter.mnuFileExitClick(null, EventArgs.Empty);
//		}

		#region MainPresenterTest

		private class MainPresenterTestInt : MainPresenter
		{
			public MainPresenterTestInt(IMainView view)
				: base(view)
			{
			}

			public new void mnuFileRemoveTab(object sender, EventArgs e)
			{
				base.mnuFileRemoveTab(sender, e);
			}

			public new void mnuCategoryAddTabClick(object sender, EventArgs e)
			{
				base.mnuCategoryAddTabClick(sender, e);
			}

			public new void mnuCategoryShowDialogClick(object sender, EventArgs e)
			{
				base.mnuCategoryShowDialogClick(sender, e);
			}

//			public new void mnuFileExitClick(object sender, EventArgs e)
//			{
//				base.mnuFileExitClick(sender, e);
//			}

		}

		#endregion
	}
}
