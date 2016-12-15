using System;
using Gtk;
using Calendario;
using Meetings;

namespace SharpAgenda
{
	public class VentanaCitasListar: Window
	{
		private Controler_Meetings citas;
		private String listado;

		public VentanaCitasListar(): base( "Listar Citas" )
		{
			citas = new Controler_Meetings ();
			listado = citas.ToString ();
			this.Build();
		}

		private void Build() 
		{
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();
			//DeleteEvent += delegate { Application.Quit(); };

			if (listado == "") 
			{
				Label aMostrar = new Label ("No hay ninguna cita guardada.");
				Main.Add(aMostrar);
			} 
			else 
			{
				System.Console.Write (listado);
				Label aMostrar = new Label(listado);
				Main.Add(aMostrar);
			}

			Add(Main);
			this.ShowAll ();
		}
	}
}

