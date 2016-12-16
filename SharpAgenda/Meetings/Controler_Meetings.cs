using System;

namespace Meetings
{
	public class Controler_Meetings
	{
		public Meets listaCitas;

		public Controler_Meetings ()
		{ 
			listaCitas = new Meets("citas.xml");
		}

		public void ToAddNewMeet(string nombre, string nomCon, string fecha, string hora, string des)
		{
			Cita nueva = new Cita (nombre, nomCon, fecha, hora, des);
			this.listaCitas.AddMeet (nueva);
		}

		public void ToModifyMeet(string nom, string nombreCita, string nomContacto, string fecha, string hora, string des)
		{
			Cita nueva = new Cita (nombreCita, nomContacto, fecha, hora, des);
			this.listaCitas.ModifyMeet (nom, nueva);
		}

		public Boolean ToDeleteMeet(string nom)
		{
			return this.listaCitas.RemoveMeet (nom);
		}

		public String[] GetAll()
		{
			return this.listaCitas.GetAll ();
		}

		public Cita ToGetMeetByName(string nom)
		{
			return this.listaCitas.GetByName(nom);
		}

		public string ToViewMeetByName(string nom)
		{
			return (this.listaCitas.GetByName(nom).ToString () + "\n");
		}

		public string ToViewMeetByContact(string nom)
		{
			return this.listaCitas.GetByContact(nom).ToString () + "\n";
		}

		public void ToGenerateXml()
		{
			listaCitas.GenerateXml ();
		}

		public override string ToString()
		{
			return listaCitas.ToString ();
		}
	}
}

