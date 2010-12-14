using System;

namespace EvolutionNet.MVP.View
{
//	public delegate void AfterLoadDelegate(object sender, EventArgs e);

	public interface IWinControl
	{
		event EventHandler LoadComplete;
		void Close();
	}
}