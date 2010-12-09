/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using log4net;
using EvolutionNet.MVP.Core.IoC;

namespace EvolutionNet.MVP.Core
{
	public abstract class BaseAbstractFactory<T> where T : IFactory
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseAbstractFactory<T>));

		public static T Instance
		{
			get
			{
				// Implementar um mecanismo de IOC para instancia a classe de DAO.
				// O interessante, neste caso, é colocar as classes que implementam o NHibernate em outra Dll...
				// E colocar essa DaoFactory no projeto MvpEvolutionNet.Core
				//				Assembly.LoadFrom("SysVip.Business.dll");
				T anyFactoryImpl = IoCManager.DefaultInstance.CreateObject<T>();

				if (log.IsDebugEnabled)
					log.DebugFormat("Get FactoryImpl ({0})", anyFactoryImpl);

				return anyFactoryImpl;
				//return (DAOAbstractFactoryCadastro)SpringUtil.getBean("META-INF/negocio-cadastro-cfg.xml", "cadastroDAOFactory");
			}
		}
	}
}