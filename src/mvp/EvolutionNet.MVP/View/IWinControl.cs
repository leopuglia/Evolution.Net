using System;

namespace EvolutionNet.MVP.View
{
	public interface IWinControl : IControlView
	{
		event EventHandler LoadComplete;
		void Close();
	}
}