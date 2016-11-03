using System;

namespace Contactos
{
	public class Contacto
	{
		public string Nombre {
			get;
			private set;
		}
		public string Apellidos {
			get;
			private set;
		}
		public string Direccion {
			get;
			private set;
		}
		public string Email {
			get;
			private set;
		}
		public string Telefono {
			get;
			private set;
		}

		public Contacto ()
		{
		}
		public Contacto (String n, String a, String d, String e, String t)
		{
			Nombre = n;
			Apellidos = a;
			Direccion = d;
			Email = e;
			Telefono = t;
		}
		public override string ToString ()
		{
			return string.Format ("[Contacto: Nombre={0} \nApellidos={1} \nDireccion={2} \nEmail={3} \nTelefono={4}]", Nombre, Apellidos, Direccion, Email, Telefono);
		}


	}
}

