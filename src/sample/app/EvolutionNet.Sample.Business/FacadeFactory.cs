using System.Reflection;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using EvolutionNet.MVP.Business;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Business
{
    public class FacadeFactory : BaseFacadeFactory, IFacadeFactory
    {
        public override void Initialize()
        {
            ActiveRecordStarter.Initialize(Assembly.GetAssembly(typeof(SqlServerModel)), ActiveRecordSectionHandler.Instance);
        }

        public void GenerateCreationScripts(string fileName)
        {
            ActiveRecordStarter.CreateSchema(typeof(SqlServerModel));
        }
    }
}