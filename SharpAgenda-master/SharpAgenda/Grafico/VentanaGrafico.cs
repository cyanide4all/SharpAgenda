using System;
using Gtk;
namespace Grafico
{
	public class VentanaGrafico : Window
	{

		String[] Days = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
		VBox Main = new VBox();
		HBox DayContainer = new HBox();
		VBox[] Dias = new VBox[7];

		public VentanaGrafico ()
			:base("Gráfico")
		{
			//Crea los dias
			for (int i = 0; i < 7; i++) {
				Dias [i] = new VBox ();
				Dias [i].Add (new Label (Days[i]));
				DayContainer.Add (Dias [i]);
			
			}


			//Enseña la interfaz
			Main.Add (DayContainer);
			this.Add (Main);
			this.ShowAll ();
		}
	}
}

