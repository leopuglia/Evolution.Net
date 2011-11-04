using System;
using EvolutionNet.MVP.View.Helper;

namespace EvolutionNet.MVP.UI.Web
{
	public class WebMessageHelper : IMessageHelper
	{
		private BaseMessageUC messageUC;
		public BaseMessageUC MessageUC
		{
			get { return messageUC; }
			set { messageUC = value; }
		}

		private BaseMessageConfirmUC messageConfirmUC;
		public BaseMessageConfirmUC MessageConfirmUC
		{
			get { return messageConfirmUC; }
			set { messageConfirmUC = value; }
		}

		#region Thread-safe Singleton

		private WebMessageHelper()
		{
		}

		public static WebMessageHelper Instance
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

			internal static readonly WebMessageHelper instance = new WebMessageHelper();
		}

		#endregion

		public void ShowMessage(string caption, string message)
		{
			if (messageUC != null)
				messageUC.ShowMessage(caption, message);
		}

		public void ShowMessageError(string caption, string message)
		{
			ShowMessageError(caption, message, null);
		}

		public void ShowMessageError(string caption, string message, Exception exception)
		{
			if (messageUC != null)
				messageUC.ShowMessageError(caption, message, exception);
		}

		public bool ShowMessageConfirm(string caption, string msg)
		{
			if (messageConfirmUC != null)
				return messageConfirmUC.ShowMessageConfirm(caption, msg);

			return true;
		}

		public MessageConfirmCancel ShowMessageConfirmCancel(string caption, string msg)
		{
			if (messageConfirmUC != null)
				return messageConfirmUC.ShowMessageConfirmCancel(caption, msg);

			return MessageConfirmCancel.Yes;
		}
	}
}