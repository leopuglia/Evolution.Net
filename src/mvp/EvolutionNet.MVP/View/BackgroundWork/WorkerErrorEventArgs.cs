using System;

namespace EvolutionNet.MVP.View.BackgroundWork
{
	public class WorkerErrorEventArgs : EventArgs
	{
		private readonly Exception error;

		public Exception Error
		{
			get { return error; }
		}

		public WorkerErrorEventArgs(Exception error)
		{
			this.error = error;
		}
	}
}