using System;
using System.Collections.Generic;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.Util;

namespace EvolutionNet.MVP.Data.Definition
{
	//TODO: Pra ficar bom, eu teria q usar um assembler/mapeador pra "montar" o active record
	//a partir de um objeto que n�o tem os m�todos CRUD, tipo um "tipo" pessoa, que tem
	//apenas as propriedades e, talvez, alguns comportamentos, mas � diferente da classe
	//"PessoaActiveRecord" q possivelmente herda dela, tem tudo isso, mas n�o os m�todos.

	//Ou ent�o crio o ActiveRecord mermo, trabalho com ele atrav�s da interface e pronto, mas isso tem alguns
	//problemas...
	[Serializable]
	public abstract class BaseTo<T, IdT> : ITo<T, IdT> where T : IModel<IdT>
	{
		private T mainModel;
	    private IList<T> list;

		public T MainModel
		{
			get { return mainModel; }
			set { mainModel = value;  }
		}

	    public IList<T> List
	    {
            get { return list; }
            set { list = value; }
	    }

	    public BaseTo()
		{
			try
			{
				// Inicializa o sistema Dao
//				DaoAbstractFactory.Instance.Initialize();

				// Instancia o tipo se n�o for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					mainModel = (T) DaoAbstractFactory.Instance.GetDao<IdT>(typeof (T));

                    //TODO: Adicionei aqui. Verificar como buscar os dados.
				    list = new SortableBindingList<T>();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("N�o foi poss�vel instanciar o Dao no TO.", ex);
			}
		}
		
		//TODO: Esse m�todo aki � necess�rio pq a inst�ncia do to n�o pode ser criada aki.
		//Alternativamente eu poderia deixar a propriedade MainModel como abstrata e implement�-la
		//qdo eu crio a classe concreta do TO, tipo [Nome]TO, e l� eu saber quem � o Dao, q at� faria
		//mais sentido, por�m eu teria uma refer�ncia do Data.Definition no Data.Access, q n�o faz sentido!!!
		//Do jeito q est� agora, s� quem saberia realmente quem � a implementa��o do I[Nome] � o Facade...
		//TODO: Por isso q eu acho q vou precisar de um DataMapper, ou DataAssembler, q joga os dados de uma
		//implementa��o real da interface, mas sem os m�todos em uma implementa��o ActiveRecord da interface,
		//com todos os m�todos. O �nico problema � q eu n�o sei como eu faria pra definir os atributos das propriedades
		//desse novo objeto, a n�o ser que ele implementasse novamente todo o c�digo implementado no objeto real,
		//o q levaria a uma duplica��o de c�digo muito grande, eu queria fazer o objeto Dao herdar do objeto
		//real, mas a� eu tbm n�o poderia herdar de um BaseDao... Q saco!
		
		//TODO: Uma outra op��o � acabar com esse tanto de generics aki q eu acho q t� mais atrapalhando q ajudando
		//e criar tudo como object, ou com o objeto base e dar um cast onde for necess�rio mermo...
		//A desvantagem, al�m de n�o saber nem qual � a interface q t� sendo implementada, � q tenho q fazer tudo na m�o...
//		public BaseTo(T model)
//		{
//			mainModel = model;
//		}
		
/*
		public static TO CreateTO<TO>() where TO : ITo<T, IdT>
		{
//			IDao<IdT> model = DaoAbstractFactory.Instance.GetDao<IdT>(typeof(T));
			return (TO)Activator.CreateInstance(typeof(TO));
		}
*/
	}
}
