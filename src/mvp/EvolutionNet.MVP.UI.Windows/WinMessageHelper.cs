using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.Singleton;
using log4net;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinMessageHelper : BaseSingleton<WinMessageHelper>, IMessageHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(WinMessageHelper));

		private Control owner;

		public void Initialize(Control owner)
		{
			this.owner = owner;
		}

		public void ShowMessage(string caption, string message)
		{
			ShowMessageBox(caption, message);
		}

		public void ShowErrorMessage(string caption, string message)
		{
			ShowErrorMessage(caption, message, null);
		}

		public void ShowErrorMessage(string caption, string message, Exception exception)
		{
#if DEBUG
			if (exception != null)
				ShowMessageBoxError(caption, message + "\r\nException: {0}", exception.Message);
			else
				ShowMessageBoxError(caption, message);
#else
			ShowMessageBoxError(caption, message);
#endif
			if (log.IsErrorEnabled)
				log.Error(message, exception);
		}

		public void ShowMessageBox(string caption, string msg, params string[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			MessageBox.Show(
				owner,
				msg,
				caption,
				MessageBoxButtons.OK,
				MessageBoxIcon.Information,
				MessageBoxDefaultButton.Button1);
		}

		public bool ShowMessageBoxOKCancel(string caption, string msg, params string[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				owner,
				msg,
				caption,
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1) == DialogResult.OK;
		}

		public bool ShowMessageBoxYesNo(string caption, string msg, params string[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				owner,
				msg,
				caption,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1) == DialogResult.OK;
		}

		public DialogResult ShowMessageBoxYesNoCancel(string caption, string msg, params string[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			return MessageBox.Show(
				owner,
				msg,
				caption,
				MessageBoxButtons.YesNoCancel,
				MessageBoxIcon.Warning,
				MessageBoxDefaultButton.Button1);
		}

		public void ShowMessageBoxError(string caption, string msg, params string[] args)
		{
			if (args != null && args.Length > 0)
				msg = string.Format(msg, args);

			MessageBox.Show(
				owner,
				msg,
				caption,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1);
		}

	}
}