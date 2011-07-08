using System;
using log4net;

namespace EvolutionNet.Util.Singleton
{
	/// <summary>
	/// Thread Safe Singleton
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class BaseSingleton<T>
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(BaseSingleton<T>));

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
					var message = string.Format(
						"Error creating the Singleton of type ({0})",
						typeof(T));

					if (log.IsErrorEnabled)
						log.Error(message, ex);

					throw new UtilSingletonException(
						message, ex);
				}
			}
		}

		public static T CreateInstance()
		{
			// TODO: Teoricamente um singleton só deve ter uma instância, mas há casos em que outras instâncias podem ser necessárias
			return Nested.CreateLocalInstance();
		}

		private class Nested
		{
			internal static readonly T instance;

			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
				instance = CreateLocalInstance();
			}

			internal static T CreateLocalInstance()
			{
				return Activator.CreateInstance<T>();
			}
		}

	}
}