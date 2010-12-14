using System;
using EvolutionNet.MVP.View;

namespace EvolutionNet.Sample.Core.View
{
	public interface IMainView : IControlView
	{
		object AddMenuItem(string text, string name);
		object AddMenuItem(string text, string name, EventHandler eventHandler);
		
		object AddMenuItem(string text, string name, object parent);
		object AddMenuItem(string text, string name, object parent, EventHandler eventHandler);
	}
}