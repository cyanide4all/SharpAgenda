using System;
using Gtk;
using Contactos;
using Meetings;

namespace SharpAgenda
{
	public class VentanaCitasNueva:Window
	{
		private String fechaAguardar;
		private Controler_Meetings citas;
		private String[] nombreContactos;
		private String contactoAGuardar;

		Entry NombreCita;
		//Entry NombreContacto;
		ComboBox cb;
		//Entry Fecha =; //Utilizo un calendario en vez de una entrada
		Entry Hora;
		Entry Descripcion;


		public VentanaCitasNueva (): base( "Nueva Cita" )
		{
			citas = new Controler_Meetings ();
			nombreContactos = Agenda.Get ().ToStringCB ();
			contactoAGuardar = "";
			fechaAguardar = "";
			this.Build ();
		}

		private void Build ()
		{
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			HBox H1 = new HBox ();
			HBox H2 = new HBox ();
			HBox H3 = new HBox ();
			HBox H4 = new HBox ();
			HBox H5 = new HBox ();

			NombreCita = new Entry ();
			//NombreContacto = new Entry ();
			cb = new ComboBox(nombreContactos); //Selleccionar Contacto.
			cb.Changed += OnChanged;

			//Entry Fecha = new Entry ();
			Hora = new Entry ();
			Descripcion = new Entry ();

			Label LnombreCita = new Label ("Indentificación de la cita: ");
			Label LNombreContacto = new Label ("Nombre del contacto: ");
			Label LFecha = new Label ("Fecha: ");
			Label LHora = new Label ("Hora: ");
			Label LDescripcion = new Label ("Descripción: ");

			//Calendario
			Calendar calendar = new Calendar();
			calendar.DaySelected += OnDaySelected;

			//Fixed fix = new Fixed();
			//fix.Put(calendar, 20, 20);
			//fix.Put(label, 40, 230);

			H1.Add(LnombreCita);
			H1.Add(NombreCita);
			H2.Add(LNombreContacto);
			H2.Add(cb);
			H3.Add(LFecha);
			H3.Add(calendar);
			H4.Add(LHora);
			H4.Add(Hora);
			H5.Add(LDescripcion);
			H5.Add(Descripcion);

			Main.Add (H1);
			Main.Add (H2);
			Main.Add (H3);
			Main.Add (H4);
			Main.Add (H5);

			Button btn = new Button("Guardar");
			btn.Clicked += Guardar;

			Main.Add (btn);

			Add(Main);
			this.ShowAll ();
		}


		void OnDaySelected(object sender, EventArgs args)
		{
			Calendar cal = (Calendar) sender;
			fechaAguardar = cal.Day + "/" + (cal.Month + 1) + "/" + cal.Year; //Fecha en String
		}

		void OnChanged(object sender, EventArgs args)
		{
			ComboBox cb = (ComboBox) sender;
			contactoAGuardar = cb.ActiveText;	//Este es la cita seleccionada
		}

		public void Guardar (object sender, EventArgs args)
		{
			if ((NombreCita.Text == "") || (contactoAGuardar == "") || fechaAguardar == "") 
			{
				MessageDialog md = new MessageDialog(this, 
					DialogFlags.DestroyWithParent, MessageType.Warning, 
					ButtonsType.Close, "Completa los campos: Identificador de Cita, Nombre de Contacto y Fecha.");
				md.Run();
				md.Destroy();
			}
			else
			{
				citas.ToAddNewMeet( NombreCita.Text, contactoAGuardar, fechaAguardar, Hora.Text, Descripcion.Text);
				citas.ToGenerateXml ();
				this.Destroy();
			}
		}
	}
}

