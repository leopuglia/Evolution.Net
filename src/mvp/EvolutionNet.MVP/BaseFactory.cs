using System;
using EvolutionNet.MVP.IoC;

namespace EvolutionNet.MVP
{
	public abstract class BaseFactory : IFactory
	{
//		protected bool isInitialized = false;
//		protected bool isDisposed = false;

		/// <summary>
		/// Instancia um objeto a partir de tipo e descri��o do formato do tipo, tanto de origem como de destino.
		/// </summary>
		/// <param name="sourceFormat">String de formato do tipo de origem, por exemplo "{0}Presenter"</param>
		/// <param name="sourceType">Tipo de origem, por exemplo [Funcionalidade]Presenter</param>
		/// <param name="destFormat">String de formato do tipo de destino, por exemplo "{0}Facade"</param>
		/// <param name="destType">Tipo de destino, por exemplo [Funcionalidade]Facade</param>
		/// <param name="args">Argumentos a serem passados ao construtor do tipo</param>
		/// <returns>Retorna uma inst�ncia baseada no tipo de destino, por exemplo [Tipo.Funcionalidade]Facade</returns>
		public object GetObject(string sourceFormat, Type sourceType, 
			string destFormat, Type destType, params object[] args)
		{
			return IoCHelper.InstantiateObj(sourceFormat, sourceType,
											destFormat, destType, args);
		}

/*
		/// <summary>
		/// Realiza a inicializa��o b�sica de um m�dulo, na implementa��o da Factory.
		/// </summary>
		public abstract void Initialize();

		///<summary>
		/// Realiza a libera��o de recursos alocados pelo objeto.
		///</summary>
		public abstract void Dispose();
*/

	}
}
