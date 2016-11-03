using System;
using Gtk;

namespace Grafico
{
	public class MainClass
	{
		public static void Main (String[] args)
		{
			/*//Test de contactos
			Agenda hue = Agenda.Get ();
			Console.Write (hue.ToString ());
			hue.AddContacto(new Contacto("hue","hue lelelele","huehue","huhue","678856329"));
			hue.AddContacto ("hue2", "hue2 lelelele2", "huehue2", "huhue2", "678856322");
			hue.SaveXML ();
			*///END Test de contactos



			Application.Init ();
			new VentanaGrafico ();
			Application.Run ();
		}

	}
}
