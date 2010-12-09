using System;

namespace EvolutionNet.Calendar.Holiday
{
	public static class Common
	{
		public static DateTime GetNewYearDayDate(int year)
		{
			return new DateTime(year, 1, 1);
		}

	}
}
