using Biblioteca_de_Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca_de_Clases
{
    public static class MiClaseSerializadoraGenerica<T> where T : class, new()
    {

        public static bool Escribir(string path, string nombre, T obj)
        {

            bool exito = true;

            if (!string.IsNullOrEmpty(nombre))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter($@"{path}\{nombre}"))
                    {
                        switch (TipoDeArchivo(nombre))
                        {
                            case "json":
                                string data = JsonSerializer.Serialize(obj);
                                writer.WriteLine(data);
                                break;
                            case "xml":
                                XmlSerializer serializer = new XmlSerializer(typeof(T));
                                serializer.Serialize(writer, obj);
                                break;
                            
                        }

                    }
                }
                catch (Exception ex)
                {
                    exito = false;
                }
            }
            else 
            {
                exito = true;
            }

            return exito;

        }

        public static T Leer (string path,string nombre)
        {
         
            T obj = new();
            using (StreamReader reader = new StreamReader($@"{path}\{nombre}"))
            {
                switch (TipoDeArchivo(nombre))
                {
                    case "json":
                        string data = reader.ReadToEnd();
                        obj = JsonSerializer.Deserialize<T>(data);
                        break;
                    case "xml":
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        obj = (T)serializer.Deserialize(reader);
                        break;
                  
                }
            }
            return obj;
        }

       

        public static string LeerTxt(string path, string nombre)
        {
            string lectura;
            using (StreamReader reader = new StreamReader($@"{path}\{nombre}"))
            {
                lectura = reader.ReadToEnd();
            }

            return lectura;
        }


        private static string TipoDeArchivo(string nombre)
        {
            string archivo = string.Empty;

            if (nombre.Contains("json"))
            {
                archivo = "json";
            } 
            else if (nombre.Contains("xml"))
            {
                archivo = "xml";
            }
           


            return archivo;
        }
    }
}
