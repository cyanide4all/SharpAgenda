using System;
using Gtk;
using Contactos;
using Meetings;

namespace SharpAgenda
{
	public class VentanaCitasModificar : Window
	{
		private String fechaAguardar;
		private Controler_Meetings citas;
		private String[] nombresCitas;
		private String[] nombresContactos;
		private String citaAModificar;
		private String contactoAGuardar;

		private Entry NombreCita;
		//private Entry NombreContacto;
		//Entry Fecha =; //Utilizo un calendario en vez de una entrada
		private Entry Hora;
		private Entry Descripcion;

		private Label textoAMostrar;

		private ComboBox cbModifica;

		private Calendar calendar;

		public VentanaCitasModificar (): base( "Modificar Cita" )
		{
			citas = new Controler_Meetings ();
			nombresCitas = citas.GetAll ();
			nombresContactos = Agenda.Get ().ToStringCB ();
			fechaAguardar = "";
			this.Build ();
		}

		private void Build ()
		{
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			HBox H0 = new HBox ();
			HBox H00 = new HBox ();
			HBox H1 = new HBox ();
			HBox H2 = new HBox ();
			HBox H3 = new HBox ();
			HBox H4 = new HBox ();
			HBox H5 = new HBox ();

			NombreCita = new Entry ();
			//NombreContacto = new Entry ();
			ComboBox cb = new ComboBox(nombresCitas); //Selleccionar Contacto.
			cb.Changed += OnChanged;
			cbModifica = new ComboBox(nombresContactos); //Selleccionar Contacto.
			cbModifica.Changed += OnChanged2;
			//Entry Fecha = new Entry ();
			Hora = new Entry ();
			Descripcion = new Entry ();

			textoAMostrar = new Label ("...");
			Label LnombreCita = new Label ("Indentificación de la cita: ");
			Label LNombreContacto = new Label ("Nombre del contacto: ");
			Label LFecha = new Label ("Fecha: ");
			Label LHora = new Label ("Hora: ");
			Label LDescripcion = new Label ("Descripción: ");

			//Calendario
			calendar = new Calendar();
			calendar.DaySelected += OnDaySelected;

			//Fixed fix = new Fixed();
			//fix.Put(calendar, 20, 20);
			//fix.Put(label, 40, 230);

			H0.Add(textoAMostrar);
			H00.Add(cb);
			H1.Add(LnombreCita);
			H1.Add(NombreCita);
			H2.Add(LNombreContacto);
			H2.Add(cbModifica);
			H3.Add(LFecha);
			H3.Add(calendar);
			H4.Add(LHora);
			H4.Add(Hora);
			H5.Add(LDescripcion);
			H5.Add(Descripcion);

			Main.Add (H0);
			Main.Add (H00);
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
			citaAModificar = cb.ActiveText;	//Este es la cita seleccionada
			textoAMostrar.Text = citas.ToViewMeetByName(citaAModificar);

			NombreCita.Text = citas.ToGetMeetByName (citaAModificar).Nombre;
			String nombreYApellidos = citas.ToGetMeetByName (citaAModificar).NombreContacto;
			String nombre = nombreYApellidos.Split (',')[0];		
			String apellidos = nombreYApellidos.Split (',')[1];
			cbModifica.Active = (Agenda.Get().GetPosicion(Agenda.Get().GetContactoByNombreCompleto(nombre,apellidos))); //Inicializamos combo box a una posicion

			String fecha = citas.ToGetMeetByName (citaAModificar).Fecha;	//Ponemos el calendario a lo qe estaba antiguamente
			String dia = fecha.Split ('/') [0];
			String mes = fecha.Split ('/') [1];
			String ano = fecha.Split ('/') [2];
			calendar = new Calendar();
			calendar.DaySelected += OnDaySelected;
			calendar.Day = Int32.Parse(dia.Trim());
			calendar.Month = Int32.Parse(mes.Trim());
			calendar.Year = Int32.Parse(ano.Trim());
			calendar.MarkDay ((uint)calendar.Day);
			calendar.SelectDay ((uint)calendar.Day);
			calendar.SelectMonth ((uint)calendar.Month, (uint)calendar.Year);

			Hora.Text = citas.ToGetMeetByName (citaAModificar).Hora;
			Descripcion.Text = citas.ToGetMeetByName (citaAModificar).Descripcion;

		}

		void OnChanged2(object sender, EventArgs args)
		{
			ComboBox cb = (ComboBox) sender;
			contactoAGuardar = cb.ActiveText;	//Este es la cita seleccionada
			//textoAMostrar.Text = citas.ToViewMeetByName(citaABorrar);
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
				citas.ToModifyMeet (citaAModificar, NombreCita.Text, contactoAGuardar, fechaAguardar, Hora.Text, Descripcion.Text);
				citas.ToGenerateXml ();

				MessageDialog md = new MessageDialog(this, 
					DialogFlags.DestroyWithParent, MessageType.Info, 
					ButtonsType.Close, "Cita modificada con éxito.");
				md.Run();
				md.Destroy();

				this.Destroy();
			}
		}
	}
}



