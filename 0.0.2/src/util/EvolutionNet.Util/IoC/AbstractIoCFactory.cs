/*
 * Created by: 
 * Created: quinta-feira, 6 de dezembro de 2007
 */

using System;
using log4net;

namespace EvolutionNet.Util.IoC
{
	public abstract class AbstractIoCFactory<T> where T : IFactory
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AbstractIoCFactory<T>));

		public static T Instance
		{
			get
			{
				try
				{
					return Nested.instance;
				}
				catch (Exception ex)
				{
					throw new UtilIoCException(
						string.Format(
							"Error creating the Factory instance of type ({0}) via IoC. See if the factory is set on the config, in the <castle><components> section.",
							typeof(T)), ex);
				}
			}
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