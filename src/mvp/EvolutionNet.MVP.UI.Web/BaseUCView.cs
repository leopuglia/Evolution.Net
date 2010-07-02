using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseUCView : UserControl, IControlView
	{
	    private GridView grid;
		protected BaseMessageUC messageUC;

        public IPathHelper PathHelper
        {
            get { return WebPathHelper.Instance; }
        }

        protected virtual ControlCollection ControlCollection
        {
            get { return Controls; }
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
            get
            {
                return grid ?? (grid = GetGrid()).DataSource;
            }
            set
            {
                if (grid == null)
                    grid = GetGrid();
                grid.DataSource = value;
                grid.DataBind();
            }
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
			ControlCollection.Add((Control) view);
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            Page.LoadComplete += BasePage_LoadComplete;
        }

        protected void BasePage_LoadComplete(object sender, EventArgs e)
        {
            DoLoadComplete();
        }

        private GridView GetGrid()
	    {
            foreach (var control in ControlCollection)
            {
                if (control is GridView)
                    return (GridView)control;
            }
            throw new ArgumentOutOfRangeException("", "A View não possui um Grid!");
	    }

/*
		public virtual object CreateControl(string virtualPath)
		{
			return LoadControl(virtualPath);
		}

		public virtual object CreateControl(Type t, params object[] args)
		{
			return LoadControl(t, args);
		}

		public virtual T CreateControl<T>(string virtualPath) where T : Control, IView
		{
			return (T) LoadControl(virtualPath);
		}

		public virtual T CreateControl<T>(params object[] args) where T : Control
		{
			return (T)LoadControl(typeof(T), args);
		}
*/

	}
}
