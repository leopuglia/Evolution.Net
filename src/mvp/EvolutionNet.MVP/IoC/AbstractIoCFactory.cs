/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using log4net;

namespace EvolutionNet.MVP.IoC
{
	public abstract class AbstractIoCFactory<T> where T : IFactory
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AbstractIoCFactory<T>));

		public static T Instance
		{
			get { return Nested.instance; }
		}

		private class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly T instance = CreateLocalInstance();

			internal static T CreateLocalInstance()
			{
				T anyFactoryImpl = IoCManager.DefaultInstance.CreateObject<T>();

				if (log.IsDebugEnabled)
					log.DebugFormat("Get FactoryImpl ({0})", anyFactoryImpl);

				return anyFactoryImpl;
			}
		}

	}
}