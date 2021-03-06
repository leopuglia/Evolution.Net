/*
 * CHANGES:
 * ========
 * 2008-02-19: Fixed a _bug in PrepareControlHierarchy that appeared when using a pager
 *			  row at the top of the grid. (Thanks to Barbaros Sağlamtimur for catching this!)
 * 
 * 2008-02-06: Deprecated BoundField class & OnSorted override in GridView class
 *			 Added override for PrepareControlHierarchy; added CreateSortArrows method
 *			 (Thanks to Richard Deeming for this suggestion!)
 * 
 *			 Added two new properties: SortAscendingStyle and SortDescendingStyle
 *			 (Thanks to Tom Mason for this suggestion!)
 */

using System.Drawing.Design;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolutionNet.Util.Web
{
	public class GridView : System.Web.UI.WebControls.GridView
	{
		#region Properties

		#region Style properties

		private TableItemStyle sortAscendingStyle;
		private TableItemStyle sortDescendingStyle;

		[Description("The style applied to the header cell that is sorted in ascending order."), Themeable(true),
		 Category("Styles"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		 NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle SortAscendingStyle
		{
			get
			{
				if (sortAscendingStyle == null)
				{
					sortAscendingStyle = new TableItemStyle();
					if (IsTrackingViewState)
						((IStateManager) sortAscendingStyle).TrackViewState();
				}

				return sortAscendingStyle;
			}
		}

		[Description("The style applied to the header cell that is sorted in descending order."), Themeable(true),
		 Category("Styles"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		 NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
		public TableItemStyle SortDescendingStyle
		{
			get
			{
				if (sortDescendingStyle == null)
				{
					sortDescendingStyle = new TableItemStyle();
					if (IsTrackingViewState)
						((IStateManager) sortDescendingStyle).TrackViewState();
				}

				return sortDescendingStyle;
			}
		}

		#endregion

		#region ArrowUpImageUrl

		[Description("The url of the image shown when a column is sorted in ascending order."), DefaultValue(""),
		 Themeable(true), Category("Appearance"), Editor("System.Web.UI.Design.UrlEditor", typeof (UITypeEditor))]
		public string ArrowUpImageUrl
		{
			get
			{
				return ViewState["ArrowUpImageUrl"] as string ?? string.Empty;
			}
			set { ViewState["ArrowUpImageUrl"] = value; }
		}

		protected virtual string ArrowUpImageUrlInternal
		{
			get
			{
				return string.IsNullOrEmpty(ArrowUpImageUrl) 
					? Page.ClientScript.GetWebResourceUrl(GetType(), "EvolutionNet.Util.Web.ArrowUp.gif") 
					: ArrowUpImageUrl;
			}
		}

		#endregion

		#region ArrowDownImageUrl

		[Description("The url of the image shown when a column is sorted in descending order."), DefaultValue(""),
		 Themeable(true), Category("Appearance"), Editor("System.Web.UI.Design.UrlEditor", typeof (UITypeEditor))]
		public string ArrowDownImageUrl
		{
			get
			{
				return ViewState["ArrowDownImageUrl"] as string ?? string.Empty;
			}
			set { ViewState["ArrowDownImageUrl"] = value; }
		}

		protected virtual string ArrowDownImageUrlInternal
		{
			get
			{
				return string.IsNullOrEmpty(ArrowDownImageUrl) 
					? Page.ClientScript.GetWebResourceUrl(GetType(), "EvolutionNet.Util.Web.ArrowDown.gif") 
					: ArrowDownImageUrl;
			}
		}

		#endregion

		#endregion

		#region Methods

		protected override void PrepareControlHierarchy()
		{
			base.PrepareControlHierarchy();

			if (!HasControls()) 
				return;

			if (string.IsNullOrEmpty(SortExpression) || !ShowHeader) 
				return;

			var table = Controls[0] as Table;

			if (table == null || table.Rows.Count <= 0) 
				return;

			// Need to check first TWO rows because the first row may be a
			// pager row... Thanks for Barbaros Sağlamtimur for this catch!
			var headerRow = table.Rows[0] as GridViewRow;
			if (headerRow != null && headerRow.RowType != DataControlRowType.Header && table.Rows.Count > 1)
				headerRow = table.Rows[1] as GridViewRow;

			if (headerRow == null || headerRow.RowType != DataControlRowType.Header) 
				return;

			foreach (TableCell cell in headerRow.Cells)
			{
				var gridViewCell = cell as DataControlFieldCell;
								
				if (gridViewCell == null) 
					continue;

				DataControlField cellsField = gridViewCell.ContainingField;
								
				if (cellsField == null || cellsField.SortExpression != SortExpression) 
					continue;

				// Add the sort arrows for this cell
				CreateSortArrows(cell);

				// We're done!
				break;
			}
		}

		protected virtual void CreateSortArrows(TableCell sortedCell)
		{
			// Add the appropriate arrow image and apply the appropriate state, depending on whether we're
			// sorting the results in ascending or descending order
			TableItemStyle sortStyle;
			string imgUrl;

			if (SortDirection == SortDirection.Ascending)
			{
				imgUrl = ArrowUpImageUrlInternal;
				sortStyle = sortAscendingStyle;
			}
			else
			{
				imgUrl = ArrowDownImageUrlInternal;
				sortStyle = sortDescendingStyle;
			}

			var arrow = new Image();
			arrow.ImageUrl = imgUrl;
			arrow.BorderStyle = BorderStyle.None;
			sortedCell.Controls.Add(arrow);

			if (sortStyle != null)
				sortedCell.MergeStyle(sortStyle);
		}

		#region State Management Methods

		protected override object SaveViewState()
		{
			// We need to save any programmatic changes to the SortAscendingStyle or SortDescendingStyle
			// properties to view state...
			var state = new object[3];
			state[0] = base.SaveViewState();
			if (sortAscendingStyle != null)
				state[1] = ((IStateManager) sortAscendingStyle).SaveViewState();
			if (sortDescendingStyle != null)
				state[2] = ((IStateManager) sortDescendingStyle).SaveViewState();

			return state;
		}

		protected override void LoadViewState(object savedState)
		{
			var state = (object[]) savedState;

			base.LoadViewState(state[0]);

			if (state[1] != null)
				((IStateManager) SortAscendingStyle).LoadViewState(state[1]);
			if (state[2] != null)
				((IStateManager) SortDescendingStyle).LoadViewState(state[2]);
		}

		protected override void TrackViewState()
		{
			base.TrackViewState();

			if (sortAscendingStyle != null)
				((IStateManager) sortAscendingStyle).TrackViewState();
			if (sortDescendingStyle != null)
				((IStateManager) sortDescendingStyle).TrackViewState();
		}

		#endregion

		#endregion
	}
}
