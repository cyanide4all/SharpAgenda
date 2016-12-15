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

		public void ToModifyMeet(string nom, string nombre, string nomCita, string fecha, string hora, string des)
		{
			Cita nueva = new Cita (nombre, nomCita, fecha, hora, des);
			this.listaCitas.ModifyMeet (nom, nueva);
		}

		public void ToDeleteMeet(string nom)
		{
			this.listaCitas.RemoveMeet (nom);
		}

		public string ToViewMeetByName(string nom)
		{
			return this.listaCitas.GetByName(nom).ToString () + "\n";
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

