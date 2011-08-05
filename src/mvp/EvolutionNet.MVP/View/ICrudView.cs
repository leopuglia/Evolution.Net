using System;
using EvolutionNet.MVP.Data.Definition;

namespace EvolutionNet.MVP.View
{
//	public delegate void CrudEventHandler(object sender, CrudEventArgs e);

	public interface ICrudView<ModelT> : IControlView, IListView<ModelT> where ModelT : IBaseModel
	{
		// Exclui o evento Load, porque ele n�o � �til no Presenter, uma vez que o pr�prio presenter � criado no Load, isto �, s� pode se subscrever pra eventos posteriores
//		event EventHandler Load;
		event EventHandler LoadComplete;

//		bool IsPostBack { get; }
//		event CrudEventHandler Save;
//		event CrudEventHandler Delete;
//		event CrudEventHandler Edit;
//		event CrudEventHandler Cancel;

	}
}