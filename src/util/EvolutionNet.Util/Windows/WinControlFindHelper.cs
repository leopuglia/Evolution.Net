using System.Windows.Forms;

namespace EvolutionNet.Util.Windows
{
	public static class WinControlFindHelper
	{
		public static T FindControlOnChild<T>(Control control)
		{
			T findControl = default(T);
			foreach (object child in control.Controls)
			{
				if (child is T)
					return (T)child;

				if (child is Control)
					findControl = FindControlOnChild<T>((Control)child);

				if (findControl != null && !findControl.Equals(default(T)))
					return findControl;
			}
			return findControl;
		}

	}
}