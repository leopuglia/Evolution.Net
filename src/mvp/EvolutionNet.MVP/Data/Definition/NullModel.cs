namespace EvolutionNet.MVP.Data.Definition
{
	/// <summary>
	/// Interface que representa um objeto nulo, para módulos que não possuem um modelo base, como algumas de relatórios ou que não possuem atualização dos dados.
	/// </summary>
	public abstract class NullModel : Model<object>
	{
	}
}