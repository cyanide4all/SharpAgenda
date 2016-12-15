using System;

namespace Contactos
{
	public class Contacto : IEquatable<Contacto> //Esto para que remove funque en agenda
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

		public bool Equals(Contacto otro)
		{
			if (otro == null) return false;
			return (this.Nombre.Equals(otro.Nombre) && this.Apellidos.Equals(otro.Apellidos) &&
				this.Direccion.Equals(otro.Direccion) && this.Email.Equals(otro.Email)&&
				this.Telefono.Equals(otro.Telefono));
		}


		public override string ToString ()
		{
			return string.Format ("Nombre: {0} \nApellidos: {1} \nDireccion: {2} \nEmail: {3} \nTelefono: {4}\n\n", Nombre, Apellidos, Direccion, Email, Telefono);
		}


	}
}

