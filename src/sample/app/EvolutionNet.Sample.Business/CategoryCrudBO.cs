using System.Threading;
using EvolutionNet.MVP.Business;
using EvolutionNet.MVP.Presenter;
using EvolutionNet.Sample.Core.Business;
using EvolutionNet.Sample.Data.Definition;

namespace EvolutionNet.Sample.Business
{
	public class CategoryCrudBO : BaseCrudBO<CategoryCrudTO, Category, int>, ICategoryCrudContract
	{
		protected override bool ThrowExceptionOnValidation
		{
			get { return false; }
		}

		public CategoryCrudBO(IPresenter presenter) : base(presenter)
		{
			reportsProgress = true;
//			supportsCancellation = false;
		}

		public void SlowWork()
		{
			// Defining a number of 10 steps
			const int numSteps = 10;

			// Geting the step size: 100 / numSteps => 10. It should be usefull on complex cases, when the step is in thousands of database rows, for example
//			int stepSize = (int) ProgressHelper.CalculateStepSize(0, 100, numSteps);

			// Simulates a slow operation with 10 steps
			for (int i = 1; i <= numSteps; i++)
			{
				// If I'm using ReportProgress, I have to inform the report percent
				ReportProgress(i * numSteps);

				// If I'm using ReportProgressStep
//				ReportProgressStep(stepSize);

				// The time to Sleep, in miliseconds
				Thread.Sleep(((To.SlowWorkTime * 1000) / numSteps));

				// The lines below throw an exception randomically, showing the error message set on BackgroundWorkCompleted
//				int r = (new Random()).Next(20);
//				if (r == 10)
//					throw new Exception("Test error");

				// The lines below throw an exception at the midle of the progress, showing the error message set on BackgroundWorkCompleted
//				if (i == 5)
//					throw new Exception("Test error");
			}
		}
	}
}