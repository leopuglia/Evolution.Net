using System.Collections.Generic;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IRedirectHelper
	{
		// TODO: Esse método não vai dar certo, especialmente se as páginas forem implementadas usando uma nomenclatura não convencional
		// Eu tenho que definir interfaces (ou coisa do genero) que as páginas / controles implementem, independentes 
		// de serem a view ou não, que defina a hierarquia das páginas, de forma que eu possa navegar nelas pelo menos 
		// sabendo quem são seus pais.
		// Então eu tenho que definir a View e o Form que contém a view (que pode ser o mesmo no caso de não usar user controls)
		// IView
		// {
		//		IForm(ou Page) Current { get; } // retorna o form/page atual
		// }
		// IForm
		// {
		//		IForm Parent { get; } // retorna o form pai
		// }
		// Ou então, definir uma estrutura tipo de SiteMap abstrata, que eu preencha na View, com as páginas e forma de navegação entre elas
		// Quando for win forms, eu tenho que saber se o redirect vai ter um Close, ou se devo criar o Form, etc
		void RedirectToView<T>(object senderView) where T : IControlView;
		void RedirectToView<T>(object senderView, IDictionary<string, string> args) where T : IControlView;

		T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView;
//		bool ShowModalDialogView(IControlView destView, object senderView);
		bool ShowModalDialogView<T>(T destView, object senderView) where T : IControlView;
	}
}