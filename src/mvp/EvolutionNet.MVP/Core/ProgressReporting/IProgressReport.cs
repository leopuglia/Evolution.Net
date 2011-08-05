using System;

namespace EvolutionNet.MVP.Core.ProgressReporting
{
	//TODO: Verificar se essas classes devem ser movidas para o EvolutionNet.Util
	public interface IProgressReport
	{
		bool CancelationPending { get; }
		bool ReportsProgress { get; set; }
		bool SupportsCancelation { get; set; }

		/// <summary>
		/// Calcula o progresso restante ao método sendo utilizado.
		/// </summary>
		double RemainingProgress { get; }

		event EventHandler<ProgressEventArgs> ProgressReported;
		event EventHandler WorkCompleted;

		void ReportProgress(int progress);
		void ReportProgressStep(int step);

		/// <summary>
		/// Calculates the correct value of the step
		/// </summary>
		/// <param name="progressStart">Start value</param>
		/// <param name="progressEnd">End value</param>
		/// <param name="numSteps">Number of steps</param>
		/// <returns>Size of the step</returns>
		double CalculateStepSize(double progressStart, double progressEnd, double numSteps);

		/// <summary>
		/// Ajusta o tamanho do passo atual, pelo início, final e tamanho do passo
		/// </summary>
		/// <param name="progressStart">Valor do progresso inicial</param>
		/// <param name="progressEnd">Valor do progresso final</param>
		/// <param name="step">Tamanho do passo atual</param>
		/// <returns>Valor correto do tamanho do passo</returns>
		double AdjustStep(double progressStart, double progressEnd, double step);

		void Cancel();
	}
}