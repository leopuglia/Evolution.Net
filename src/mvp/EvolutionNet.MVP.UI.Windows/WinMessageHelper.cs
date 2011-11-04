using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View.Helper;
using log4net;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinMessageHelper : IMessageHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(WinMessageHelper));

		private Control owner;

		#region Thread-safe Singleton

		private WinMessageHelper()
		{
		}

		public static WinMessageHelper Instance
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

			internal static readonly WinMessageHelper instance = new WinMessageHelper();
		}

		#endregion

		#region Public Methods (IMessageHelper)

		public void ShowMessage(string caption, string message)
		{
			ShowMessageBox(caption, message);
		}

		public void ShowMessageError(string caption, string message)
		{
			ShowMessageError(caption, message, null);
		}

		public void ShowMessageError(string caption, string message, Exception exception)
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

		public bool ShowMessageConfirm(string caption, string msg)
		{
			return ShowMessageBoxOKCancel(caption, msg);
		}

		public MessageConfirmCancel ShowMessageConfirmCancel(string caption, string msg)
		{
			switch (ShowMessageBoxYesNoCancel(caption, msg))
			{
				case DialogResult.Yes:
					return MessageConfirmCancel.Yes;
				case DialogResult.No:
					return MessageConfirmCancel.No;
				case DialogResult.Cancel:
					return MessageConfirmCancel.Cancel;
				default:
					return MessageConfirmCancel.Cancel;
			}
		}

		#endregion

		#region Public Initialization (called at BaseUCView)

		public void Initialize(Control owner)
		{
			this.owner = owner;
		}

		#endregion

		#region Local Auxiliary Methods

		private void ShowMessageBox(string caption, string msg, params string[] args)
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

		private void ShowMessageBoxError(string caption, string msg, params string[] args)
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

		private bool ShowMessageBoxOKCancel(string caption, string msg, params string[] args)
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

		private DialogResult ShowMessageBoxYesNoCancel(string caption, string msg, params string[] args)
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

		#endregion

/*
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
*/

	}
}