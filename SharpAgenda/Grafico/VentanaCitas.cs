using System;
using Gtk;
using Calendario;
using Meetings;

namespace SharpAgenda
{
	public class VentanaCitas: Window
	{
		private Controler_Meetings citas;

		public VentanaCitas(): base( "Gráfico" )
		{
			this.Build();
			citas = new Controler_Meetings ();
		}

		private void Build() 
		{
			SetDefaultSize(640, 400);
			SetPosition(WindowPosition.Center);
			DeleteEvent += delegate { Application.Quit(); };

			MenuBar mb = new MenuBar();

			Menu filemenu = new Menu();
			MenuItem file = new MenuItem("Citas");
			file.Submenu = filemenu;

			MenuItem verCita = new MenuItem("Ver Citas");
			//nueva.Activated += ;
			MenuItem nuevaCita = new MenuItem("Nueva");
			//nueva.Activated += ;
			MenuItem eliminarCita = new MenuItem("Eliminar");
			//nueva.Activated += ;
			MenuItem modificarCita = new MenuItem("Modificar");
			//nueva.Activated += Funcion a llamar;

			filemenu.Append(verCita);
			filemenu.Append(nuevaCita);
			filemenu.Append(eliminarCita);
			filemenu.Append(modificarCita);

			mb.Append(file);

			VBox vbox = new VBox(false, 2);
			vbox.PackStart(mb, false, false, 0);

			Add(vbox);

			this.ShowAll ();
		}
	}
}

