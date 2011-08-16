using System;
using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using log4net;

namespace EvolutionNet.MVP.Data.Access
{
	public class DaoInitializer
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DaoInitializer));
//		private bool isDisposed;

		#region Thread-safe Singleton

		private DaoInitializer()
		{
		}

		public static DaoInitializer Instance
		{
			get
			{
				return Nested.instance;
			}
		}
		
		class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly DaoInitializer instance = new DaoInitializer();
		}

		#endregion

		public void GenerateCreationScripts(string fileName)
		{
			ActiveRecordStarter.GenerateCreationScripts(fileName);
		}

		public void InitializeActiveRecord()
		{
			InitializeActiveRecord(null);
		}

		public void InitializeActiveRecord(Type type)
		{
			try
			{
				if (!ActiveRecordStarter.IsInitialized)
				{
					if (log.IsInfoEnabled)
						log.Info("Inicializando o ActiveRecord\r\n******************************");

					// TODO: Eu tenho que criar algum valor no arquivo de config onde eu possa setar as assemblies que devem ser inicializadas pelo ActiveRecord, se isso não puder ser setado nas próprias sections do ActiveRecord.
					//Aqui eu estou inicializando o ActiveRecord, dizendo pra achar as classes que implementam [ActiveRecord] apenas neste assembly (por padrão é o assembly que chama).
					if (type == null)
						ActiveRecordStarter.Initialize(ActiveRecordSectionHandler.Instance);
//						ActiveRecordStarter.Initialize();
					else
						ActiveRecordStarter.Initialize(Assembly.GetAssembly(type), ActiveRecordSectionHandler.Instance);
				}
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("\r\n\r\nErro na inicialização do ActiveRecord!!!", ex);

				throw new Castle.ActiveRecord.Framework.ActiveRecordInitializationException(
					"Não foi possível inicializar o ActiveRecord. Dica: Verifique se todas os BaseDao's estão declarados como abstract.",
					ex);
			}
		}

		public void InitializeSessionScope()
		{
			try
			{
				if (log.IsInfoEnabled)
					log.Info("Inicializando o SessionScope");

				if (SessionScope.Current == null)
					new SessionScope(FlushAction.Never);
			}
			catch (Exception ex)
			{
				if (log.IsErrorEnabled)
					log.Error("Não foi possível iniciar uma sessão no ActiveRecord/NHibernate.", ex);

				throw new MVPIoCException("Não foi possível iniciar uma sessão no ActiveRecord/NHibernate.", ex);
			}
		}

		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public void DisposeSessionScope()
		{
			if (SessionScope.Current != null)
			{
				if (log.IsInfoEnabled)
					log.Info("Finalizando o SessionScope");

				SessionScope.Current.Dispose();
			}
		}
	}
}