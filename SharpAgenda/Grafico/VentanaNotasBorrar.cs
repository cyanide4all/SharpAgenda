using System;
using System.Collections.Generic;
using Gtk;
using Contactos;
using Notas;

namespace SharpAgenda
{
	public class VentanaNotasBorrar : Window
	{
		private VBox comentariosBox;
		private VBox mainBox;
		private Contacto contacto;
		private ComboBox lista_contactos;

		private List<Nota> notasTotal;
		private List<Nota> notasBorradas;

		private Dictionary<CheckButton,Nota> checks;


		public VentanaNotasBorrar () : base("Borrar notas")
		{
			Agenda agenda = Agenda.Get ();
			lista_contactos = new ComboBox(agenda.ToStringCB());
			lista_contactos.Changed += cambiarContacto;
			mainBox = new VBox();

			mainBox.Add (lista_contactos);
			Add (mainBox);
			ShowAll ();
		}

		private void cambiarContacto (object sender, EventArgs args)
		{
			String[] nomyaps = lista_contactos.ActiveText.Split (',');
			String nombre = nomyaps [0];
			String apellidos = nomyaps [1];
			Agenda agenda = Agenda.Get ();
			this.contacto = agenda.GetContactoByNombreCompleto (nombre, apellidos);

			List<Nota> notasMostradas;
			notasTotal = Nota.GetNotasXML ();
			notasMostradas = notasTotal.FindAll (x => x.contacto.Equals (this.contacto));

			if (comentariosBox != null)
				comentariosBox.Destroy ();
			comentariosBox = new VBox ();
			mainBox.Add (comentariosBox);

			checks = new Dictionary<CheckButton, Nota>();
			foreach (Nota n in notasMostradas) {
				HBox hbox = new HBox();
				CheckButton c = new CheckButton(n.ToString());
				hbox.Add (c);
				comentariosBox.Add(hbox);
				checks.Add (c, n);
			}

			Button borrar = new Button("Borrar");
			borrar.Clicked += borrarNotas;
			comentariosBox.Add (borrar);
			ShowAll ();
		}

		private void borrarNotas (object sender, EventArgs args)
		{
			notasBorradas = new List<Nota>(notasTotal);

			foreach (KeyValuePair<CheckButton,Nota> c in checks) {
				if(c.Key.Active) {
					notasBorradas.Remove (c.Value);
				}
			}
			Nota.SaveNotas (notasBorradas);
			Destroy ();
		}
	}
}

