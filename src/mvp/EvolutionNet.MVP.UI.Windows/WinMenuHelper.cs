using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinMenuHelper : IMenuHelper
	{
		private readonly MenuStrip menuStrip;
		
		public WinMenuHelper(MenuStrip menuStrip)
		{
			this.menuStrip = menuStrip;
		}

		public object AddMenuItem(string text, string name)
		{
			return AddMenuItem(text, name, null);
		}

		public object AddMenuItem(string text, string name, EventHandler eventHandler)
		{
			var menu = menuStrip.Items.Add(text, null, eventHandler);
			menu.Name = name;

			return menu;
		}

		public object AddMenuItem(string text, string name, object parent)
		{
			return AddMenuItem(text, name, parent, null);
		}

		public object AddMenuItem(string text, string name, object parent, EventHandler eventHandler)
		{
			var parentItem = (ToolStripMenuItem)parent;
			var menu = parentItem.DropDownItems.Add(text, null, eventHandler);
			menu.Name = name;

			return menu;
		}

	}
}