using System;
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

        private GridView GetGrid()
        {
            foreach (var control in ControlCollection)
            {
                if (control is GridView)
                    return (GridView)control;
            }
            throw new ArgumentOutOfRangeException("", "A View não possui um Grid!");
        }
    }
}
