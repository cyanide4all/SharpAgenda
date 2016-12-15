using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Notas
{
	public partial class Nota
	{
		private const string ficheroNotas = "notas-";
		private string contenido {
			get;
			set;
		}
		private Contactos.Contacto cont = null;

		public Nota (Contactos.Contacto c)
		{
			this.cont = c;
		}

		public static List<Nota> GetNotasXML(Contactos.Contacto c) {
			var resultado = new List<Nota> ();

			var file = new XmlDocument ();
			file.Load (ficheroNotas + c.Email + ".xml");

			foreach (XmlNode node in file.ChildNodes) {
				if (node.Name != "nota") {
					throw new Exception ("formato incorrecto");
				}
			
				var nota = new Nota (c);
				nota.contenido = node.InnerText;
				resultado.Add (nota);
			}
			return resultado;

		}

		public void SaveXML() {
			var wr = new XmlTextWriter (ficheroNotas + cont.Email + ".xml", Encoding.UTF8);
			wr.WriteStartDocument ();

			wr.WriteStartElement("nota");
			wr.WriteString(this.contenido);
			wr.WriteEndElement();

			wr.WriteEndDocument();
		}

		public override string ToString() {
			return contenido;
		}
	}
}

