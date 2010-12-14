namespace EvolutionNet.MVP.View
{
    public interface IMessageHelper
    {
        void ShowMessage(string caption, string msg);
        void ShowErrorMessage(string caption, string msg, string exceptionMessage);
    }
}