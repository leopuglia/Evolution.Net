/*
 * Created by: 
 * Created: ter�a-feira, 4 de dezembro de 2007
 */

using System;
using System.Reflection;
using log4net;

namespace EvolutionNet.MVP.Core.IoC
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

		/// <summary>
		/// Instancia um objeto a partir de tipo e descri��o do formato do tipo, tanto de origem como de destino, j� no tipo desejado.
		/// </summary>
		/// <typeparam name="T">Tipo de retorno</typeparam>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceType">Tipo de origem, por exemplo [Funcionalidade]Presenter</param>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destType">Tipo de destino, por exemplo [Funcionalidade]Facade</param>
		/// <param name="args">Argumentos a serem passados ao construtor do tipo</param>
		/// <returns>Retorna uma inst�ncia do tipo de retorno, que � baseada no tipo de destino, por exemplo [Tipo.Funcionalidade]Facade</returns>
		public static T InstantiateObj<T>(string sourceFormat, Type sourceType,
		                                  string destFormat, Type destType,
		                                  params object[] args)
		{
			return (T)InstantiateObj(sourceFormat, sourceType, destFormat, destType, args);
		}

		#endregion

		#region InstantiateObj

		/// <summary>
		/// Instancia um objeto a partir de tipo e descri��o do formato do tipo, tanto de origem como de destino.
		/// </summary>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceType">Tipo de origem, por exemplo [Funcionalidade]Presenter</param>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destType">Tipo de destino, por exemplo [Funcionalidade]Facade</param>
		/// <param name="args">Argumentos a serem passados ao construtor do tipo</param>
		/// <returns>Retorna uma inst�ncia baseada no tipo de destino, por exemplo [Tipo.Funcionalidade]Facade</returns>
		public static object InstantiateObj(string sourceFormat, Type sourceType,
		                                    string destFormat, Type destType, 
		                                    params object[] args)
		{
			string sourceAssemblyName = sourceType.Assembly.GetName().Name;
			string sourceTypeName = sourceType.Name;

			string destNamespace = destType.Namespace +
			                       sourceType.Namespace.Substring(sourceAssemblyName.Length,
			                                                      sourceType.Namespace.Length - sourceAssemblyName.Length);

			string destTypeFullName = GetDestTypeFullName(destFormat, destNamespace,
			                                              sourceFormat, sourceTypeName);

			try
			{
				object ret = destType.Assembly.CreateInstance(
					destTypeFullName, false, BindingFlags.Default, null, args, null, null);

                if (ret == null)
                {
                    string msg = string.Format("O tipo \"{0}\" n�o existe no namespace \"{1}\"!",
                        destTypeFullName, destNamespace);

                    Exception ex = new TypeLoadException(msg);

                    if (log.IsErrorEnabled)
                        log.Error(msg, ex);

                    throw ex;
                }

			    return ret;
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

		#endregion

		#endregion

		#region M�todos Auxiliares

		/// <summary>
		/// M�todo que obt�m o nome completo do tipo de destino.
		/// </summary>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destRootNamespace">String contendo o namespace de raiz do tipo de destino</param>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceTypeName">String contendo o nome do tipo de origem</param>
		/// <returns>Retorna uma string com o nome completo do tipo de destino</returns>
		private static string GetDestTypeFullName(string destFormat, string destRootNamespace,
		                                          string sourceFormat, string sourceTypeName)
		{
			destRootNamespace += ".";

			int sourcePrefixLength = sourceFormat.IndexOf("{0}");
			int sourceSuffixLength = sourceFormat.Length - sourcePrefixLength - 3;

			string sourceEssence = sourceTypeName.Substring(sourcePrefixLength, sourceTypeName.Length - sourcePrefixLength - sourceSuffixLength);

			if (string.Format(sourceFormat, sourceEssence) != sourceTypeName)
				throw new ArgumentException(string.Format("O tipo \"{0}\" n�o est� no formato \"{1}\"!", sourceTypeName, sourceFormat));

			return destRootNamespace + string.Format(destFormat, sourceEssence);
		}

		#endregion

	}
}