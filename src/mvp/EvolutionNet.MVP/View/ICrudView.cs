using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.View
{
//	public delegate void CrudEventHandler(object sender, CrudEventArgs e);

	public interface ICrudView<ModelT> : IControlView, IListView<ModelT> where ModelT : IBaseModel
	{
//		object GridDataSource { get; set; }
//		bool IsPostBack { get; }

//		event CrudEventHandler AddNew;
/*
		event CrudEventHandler Save;
		event CrudEventHandler Delete;
		event CrudEventHandler Edit;
		event CrudEventHandler Cancel;
*/

	}
}