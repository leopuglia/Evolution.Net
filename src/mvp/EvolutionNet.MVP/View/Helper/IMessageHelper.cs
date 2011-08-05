using System;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IMessageHelper
	{
		void ShowMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg);
		void ShowErrorMessage(string caption, string msg, Exception exception);
	}
}