using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using EvolutionNet.MVP.View;

namespace EvolutionNet.MVP.UI.Web
{
	public class BaseCrudUCView : BaseUCView, ICrudView
	{
		private GridView grid;

		public virtual object GridDataSource
		{
			get
			{
				return grid ?? (grid = FindMainGrid(this)).DataSource;
			}
			set
			{
				if (grid == null)
					grid = FindMainGrid(this);
				grid.DataSource = value;
				grid.DataBind();
			}
		}

		public virtual event EventHandler Save;
		public virtual event EventHandler Delete;
		public virtual event EventHandler Edit;
		public virtual event EventHandler Cancel;

		private GridView FindMainGrid(Control control)
		{
			GridView gridView = null;
			foreach (Control child in control.Controls)
			{
				if (child is GridView)
					return (GridView)child;

				gridView = FindMainGrid(child);
				if (gridView != null)
					return gridView;
			}
			return gridView;
		}
	}
}
