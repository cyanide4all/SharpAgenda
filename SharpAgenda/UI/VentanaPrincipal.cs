using System;
using Gtk;

namespace SharpAgenda
{
	public class VentanaPrincipal: Window
	{
		VBox Main = new VBox();

		public VentanaPrincipal ()
			:base("SharpAgenda")
		{
			//Config
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			DeleteEvent += delegate { Application.Quit(); };

			//Partes
			MenuBar mb = new MenuBar();
			Menu contactosOpciones = new Menu ();
			MenuItem contactosMenu = new MenuItem ("Contactos");
			MenuItem contactosListar = new MenuItem ("Listar contactos");
			contactosMenu.Submenu = contactosOpciones;


			contactosOpciones.Append (contactosListar);
			mb.Append(contactosMenu);


			//PASTEADO
			VBox menuBox = new VBox(false, 2);
			menuBox.PackStart(mb, false, false, 0);

			VBox textBox = new VBox ();

			textBox.Add(new Label("Bienvenido a SharpAgenda\nSelecciona una opcion usando el menu"));
			Main.Add (menuBox);
			Main.Add (textBox);

			Add (Main);

			ShowAll();



		}
	}
}

