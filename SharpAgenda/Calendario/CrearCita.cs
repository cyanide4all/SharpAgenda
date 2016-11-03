using System;
using System.Xml;
using System.Xml.Linq;

namespace Calendario
{
	public class CrearCita
	{
		public CrearCita()
		{
			var raiz = 	new XElement("cita",
						new XElement("cita",
			                new XElement("nombre", "Compras"),
			                new XElement("nombreContacto", "Manolo"),
			                new XElement("hora", "Todo el día"),
							new XElement("descripcion", "Ir de compras"),
							new XElement("fecha", "16/11/2016")),
						new XElement("cita",
							new XElement("descripcion", "Jugar bolos"),
							new XElement("fecha", "2/11/2016")),
			            new XElement("cita",
							new XElement("descripcion", "Jugar futbol"),
							new XElement("fecha", "3/11/2016")),
			            new XElement("cita",
							new XElement("descripcion", "Marcar Tendencia"),
							new XElement("fecha", "16/11/2016"))

						);
			
			raiz.Save("citas.xml");

			Console.WriteLine("Cita creada adecuadamente");
		}
	}
}
