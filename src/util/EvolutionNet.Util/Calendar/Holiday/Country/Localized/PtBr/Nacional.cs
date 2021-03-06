﻿using System;
using System.Collections.Generic;
using EvolutionNet.Util.Calendar.Holiday.Country;

namespace EvolutionNet.Util.Calendar.Holiday.Country.Localized.PtBr
{
	public class Nacional : Base
	{
		public Nacional(int year) : base(year)
		{
		}

		#region AnoNovo

		public NationalHoliday AnoNovo
		{
			get { return GetAnoNovo(Year); }
		}

		public static DateTime GetAnoNovoDate(int year)
		{
			return Br.National.GetNewYearDayDate(year);
		}

		public static NationalHoliday GetAnoNovo(int year)
		{
			return new NationalHoliday(GetAnoNovoDate(year), "AnoNovo");
		}

		#endregion

		#region Reveillon

		public NationalHolidayAlias Reveillon
		{
			get { return GetReveillon(Year); }
		}

		public static DateTime GetReveillonDate(int year)
		{
			return Br.National.GetNewYearDayDate(year);
		}

		public static NationalHolidayAlias GetReveillon(int year)
		{
			return new NationalHolidayAlias(GetReveillonDate(year), "Reveillon");
		}

		#endregion

		#region CarnavalTerca

		public NationalHoliday CarnavalTerca
		{
			get { return GetCarnavalTerca(Year); }
		}

		public static DateTime GetCarnavalTercaDate(int year)
		{
			return Br.National.GetCarnivalTuesdayDate(year);
		}

		public static NationalHoliday GetCarnavalTerca(int year)
		{
			return new NationalHoliday(GetCarnavalTercaDate(year), "CarnavalTerca");
		}

		#endregion

		#region CorpusChristiSexta

		public NationalHoliday CorpusChristiSexta
		{
			get { return GetCorpusChristiSexta(Year); }
		}

		public static DateTime GetCorpusChristiSextaDate(int year)
		{
			return Br.National.GetCorpusChristiFridayDate(year);
		}

		public static NationalHoliday GetCorpusChristiSexta(int year)
		{
			return new NationalHoliday(GetCorpusChristiSextaDate(year), "CorpusChristi");
		}

		#endregion

		#region Tiradentes

		public NationalHoliday Tiradentes
		{
			get { return GetTiradentes(Year); }
		}

		public static DateTime GetTiradentesDate(int year)
		{
			return Br.National.GetTiradentesDate(year);
		}

		public static NationalHoliday GetTiradentes(int year)
		{
			return new NationalHoliday(GetTiradentesDate(year), "Tiradentes");
		}

		#endregion

		#region DiaDoTrabalho

		public NationalHoliday DiaDoTrabalho
		{
			get { return GetDiaDoTrabalho(Year); }
		}

		public static DateTime GetDiaDoTrabalhoDate(int year)
		{
			return Br.National.GetLaborDayDate(year);
		}

		public static NationalHoliday GetDiaDoTrabalho(int year)
		{
			return new NationalHoliday(GetDiaDoTrabalhoDate(year), "DiaDoTrabalho");
		}

		#endregion

		#region Independencia

		public NationalHoliday Independencia
		{
			get { return GetIndependencia(Year); }
		}

		public static DateTime GetIndependenciaDate(int year)
		{
			return Br.National.GetIndependenceDayDate(year);
		}

		public static NationalHoliday GetIndependencia(int year)
		{
			return new NationalHoliday(GetIndependenciaDate(year), "Independencia");
		}

		#endregion

		#region NossaSenhoraAparecida

		public NationalHoliday NossaSenhoraAparecida
		{
			get { return GetNossaSenhoraAparecida(Year); }
		}

		public static DateTime GetNossaSenhoraAparecidaDate(int year)
		{
			return Br.National.GetNossaSenhoraAparecidaDate(year);
		}

		public static NationalHoliday GetNossaSenhoraAparecida(int year)
		{
			return new NationalHoliday(GetNossaSenhoraAparecidaDate(year), "NossaSenhoraAparecida");
		}

		#endregion

		#region DiaDasCriancas

		public CommemorativeDay DiaDasCriancas
		{
			get { return GetDiaDasCriancas(Year); }
		}

		public static DateTime GetDiaDasCriancasDate(int year)
		{
			return Br.National.GetChildrensDayDate(year);
		}

		public static CommemorativeDay GetDiaDasCriancas(int year)
		{
			return new CommemorativeDay(GetDiaDasCriancasDate(year), "DiaDasCriancas");
		}

		#endregion

		#region Finados

		public NationalHoliday Finados
		{
			get { return GetFinados(Year); }
		}

		public static DateTime GetFinadosDate(int year)
		{
			return Br.National.GetDayOfTheDeadDate(year);
		}

		public static NationalHoliday GetFinados(int year)
		{
			return new NationalHoliday(GetFinadosDate(year), "Finados");
		}

		#endregion

		#region ProclamacaoDaRepublica

		public NationalHoliday ProclamacaoDaRepublica
		{
			get { return GetProclamacaoDaRepublica(Year); }
		}

		public static DateTime GetProclamacaoDaRepublicaDate(int year)
		{
			return Br.National.GetRepublicProclamationDate(year);
		}

		public static NationalHoliday GetProclamacaoDaRepublica(int year)
		{
			return new NationalHoliday(GetProclamacaoDaRepublicaDate(year), "ProclamacaoDaRepublica");
		}

		#endregion

		#region Natal

		public NationalHoliday Natal
		{
			get { return GetNatal(Year); }
		}

		public static DateTime GetNatalDate(int year)
		{
			return Br.National.GetChristmasDayDate(year);
		}

		public static NationalHoliday GetNatal(int year)
		{
			return new NationalHoliday(GetNatalDate(year), "Natal");
		}

		#endregion

		public override IList<NationalHoliday> NationalHolidays
		{
			get
			{
				IList<NationalHoliday> list = new List<NationalHoliday>(
					new NationalHoliday[]
						{
							AnoNovo,
							CarnavalTerca,
							CorpusChristiSexta,
							Tiradentes,
							DiaDoTrabalho,
							Independencia,
							NossaSenhoraAparecida,
							Finados,
							ProclamacaoDaRepublica,
							Natal
						});

				return list;
			}
		}

		public override IList<BaseHoliday> Holidays
		{
			get { return ConvertListTo<BaseHoliday>(NationalHolidays); }
		}
	}
}