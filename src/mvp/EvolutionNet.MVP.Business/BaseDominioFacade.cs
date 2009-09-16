using System;
using System.Reflection;
using EvolutionNet.MVP.Core.Contract;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.Util;
#if FRAMEWORK_2
using NHibernate.Expression;
#else
using NHibernate.Criterion;
#endif

namespace EvolutionNet.MVP.Business
{
	public abstract class BaseDominioFacade<TO, T, IdT> : BaseFacade<TO, T, IdT>, IDominioContract
		where TO : ITo<T, IdT>
		where T : IModel<IdT>
	{
		protected override void DoFindAll()
		{
#if FRAMEWORK_2
			ICriterion criterion = new EqExpression("Visivel", true);
#else
			ICriterion criterion = Restrictions.Eq("Visivel", true);
#endif
			Order order = new Order("Nome", true);

			Type type = Dao.GetType();

			To.List = new SortableBindingList<T>(
				(T[])type.InvokeMember(
					"FindAll",
					BindingFlags.InvokeMethod | BindingFlags.Public |
					BindingFlags.Static | BindingFlags.FlattenHierarchy,
					null,
					null,
					new object[] { order, criterion } ));
		}

		public void FindAllForEdit()
		{
			base.DoFindAll();
		}
	}
}