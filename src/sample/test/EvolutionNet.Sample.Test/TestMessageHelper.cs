using System;
using EvolutionNet.MVP.View.Helper;
using log4net;

namespace EvolutionNet.Sample.Test
{
	public class TestMessageHelper : IMessageHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(TestMessageHelper));

		public void ShowMessage(string caption, string msg)
		{
			if (log.IsInfoEnabled)
				log.Info(string.Format(@"{0}: {1}", caption, msg));
		}

		public void ShowErrorMessage(string caption, string msg)
		{
			if (log.IsErrorEnabled)
				log.Error(string.Format(@"{0}: {1}", caption, msg));

			throw new Exception(msg);
		}

		public void ShowErrorMessage(string caption, string msg, Exception exception)
		{
			if (log.IsErrorEnabled)
				log.Error(string.Format(@"{0}: {1}", caption, msg), exception);

			throw exception;
		}
	}
}