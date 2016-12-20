using System;
using Gtk;
using SharpAgenda;

using System.Collections.Generic;
using Notas;
using Contactos;
using System.Xml;
using System.Text;

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

			//ACTUAL FUNKING APLICATION
			Application.Init ();
			new VentanaPrincipal ();
			Application.Run ();
		}

	}
}
