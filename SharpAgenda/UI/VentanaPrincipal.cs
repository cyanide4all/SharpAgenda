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
			BorderWidth = 15;


			Main.Add(new Label("Bienvenido a SharpAgenda\nSelecciona una opcion usando el menu"));
			this.Add (Main);
			this.ShowAll();



		}
	}
}

