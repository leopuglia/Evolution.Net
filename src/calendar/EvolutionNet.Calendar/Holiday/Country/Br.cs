using System;
using System.Collections.Generic;

namespace EvolutionNet.Calendar.Holiday.Country
{
	//TODO: Posso fazer com que esse tipo não seja estático, sendo inicializado como new Br(int year). Assim, eu posso utilizar propriedades pra calcular cada um dos feriados.
	//TODO: Eu posso melhorar essas definições. Talvez eu tenha realmente que criar uma classe/struct para cada feriado, de forma a poder passar mais dados relativos àquele feriado específico. Senão, quando eu listar, vou ter um monte de datas que não servem pra gerar um relatório.
	public class Br : BaseCountry
	{
		public Br(int year) : base(year)
		{
		}

		#region Holidays

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

		#region CarnivalTuesday

		public NationalHoliday CarnivalTuesday
		{
			get { return GetCarnivalTuesday(Year); }
		}

		public static DateTime GetCarnivalTuesdayDate(int year)
		{
			return Christian.GetCarnivalTuesdayDate(year);
		}

		public static NationalHoliday GetCarnivalTuesday(int year)
		{
			return new NationalHoliday(GetCarnivalTuesdayDate(year), "CarnivalTuesday");
		}

		#endregion

		#region CorpusChristiFriday

		public NationalHoliday CorpusChristiFriday
		{
			get { return GetCorpusChristiFriday(Year); }
		}

		public static DateTime GetCorpusChristiFridayDate(int year)
		{
			return Christian.GetCorpusChristiFridayDate(year);
		}

		public static NationalHoliday GetCorpusChristiFriday(int year)
		{
			return new NationalHoliday(GetCorpusChristiFridayDate(year), "CorpusChristiFriday");
		}

		#endregion

		#region Tiradentes

		public NationalHoliday Tiradentes
		{
			get { return GetTiradentes(Year); }
		}

		public static DateTime GetTiradentesDate(int year)
		{
			return new DateTime(year, 4, 21);
		}

		public static NationalHoliday GetTiradentes(int year)
		{
			return new NationalHoliday(GetTiradentesDate(year), "Tiradentes");
		}

		#endregion

		#region LaborDay

		public NationalHoliday LaborDay
		{
			get { return GetLaborDay(Year); }
		}

		public static DateTime GetLaborDayDate(int year)
		{
			return new DateTime(year, 5, 1);
		}

		public static NationalHoliday GetLaborDay(int year)
		{
			return new NationalHoliday(GetLaborDayDate(year), "LaborDay");
		}

		#endregion

		#region IndependenceDay

		public NationalHoliday IndependenceDay
		{
			get { return GetIndependenceDay(Year); }
		}

		public static DateTime GetIndependenceDayDate(int year)
		{
			return new DateTime(year, 9, 7);
		}

		public static NationalHoliday GetIndependenceDay(int year)
		{
			return new NationalHoliday(GetIndependenceDayDate(year), "IndependenceDay");
		}

		#endregion

		#region NossaSenhoraAparecida

		public NationalHoliday NossaSenhoraAparecida
		{
			get { return GetNossaSenhoraAparecida(Year); }
		}

		public static DateTime GetNossaSenhoraAparecidaDate(int year)
		{
			return new DateTime(year, 10, 12);
		}

		public static NationalHoliday GetNossaSenhoraAparecida(int year)
		{
			return new NationalHoliday(GetNossaSenhoraAparecidaDate(year), "NossaSenhoraAparecida");
		}

		#endregion

		#region ChildrensDay

		public CommemorativeDay ChildrensDay
		{
			get { return GetChildrensDay(Year); }
		}

		public static DateTime GetChildrensDayDate(int year)
		{
			return new DateTime(year, 10, 12);
		}

		public static CommemorativeDay GetChildrensDay(int year)
		{
			return new CommemorativeDay(GetChildrensDayDate(year), "ChildrensDay");
		}

		#endregion

		#region DayOfTheDead

		public NationalHoliday DayOfTheDead
		{
			get { return GetDayOfTheDead(Year); }
		}

		public static DateTime GetDayOfTheDeadDate(int year)
		{
			return new DateTime(year, 11, 2);
		}

		public static NationalHoliday GetDayOfTheDead(int year)
		{
			return new NationalHoliday(GetDayOfTheDeadDate(year), "DeadsDay");
		}

		#endregion

		#region RepublicProclamation

		public NationalHoliday RepublicProclamation
		{
			get { return GetRepublicProclamation(Year); }
		}

		public static DateTime GetRepublicProclamationDate(int year)
		{
			return new DateTime(year, 11, 15);
		}

		public static NationalHoliday GetRepublicProclamation(int year)
		{
			return new NationalHoliday(GetRepublicProclamationDate(year), "RepublicProclamation");
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

		#endregion

		public override IList<NationalHoliday> NationalHolidays
		{
			get
			{
				//TODO: Aqui eu posso fazer na mão ou via reflection. Seria pegar todas as propriedades que são NationalHoliday.
				//TODO: Posso fazer um Helper para isso, tipo akele helper pra instanciar objetos.
				IList<NationalHoliday> list = new List<NationalHoliday>(
					new NationalHoliday[]
          			{
          				NewYearDay,
          				CarnivalTuesday,
          				CorpusChristiFriday,
          				Tiradentes,
          				LaborDay,
          				IndependenceDay,
          				NossaSenhoraAparecida,
          				DayOfTheDead,
          				RepublicProclamation,
          				ChristmasDay
          			});

				return list;
			}
		}

	}
}
