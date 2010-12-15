using System;
using System.Windows.Forms;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.UI.Windows
{
	public class WinControlHelper : IControlHelper
	{
		private const string TypeNameSource = "I{0}View";
		private const string TypeNameSourceExclude = "View";
		private const string TypeNameDest = "{0}View";
		private readonly ContainerControl parentView;

		public WinControlHelper(IControlView view)
		{
			parentView = (ContainerControl)view;
		}

/*
		public void Initialize(IControlView view)
		{
			parentView = (ContainerControl)view;
		}
*/

		public T CreateControlView<T>() where T : IControlView
		{
			return CreateControlView<T>(null);
		}

		public T CreateControlView<T>(params object[] args) where T : IControlView
		{
			return (T)IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T),
				TypeNameDest, "", parentView.GetType(), args);

//			return (T)Activator.CreateInstance(typeof(T), args);
		}

		public void AddControlView(IControlView view)
		{
			parentView.Controls.Add((Control)view);
		}

		public void AddControlView(IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Add((Control)view);
		}

		public void AddControlViewAt(int index, IControlView view)
		{
			parentView.Controls.Add((Control)view);
		}

		public void AddControlViewAt(int index, IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Add((Control)view);
		}

		public void RemoveControlView(IControlView view)
		{
			parentView.Controls.Remove((Control)view);
		}

		public void RemoveControlView(IControlView view, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).Remove((Control)view);
		}

		public void RemoveControlViewAt(int index)
		{
			parentView.Controls.RemoveAt(index);
		}

		public void RemoveControlViewAt(int index, object controlCollection)
		{
			((Control.ControlCollection)controlCollection).RemoveAt(index);
		}

		public T GetControlView<T>(object sender) where T : IControlView
		{
			while (!(sender is T))
			{
				sender = ((Control)sender).Parent;
			}

			return (T)sender;
		}

		public T FindControlView<T>(IControlView view) where T : IControlView
		{
			return FindControl<T>((Control)view);
		}

		public static T FindControl<T>(Control control)
		{
			T findControl = default(T);
			foreach (object child in control.Controls)
			{
				if (child is T)
					return (T)child;

				findControl = FindControl<T>(child as Control);
				if (!findControl.Equals(default(T)))
					return findControl;
			}
			return findControl;
		}

	}
}