using System;
using EvolutionNet.MVP.UI.Web;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;
using log4net;

namespace EvolutionNet.Sample.Test
{
	public class TestMessageHelper : BaseSingleton<TestMessageHelper>, IMessageHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(TestMessageHelper));

//		private BaseMessageUC messageUC;
//		public BaseMessageUC MessageUC
//		{
//			get { return messageUC; }
//			set { messageUC = value; }
//		}

		public void ShowMessage(string caption, string message)
		{
			if (log.IsInfoEnabled)
				log.Info(message);	
		}

		public void ShowErrorMessage(string caption, string message, Exception exception)
		{
			if (log.IsErrorEnabled)
				log.Error(message, exception);
		}
	}
}