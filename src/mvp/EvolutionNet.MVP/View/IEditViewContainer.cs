namespace EvolutionNet.MVP.View
{
	public interface IEditViewContainer<T> where T : IControlView
	{
		T EditView { get; }
		void ShowModalDialog();
		void HideModalDialog();
		void Clear();
	}
}