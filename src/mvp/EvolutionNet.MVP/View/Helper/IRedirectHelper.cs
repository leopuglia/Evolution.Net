using System.Collections.Generic;

namespace EvolutionNet.MVP.View.Helper
{
	public interface IRedirectHelper
	{
		// TODO: Esse m�todo n�o vai dar certo, especialmente se as p�ginas forem implementadas usando uma nomenclatura n�o convencional
		// Eu tenho que definir interfaces (ou coisa do genero) que as p�ginas / controles implementem, independentes 
		// de serem a view ou n�o, que defina a hierarquia das p�ginas, de forma que eu possa navegar nelas pelo menos 
		// sabendo quem s�o seus pais.
		// Ent�o eu tenho que definir a View e o Form que cont�m a view (que pode ser o mesmo no caso de n�o usar user controls)
		// IView
		// {
		//		IForm(ou Page) Current { get; } // retorna o form/page atual
		// }
		// IForm
		// {
		//		IForm Parent { get; } // retorna o form pai
		// }
		// Ou ent�o, definir uma estrutura tipo de SiteMap abstrata, que eu preencha na View, com as p�ginas e forma de navega��o entre elas
		// Quando for win forms, eu tenho que saber se o redirect vai ter um Close, ou se devo criar o Form, etc
		void RedirectToView<T>(object senderView) where T : IControlView;
		void RedirectToView<T>(object senderView, IDictionary<string, string> args) where T : IControlView;

		T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView;
//		bool ShowModalDialogView(IControlView destView, object senderView);
		bool ShowModalDialogView<T>(T destView, object senderView) where T : IControlView;
	}
}