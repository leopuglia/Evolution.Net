using System;
using System.Reflection;

namespace EvolutionNet.Sample.Test
{
	public class ReflectionHelper
	{
		public static object RunInstanceMethod(Type t, string strMethod, object objInstance, params object[] objParams)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
			
			return RunMethod(t, strMethod, objInstance, flags, objParams);
		}

		public static object GetInstanceValue(Type t, string strProperty, object objInstance)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

			return GetValue(t, strProperty, objInstance, flags);
		}

		private static object RunMethod(Type t, string strMethod,
			object objInstance, BindingFlags flags, params object[] objParams)
		{
			MethodInfo m;
			try
			{
				m = t.GetMethod(strMethod, flags);
				if (m == null)
				{
					throw new ArgumentException("There is no method '" +
					 strMethod + "' for type '" + t.ToString() + "'.");
				}

				object objRet = m.Invoke(objInstance, objParams);
				return objRet;
			}
			catch
			{
				throw;
			}
		}

		private static object GetValue(Type t, string strProperty,
			object objInstance, BindingFlags flags)
		{
			FieldInfo f;
			PropertyInfo p;
			try
			{
				f = t.GetField(strProperty, flags);
				p = t.GetProperty(strProperty, flags);

				if (f != null)
					return f.GetValue(objInstance);
				if (p != null)
					return p.GetValue(objInstance, null);

				throw new ArgumentException(string.Format("There is no property '{0}' for type '{1}", strProperty, t));
			}
			catch
			{
				throw;
			}
		}

	}
}