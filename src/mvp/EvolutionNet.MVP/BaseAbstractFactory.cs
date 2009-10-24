/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using log4net;
using EvolutionNet.MVP.IoC;

namespace EvolutionNet.MVP
{
	public abstract class BaseAbstractFactory<T> where T : IFactory
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseAbstractFactory<T>));

		public static T Instance
		{
			get
			{
				T anyFactoryImpl = IoCManager.DefaultInstance.CreateObject<T>();

				if (log.IsDebugEnabled)
					log.DebugFormat("Get FactoryImpl ({0})", anyFactoryImpl);

				return anyFactoryImpl;
			}
		}
	}
}