using System;

namespace EvolutionNet.MVP.Core.ProgressReporting
{
	/// <summary>
	/// Helper class for informing progress on any request
	/// </summary>
	public class ProgressReportHelper : IProgressReport
	{
		private double progress;
		private bool cancelationPending;
		private bool reportsProgress = true;
		private bool supportsCancelation;

		#region Public Properties

		/// <summary>
		/// Calcula o progresso restante ao método sendo utilizado.
		/// </summary>
		public double RemainingProgress
		{
			get { return 100d - progress; }
		}

		public bool CancelationPending
		{
			get { return cancelationPending; }
		}

		public bool ReportsProgress
		{
			get { return reportsProgress; }
			set { reportsProgress = value; }
		}

		public bool SupportsCancelation
		{
			get { return supportsCancelation; }
			set { supportsCancelation = value; }
		}

		#endregion

		#region Event Definition

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		public virtual event EventHandler<ProgressEventArgs> ProgressReported;
		public virtual event EventHandler WorkCompleted;

		#endregion

		#region Public Methods

		public void ReportProgress(int progress)
		{
			OnReportProgress(progress);
		}

		public void ReportProgressStep(int step)
		{
			OnReportProgressStep(step);
		}

		public void Cancel()
		{
			cancelationPending = true;
		}

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

		#endregion

		#region Events Calling Methods

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="step">O tamanho do passo atual realizado (porcentagem).</param>
		protected virtual void OnReportProgressStep(double step)
		{
			progress += step;

			if (progress > 100)
				throw new ArgumentOutOfRangeException(CommonMessages.ProgressReportHelper_CaptionError, CommonMessages.ProgressReportHelper_Error001);
			
			if (progress == 100 && WorkCompleted != null)
				WorkCompleted(this, new EventArgs());

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}

		/// <summary>
		/// Reporta o progresso da requisição atual.
		/// </summary>
		/// <param name="progress">O progresso total realizado (porcentagem).</param>
		protected virtual void OnReportProgress(double progress)
		{
			double step = progress - this.progress;
			this.progress = progress;

			if (progress > 100)
				throw new ArgumentOutOfRangeException(CommonMessages.ProgressReportHelper_CaptionError, CommonMessages.ProgressReportHelper_Error001);

			if (progress == 100 && WorkCompleted != null)
				WorkCompleted(this, new EventArgs());

			if (ProgressReported != null)
				ProgressReported(this, new ProgressEventArgs(step, progress));
		}


		#endregion


	}
}
