using System;
using System.Windows.Forms;
using EvolutionNet.MVP.UI.Windows;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Presenter;

namespace EvolutionNet.Sample.UI.Windows
{
	public partial class MainView : BaseUCView, IMainView
	{
		public MainView()
		{
			InitializeComponent();

			// Do not create the presenter on visual studio design time, because it causes error
//			if (!IsVSDesigner)
//				new MainPresenter(this);
		}

		private void MainView_Load(object sender, EventArgs e)
		{
			// Do not create the presenter on visual studio design time, because it causes error
			if (!IsVSDesigner)
				new MainPresenter(this);
		}

		public void AddTabPageView(string text, IControlView controlView)
		{
			TabPage tabPage = new TabPage(text);
			tabPage.Padding = new Padding(3);
			tabPage.UseVisualStyleBackColor = true;

			tabPage.Controls.Add((Control)controlView);

			tabControl1.TabPages.Add(tabPage);
			tabPage.Focus();
		}

		public void DeleteTabPage()
		{
			if (tabControl1.SelectedTab != null)
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
		}
	}
}
