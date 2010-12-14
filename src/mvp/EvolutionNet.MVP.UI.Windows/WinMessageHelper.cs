using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.MVP.UI.Windows
{
    public class WinMessageHelper : BaseSingleton<WinMessageHelper>, IMessageHelper
    {
        private Control owner;

        public void Initialize(Control owner)
        {
            this.owner = owner;
        }

        public void ShowMessage(string caption, string message)
        {
            ShowMessageBox(caption, message);
        }

        public void ShowErrorMessage(string caption, string message, string exceptionMessage)
        {
            ShowMessageBoxError(caption, message, exceptionMessage);
        }

        public void ShowMessageBox(string caption, string msg, params object[] args)
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

        public bool ShowMessageBoxOKCancel(string caption, string msg, params object[] args)
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

        public bool ShowMessageBoxYesNo(string caption, string msg, params object[] args)
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

        public DialogResult ShowMessageBoxYesNoCancel(string caption, string msg, params object[] args)
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

        public void ShowMessageBoxError(string caption, string msg, params object[] args)
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