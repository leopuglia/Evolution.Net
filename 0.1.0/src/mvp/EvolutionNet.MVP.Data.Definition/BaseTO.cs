using System;
using System.Collections.Generic;
using EvolutionNet.MVP.Core.Data.Access;
using EvolutionNet.MVP.Core.Data.Definition;
using EvolutionNet.MVP.Core.TO;
using EvolutionNet.MVP.Core.Util;

namespace EvolutionNet.MVP.Data.Definition
{
	//TODO: Pra ficar bom, eu teria q usar um assembler/mapeador pra "montar" o active record
	//a partir de um objeto que não tem os métodos CRUD, tipo um "tipo" pessoa, que tem
	//apenas as propriedades e, talvez, alguns comportamentos, mas é diferente da classe
	//"PessoaActiveRecord" q possivelmente herda dela, tem tudo isso, mas não os métodos.

	//Ou então crio o ActiveRecord mermo, trabalho com ele através da interface e pronto, mas isso tem alguns
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

				// Instancia o tipo se não for um tipo nulo
				if (typeof(T) != typeof(INullModel))
				{
					mainModel = (T) DaoAbstractFactory.Instance.GetDao<IdT>(typeof (T));

                    //TODO: Adicionei aqui. Verificar como buscar os dados.
				    list = new SortableBindingList<T>();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Não foi possível instanciar o Dao no TO.", ex);
			}
		}
		
		//TODO: Esse método aki é necessário pq a instância do to não pode ser criada aki.
		//Alternativamente eu poderia deixar a propriedade MainModel como abstrata e implementá-la
		//qdo eu crio a classe concreta do TO, tipo [Nome]TO, e lá eu saber quem é o Dao, q até faria
		//mais sentido, porém eu teria uma referência do Data.Definition no Data.Access, q não faz sentido!!!
		//Do jeito q está agora, só quem saberia realmente quem é a implementação do I[Nome] é o Facade...
		//TODO: Por isso q eu acho q vou precisar de um DataMapper, ou DataAssembler, q joga os dados de uma
		//implementação real da interface, mas sem os métodos em uma implementação ActiveRecord da interface,
		//com todos os métodos. O único problema é q eu não sei como eu faria pra definir os atributos das propriedades
		//desse novo objeto, a não ser que ele implementasse novamente todo o código implementado no objeto real,
		//o q levaria a uma duplicação de código muito grande, eu queria fazer o objeto Dao herdar do objeto
		//real, mas aí eu tbm não poderia herdar de um BaseDao... Q saco!
		
		//TODO: Uma outra opção é acabar com esse tanto de generics aki q eu acho q tá mais atrapalhando q ajudando
		//e criar tudo como object, ou com o objeto base e dar um cast onde for necessário mermo...
		//A desvantagem, além de não saber nem qual é a interface q tá sendo implementada, é q tenho q fazer tudo na mão...
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
