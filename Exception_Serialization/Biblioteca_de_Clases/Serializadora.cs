using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Serialization;

namespace Biblioteca_de_Clases
{
    public static class Serializadora<T> where T: class, new()
    {

        public static bool Escribir(object obj, string path)
        {
            bool exito = true;



            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    if (path.Contains(".txt"))
                    {
                        writer.WriteLine(obj);
                    }
                    else if (path.Contains(".json"))
                    {
                        string data = JsonSerializer.Serialize(obj);

                        writer.WriteLine(data);
                    }
                    else if (path.Contains(".xml"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(object));
                        serializer.Serialize(writer, obj);
                    }
                }




            }
            catch (Exception)
            {

                throw;
            }
            




            return exito;

            
        }





    }
}
