using System;
using System.IO;
using System.Collections.Generic;
using Gtk;
using Notas;
using Contactos;

namespace SharpAgenda
{
	public class VentanaNotasCrear : Gtk.Window
	{

		private Entry email;
		private Entry contenido;
		public VentanaNotasCrear () : base("Crear Notas")
		{
			this.Build ();
		}

		private void Build() {
			VBox main = new VBox();

			Label labelEmail = new Label("Email: ");
			email = new Entry();
			contenido = new Entry();
			Button crear = new Button("Crear nota");
			crear.Clicked += CrearNota;

			main.Add (labelEmail);
			main.Add (email);
			main.Add (contenido);
			main.Add (crear);

			Add (main);
			ShowAll ();
		}

		private void CrearNota (object sender, EventArgs args)
		{
			Nota n = new Nota ();
			Agenda agenda = Agenda.Get ();
			n.contacto = agenda.GetContactoByEmail (email.Text);
			if (n.contacto == null) {
				alertaContactoNulo(email.Text);
			}
			n.contenido = contenido.Text;

			System.Console.WriteLine (n.contacto.ToString ());

			List<Nota> notas = Nota.GetNotasXML ();
			notas.Add (n);

			Nota.SaveNotas (notas);
			Destroy ();
		}

		private void alertaContactoNulo(string email) {
			MessageDialog md = new MessageDialog (this, 
				                   DialogFlags.DestroyWithParent, MessageType.Info, 
				                   ButtonsType.Ok, "Contacto " + email + " no encontrado.");
			md.Run ();
			md.Destroy ();
		}
	}
}

