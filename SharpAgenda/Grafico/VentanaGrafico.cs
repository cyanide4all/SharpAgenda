using System;
using Gtk;
using Calendario;


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
			//Config
			DayContainer.Spacing=30;



			//Crea los dias
			for (int i = 0; i < 7; i++) {
				Dias [i] = new VBox ();
				Dias [i].Add (new Label (Days[i]));
				DayContainer.Add (Dias [i]);
			}
			CalendarioCitas cc = new CalendarioCitas ();

			//Rellena los dias con datos
			for (int i = 0; i < 7; i++) {
				Dias [i].Add(new Label("Aqui va la info de cada dia")); //TODO muy fuerte pero no lo toco hasta que luis arregle su mierda
			}

			//Enseña la interfaz
			Main.Add (DayContainer);
			this.Add (Main);
			this.ShowAll ();
		}
	}
}

