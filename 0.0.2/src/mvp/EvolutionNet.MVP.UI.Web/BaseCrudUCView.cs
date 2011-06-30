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

//		public virtual event CrudEventHandler AddNew;
		public virtual event CrudEventHandler Save;
		public virtual event CrudEventHandler Delete;
		public virtual event CrudEventHandler Edit;
		public virtual event CrudEventHandler Cancel;

		private GridView FindMainGrid(Control control)
		{
			return WebControlHelper.FindControl<GridView>(control);
		}
	}
}
