using System;
using System.Collections.Generic;
using Gtk;
using Contactos;
using Notas;

namespace SharpAgenda
{
	public class VentanaNotasModificar : Gtk.Window
	{
		private VBox inf;
		private Contacto contacto;
		private ComboBox listaContactos;
		private VBox mainBox;
		private List<Nota> notasModificadas;
		private List<Nota> notasNoModificadas;
		private List<Nota> notasTotal;
		private List<Entry> entradasNota;

		public VentanaNotasModificar () : base("Modificar notas")
		{
			mainBox = new VBox();
			inf = new VBox();

			listaContactos = new ComboBox(Agenda.Get().ToStringCB ());
			listaContactos.Changed += cambiarContacto;
			mainBox.Add (listaContactos);

			Add (mainBox);
			mainBox.Add (inf);
			ShowAll ();
		}

		private void cambiarContacto(object sender, EventArgs args) {
			String[] nomyaps = listaContactos.ActiveText.Split(',');
			String nombre = nomyaps [0];
			String apellidos = nomyaps [1];
			Agenda agenda = Agenda.Get ();
			this.contacto = agenda.GetContactoByNombreCompleto (nombre, apellidos);

			notasTotal = Nota.GetNotasXML ();
			notasModificadas = notasTotal.FindAll(x => x.contacto.Equals (this.contacto));
			notasNoModificadas = new List<Nota>(notasTotal);
			notasNoModificadas.RemoveAll(x => x.contacto.Equals (this.contacto));
			entradasNota = new List<Entry>();
		
			inf.Destroy ();
			inf = new VBox();
			foreach (Nota nota in notasModificadas) {
				Entry entrada_nota = new Entry();
				entrada_nota.Text = nota.contenido;
				inf.Add (entrada_nota);
				entradasNota.Add (entrada_nota);
			}
			Button enviar = new Button("Enviar");
			enviar.Clicked += modificarNotas;
			inf.Add(enviar);
			mainBox.Add (inf);
			ShowAll ();
		}

		private void modificarNotas (object sender, EventArgs args)
		{
			notasTotal = new List<Nota> ();
			foreach (Entry e in entradasNota) {
				Nota nueva_nota = new Nota ();
				nueva_nota.contacto = this.contacto;
				nueva_nota.contenido = e.Text;
				notasTotal.Add (nueva_nota);
			}
			foreach (Nota n in notasNoModificadas) {
				notasTotal.Add (n);
			}
			Nota.SaveNotas (notasTotal);
			Destroy ();
		}
	}
}

