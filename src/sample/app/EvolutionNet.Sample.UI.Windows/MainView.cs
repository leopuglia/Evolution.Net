﻿using System;
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

		public object AddMenuItem(string text, string name)
		{
			return AddMenuItem(text, name, null);
		}

		public object AddMenuItem(string text, string name, EventHandler eventHandler)
		{
			var menu = menuStrip1.Items.Add(text, null, eventHandler);
			menu.Name = name;

			return menu;
		}

		public object AddMenuItem(string text, string name, object parent)
		{
			return AddMenuItem(text, name, parent, null);
		}

		public object AddMenuItem(string text, string name, object parent, EventHandler eventHandler)
		{
			var parentItem = (ToolStripMenuItem) parent;
			var menu = parentItem.DropDownItems.Add(text, null, eventHandler);
			menu.Name = name;

			return menu;
		}

		public void AddTabItemView(string text, IControlView controlView)
		{
			TabPage tabPage = new TabPage(text);
			tabPage.Padding = new Padding(3);
			tabPage.UseVisualStyleBackColor = true;

			tabPage.Controls.Add((Control)controlView);

			tabControl1.TabPages.Add(tabPage);
			tabPage.Focus();
		}

		public void DeleteTabItem()
		{
			if (tabControl1.SelectedTab != null)
				tabControl1.TabPages.Remove(tabControl1.SelectedTab);
		}
	}
}
