/*
 * Created by: 
 * Created: sexta-feira, 29 de fevereiro de 2008
 */

using System;
using System.Collections.Generic;
using System.Reflection;

namespace EvolutionNet.Util.Reflection
{
	/// <summary>
	/// Classe estática com métodos utilitários para cópia de valores de propriedades comuns entre tipos diferentes.
	/// </summary>
	public static class TypePropertiesHelper
	{
		#region Métodos de Cópia de Super-Classe -> Sub-Classe

		/// <summary>
		/// Copia os valores das propriedades em comum de um objeto super-classe para um objeto filho.
		/// </summary>
		/// <typeparam name="TOld">O tipo do objeto pai (super-classe)</typeparam>
		/// <typeparam name="TNew">O tipo do objeto filho (classe herdada)</typeparam>
		/// <param name="obj">O objeto pai</param>
		/// <returns>Retorna um novo objeto filho</returns>
		public static TNew ToInheritedObject<TOld, TNew>(TOld obj) where TNew: new() 
		{
			return ToInheritedObject<TOld, TNew>(obj, false);
		}

		/// <summary>
		/// Copia os valores das propriedades em comum de um objeto super-classe para um objeto filho.
		/// </summary>
		/// <typeparam name="TOld">O tipo do objeto pai (super-classe)</typeparam>
		/// <typeparam name="TNew">O tipo do objeto filho (classe herdada)</typeparam>
		/// <param name="obj">O objeto pai</param>
		/// <param name="flattenHierarchy">Define se os métodos das interfaces e classes herdadas também devem ser copiados</param>
		/// <returns>Retorna um novo objeto filho</returns>
		public static TNew ToInheritedObject<TOld, TNew>(TOld obj, bool flattenHierarchy) where TNew : new()
		{
			TNew newObj = new TNew();
			CopyTypePropertyValues<TOld>(obj, newObj, flattenHierarchy);

			return newObj;
		}

		/// <summary>
		/// Copia os valores das propriedades definidas em uma interface de um objeto super-classe para um objeto filho
		/// </summary>
		/// <typeparam name="TOld">O tipo do objeto pai (super-classe)</typeparam>
		/// <typeparam name="TNew">O tipo do objeto filho (classe herdada)</typeparam>
		/// <typeparam name="TInterface">O tipo que contém as propriedades (geralmente a super-classe)</typeparam>
		/// <param name="obj">O objeto pai</param>
		/// <returns>Retorna um novo objeto filho</returns>
		public static TNew ToInheritedObjectByInterface<TOld, TNew, TInterface>(TOld obj) where TNew : new()
		{
			return ToInheritedObjectByInterface<TOld, TNew, TInterface>(obj, false);
		}

		/// <summary>
		/// Copia os valores das propriedades definidas em uma interface de um objeto super-classe para um objeto filho
		/// </summary>
		/// <typeparam name="TOld">O tipo do objeto pai (super-classe)</typeparam>
		/// <typeparam name="TNew">O tipo do objeto filho (classe herdada)</typeparam>
		/// <typeparam name="TInterface">O tipo que contém as propriedades (geralmente a super-classe)</typeparam>
		/// <param name="obj">O objeto pai</param>
		/// <param name="flattenHierarchy">Define se os métodos das interfaces e classes herdadas também devem ser copiados</param>
		/// <returns>Retorna um novo objeto filho</returns>
		public static TNew ToInheritedObjectByInterface<TOld, TNew, TInterface>(TOld obj, bool flattenHierarchy) where TNew : new()
		{
			TNew newObj = new TNew();
			CopyTypePropertyValues<TInterface>(obj, newObj, flattenHierarchy);

			return newObj;
		}

		#endregion

		#region Método de Comparação de Valores

		/// <summary>
		/// Compara os valores das propriedades em comum de um objeto super-classe com um objeto filho
		/// </summary>
		/// <param name="obj1">Objeto 1</param>
		/// <param name="obj2">Objeto 2</param>
		/// <param name="type">Tipo com as propriedades a serem comparadas; Pode ser uma interface ou classe que os 2 objetos implementam</param>
		/// <returns>True se todas as propriedades contiverem os mesmos valores ou False caso contrário</returns>
		public static bool Equals(object obj1, object obj2, Type type)
		{
			foreach (PropertyInfo property in type.GetProperties())
			{
				if (property.CanRead)
				{
					object value1 = property.GetValue(obj1, null);
					object value2 = property.GetValue(obj2, null);

					if (value1 == null)
					{
						if (value2 != null)
							return false;
					}
					else
						if (!value1.Equals(value2))
							return false;
				}
			}

			return true;
		}

		#endregion

		#region Métodos Auxiliares de Realização da Cópia

		/// <summary>
		/// Cria a lista de propriedades a serem copiadas entre os objetos super-classe e filho, e chama a cópia.
		/// </summary>
		/// <typeparam name="TypeToCopy">O tipo que contém as propriedades (geralmente a super-classe)</typeparam>
		/// <param name="objOld">O objeto pai (super-classe)</param>
		/// <param name="objNew">O objeto filho (classe herdada)</param>
		/// <param name="flattenHierarchy">Define se os métodos das interfaces e classes herdadas também devem ser copiados</param>
		private static void CopyTypePropertyValues<TypeToCopy>(object objOld, object objNew, bool flattenHierarchy)
		{
			List <PropertyInfo> properties = new List<PropertyInfo>();

			properties.AddRange(GetTypeProperties(typeof(TypeToCopy)));

			if (flattenHierarchy)
			{
				Type baseType = typeof (TypeToCopy).BaseType;
				while (baseType != null && baseType != typeof(object))
					properties.AddRange(GetTypeProperties(baseType));

				foreach (Type interfaceType in typeof(TypeToCopy).GetInterfaces())
					properties.AddRange(GetTypeProperties(interfaceType));
			}

			CopyPropertyValues(properties, objOld, objNew);
		}

		/// <summary>
		/// Realiza realmente a cópia dos valores das propriedades em comum de um objeto super-classe para um objeto filho
		/// </summary>
		/// <param name="properties">Lista de propriedades a serem copiadas</param>
		/// <param name="objOld">O objeto pai (super-classe)</param>
		/// <param name="objNew">O objeto filho (classe herdada)</param>
		private static void CopyPropertyValues(IEnumerable<PropertyInfo> properties, object objOld, object objNew)
		{
			foreach (PropertyInfo propertyToCopy in properties)
			{
				PropertyInfo property = objOld.GetType().GetProperty(propertyToCopy.Name, propertyToCopy.PropertyType);

				if (property.CanRead && property.CanWrite/* && property.PropertyType.GetInterface("IList") == null*/)
				{
					PropertyInfo propertyNew = objNew.GetType().GetProperty(
						propertyToCopy.Name, propertyToCopy.PropertyType);

					object value = property.GetValue(objOld, null);
					propertyNew.SetValue(objNew, value, null);
				}
			}
		}

		/// <summary>
		/// Obtém as propriedades de um determinado tipo.
		/// </summary>
		/// <param name="typeToCopy">Tipo que serão obtidas as propriedades</param>
		/// <returns>Retorna uma lista com as propriedades obtidas</returns>
		private static PropertyInfo[] GetTypeProperties(Type typeToCopy)
		{
			return typeToCopy.GetProperties(
//				BindingFlags.FlattenHierarchy |
//				BindingFlags.Instance |
//				BindingFlags.Public
				);
		}

		#endregion

	}
}