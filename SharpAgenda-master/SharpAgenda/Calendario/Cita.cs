using System;

namespace Calendario
{
	public class Cita
	{
		public Cita(string nom, string nomC, string fe, string hora, string des)
		{
			Nombre = nom;
			NombreContacto = nomC;
			Fecha = fe;
			Hora = hora;
			Descripcion = des;
		}

		public string Nombre
		{
			get; private set;
		}

		public string NombreContacto
		{
			get; private set;
		}

		public string Fecha
		{
			get; private set;
		}

		public string Hora
		{
			get; private set;
		}

		public string Descripcion
		{
			get; private set;
		}

		public override string ToString()
		{
			return string.Format("Cita:\n \t-{0}\n \t-{1}\n \t-{2}\n \t-{3}\n \t-{4}", Nombre, NombreContacto, Fecha, Hora, Descripcion);
		}
	}
}


