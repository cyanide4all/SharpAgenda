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
		public string contenido {
			get;
			set;
		}
		public Contacto contacto {
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
			}catch (System.IO.FileNotFoundException) {
				List<Nota> emptyList = new List<Nota>();
				Nota.SaveNotas (emptyList);
				file.Load (ficheroNotas);
			}
		

			foreach(XmlNode mainNode in file.ChildNodes) {
				if(mainNode.Name == "xml") {
						continue;
				} else if (mainNode.Name == "notas") {
					foreach (XmlNode node in mainNode.ChildNodes) {
				
					if (node.Name == "nota") {
						Contacto cont = null;
						string contenido = null;

						foreach(XmlNode subnode in node.ChildNodes) {
							if(subnode.Name == "contacto") {
								cont = agenda.GetContactoByEmail (subnode.InnerText);
								if(cont == null) {
									throw new Exception("invalid contact email: " + subnode.InnerText);
								}
							}
							if(subnode.Name == "contenido") {
								contenido = subnode.InnerText;
							}
						}

						var nota = new Nota ();
						nota.contacto = cont;
						nota.contenido = contenido;
						resultado.Add (nota);
						}
					}
				}
			}
			file.Save(ficheroNotas);
			return resultado;

		}

		public static void SaveNotas (List<Nota> notas)
		{
			var wr = new XmlTextWriter (ficheroNotas, Encoding.UTF8);
			wr.WriteStartDocument ();
			wr.WriteStartElement ("notas");

			foreach (Nota n in notas) {
				n.SaveXML (wr);
			}

			wr.WriteEndElement ();
			wr.WriteEndDocument ();
			wr.Close ();
		}

		private void SaveXML(XmlTextWriter wr) {
			wr.WriteStartElement("nota");
			wr.WriteStartElement ("contacto");
			wr.WriteString (contacto.Email);
			wr.WriteEndElement ();
			wr.WriteStartElement ("contenido");
			wr.WriteString(this.contenido);
			wr.WriteEndElement ();
			wr.WriteEndElement();
		}

		public override string ToString() {
			return "Contacto: " + contacto.Nombre + " " + contacto.Apellidos + "\n" + contenido;
		}
	}
}

