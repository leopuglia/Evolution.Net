using System;

namespace EvolutionNet.Util.ProgressReporting
{
	/// <summary>
	/// Helper class for informing progress on any request
	/// </summary>
	public class ProgressReportHelper// : BaseSingleton<ProgressReportHelper>
	{
		protected double progress;

		#region Protected Properties

		/// <summary>
		/// Calcula o progresso restante ao método sendo utilizado.
		/// </summary>
		protected double RemainingProgress
		{
			get { return 100d - progress; }
		}

		#endregion

		#region Event Definition (IProgressReport)

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		public virtual event EventHandler<ProgressEventArgs> ProgressReported;

		#endregion

		/// <summary>
		/// Calculates the correct value of the step
		/// </summary>
		/// <param name="progressStart">Start value</param>
		/// <param name="progressEnd">End value</param>
		/// <param name="numSteps">Number of steps</param>
		/// <returns>Size of the step</returns>
		public double CalculateStepSize(double progressStart, double progressEnd, double numSteps)
		{
			return (progressEnd - progressStart) / numSteps;
		}

		/// <summary>
		/// Ajusta o tamanho do passo atual, pelo início, final e tamanho do passo
		/// </summary>
		/// <param name="progressStart">Valor do progresso inicial</param>
		/// <param name="progressEnd">Valor do progresso final</param>
		/// <param name="step">Tamanho do passo atual</param>
		/// <returns>Valor correto do tamanho do passo</returns>
		public double AdjustStep(double progressStart, double progressEnd, double step)
		{
			return ((step * (progressEnd - progressStart)) / 100);
		}

		#region Métodos de Eventos

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="step">O tamanho do passo atual realizado (porcentagem).</param>
		public virtual void OnReportProgressStep(double step)
		{
			progress += step;

			if (progress > 100)
				throw new ArgumentOutOfRangeException("step", "The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="progress">O progresso total realizado (porcentagem).</param>
		public virtual void OnReportProgressSet(double progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

			if (progress > 100)
				throw new ArgumentOutOfRangeException("progress", "The maximum progress allowed is 100%");

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion


	}
}
