using System.Web.UI;

namespace EvolutionNet.Util.Web
{
	public static class WebControlHelper
	{
		public static T FindControl<T>(Control control)
		{
			T findControl = default(T);
			foreach (object child in control.Controls)
			{
				if (child is T)
					return (T)child;

				if (child is Control)
					findControl = FindControl<T>((Control)child);

				if (findControl != null && !findControl.Equals(default(T)))
					return findControl;
			}
			return findControl;
		}

		public static Control FindUpdatePanelOrPage(Control control)
		{
			if (control.Parent != null && control.Parent is UpdatePanel)
				return control.Parent;

			if (control.Parent is Page)
				return control.Parent;

			return FindUpdatePanelOrPage(control.Parent);
		}

		public static bool IsInsideUpdatePanel(Control control)
		{
			return FindUpdatePanelOrPage(control) is UpdatePanel;
		}

	}
}