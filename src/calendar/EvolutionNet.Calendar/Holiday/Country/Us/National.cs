using System;
using System.Collections.Generic;

namespace EvolutionNet.Calendar.Holiday.Country.Us
{
	public class National : BaseCountry
	{
		public National(int year) : base(year)
		{
		}

		#region NewYearDay

		public NationalHoliday NewYearDay
		{
			get { return GetNewYearDay(Year); }
		}

		public static DateTime GetNewYearDayDate(int year)
		{
			return Common.GetNewYearDayDate(year);
		}

		public static NationalHoliday GetNewYearDay(int year)
		{
			return new NationalHoliday(GetNewYearDayDate(year), "New Year");
		}

		#endregion

		#region MartinLutherKingBirthday

		public NationalHoliday MartinLutherKingBirthday
		{
			get { return GetMartinLutherKingBirthday(Year); }
		}

		public static DateTime GetMartinLutherKingBirthdayDate(int year)
		{
			return MonthHelper.DateFromWeekday(year, 1, DayOfWeek.Monday, 3);
		}

		public static NationalHoliday GetMartinLutherKingBirthday(int year)
		{
			return new NationalHoliday(GetMartinLutherKingBirthdayDate(year), "MartinLutherKingBirthday");
		}

		#endregion

		#region InaugurationDay

		public NationalHoliday InaugurationDay
		{
			get { return GetInaugurationDay(Year); }
		}

		public static DateTime? GetInaugurationDayDate(int year)
		{
			DateTime? date = null;
			if (year%4 == 1)
			{
				date = new DateTime(year, 1, 20);

				if (date.Value.DayOfWeek == DayOfWeek.Sunday)
					date.Value.AddDays(1);
			}

			return date;
		}

		public static NationalHoliday GetInaugurationDay(int year)
		{
			if (GetInaugurationDayDate(year) != null)
				return new NationalHoliday(GetInaugurationDayDate(year).Value, "InaugurationDay");
			
			return null;
		}

		#endregion

		#region WashingtonBirthday

		public NationalHoliday WashingtonBirthday
		{
			get { return GetWashingtonBirthday(Year); }
		}

		public static DateTime GetWashingtonBirthdayDate(int year)
		{
			return MonthHelper.DateFromWeekday(year, 2, DayOfWeek.Monday, 3);
		}

		public static NationalHoliday GetWashingtonBirthday(int year)
		{
			return new NationalHoliday(GetWashingtonBirthdayDate(year), "WashingtonBirthday");
		}

		#endregion

		#region MemorialDay

		// Ultima segunda do mês
		public NationalHoliday MemorialDay
		{
			get { return GetMemorialDay(Year); }
		}

		public static DateTime GetMemorialDayDate(int year)
		{
			return MonthHelper.DateFromWeekdayByEnd(year, 5, DayOfWeek.Monday, 1);
		}

		public static NationalHoliday GetMemorialDay(int year)
		{
			return new NationalHoliday(GetMemorialDayDate(year), "MemorialDay");
		}

		#endregion

		#region IndependenceDay

		public NationalHoliday IndependenceDay
		{
			get { return GetIndependenceDay(Year); }
		}

		public static DateTime GetIndependenceDayDate(int year)
		{
			return new DateTime(year, 7, 4);
		}

		public static NationalHoliday GetIndependenceDay(int year)
		{
			return new NationalHoliday(GetIndependenceDayDate(year), "IndependenceDay");
		}

		#endregion

		#region LaborDay

		public NationalHoliday LaborDay
		{
			get { return GetLaborDay(Year); }
		}

		public static DateTime GetLaborDayDate(int year)
		{
			return MonthHelper.DateFromWeekday(year, 9, DayOfWeek.Monday, 1);
		}

		public static NationalHoliday GetLaborDay(int year)
		{
			return new NationalHoliday(GetLaborDayDate(year), "LaborDay");
		}

		#endregion

		#region ColumbusDay

		public NationalHoliday ColumbusDay
		{
			get { return GetColumbusDay(Year); }
		}

		public static DateTime GetColumbusDayDate(int year)
		{
			return MonthHelper.DateFromWeekday(year, 10, DayOfWeek.Monday, 2);
		}

		public static NationalHoliday GetColumbusDay(int year)
		{
			return new NationalHoliday(GetColumbusDayDate(year), "ColumbusDay");
		}

		#endregion

		#region VeteransDay

		public NationalHoliday VeteransDay
		{
			get { return GetVeteransDay(Year); }
		}

		public static DateTime GetVeteransDayDate(int year)
		{
			return new DateTime(year, 11, 11);
		}

		public static NationalHoliday GetVeteransDay(int year)
		{
			return new NationalHoliday(GetVeteransDayDate(year), "VeteransDay");
		}

		#endregion

		#region ThanksGivingDay

		public NationalHoliday ThanksGivingDay
		{
			get { return GetThanksGivingDay(Year); }
		}

		public static DateTime GetThanksGivingDayDate(int year)
		{
			return MonthHelper.DateFromWeekday(year, 11, DayOfWeek.Thursday, 4);
		}

		public static NationalHoliday GetThanksGivingDay(int year)
		{
			return new NationalHoliday(GetThanksGivingDayDate(year), "ThanksGivingDay");
		}

		#endregion

		#region ChristmasDay

		public NationalHoliday ChristmasDay
		{
			get { return GetChristmasDay(Year); }
		}

		public static DateTime GetChristmasDayDate(int year)
		{
			return Christian.GetChristmasDayDate(year);
		}

		public static NationalHoliday GetChristmasDay(int year)
		{
			return new NationalHoliday(GetChristmasDayDate(year), "ChristmasDay");
		}

		#endregion

		public override IList<NationalHoliday> NationalHolidays
		{
			get
			{
				//TODO: Aqui eu posso fazer na mão ou via reflection. Seria pegar todas as propriedades que são NationalHoliday.
				//TODO: Posso fazer um Helper para isso, tipo akele helper pra instanciar objetos.
				IList<NationalHoliday> list = new List<NationalHoliday>();

				list.Add(NewYearDay);
				list.Add(MartinLutherKingBirthday);
				if (InaugurationDay != null)
					list.Add(InaugurationDay);
				list.Add(WashingtonBirthday);
				list.Add(MemorialDay);
				list.Add(IndependenceDay);
				list.Add(LaborDay);
				list.Add(ColumbusDay);
				list.Add(VeteransDay);
				list.Add(ThanksGivingDay);
				list.Add(ChristmasDay);

				return list;
			}
		}

		public override IList<BaseHoliday> Holidays
		{
			get { return ConvertListTo<BaseHoliday>(NationalHolidays); }
		}
	}
}