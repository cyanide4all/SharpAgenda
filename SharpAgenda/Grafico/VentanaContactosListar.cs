using System;
using Gtk;
using Contactos;

namespace SharpAgenda
{
	public class VentanaContactosListar : Window
	{
		public VentanaContactosListar () : base("Lista de contactos")
		{
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			Agenda agenda = Agenda.Get ();
			VBox Main = new VBox();
			if (agenda.IsEmpty ()) {
				Main.Add(new Label("No hay contactos que mostrar"));
			} else {
				Label label = new Label (agenda.ToString ());
				label.SetAlignment (0, 1);
				Main.Add (label);
			}
			Add (Main);
			ShowAll();
		}
	}
}

