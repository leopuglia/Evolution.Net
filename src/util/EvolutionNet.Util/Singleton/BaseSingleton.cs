using System;

namespace EvolutionNet.Util.Singleton
{
	/// <summary>
	/// Thread Safe Singleton
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class BaseSingleton<T>
	{
		public static T Instance
		{
			get { return Nested.instance; }
		}

		public static T CreateInstance()
		{
			// TODO: Teoricamente um singleton só deve ter uma instância, mas há casos em que outras instâncias podem ser necessárias
			return Nested.CreateLocalInstance();
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
				return Activator.CreateInstance<T>();
			}
		}

	}
}