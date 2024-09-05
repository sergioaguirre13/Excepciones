using System.Xml.Serialization;

namespace Biblioteca_de_Clases
{
    public static class Serializadora<t> where t : class, new()
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
                    else if (path.Contains(".xml"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(obj));
                        serializer.Serialize(writer, obj);
                    }





                }
            }
            catch (Exception e)
            {

                throw;
            }

            return exito;
        }



    }
}
