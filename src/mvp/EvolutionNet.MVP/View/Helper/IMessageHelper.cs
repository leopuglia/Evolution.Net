using System;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IMessageHelper
	{
		void ShowMessage(string caption, string msg);
		void ShowMessageError(string caption, string msg);
		void ShowMessageError(string caption, string msg, Exception exception);
		bool ShowMessageConfirm(string caption, string msg);
		MessageConfirmCancel ShowMessageConfirmCancel(string caption, string msg);
	}

	public enum MessageConfirmCancel
	{
		Yes,
		No,
		Cancel
	}
}