
namespace EvolutionNet.MVP.Data.Access.ActiveRecord
{
	/// <summary>
	/// Classe básica para a instância da Factory usando o ActiveRecord.
	/// </summary>
	public abstract class ARBaseDaoFactory : BaseDaoFactory
	{
/*
		public SessionScope scope;
		protected override void AddChildAssembly()
		{
			AddAssembly(Assembly.GetExecutingAssembly());
		}

		protected override void AddChildTypes()
		{
			AddType(typeof (VipBaseDao<>));
			AddType(typeof (UsuarioDao));
			AddType(typeof (PessoaDao));
		}

		static DaoFactory()
		{
			DoInitialize();
		}

		~DaoFactory()
		{
			scope.Dispose();
		}
*/

/*
		private static List<Assembly> assemblies = new List<Assembly>();

		protected void AddAssembly(Assembly assembly)
		{
//			Assembly assembly = Assembly.GetExecutingAssembly();
			
			if (! assemblies.Contains(assembly))
			{
				assemblies.Add(assembly);
				AddChildAssembly();
			}
				
		}

		protected abstract void AddChildAssembly();

		protected static void InitializeActiveRecord()
		{
			ActiveRecordStarter.Initialize(
				assemblies.ToArray(), 
				ActiveRecordSectionHandler.Instance);
		}
		
		public ARBaseDaoFactory()
		{
			AddAssembly(Assembly.GetExecutingAssembly());
			
			InitializeActiveRecord();
		}
*/
		
/*
		private static List<Type> types = new List<Type>();

		protected void AddType(Type type)
		{
			if (!types.Contains(type))
			{
				types.Add(type);
				AddChildTypes();
			}

		}

		protected abstract void AddChildTypes();

		protected static void InitializeActiveRecord()
		{
			ActiveRecordStarter.Initialize(ActiveRecordSectionHandler.Instance, types.ToArray());
		}

		public ARBaseDaoFactory()
		{
			AddType(typeof(ARBaseDao<>));

			InitializeActiveRecord();
		}
*/
		
/*
		public override void DoInitialization()
		{
			ActiveRecordStarter.Initialize();
			
			base.DoInitialization();
		}
*/

	}
}
