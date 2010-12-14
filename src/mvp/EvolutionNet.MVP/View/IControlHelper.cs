namespace EvolutionNet.MVP.View
{
	public interface IControlHelper
	{
//		void Initialize(IControlView view);

		T CreateControlView<T>() where T : IControlView;
//		T CreateControlView<T>(object controlCollection) where T : IControlView;
		T CreateControlView<T>(params object[] args) where T : IControlView;
//		T CreateControlView<T>(object controlCollection, params object[] args) where T : IControlView;
		void AddControlView(IControlView view);
		void AddControlView(IControlView view, object controlCollection);
		void AddControlViewAt(int index, IControlView view);
		void AddControlViewAt(int index, IControlView view, object controlCollection);
		void RemoveControlView(IControlView view);
		void RemoveControlView(IControlView view, object controlCollection);
		void RemoveControlViewAt(int index);
		void RemoveControlViewAt(int index, object controlCollection);
		T GetControlView<T>(object sender) where T : IControlView;
//		T GetControlView<T>(object sender, object controlCollection) where T : IControlView;
	}
}