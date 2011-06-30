namespace EvolutionNet.MVP.View
{
	public interface IRedirectHelper
	{
		void RedirectToView<T>(object senderView, params object[] args) where T : IControlView;

		bool ShowModalDialogView(IControlView destView, object senderView);
		T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView;
	}
}