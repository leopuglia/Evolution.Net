using EvolutionNet.Util.IoC;

namespace EvolutionNet.MVP.View
{
	public interface IHelperFactory : IFactory
	{
		IPathHelper PathHelper { get; }
		IControlHelper GetControlHelper(IControlView view);
		IMessageHelper MessageHelper { get; }
		IRedirectHelper RedirectHelper { get; }
		IMenuHelper MenuHelper { get; }
	}
}