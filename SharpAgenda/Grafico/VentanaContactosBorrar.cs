//DEPRECATED PORQUE SE ME OCURRIÓ ALGO MEJOR

using System;
using Gtk;
using Contactos;

namespace SharpAgenda
{
	public class VentanaContactosBorrar : Window
	{
		Label textoAMostrar;
		Entry nombre;
		Entry apellidos;
		Entry email;
		Contacto toDelete;
		public VentanaContactosBorrar () :base("Eliminar contactos")
		{
			//Config
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			toDelete = null;
			textoAMostrar = new Label ("Busca abajo por nombre y apellidos o bien por email");
			nombre = new Entry ();
			apellidos = new Entry ();
			email = new Entry ();

			Button BnombreYApellidos = new Button ("Buscar por nombre/apellidos");
			BnombreYApellidos.Clicked += buscarNombreApellidos;
			Button Bemail = new Button ("Buscar por email");
			Bemail.Clicked += buscarEmail;
			Button BborrarContacto = new Button ("Borrar contacto");
			BborrarContacto.Clicked += borrarContacto;

			Main.Add (new Label ("Se eliminará el siguiente contacto: \n"));
			Main.Add (textoAMostrar);
			Main.Add (BborrarContacto);
			Main.Add(new Label("Nombre a buscar: "));
			Main.Add (nombre);
			Main.Add(new Label("Apellidos a buscar: "));
			Main.Add (apellidos);
			Main.Add (BnombreYApellidos);
			Main.Add(new Label("Email a buscar: "));
			Main.Add (email);
			Main.Add (Bemail);



			this.Add (Main);
			this.ShowAll();


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
			
		void buscarNombreApellidos(object sender, EventArgs args){
			Agenda agenda = Agenda.Get();
			toDelete = agenda.GetContactoByNombreCompleto (nombre.Text, apellidos.Text);
			if (toDelete == null) {
				alertaNoResultados ();
			} else {
				textoAMostrar.Text = toDelete.ToString ();
			}
		}

		void buscarEmail(object sender, EventArgs args){
			Agenda agenda = Agenda.Get();
			toDelete = agenda.GetContactoByEmail (email.Text);
			if (toDelete == null) {
				alertaNoResultados ();
			} else {
				textoAMostrar.Text = toDelete.ToString ();
			}
		}
			

		//ALERTAS
		private void alertaNoResultados(){
			MessageDialog md = new MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Warning, 
				ButtonsType.Close, "La búsqueda no produjo resultados");
			md.Run();
			md.Destroy();
		}

		private void alertaNoEliminable(){
			MessageDialog md = new MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Warning, 
				ButtonsType.Close, "No se ha buscado el contacto a eliminar");
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

