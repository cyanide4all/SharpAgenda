﻿using System;
using Gtk;
using Contactos;

namespace SharpAgenda
{
	public class VentanaContactosModificar : Window
	{
		Contacto toMod;
		ComboBox comboBox;
		Entry Nombre;
		Entry Apellidos;
		Entry Direccion;
		Entry Telefono;
		Entry Email;

		public VentanaContactosModificar () : base("Modificar contactos")
		{
			//Config
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);

			VBox Main = new VBox();
			//TODO ESTA TARDE

			comboBox = new ComboBox(Agenda.Get ().ToStringCB ());
			comboBox.Changed += cambiarContacto;

			Button botonModificar = new Button ("Modificar");
			botonModificar.Clicked += modificarContacto;

			Nombre = new Entry ();
			Apellidos = new Entry ();
			Direccion = new Entry ();
			Telefono = new Entry ();
			Email = new Entry ();

			Label labelNombreContacto = new Label ("Nombre");
			labelNombreContacto.SetAlignment (0, 1);
			Label labelApellidosContacto = new Label ("Apellidos");
			labelApellidosContacto.SetAlignment (0, 1);
			Label labelDireccionContacto = new Label ("Dirección");
			labelDireccionContacto.SetAlignment (0, 1);
			Label labelTelefonoContacto = new Label ("Teléfono");
			labelTelefonoContacto.SetAlignment (0, 1);
			Label labelEmailContacto = new Label ("Email");
			labelEmailContacto.SetAlignment (0, 1);

			Main.Add (comboBox);
			Main.Add(labelNombreContacto);
			Main.Add (Nombre);
			Main.Add(labelApellidosContacto);
			Main.Add (Apellidos);
			Main.Add(labelDireccionContacto);
			Main.Add (Direccion);
			Main.Add(labelTelefonoContacto);
			Main.Add (Telefono);
			Main.Add(labelEmailContacto);
			Main.Add (Email);
			Main.Add (botonModificar);

			this.Add (Main);
			this.ShowAll ();
		}

		void cambiarContacto(object sender, EventArgs args){
			String[] nombreYApellidos = comboBox.ActiveText.Split(','); //Esto es el Nombre,Apellidos
			String nombre = nombreYApellidos[0];
			String apellidos = nombreYApellidos [1];
			toMod = Agenda.Get ().GetContactoByNombreCompleto (nombre, apellidos);
			Nombre.Text = toMod.Nombre;
			Apellidos.Text = toMod.Apellidos;
			Direccion.Text = toMod.Direccion;
			Telefono.Text = toMod.Telefono;
			Email.Text = toMod.Email;
		}

		void modificarContacto(object sender, EventArgs args){
			if(toMod == null){
				alertaNoModificable ();
			}else{
				if (Nombre.Text == "") {
					alertaIntroduzcaAlMenosNombre ();
				} else {
					Agenda agenda = Agenda.Get ();
					int pos = agenda.GetPosicion (toMod);
					agenda.ModificarContacto (pos, Nombre.Text, Apellidos.Text, Direccion.Text, Email.Text, Telefono.Text);
					agenda.SaveXML ();
					alertaOperacionExitosa ();
					this.Destroy ();
				}
			}
		}

		//ALERTAS
		private void alertaNoModificable(){
			MessageDialog md = new MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Warning, 
				ButtonsType.Close, "No se ha seleccionado el contacto a modificar");
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

		private void alertaIntroduzcaAlMenosNombre (){
			MessageDialog md = new	MessageDialog(this, 
				DialogFlags.DestroyWithParent, MessageType.Warning, 
				ButtonsType.Close, "Introduce al menos un nombre para el contacto");
			md.Run();
			md.Destroy();
		}
	}
}

