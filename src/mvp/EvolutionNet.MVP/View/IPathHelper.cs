namespace EvolutionNet.MVP.View
{
	public interface IPathHelper
	{
		string GetAbsolutePath(string path);
		string GetRelativePath(string path);
	}
}