using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.Windows;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinMenuHelper : IMenuHelper
	{
		#region Thread-safe Singleton

		public static WinMenuHelper Instance
		{
			get
			{
				return Nested.instance;
			}
		}
		
		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly WinMenuHelper instance = new WinMenuHelper();
		}

		#endregion

		public object AddMenuItem(string text, string name, IControlView view)
		{
			return AddMenuItem(text, name, view, null);
		}

		public object AddMenuItem(string text, string name, IControlView view, EventHandler eventHandler)
		{
			var menuStrip = (MenuStrip)FindMenuStrip(view);

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
			if (parent is ToolStripMenuItem)
			{
				var parentItem = (ToolStripMenuItem) parent;
				var menuItem = parentItem.DropDownItems.Add(text, null, eventHandler);
				menuItem.Name = name;

				return menuItem;
			}
			
			if (parent is ToolStrip)
			{
				var parentItem = (ToolStrip)parent;
				var menuItem = parentItem.Items.Add(text, null, eventHandler);
				menuItem.Name = name;

				return menuItem;
			}

			throw new ArgumentOutOfRangeException("parent", parent, "The parent object is not a MenuStrip or a ToolStripMenuItem");
		}

		public object FindMenuStrip(IControlView view)
		{
			return WinControlFindHelper.FindControlOnChild<MenuStrip>((Control)view);
		}

	}
}