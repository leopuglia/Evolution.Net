using System;
using Castle.Core.Resource;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using log4net;

namespace EvolutionNet.MVP.Core.IoC
{
	/// <summary>
	/// Classe que gerencia o acesso ao IOC usando o Castle Windsor.
	/// </summary>
	public sealed class IoCManager
	{
		#region Atributos Privados

		private readonly IWindsorContainer container;

		#endregion

		#region Construtor (Privado)

		private IoCManager()
		{
			container = new WindsorContainer(new XmlInterpreter());
		}

		/// <summary>
		/// Inicializa um IoCManager utilizando um determinado resource, que pode ser o AppDomain.config (Web.Config, por exemplo),
		/// ou um arquivo xml, ou um xml compilado dentro de uma assembly.
		/// </summary>
		/// <param name="resourceName">
		/// Deve ser um dos seguintes valores, dependendo do tipo do resource:
		/// null, se for AppDomainConfig, ou
		/// "assembly://nome-do-assembly/path-dentro-do-assembly/nome-do-arquivo.xml
		/// "nome-do-arquivo-com-path.xml", se for XmlFile.
		/// </param>
		/// <param name="resourceType">O tipo do resource para carregar o manager.</param>
		private IoCManager(string resourceName, IoCManagerResourceType resourceType)
		{
			switch (resourceType)
			{
				case IoCManagerResourceType.AppDomainConfig:
					container = new WindsorContainer(new XmlInterpreter());
					break;
				case IoCManagerResourceType.Assembly:
					container = new WindsorContainer(new XmlInterpreter(new AssemblyResource(resourceName)));
					break;
				case IoCManagerResourceType.XmlFile:
					container = new WindsorContainer(new XmlInterpreter(new FileResource(resourceName)));
					break;
			}
		}

		#endregion

		#region Atributos Privados Estáticos

		private static IoCManager defaultInstance;
		private static readonly ILog log = LogManager.GetLogger(typeof(IoCManager));

		#endregion

		#region Propriedades Públicas Estáticas

		/// <summary>
		/// Instância padrão do IOC.
		/// </summary>
		public static IoCManager DefaultInstance
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new IoCManager();

					if (log.IsDebugEnabled)
						log.DebugFormat("Creating the IoCManager Singleton");
				}

				return defaultInstance;
			}
		}

		#endregion

		#region Métodos Públicos Estáticos

		/// <summary>
		/// Cria uma instância diferente do IoCManager, com outros tipos de recursos.
		/// </summary>
		/// <param name="resourceName">
		/// Deve ser um dos seguintes valores, dependendo do tipo do resource:
		/// null, se for AppDomainConfig, ou
		/// "assembly://nome-do-assembly/path-dentro-do-assembly/nome-do-arquivo.xml
		/// "nome-do-arquivo-com-path.xml", se for XmlFile.
		/// </param>
		/// <param name="resourceType">O tipo do resource para carregar o manager.</param>
		/// <returns>Instância do IoCManager</returns>
		public static IoCManager GetInstance(string resourceName, IoCManagerResourceType resourceType)
		{
			return new IoCManager(resourceName, resourceType);
		}

		/// <summary>
		/// Cria uma instância do objeto do tipo informado.
		/// </summary>
		/// <param name="t">Tipo do objeto a ser criado</param>
		/// <returns>Retorna o objeto criado</returns>
		public object CreateObject(Type t)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat(string.Format("Creating the requested {0} object via Windsor Container", t));

			return container[t];
		}

		/// <summary>
		/// Cria uma instância do objeto do tipo informado.
		/// </summary>
		/// <typeparam name="T">Tipo do objeto a ser criado</typeparam>
		/// <returns>Retorna o objeto criado</returns>
		public T CreateObject<T>()
		{
			if (log.IsDebugEnabled)
				log.DebugFormat(string.Format("Creating the requested {0} object via Windsor Container", typeof(T)));

			return (T)container[typeof(T)];
		}

		/// <summary>
		/// Cria uma instância do objeto do tipo informado, a partir de uma chave.
		/// </summary>
		/// <typeparam name="T">Tipo do objeto a ser criado</typeparam>
		/// <param name="key">A chave para a criação do objeto</param>
		/// <returns>Retorna o objeto criado</returns>
		public T CreateObject<T>(string key)
		{
			if (log.IsDebugEnabled)
				log.DebugFormat(string.Format("Creating the requested {0} object via Windsor Container", typeof(T)));

			return (T)container[key];
		}

		#endregion

	}

	/// <summary>
	/// Enumeração dos tipos possíveis de tipos de recursos aceitos pelo IoCManager.
	/// </summary>
	public enum IoCManagerResourceType
	{
		AppDomainConfig,
		Assembly,
		XmlFile
	}
	
}
