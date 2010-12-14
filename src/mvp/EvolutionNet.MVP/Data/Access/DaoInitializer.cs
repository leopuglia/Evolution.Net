using System;
using Castle.ActiveRecord;
using log4net;

namespace EvolutionNet.MVP.Data.Access
{
/*
	public static class DaoInitializer
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(DaoInitializer));
		private static bool isInitialized;
		private static bool isDisposed;

		/// <summary>
		/// Realiza a inicialização básica de um módulo, na implementação da Factory.
		/// </summary>
		public static void InitializeActiveRecord()
		{
			try
			{
				if (!isInitialized)
				{
					if (log.IsInfoEnabled)
						log.Info("Inicializando o ActiveRecord\r\n******************************");

					//TODO: Eu tenho que criar algum valor no arquivo de config onde eu possa setar as assemblies que devem ser inicializadas pelo ActiveRecord.
					//Se isso não puder ser setado nas próprias sections do ActiveRecord.

					//Aqui eu estou inicializando o ActiveRecord, dizendo pra achar as classes que implementam [ActiveRecord] apenas neste assembly (por padrão é o assembly que chama).
					ActiveRecordStarter.Initialize();

					if (log.IsInfoEnabled)
						log.Info("Finalizando a inicialização do ActiveRecord\r\n******************************");

					isInitialized = true;
				}
			}
			catch (Exception ex)
			{
				throw new Castle.ActiveRecord.Framework.ActiveRecordInitializationException(
					"Não foi possível inicializar o ActiveRecord. Dica: Verifique se todas os BaseDao's estão declarados como abstract.",
					ex);
			}
		}

		public static void Initialize()
		{
			//TODO: Verificar aqui setando o SessionScope pra nunca fazer o flush. Senão o NHibernate pode fazer alterações nas tabelas em qualquer momento, mesmo sem chamar um Save...
			//TODO: Eu tinha feito o HospedagemDao ser Lazy, mas aí eu preciso manter o session scope vivo durante toda a vida do TO, pois ele cria um proxy nem onde as propriedades podem ser obtidas apenas na hora que forem chamadas
			//TODO: O mesmo vale pra relações lazy...
			//TODO: De qq jeito, eu ainda tenho que estudar onde vai ficar o sessionscope (talvez no to??), pois ele é o responsável pelos flush's.
			//				scope = new SessionScope(FlushAction.Never);

			if (log.IsInfoEnabled)
				log.Info("Inicializando o SessionScope");

			new SessionScope(FlushAction.Never);
		}

		///<summary>
		/// Realiza a liberação de recursos alocados pelo objeto.
		///</summary>
		public static void Dispose()
		{
			if (!isDisposed)
			{
				if (SessionScope.Current != null)
				{
					if (log.IsInfoEnabled)
						log.Info("Finalizando o SessionScope");

					SessionScope.Current.Dispose();
				}
				isDisposed = true;
			}
		}

		public static void GenerateCreationScripts(string fileName)
		{
			ActiveRecordStarter.GenerateCreationScripts(fileName);
		}

	}
*/
}