
namespace EvolutionNet.MVP.Util
{
	/// <summary>
	/// Classe utilit�ria para os eventos de progresso da requisi��o.
	/// </summary>
	public static class ProgressReportHelper
	{
		/// <summary>
		/// Calcula o valor correto do passo, pelo in�cio, final e n�mero de passos.
		/// </summary>
		/// <param name="progressStart">Valor do progresso inicial</param>
		/// <param name="progressEnd">Valor do progresso final</param>
		/// <param name="numSteps">N�mero de passos</param>
		/// <returns>Valor correto do passo</returns>
		public static double CalculateStepSize(double progressStart, double progressEnd, double numSteps)
		{
			return (progressEnd - progressStart) / numSteps;
		}

		/// <summary>
		/// Ajusta o tamanho do passo atual, pelo in�cio, final e tamanho do passo
		/// </summary>
		/// <param name="progressStart">Valor do progresso inicial</param>
		/// <param name="progressEnd">Valor do progresso final</param>
		/// <param name="step">Tamanho do passo atual</param>
		/// <returns>Valor correto do tamanho do passo</returns>
		public static double AdjustStep(double progressStart, double progressEnd, double step)
		{
			return ((step * (progressEnd - progressStart)) / 100);
		}
	}
}
