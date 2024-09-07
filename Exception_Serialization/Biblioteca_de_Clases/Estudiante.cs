using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca_de_Clases
{
    public class Estudiante
    {
        public Estudiante()
        {
                
        }

        public Estudiante(int legajo, string nombre, string apellido, List<string> materias)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.materias = materias;
        }

        public int legajo {  get; set; }
        public string nombre {  get; set; }
        public string apellido {  get; set; }
        public List<string> materias { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Legajo: {legajo}");
            sb.AppendLine($"Nombre: {nombre} - apellido: {apellido}");
            sb.AppendLine($"Materias:");
            foreach (string materia in materias)
            {
                sb.AppendLine($"  *{materia}");
            }

            return sb.ToString();
        }

        public bool EscribirXml(string path)
        {
            bool exito = true;
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Estudiante));
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }

        public bool EscribirJson(string path)
        {
            bool exito = true;
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    string data = JsonSerializer.Serialize(this);
                    writer.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }

        public bool EscribirTxt(string path)
        {
            bool exito = true;
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(this);
                }
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }
    }
}
