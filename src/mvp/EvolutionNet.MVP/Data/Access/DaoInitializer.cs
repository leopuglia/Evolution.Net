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
		/// Realiza a inicializa��o b�sica de um m�dulo, na implementa��o da Factory.
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
					//Se isso n�o puder ser setado nas pr�prias sections do ActiveRecord.

					//Aqui eu estou inicializando o ActiveRecord, dizendo pra achar as classes que implementam [ActiveRecord] apenas neste assembly (por padr�o � o assembly que chama).
					ActiveRecordStarter.Initialize();

					if (log.IsInfoEnabled)
						log.Info("Finalizando a inicializa��o do ActiveRecord\r\n******************************");

					isInitialized = true;
				}
			}
			catch (Exception ex)
			{
				throw new Castle.ActiveRecord.Framework.ActiveRecordInitializationException(
					"N�o foi poss�vel inicializar o ActiveRecord. Dica: Verifique se todas os BaseDao's est�o declarados como abstract.",
					ex);
			}
		}

		public static void Initialize()
		{
			//TODO: Verificar aqui setando o SessionScope pra nunca fazer o flush. Sen�o o NHibernate pode fazer altera��es nas tabelas em qualquer momento, mesmo sem chamar um Save...
			//TODO: Eu tinha feito o HospedagemDao ser Lazy, mas a� eu preciso manter o session scope vivo durante toda a vida do TO, pois ele cria um proxy nem onde as propriedades podem ser obtidas apenas na hora que forem chamadas
			//TODO: O mesmo vale pra rela��es lazy...
			//TODO: De qq jeito, eu ainda tenho que estudar onde vai ficar o sessionscope (talvez no to??), pois ele � o respons�vel pelos flush's.
			//				scope = new SessionScope(FlushAction.Never);

			if (log.IsInfoEnabled)
				log.Info("Inicializando o SessionScope");

			new SessionScope(FlushAction.Never);
		}

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
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