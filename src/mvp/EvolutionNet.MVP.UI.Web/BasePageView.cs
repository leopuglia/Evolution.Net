using System;
using System.Web.UI;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BasePageView : Page, IControlView
	{
		protected BaseMessageUC messageUC;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			Page.LoadComplete += BasePage_LoadComplete;
		}

		private void BasePage_LoadComplete(object sender, EventArgs e)
		{
			DoLoadComplete();
		}

		public IPathHelper PathHelper
		{
			get { return WebPathHelper.Instance; }
		}

		public virtual void DoLoad()
		{
		}

		public virtual void DoLoadComplete()
		{
		}

		public virtual void ShowMessage(string caption, string message)
		{
			messageUC.ShowMessage(caption, message);
		}

		public virtual void ShowErrorMessage(string caption, string message, Exception ex)
		{
			messageUC.ShowErrorMessage(caption, message, ex);
		}

	    public object GridDataSource
	    {
	        get { throw new NotImplementedException(); }
	        set { throw new NotImplementedException(); }
	    }

	    public T CreateControlView<T>() where T : IControlView
		{
			return ControlHelper.CreateControlFromView<T>(this);
		}

		public virtual T CreateControlView<T>(params object[] args) where T : IControlView
		{
			throw new NotImplementedException();
		}

		public virtual T GetControlView<T>(object sender) where T : IControlView
		{
			while (!(sender is T))
			{
				sender = ((Control)sender).Parent;
			}

			return (T)sender;
		}

		public virtual void AddControlView(IControlView view)
		{
			ControlCollection.Add((Control)view);
		}

		public virtual void AddControlViewAt(int index, IControlView view)
		{
			ControlCollection.AddAt(index, (Control)view);
		}

		public virtual void RemoveControlView(IControlView view)
		{
			ControlCollection.Remove((Control)view);
		}

		public virtual void RemoveControlViewAt(int index)
		{
			ControlCollection.RemoveAt(index);
		}

		protected virtual ControlCollection ControlCollection
		{
			get { return Controls; }
		}

	}
}
