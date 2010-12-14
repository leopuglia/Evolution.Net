namespace EvolutionNet.MVP.View
{
    public interface IRedirectHelper
    {
        void RedirectToView<T>(object senderView, params object[] args);
        bool RedirectToViewModal<T>(object senderView, params object[] args);
    }
}