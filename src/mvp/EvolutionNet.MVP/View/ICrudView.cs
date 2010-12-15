using System;

namespace EvolutionNet.MVP.View
{
	public delegate void CrudEventHandler(object sender, CrudEventArgs e);
	
	public class CrudEventArgs : EventArgs
	{
		private int rowIndex = -1;

		public int RowIndex
		{
			get { return rowIndex; }
			set { rowIndex = value; }
		}

		public CrudEventArgs() : this(-1)
		{
		}

		public CrudEventArgs(int rowIndex)
		{
			this.rowIndex = rowIndex;
		}
	}

	public interface ICrudView : IControlView
	{
		object GridDataSource { get; set; }
		bool IsPostBack { get; }

//		event CrudEventHandler AddNew;
		event CrudEventHandler Save;
		event CrudEventHandler Delete;
		event CrudEventHandler Edit;
		event CrudEventHandler Cancel;

	}
}