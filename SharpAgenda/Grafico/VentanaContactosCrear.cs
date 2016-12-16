using System;
using Gtk;
using Contactos;

namespace SharpAgenda
{
	public class VentanaContactosCrear :Window
	{
		//Para usar en el create se sacan del constructor
		private Entry nombreContacto;
		private Entry apellidosContacto;
		private Entry direccionContacto;
		private Entry telefonoContacto;
		private Entry emailContacto;


		public VentanaContactosCrear () : base("Crear contacto")
		{
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			nombreContacto = new Entry ();
			apellidosContacto = new Entry ();
			direccionContacto = new Entry ();
			telefonoContacto = new Entry ();
			emailContacto = new Entry ();

			//Si tal, ya si eso, gravedad izquierda en las labels porque estan al medio
			Label labelNombreContacto = new Label ("Nombre");
			Label labelApellidosContacto = new Label ("Apellidos");
			Label labelDireccionContacto = new Label ("Dirección");
			Label labelTelefonoContacto = new Label ("Teléfono");
			Label LabelEmailContacto = new Label ("Email");

			Button guardar = new Button ("Guardar");
			guardar.Clicked += crearContacto;

			Main.Add (labelNombreContacto);
			Main.Add (nombreContacto);
			Main.Add (labelApellidosContacto);
			Main.Add (apellidosContacto);
			Main.Add (labelDireccionContacto);
			Main.Add (direccionContacto);
			Main.Add (labelTelefonoContacto);
			Main.Add (telefonoContacto);
			Main.Add (LabelEmailContacto);
			Main.Add (emailContacto);
			Main.Add (guardar);


			Add (Main);
			ShowAll ();
		}

		void crearContacto(object sender, EventArgs args){
			if (nombreContacto.Text != "") {
				//Crear el contacto
				Contacto nuevo = new Contacto (nombreContacto.Text, apellidosContacto.Text, 
					                  direccionContacto.Text, emailContacto.Text, 
					                  telefonoContacto.Text);
				Agenda agenda = Agenda.Get ();
				agenda.AddContacto (nuevo);
				agenda.SaveXML ();
				alertaOperacionExitosa ();
				this.Destroy ();

			} else {
				alertaIntroduzcaAlMenosNombre ();
			}
		}
	
		//ALERTAS
		private void alertaOperacionExitosa(){
			MessageDialog md = new MessageDialog (this, 
				                   DialogFlags.DestroyWithParent, MessageType.Info, 
				                   ButtonsType.Ok, "Operación Exitosa");
			md.Run ();
			md.Destroy ();
		}

		private void alertaIntroduzcaAlMenosNombre (){
			MessageDialog md = new	MessageDialog(this, 
									DialogFlags.DestroyWithParent, MessageType.Warning, 
									ButtonsType.Close, "Introduce al menos un nombre para el contacto");
			md.Run();
			md.Destroy();
		}

	}
}

