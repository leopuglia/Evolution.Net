using System.IO;
using System.Reflection;
using EvolutionNet.MVP.View;
using EvolutionNet.Util.Singleton;

namespace EvolutionNet.Sample.Test
{
	public class TestPathHelper : BaseSingleton<TestPathHelper>, IPathHelper
	{
		public string GetPhysicalPath(string virtualPath)
		{
			return Path.Combine(Assembly.GetExecutingAssembly().Location, virtualPath);
		}

		public string GetAbsolutePath(string virtualPath)
		{
			return Path.Combine(Assembly.GetExecutingAssembly().Location, virtualPath).Replace(
				Assembly.GetExecutingAssembly().Location, "");
		}

	}
}