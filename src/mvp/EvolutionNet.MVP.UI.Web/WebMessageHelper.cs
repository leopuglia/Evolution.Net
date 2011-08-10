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
			messageUC.ShowMessage(caption, message);
		}

		public void ShowErrorMessage(string caption, string message)
		{
			ShowErrorMessage(caption, message, null);
		}

		public void ShowErrorMessage(string caption, string message, Exception exception)
		{
			messageUC.ShowErrorMessage(caption, message, exception);
		}
	}
}