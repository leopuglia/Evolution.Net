using System.Collections.Generic;
using EvolutionNet.MVP.View;
using EvolutionNet.MVP.View.Helper;
using EvolutionNet.Sample.Core.View;

namespace EvolutionNet.Sample.Test
{
	public class TestRedirectHelper : IRedirectHelper
	{
		public void RedirectToView<T>(object senderView) where T : IControlView
		{
/*
			RedirectToView<T>(senderView, null);
*/
		}

		public void RedirectToView<T>(object senderView, IDictionary<string, string> args) where T : IControlView
		{
/*
			Form frm = (Form)IoCHelper.InstantiateObj(TypeNameSource, TypeNameSourceExclude, typeof(T),
				TypeNameDestForm, "", senderView.GetType(), args == null ? null : args.Values);
			frm.Show(((UserControl)senderView).ParentForm);
*/
		}

		public T CreateModalDialogView<T>(object senderView, params object[] args) where T : IControlView
		{
			// Sets the viewMock instance value with the type T
			var viewMock = BaseTest.GetViewMock<T>(args);

			return (T)viewMock.MockInstance;
		}

		public bool ShowModalDialogView(IControlView destView, object senderView)
		{
			return true;
		}

	}
}