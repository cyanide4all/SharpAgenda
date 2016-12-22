using System;
using Gtk;
using Calendario;
using Meetings;
using System.Collections.Generic;

namespace Grafico
{
	public class VentanaGrafico : Window
	{

		String[] Days = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo" };
		public List<List<Cita>> calendarioSemana;
		VBox Main = new VBox();
		HBox DayContainer = new HBox();
		VBox[] Dias = new VBox[7];
		int primerDia;
		int cont;

		public VentanaGrafico ()
			:base("Gráfico")
		{
			//Config
			DayContainer.Spacing=30;
			BorderWidth = 10;
			SetPosition(WindowPosition.Center);



			CalendarioCitas calendario =new CalendarioCitas();
			calendarioSemana = calendario.crearSemanaCalendario();
			primerDia = calendario.getPrimerDia().Day;

			//Crea los dias
			for (int i = 0; i < 7; i++) {
				Label h = new Label(Days[i]+"  "+primerDia.ToString() );
				h.SetAlignment(0,0);
				Dias [i] = new VBox ();
				Dias [i].Add (h);
				DayContainer.Add (Dias [i]);
				primerDia++;
			}

			cont = 0;
			calendarioSemana.ForEach(delegate (List<Cita> c)
	  		{
				Label Citas;

				cont++;
				c.ForEach(delegate (Cita cita)
				{
					Citas = new Label(cita.ToString());
					Citas.SetAlignment(0, 0);
					Dias[cont-1].Add(Citas);

				});
			  });

			//Enseña la interfaz
			Main.Add (DayContainer);
			this.Add (Main);
			this.ShowAll ();
		}
	}
}

