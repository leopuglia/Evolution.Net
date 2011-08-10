using System;

namespace EvolutionNet.MVP.View
{
	public interface IWinControl
	{
		event EventHandler LoadComplete;
		void Close();
	}
}