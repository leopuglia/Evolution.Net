using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.View;
using EvolutionNet.Sample.Core.View;
using EvolutionNet.Sample.Data.Definition;
using EvolutionNet.Util.IoC;
using NUnit.Mocks;

namespace EvolutionNet.Sample.Test
{
	public class BaseTest
	{
		protected static TestHelperFactory helperFactory;

		protected virtual void Setup()
		{
			AbstractIoCFactory<IBusinessFactory>.Instance.Initialize();
			
			helperFactory = new TestHelperFactory();
		}

/*
		public static object GetModelFromView(IControlView destView)
		{
			if (destView is ICategoryEditView)
				return GetCategory();

			throw new NotSupportedException();
		}
*/

		public static DynamicMock GetViewMock<T>(params object[] args) where T : IControlView
		{
			var view = new DynamicMock(typeof(T));
			view.SetReturnValue("get_HelperFactory", helperFactory);
			view.SetReturnValue("GetType", typeof(T));

			// TODO: Isso aqui é importante, o ICategoryEditView tem que retornar o valor editado do modelo
			if (typeof(T) == typeof(ICategoryEditView))
			{
				var model = (Category) args[0];
				DataFactory.GetModelEdited<Category, int>(model);
				
				view.SetReturnValue("get_Model", model);
			}

			return view;
		}

	}
}