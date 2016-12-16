using System;
using Gtk;
using Meetings;

namespace SharpAgenda
{
	public class VentanaCitasBorrar : Window
	{
		private Controler_Meetings citas;
		private String[] nombresCitas;
		private String citaABorrar;
		private Label textoAMostrar;

		public VentanaCitasBorrar () : base ("Eliminar Citas")
		{
			citas = new Controler_Meetings ();
			citaABorrar = "";
			nombresCitas = citas.GetAll();
			this.Build();
		}

		private void Build()
		{
			BorderWidth = 10;
			SetDefaultSize(250, 200);
			SetPosition(WindowPosition.Center);
			VBox Main = new VBox ();

			if(nombresCitas.Length == 0)
			{
				textoAMostrar = new Label ("No tiene citas disponibles.");
				Main.Add (textoAMostrar);
			}
			else
			{
				HBox H1 = new HBox ();



				//Devolver el array de citas.
				ComboBox cb = new ComboBox(nombresCitas);
				cb.Changed += OnChanged;

				H1.Add (cb);

				textoAMostrar = new Label ("...");	

				Button btn = new Button("Borrar");
				btn.Clicked += Borrar;

				Main.Add (H1);
				Main.Add (textoAMostrar);
				Main.Add (btn);

			}
			Add(Main);
			this.ShowAll ();

		}


		void OnChanged(object sender, EventArgs args)
		{
			ComboBox cb = (ComboBox) sender;
			citaABorrar = cb.ActiveText;	//Este es la cita seleccionada
			textoAMostrar.Text = citas.ToViewMeetByName(citaABorrar);
		}

		public void Borrar (object sender, EventArgs args)
		{
			if (citaABorrar == "") 
			{
				MessageDialog md = new MessageDialog(this, 
					DialogFlags.DestroyWithParent, MessageType.Warning, 
					ButtonsType.Close, "Selecciona al menos una Cita.");
				md.Run();
				md.Destroy();
			}
			else
			{
				if (citas.ToDeleteMeet (citaABorrar)) 
				{
					citas.ToGenerateXml ();

					MessageDialog md = new MessageDialog(this, 
						DialogFlags.DestroyWithParent, MessageType.Info, 
						ButtonsType.Close, "Se ha borrado la cita con éxito.");
					md.Run();
					md.Destroy();
				} 
				else 
				{
					MessageDialog md = new MessageDialog(this, 
						DialogFlags.DestroyWithParent, MessageType.Error, 
						ButtonsType.Close, "No se ha podido eliminar la cita.");
					md.Run();
					md.Destroy();
				}
				this.Destroy();//Mirar si se cierra al guardar
			}
		}
	}
}

