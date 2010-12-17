using System;

namespace EvolutionNet.MVP.View
{
	public interface IMenuHelper
	{
		object FindMenuStrip(IControlView view);
//		object AddMenuItem(string text, string name);
//		object AddMenuItem(string text, string name, EventHandler eventHandler);
//		object AddMenuItem(string text, string name, IControlView view);
//		object AddMenuItem(string text, string name, IControlView view, EventHandler eventHandler);
		object AddMenuItem(string text, string name, object parent);
		object AddMenuItem(string text, string name, object parent, EventHandler eventHandler);
	}
}