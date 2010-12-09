using System;

namespace EvolutionNet.MVP.Business
{
	/// <summary>
	/// Define os argumentos a serem passados por um evento ProgressReported.
	/// </summary>
	public class ProgressEventArgs : EventArgs
	{
		private double step;
		private double progress;

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
		public double Progress
		{
			get { return progress; }
			set { progress = value; }
		}
		/// <summary>
		/// Construtor da classe.
		/// </summary>
		/// <param name="step">Define a porcentagem do trabalho realizado nesse passo</param>
		/// <param name="progress">Define o trabalho total realizado até o momento</param>
		public ProgressEventArgs(double step, double progress)
		{
			this.step = step;
			this.progress = progress;
		}
	}
}