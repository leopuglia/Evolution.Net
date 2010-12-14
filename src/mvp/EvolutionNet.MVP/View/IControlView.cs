/*
 * Created by: 
 * Created: quinta-feira, 29 de novembro de 2007
 */

namespace EvolutionNet.MVP.View
{
	public interface IControlView : IView//<PresenterT> : IView, IDisposable where PresenterT : IPresenter
	{
        IControlView ParentView { get; }
        IControlHelper ControlHelper { get; }
        IMessageHelper MessageHelper { get; }
        IRedirectHelper RedirectHelper { get; }

	}
}