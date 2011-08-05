using System;

namespace EvolutionNet.MVP.Core.ProgressReporting
{
	/// <summary>
	/// Define os argumentos a serem passados por um evento ProgressReported.
	/// </summary>
	public class ProgressEventArgs : EventArgs
	{
		private double step;
		private int progressPercentage;

		/// <summary>
		/// Define a porcentagem do trabalho realizado nesse passo.
		/// </summary>
		public double Step
		{
			get { return step; }
			set { step = value; }
		}

		/// <summary>
		/// Define o trabalho total realizado até o momento.
		/// </summary>
		public int ProgressPercentage
		{
			get { return progressPercentage; }
			set { progressPercentage = value; }
		}
		/// <summary>
		/// Construtor da classe.
		/// </summary>
		/// <param name="step">Define a porcentagem do trabalho realizado nesse passo</param>
		/// <param name="progressPercentage">Define o trabalho total realizado até o momento</param>
		public ProgressEventArgs(double step, int progressPercentage)
		{
			this.step = step;
			this.progressPercentage = progressPercentage;
		}
	}
}