using System;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Linq;

namespace Contactos
{
	public class Agenda
	{
		private List<Contacto> contactos;
		public const string nombreArchivo = "contactos.xml";
		public const string EtqContactos = "contactos";
		public const string EtqContacto = "contacto";
		public const string EtqNombre = "nombre";
		public const string EtqApellidos = "apellidos";
		public const string EtqDireccion = "direccion";
		public const string EtqEmail = "email";
		public const string EtqTelefono = "telefono";

		//Constructor
		public Agenda ()
		{
			contactos = new List<Contacto> ();
		}

		//Metodo static para pillar una agenda desde XML
		public static Agenda Get(){
			var toret = new Agenda();
			toret.OverrideContactos( GetContactosFromXml() );
			return toret;
		}

		public bool IsEmpty(){
			return contactos.Count == 0;
		}

		public void OverrideContactos(List<Contacto> c){
			contactos = c;
		}

		public void AddContacto(Contacto c){
			contactos.Add (c);
		}
		public void AddContacto(String n,String a,String d,String e, String t){
			contactos.Add (new Contacto (n, a, d, e, t));
		}
			
		public Boolean DelContacto(Contacto c){
			return contactos.Remove (c); //Puesto como return for debugging purposes
		}

		public int GetPosicion(Contacto c){
			return contactos.IndexOf (c);
			//return null;
		}

		public Contacto GetContactoByIndex(int i){
			return contactos.ElementAt (i);
		}

		public Contacto GetContactoByNombreCompleto(String nom, String ap){
			return contactos.Find (x => x.Nombre == nom && x.Apellidos == ap);
		}

		public Contacto GetContactoByEmail(String email){
			return contactos.Find (x => x.Email == email);
		}

		public void ModificarContacto(int i, String nom,String ap,String d,String e,String t){
			this.DelContacto (contactos.ElementAt (i));
			this.AddContacto (nom, ap, d, e, t);
		}
			
		//Devuelve una lista de contactos para crear la Agenda con ellos en "get"
		public static List<Contacto> GetContactosFromXml (){
			var toret = new List<Contacto>();
			var docXml = new XmlDocument( );

			try {
				docXml.Load( nombreArchivo );

				if ( docXml.DocumentElement.Name == EtqContactos ) {
					string nombre = "";
					string apellidos = "";
					string direccion = "";
					string telefono = "";
					string email = "";


					foreach(XmlNode nodo in docXml.DocumentElement.ChildNodes) {
						if(nodo.Name==EtqContacto){
							foreach(XmlNode nodoHijo in nodo.ChildNodes){
								if(nodoHijo.Name == EtqNombre){
									nombre = nodoHijo.InnerText.Trim();
								}
								if(nodoHijo.Name == EtqApellidos){
									apellidos = nodoHijo.InnerText.Trim();
								}
								if(nodoHijo.Name == EtqDireccion){
									direccion = nodoHijo.InnerText.Trim();
								}
								if(nodoHijo.Name == EtqTelefono){
									telefono = nodoHijo.InnerText.Trim();
								}
								if(nodoHijo.Name == EtqEmail){
									email = nodoHijo.InnerText.Trim();
								}
							}
						}
						toret.Add(new Contacto(nombre,apellidos,direccion,telefono,email)); //Si algun dato no existe lo escribe vacio	
					}

				}	
				
			}catch(Exception){//TODO
			}

			return toret;
		}

		//A continuacion metodos sobrecargados para evitar la especificacion de un nombre de archivo
		//Sobrecargable
		public void SaveXML (){ 
			this.SaveXML (nombreArchivo);
		}

		//Sobrecargado
		public void SaveXML(String name){
			//Creación de escribidor y documento
			var writer = new XmlTextWriter( name, Encoding.UTF8 );
			writer.WriteStartDocument();

			//Primera linea
			writer.WriteStartElement(EtqContactos);
			//Escribimos cada contacto
			foreach( var e in contactos){

				writer.WriteStartElement(EtqContacto);

				//Escribimos nombre
				writer.WriteStartElement(EtqNombre);
				writer.WriteString(e.Nombre);
				writer.WriteEndElement();

				//Escribimos apellidos
				writer.WriteStartElement(EtqApellidos);
				writer.WriteString(e.Apellidos);
				writer.WriteEndElement();

				//Escribimos direccion
				writer.WriteStartElement(EtqDireccion);
				writer.WriteString(e.Direccion);
				writer.WriteEndElement();

				//Escribimos email
				writer.WriteStartElement(EtqEmail);
				writer.WriteString(e.Email);
				writer.WriteEndElement();

				//Escribimos telefono
				writer.WriteStartElement(EtqTelefono);
				writer.WriteString(e.Telefono);
				writer.WriteEndElement();

				//Cerramos el contacto
				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Close();
		}


		//TOSTRING
		public override string ToString()
		{
			var toret = new StringBuilder();
			foreach(var entry in this.contactos) {
				toret.AppendLine( entry.ToString() );
			}
			return toret.ToString();
		}

		//VERSION DE TOSTRING PARA COMBOBOX
		public String[] ToStringCB(){
			var toret = new String[this.contactos.Capacity];
			int it = 0;
			foreach(var entry in this.contactos) {
				toret[it++] = (entry.Nombre.ToString()+","+entry.Apellidos.ToString());
			}
			return toret;
		}
	}
}

