using System;

namespace Meetings
{
	public class Cita
	{
		public Cita (string nombre, string nomContacto, string fecha, string hora, string des)
		{
			Nombre = nombre;
			NombreContacto = nomContacto;
			Fecha = fecha;
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

		public string ToString (int actual)
		{
			return string.Format ("Cita#{0}:\nNombre={1}\nNombreContacto={2}\nFecha={3}\nHora={4}\nDescripcion={5}", actual, Nombre, NombreContacto, Fecha, Hora, Descripcion );
		}
	}
}

