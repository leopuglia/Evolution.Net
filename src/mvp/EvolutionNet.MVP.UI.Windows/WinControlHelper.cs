using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinControlHelper : IControlHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDest = "{0}View";
		private readonly ContainerControl parentView;

		#region Constructor

		public WinControlHelper(IControlView view)
		{
			parentView = (ContainerControl)view;
		}

		#endregion

		#region Thread Safe "Singleton"

//		public static T Instance
//		{
//			get { return Nested.instance; }
//		}

		// This is not exactly a singleton, but has to be created from a static method
		public static WinControlHelper CreateInstance(IControlView view)
		{
			return Nested.CreateLocalInstance(view);
		}

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static WinControlHelper CreateLocalInstance(IControlView view)
			{
				return new WinControlHelper(view);
			}
		}

		#endregion

		#region IControlHelper Methods

		public virtual void Clear()
		{
			parentView.Controls.Clear();
		}

		public virtual void Clear(object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Clear();
		}

		public virtual T CreateControlView<T>() where T : IControlView
		{
			return CreateControlView<T>(null);
		}

		public virtual T CreateControlView<T>(params object[] args) where T : IControlView
		{
			return (T)IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T),
				TypeNameDest, "", parentView.GetType(), args);

//			return (T)Activator.CreateInstance(typeof(T), args);
		}

		public virtual void AddControlView(IControlView view)
		{
			parentView.Controls.Add((Control)view);
		}

		public virtual void AddControlView(IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Add((Control)view);
		}

		public virtual void AddControlViewAt(int index, IControlView view)
		{
			parentView.Controls.Add((Control)view);
		}

		public virtual void AddControlViewAt(int index, IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Add((Control)view);
		}

		public virtual void RemoveControlView(IControlView view)
		{
			parentView.Controls.Remove((Control)view);
		}

		public virtual void RemoveControlView(IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Remove((Control)view);
		}

		public virtual void RemoveControlViewAt(int index)
		{
			parentView.Controls.RemoveAt(index);
		}

		public virtual void RemoveControlViewAt(int index, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).RemoveAt(index);
		}

		public virtual T GetControlView<T>(object sender) where T : IControlView
		{
			while (!(sender is T))
			{
				sender = ((Control)sender).Parent;
			}

			return (T)sender;
		}

		public virtual T FindControlView<T>(IControlView view) where T : IControlView
		{
			return FindControl<T>((Control)view);
		}

		public virtual object FindControlByNameOrID(IControlView view, string name, bool searchAllChildren)
		{
			return ((Control)view).Controls.Find(name, searchAllChildren);
		}

		#endregion

		#region Static Methods

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

		#endregion

	}
}