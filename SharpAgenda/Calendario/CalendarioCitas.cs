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
		public static int[] diasMes = new int[] {31,28,31,30,31,30,31,31,30,31,30,31};

		//Variable que guardará la primera lista de citas.
		public List<List<Cita>> calendarioCitaBase;

		public CalendarioCitas()
		{
			//Obtenemos la fecha actual para saber que lista de citas lanzar
			//int diaActual = DateTime.Today.Day;
			int mesActual = DateTime.Today.Month;
			int anoActual = DateTime.Today.Year;

			crearCal(anoActual, mesActual);
		}

		public CalendarioCitas(int ano, int mes)
		{
			crearCal(ano, mes);	
		}


		public void crearCal(int ano, int mes)
		{ 
			calendarioCitaBase = crearCalendario(ano, mes);
		}

		//Crea una lista de listas de citas para un mes en concreto
		public static List<List<Cita>> crearCalendario(int ano, int mes)
		{ 
			List<List<Cita>> calendario = new List<List<Cita>>();

			for (int i = 1; i <= diasMes[mes]; i++)
			{
				string date = i + "/" + mes + "/" + ano;

				calendario.Add(citasDia(mes,i,ano));
			}


			return calendario;
		}

		//Devuelve una lista con las citas de la fecha pasada como argumento
		public static List<Cita> citasDia(int mes, int dia, int ano)
		{
			List<Cita> citas = new List<Cita>();
			string fecha = dia + "/" + mes + "/" + ano;

			//System.Console.WriteLine("{0}",fecha);

			XElement raiz = XElement.Load("citas.xml");
			IEnumerable<Cita> citasX =
				from el in raiz.Elements("cita")
				where (string)el.Element("fecha") == fecha
				select new Cita((string)el.Element("nombre"),
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

		//Ejemplo de salida del mes
		public override string ToString()
		{

			int i = 1;

			//Prueba de que la lista de citas funciona correctamente
			calendarioCitaBase.ForEach(delegate (List<Cita> c)
	  		{

				  //Codigo ejemplo muestra fecha actual
				Console.WriteLine("Dia: {0}", i++);
				  c.ForEach(delegate (Cita cita)
	  			  {

				  Console.WriteLine(cita);

			      });
			 });

			return string.Format("[CalendarioCitas]");
		}
	}
}
