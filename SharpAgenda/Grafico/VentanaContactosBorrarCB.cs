using System;
using Gtk;
using Contactos;

namespace SharpAgenda
{
	public class VentanaContactosBorrarCB : Window
	{
		Label textoAMostrar;
		Contacto toDelete;
		ComboBox comboBox;
		public VentanaContactosBorrarCB () :base("Eliminar contactos")
		{
			//Config
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			toDelete = null;
			textoAMostrar = new Label ("Usa el selector para indicar el contacto a eliminar");

			comboBox = new ComboBox(Agenda.Get ().ToStringCB ());
			comboBox.Changed += cambiarContacto;

			Button BborrarContacto = new Button ("Borrar contacto");
			BborrarContacto.Clicked += borrarContacto;

			Main.Add (new Label ("Se eliminará el siguiente contacto: \n"));
			Main.Add (textoAMostrar);
			Main.Add (BborrarContacto);
			Main.Add (comboBox);


			this.Add (Main);
			this.ShowAll();
		}


		void cambiarContacto(object sender, EventArgs args){
			String[] nombreYApellidos = comboBox.ActiveText.Split(','); //Esto es el Nombre,Apellidos
			String nombre = nombreYApellidos[0];
			String apellidos = nombreYApellidos [1];
			toDelete = Agenda.Get ().GetContactoByNombreCompleto (nombre, apellidos);
			textoAMostrar.Text = toDelete.ToString ();
		}
			

		void borrarContacto(object sender, EventArgs args){
			if (toDelete == null) {
				alertaNoEliminable ();
			} else {
				Agenda agenda = Agenda.Get();
				agenda.DelContacto (toDelete);
				agenda.SaveXML ();
				alertaOperacionExitosa ();
				this.Destroy();
			}
		}


		//ALERTAS
		private void alertaNoEliminable(){
			MessageDialog md = new MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Warning, 
				ButtonsType.Close, "No se ha seleccionado el contacto a eliminar");
			md.Run();
			md.Destroy();
		}
		private void alertaOperacionExitosa(){
			MessageDialog md = new MessageDialog (this, 
				DialogFlags.DestroyWithParent, MessageType.Info, 
				ButtonsType.Ok, "Operación Exitosa");
			md.Run ();
			md.Destroy ();
		}




	}
}

