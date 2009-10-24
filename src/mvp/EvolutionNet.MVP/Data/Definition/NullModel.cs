namespace EvolutionNet.MVP.Data.Definition
{
	/// <summary>
	/// Interface que representa um objeto nulo, para m�dulos que n�o possuem um modelo base, como algumas de relat�rios ou que n�o possuem atualiza��o dos dados.
	/// </summary>
	public abstract class NullModel : Model<object>
	{
	}
}