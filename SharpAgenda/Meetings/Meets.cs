using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Meetings
{
	public class Meets
	{
		public List<Cita> todasLasCitas;
		public string nombreXmlDoc;

		public Meets (string xml)	//Direccion del archivo XML de Citas
		{
			nombreXmlDoc = xml;
			todasLasCitas = RecuperaXml (xml);				
		}
			
		public List<Cita> RecuperaXml(string f)
		{
			var toret = new List<Cita>();
			var docXml = new XmlDocument( );

			try {
				docXml.Load( f );

				if ( docXml.DocumentElement.Name == "Citas" ) {
					string nombre = "";
					string nombreContacto = "";
					string fecha = "";
					string hora = "";
					string descrip = "";

					foreach(XmlNode nodo in docXml.DocumentElement.ChildNodes) {
						if ( nodo.Name == "cita" ){
							foreach(XmlNode subNodo in nodo.ChildNodes) {
								if ( subNodo.Name == "nombreCita" ) {
									nombre = subNodo.InnerText.Trim(); //Trim quita los espacios en blanco
								}
								if ( subNodo.Name == "nombreContacto" ) {
									nombreContacto = subNodo.InnerText.Trim();
								}
								if ( subNodo.Name == "fecha" ) {
									fecha = subNodo.InnerText.Trim();
								}
								if ( subNodo.Name == "hora" ) {
									hora = subNodo.InnerText.Trim();
								}
								if ( subNodo.Name == "descripcion" ) {
									descrip = subNodo.InnerText.Trim();
								}
							}
								
							if ( nombre != "" ) //En caso de que el documento este vacio
							{
								toret.Add( new Cita( nombre, nombreContacto, fecha, hora, descrip ) );
							}
						}
					}
				}
			}
			catch(Exception)
			{
				toret.Clear();
				Console.WriteLine ("Exception" );
			}

			return toret;
		}

		public void AddMeet (Cita cita)
		{
			todasLasCitas.Add (cita);	//Añado la cita a todas las anteriores
		}

		public Boolean RemoveMeet (string nom)
		{
			Cita cita = this.GetByName (nom);

			if (todasLasCitas.Remove (cita))
				return true;
			else
				return false;
		}

		public void ModifyMeet (string nom, Cita cita) //Le pasas el nombre de la cita a modificar y la cita nueva
		{
			Cita aux = this.GetByName (nom);
			int position = todasLasCitas.IndexOf (aux);
			todasLasCitas.Remove (aux);
			todasLasCitas.Insert (position, cita);	//Vuelve a insertarla en la misma posicion
		}

		public String[] GetAll()
		{
			String[] toret = new string[todasLasCitas.Count];
			int j = 0;

			foreach (var i in todasLasCitas)
			{
				toret [j++] = i.Nombre;
			}
			return toret;
		}

		public Cita GetByName(string nom)
		{
			return todasLasCitas.Find (x => x.Nombre == nom);
		}

		public Cita GetByContact(string nom)
		{
			return todasLasCitas.Find (x => x.NombreContacto == nom);
		}

		public void GenerateXml ()
		{
			int j = 0; //Contador Actual

			XmlTextWriter textWriter = new XmlTextWriter( nombreXmlDoc, Encoding.UTF8 );

			textWriter.WriteStartDocument();
			textWriter.WriteStartElement("Citas");

			foreach (var i in todasLasCitas) 
			{
				textWriter.WriteStartElement ("cita");
				textWriter.WriteStartElement ("nombreCita");
				textWriter.WriteString (todasLasCitas.ElementAt (j).Nombre);
				textWriter.WriteEndElement ();
				textWriter.WriteStartElement ("nombreContacto");
				textWriter.WriteString (todasLasCitas.ElementAt (j).NombreContacto);
				textWriter.WriteEndElement ();
				textWriter.WriteStartElement ("fecha");
				textWriter.WriteString (todasLasCitas.ElementAt (j).Fecha);
				textWriter.WriteEndElement ();
				textWriter.WriteStartElement ("hora");
				textWriter.WriteString (todasLasCitas.ElementAt (j).Hora);
				textWriter.WriteEndElement ();
				textWriter.WriteStartElement ("descripcion");
				textWriter.WriteString (todasLasCitas.ElementAt (j).Descripcion);
				textWriter.WriteEndElement ();
				textWriter.WriteEndElement();

				j++;
			}
				
			textWriter.WriteEndElement(); //Cerrar Citas
			textWriter.WriteEndDocument();
			textWriter.Close();

		}

		public override string ToString ()
		{
			StringBuilder toret = new StringBuilder();
			int j = 0;

			//System.Console.WriteLine (todasLasCitas.Count);

			if (todasLasCitas.Count == 0) {
				toret.Append("");
			} else {
					foreach (var i in todasLasCitas) {
					toret.Append (i.ToString (++j) + " \n\n");
				}
			}
			return toret.ToString();
		}
	}
}

