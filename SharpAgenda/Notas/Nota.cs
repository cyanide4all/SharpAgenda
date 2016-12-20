using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using Contactos;

namespace Notas
{
	public partial class Nota
	{
		private const string ficheroNotas = "notas.xml";
		private string contenido {
			get;
			set;
		}
		private Contacto contacto {
			get; set;
		}

		public Nota ()
		{
		}

		public static List<Nota> GetNotasXML ()
		{
			var resultado = new List<Nota> ();
			Agenda agenda = Agenda.Get ();
			var file = new XmlDocument ();

			try {
				file.Load (ficheroNotas);
			} catch (Exception) {
				return resultado; //lista vacia
			}

			foreach (XmlNode node in file.ChildNodes) {
				if (node.Name == "nota") {
					Contacto cont = null;

					foreach(XmlNode subnode in node.ChildNodes) {
						if(subnode.Name == "contacto") {
							cont = agenda.GetContactoByEmail (subnode.InnerText);
							if(cont == null) {
								throw new Exception("invalid contact email: " + subnode.InnerText);
							}
						}
					}

					var nota = new Nota ();
					nota.contacto = cont;
					nota.contenido = node.InnerText;
					resultado.Add (nota);
				}
			}
			return resultado;

		}

		public void SaveXML() {
			var wr = new XmlTextWriter (ficheroNotas, Encoding.UTF8);
			wr.WriteStartDocument ();

			wr.WriteStartElement("nota");
			wr.WriteStartElement ("contacto");
			wr.WriteString (contacto.Email);
			wr.WriteEndElement ();
			wr.WriteString(this.contenido);
			wr.WriteEndElement();

			wr.WriteEndDocument();
		}

		public override string ToString() {
			return "Contacto: " + contacto.Nombre + " " + contacto.Apellidos + "\n" + contenido;
		}
	}
}

