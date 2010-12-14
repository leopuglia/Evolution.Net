using System;

namespace EvolutionNet.MVP.View
{
	public interface ICrudView : IControlView
	{
		object GridDataSource { get; set; }
		bool IsPostBack { get; }

		event EventHandler Save;
		event EventHandler Delete;
		event EventHandler Edit;
		event EventHandler Cancel;

	}
}