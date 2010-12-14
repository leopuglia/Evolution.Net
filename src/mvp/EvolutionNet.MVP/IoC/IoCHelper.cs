/*
 * Created by: 
 * Created: ter�a-feira, 4 de dezembro de 2007
 */

using System;
using System.Reflection;
using log4net;

namespace EvolutionNet.MVP.IoC
{
	/// <summary>
	/// Classe est�tica de aux�lio � cria��o de inst�ncias por Inversion Of Control (IOC).
	/// Utilizado na implementa��o das BaseFactory's.
	/// </summary>
	public static class IoCHelper
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(IoCHelper));

		#region M�todos Est�ticos P�blicos

		#region InstantiateObj<T>

		public static T InstantiateObj<T>(string sourceFormat, string sourceIgnore, string destFormat, string destAdd, Type destType, params object[] args)
		{
			return (T)InstantiateObj(sourceFormat, sourceIgnore, typeof(T), destFormat, destAdd, destType, args);
		}

		#endregion

		#region InstantiateObj

		/// <summary>
		/// Instancia um objeto a partir de tipo e descri��o do formato do tipo, tanto de origem como de destino.
		/// </summary>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceExclude">String a ser exclu�da do namespace de origem, por exemplo "Business"</param>
		/// <param name="sourceType">Tipo de origem, por exemplo [Funcionalidade]Presenter</param>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destAdd">String a ser adicionada no namespace de destino</param>
		/// <param name="destType">Tipo de destino, por exemplo [Funcionalidade]Facade</param>
		/// <param name="args">Argumentos a serem passados ao construtor do tipo</param>
		/// <returns>Retorna uma inst�ncia baseada no tipo de destino, por exemplo [Tipo.Funcionalidade]Facade</returns>
		public static object InstantiateObj(string sourceFormat, string sourceExclude, Type sourceType,
											string destFormat, string destAdd, Type destType, 
											params object[] args)
		{
			try
			{
				string sourceAssemblyName = sourceType.Assembly.GetName().Name + (string.IsNullOrEmpty(sourceExclude) ? "" : "." + sourceExclude);
				string sourceTypeName = sourceType.Name;

				if (sourceType.Namespace != null)
				{
					string destNamespace = destType.Namespace +
										   sourceType.Namespace.Substring(sourceAssemblyName.Length,
																		  sourceType.Namespace.Length - sourceAssemblyName.Length);

					string destTypeFullName = GetDestTypeFullName(destFormat, destAdd, destNamespace,
																  sourceFormat, sourceTypeName);

					object ret = destType.Assembly.CreateInstance(
						destTypeFullName, false, BindingFlags.Default, null, args, null, null);

					if (ret == null)
					{
						string msg = string.Format("O tipo \"{0}\" n�o existe no namespace \"{1}\"!",
												   destTypeFullName, destNamespace);

						TypeLoadException ex = new TypeLoadException(msg);

						if (log.IsErrorEnabled)
							log.Error(msg, ex);

						throw ex;
					}

					return ret;
				}

				string msgException = string.Format("O tipo \"{0}\" n�o possui namespace!", sourceType);
				TypeLoadException typeLoadException = new TypeLoadException(msgException);
				
				if (log.IsErrorEnabled)
					log.Error(msgException, typeLoadException);
				
				throw typeLoadException;
			}
			catch (Exception ex)
			{
				// Tenta obter uma excess�o interna de erro de configura��o do ActiveRecord, que fica oculta por outras excess�es
				Exception innerException = ex.InnerException;
				
				while (innerException != null && innerException.GetType().Name != /*Castle.ActiveRecord.Framework.*/"ActiveRecordInitializationException")
					innerException = innerException.InnerException;

				if (innerException == null)
					innerException = ex;

				if (log.IsErrorEnabled)
					log.Error("Ocorreu um erro de configura��o do ActiveRecord.", innerException);

				throw innerException;
			}
		}

		public static string GetControlVirtualPath(string sourceFormat, string sourceExclude, Type sourceType, string destFormat, string destAdd)
		{
			string sourceAssemblyName = sourceType.Assembly.GetName().Name + (string.IsNullOrEmpty(sourceExclude) ? "" : "." + sourceExclude);
			string sourceTypeName = sourceType.Name;

			if (sourceType.Namespace != null)
			{
				string virtualPath = "~/" + sourceType.Namespace.Substring(sourceAssemblyName.Length + 1,
																		   sourceType.Namespace.Length - sourceAssemblyName.Length - 1).Replace('.', '/');

				string sourceEssence = GetSourceEssence(sourceFormat, sourceTypeName);

				if (!string.IsNullOrEmpty(destAdd))
					virtualPath += "/" + destAdd;

				return virtualPath + "/" + string.Format(destFormat, sourceEssence);
			}

			string msgException = string.Format("O tipo \"{0}\" n�o possui namespace!", sourceType);
			TypeLoadException typeLoadException = new TypeLoadException(msgException);

			if (log.IsErrorEnabled)
				log.Error(msgException, typeLoadException);

			throw typeLoadException;
		}

		#endregion

		#endregion

		#region M�todos Auxiliares

		/// <summary>
		/// M�todo que obt�m o nome completo do tipo de destino.
		/// </summary>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destAdd">String a ser adicionada no namespace de destino</param>
		/// <param name="destRootNamespace">String contendo o namespace de raiz do tipo de destino</param>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceTypeName">String contendo o nome do tipo de origem</param>
		/// <returns>Retorna uma string com o nome completo do tipo de destino</returns>
		private static string GetDestTypeFullName(string destFormat, string destAdd, string destRootNamespace,
												  string sourceFormat, string sourceTypeName)
		{
			string sourceEssence = GetSourceEssence(sourceFormat, sourceTypeName);

			if (!string.IsNullOrEmpty(destAdd))
				destRootNamespace += "." + destAdd;

			return destRootNamespace + "." + string.Format(destFormat, sourceEssence);
		}

		private static string GetSourceEssence(string sourceFormat, string sourceTypeName)
		{
			int sourcePrefixLength = sourceFormat.IndexOf("{0}");
			int sourceSuffixLength = sourceFormat.Length - sourcePrefixLength - 3;

			string sourceEssence = sourceTypeName.Substring(sourcePrefixLength, sourceTypeName.Length - sourcePrefixLength - sourceSuffixLength);

			if (string.Format(sourceFormat, sourceEssence) != sourceTypeName)
				throw new ArgumentException(string.Format("O tipo \"{0}\" n�o est� no formato \"{1}\"!", sourceTypeName, sourceFormat));
			return sourceEssence;
		}

		#endregion

	}
}