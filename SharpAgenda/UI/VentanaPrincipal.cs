using System;
using Gtk;
using Grafico;

namespace SharpAgenda
{
	public class VentanaPrincipal: Window
	{
		VBox Main = new VBox();

		public VentanaPrincipal ()
			:base("SharpAgenda")
		{
			//Config
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			DeleteEvent += delegate { Application.Quit(); };

			//Partes
			MenuBar mb = new MenuBar();

			Menu contactosOpciones = new Menu ();
			MenuItem contactosMenu = new MenuItem ("Contactos");
			MenuItem contactosListar = new MenuItem ("Listar contactos");
			contactosListar.Activated += ListarContactos;
			MenuItem contactosCrear = new MenuItem ("Crear Contacto");
			contactosCrear.Activated += CrearContacto;
			MenuItem contactosBorrar = new MenuItem ("Borrar contactos");
			contactosBorrar.Activated += BorrarContacto;
			MenuItem contactosModificar = new MenuItem ("Modificar contactos");

			Menu citasOpciones = new Menu ();
			MenuItem citasMenu = new MenuItem ("Citas");
			MenuItem citasListar = new MenuItem ("Listar citas");
			citasListar.Activated += ListarCitas;
			MenuItem citasCrear = new MenuItem ("Crear citas");
			citasCrear.Activated += CrearCitas;
			MenuItem citasBorrar = new MenuItem ("Borrar citas");
			MenuItem citasModificar = new MenuItem ("Modificar citas");

			Menu notasOpciones = new Menu ();
			MenuItem notasMenu = new MenuItem ("Notas");
			MenuItem notasListar = new MenuItem ("Listar notas");
			MenuItem notasCrear = new MenuItem ("Crear notas");
			MenuItem notasBorrar = new MenuItem ("Borrar notas");
			MenuItem notasModificar = new MenuItem ("Modificar notas");

			contactosMenu.Submenu = contactosOpciones;
			citasMenu.Submenu = citasOpciones;
			notasMenu.Submenu = notasOpciones;

			contactosOpciones.Append (contactosListar);
			contactosOpciones.Append (contactosCrear);
			contactosOpciones.Append (contactosBorrar);
			contactosOpciones.Append (contactosModificar);

			citasOpciones.Append (citasListar);
			citasOpciones.Append (citasCrear);
			citasOpciones.Append (citasBorrar);
			citasOpciones.Append (citasModificar);

			notasOpciones.Append (notasListar);
			notasOpciones.Append (notasCrear);
			notasOpciones.Append (notasBorrar);
			notasOpciones.Append (notasModificar);

			mb.Append (contactosMenu);
			mb.Append (citasMenu);
			mb.Append (notasMenu);

			//PASTEADO
			VBox menuBox = new VBox(false, 2);
			menuBox.PackStart(mb, false, false, 0);

			VBox textBox = new VBox ();

			textBox.Add(new Label("Bienvenido a SharpAgenda\nSelecciona una opcion usando el menu"));
			Main.Add (menuBox);
			Main.Add (textBox);

			Add (Main);

			ShowAll();

		}
		void ListarContactos(object sender, EventArgs args){
			new VentanaContactosListar ();
		}
		void CrearContacto(object sender, EventArgs args){
			new VentanaContactosCrear();
		}
		void BorrarContacto(object sender, EventArgs args){
			new VentanaContactosBorrar();
		}
		void ListarCitas(object sender, EventArgs args){
			new VentanaCitasListar ();
		}
		void CrearCitas(object sender, EventArgs args){
			new VentanaCitasNueva();
		}
	}
}

