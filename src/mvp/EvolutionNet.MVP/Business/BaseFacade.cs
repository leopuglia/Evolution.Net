using System;
using EvolutionNet.MVP.Data.Definition;
using EvolutionNet.MVP.Presenter;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Base class for all Facades. Implements the IContract interface. (Deprecated)
	/// </summary>
	/// <typeparam name="TO">Tranfer Object: used to transfer values between the layers</typeparam>
	[Obsolete]
	public abstract class BaseFacade<TO> : BaseBO<TO> where TO : class, ITO
	{
		protected BaseFacade(IPresenter presenter) : base(presenter)
		{
		}
	}
}