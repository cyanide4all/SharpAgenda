using System;
using System.Collections.Generic;
using Gtk;
using Contactos;
using Notas;

namespace SharpAgenda
{
	public class VentanaNotasListar : Gtk.Window
	{
		public VentanaNotasListar () : base("Listar notas")
		{
			this.Build ();
		}

		private void Build ()
		{
			List<Nota> listaNotas = Nota.GetNotasXML ();

			VBox main = new VBox ();
		
			foreach (Nota n in listaNotas) {
				main.Add (new Label(n.ToString()));
			}

			Add (main);
			ShowAll ();
		}
	}
}

