using System;

namespace EvolutionNet.MVP.Business.ProgressReporting
{
	/// <summary>
	/// Helper class for informing progress on any request
	/// </summary>
	public class BaseProgressReport : IProgressReport
	{
		private int progress;
//		private bool cancellationPending;
		protected bool reportsProgress;
		protected bool supportsCancellation = true;

		#region Public Properties

		/// <summary>
		/// Calcula o progresso restante ao método sendo utilizado.
		/// </summary>
		public double RemainingProgress
		{
			get { return 100 - progress; }
		}

/*
		public bool CancellationPending
		{
			get { return cancellationPending; }
		}
*/

		public bool ReportsProgress
		{
			get { return reportsProgress; }
			set { reportsProgress = value; }
		}

		public bool SupportsCancellation
		{
			get { return supportsCancellation; }
			set { supportsCancellation = value; }
		}

		#endregion

		#region Event Definition

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		public virtual event EventHandler<ProgressEventArgs> ProgressReported;
//		public virtual event EventHandler<WorkCompletedEventArgs> WorkCompleted;

		#endregion

		#region Public Methods

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="progress">O progresso total realizado (porcentagem).</param>
		public void ReportProgress(int progress)
		{
			OnReportProgress(progress);
		}

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="step">O tamanho do passo atual realizado (porcentagem).</param>
		public void ReportProgressStep(int step)
		{
			OnReportProgress(progress + step);
		}

/*
		public void Cancel()
		{
			if (! supportsCancellation)
				throw new Exception("The component doesn't support cancellation");

			cancellationPending = true;

//			throw new Exception("Work canceled");
			// Acho que aqui tá o pulo do gato, eu espero um pouco antes de resetar o valor
			// De qualquer jeito, pelo que eu entendi, esse Cancel fica sendo chamado até o worker ser realmente cancelado
//			Thread.Sleep(100);
//			ResetAttributes();
		}
*/

		/// <summary>
		/// Calculates the correct value of the step
		/// </summary>
		/// <param name="progressStart">Start value</param>
		/// <param name="progressEnd">End value</param>
		/// <param name="numSteps">Number of steps</param>
		/// <returns>Size of the step</returns>
		public double CalculateStepSize(double progressStart, double progressEnd, double numSteps)
		{
			return ((progressEnd - progressStart) / numSteps);
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

		#endregion

		#region Event Calling Methods

		protected virtual void OnReportProgress(int progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

/*
			if (cancellationPending)
			{
				ResetAttributes();

//				throw new WorkCanceledException();
				throw new Exception("The background work has been canceled");
			}
*/

			if (progress > 100)
				throw new ArgumentOutOfRangeException(MVPCommonMessages.ProgressReportHelper_CaptionError, MVPCommonMessages.ProgressReportHelper_Error001);

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));

			if (progress == 100)
			{
				this.progress = 0;
//				cancellationPending = false;
			}

		}

		#endregion
	}
}
