using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using Meetings;

namespace Calendario
{
	public class CalendarioCitas
	{
		public int[] diasMes = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
		public List<List<Cita>> calendarioCitaBase;
		public DateTime primerDiaSemana;
		public DateTime diaDeHoy;

		public CalendarioCitas()
		{
			diaDeHoy = DateTime.Today;
			primerDiaSemana = diaDeHoy.AddDays(DayOfWeek.Monday - diaDeHoy.DayOfWeek);

			calendarioCitaBase = crearSemanaCalendario();
		}


		//Crea una lista de listas de citas para una semana
		public List<List<Cita>> crearSemanaCalendario()
		{
			List<List<Cita>> calendario = new List<List<Cita>>();
			int diaActual = primerDiaSemana.Day;
			int mesActual = primerDiaSemana.Month;
			int anoActual = primerDiaSemana.Year;

			for (int i = 1; i <= 7; i++)
			{
				string date = diaActual + "/" + mesActual + "/" + anoActual;

				Console.WriteLine("Date: {0}", date);

				calendario.Add(citasDia(mesActual, diaActual, anoActual));

				if (diaActual == diasMes[mesActual - 1])
				{
					diaActual = 1;

					if (mesActual == 12)
					{
						mesActual = 1;
						anoActual++;
					}
				}
				else
				{
					diaActual++;
				}
			}

			return calendario;
		}

		public DateTime getPrimerDia()
		{
			return primerDiaSemana;
		}

		//Devuelve una lista con las citas de la fecha pasada como argumento
		public List<Cita> citasDia(int mes, int dia, int ano)
		{
			List<Cita> citas = new List<Cita>();
			string fecha = dia + "/" + mes + "/" + ano;

			//System.Console.WriteLine("{0}",fecha);vb 

			XElement raiz = XElement.Load("citas.xml");
			IEnumerable<Cita> citasX =
				from el in raiz.Elements("cita")
				where (string)el.Element("fecha") == fecha
				select new Cita((string)el.Element("nombreCita"),
								(string)el.Element("nombreContacto"),
								(string)el.Element("fecha"),
								(string)el.Element("hora"),
								(string)el.Element("descripcion"));

			foreach (Cita cita in citasX)
			{
				citas.Add(cita);
			}

			return citas;
		}
	}
}
