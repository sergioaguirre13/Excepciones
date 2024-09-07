using Biblioteca_de_Clases;
using System.Text.Json;
using System.Xml.Serialization;


namespace Exception_Serialization
{
    internal class Testeo_Estudiante
    {
        static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante(2004, "Sergio", "Aguirre", new List<string>() { "Programación", "Matematicas", "Ingles" });

            Estudiante e2;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreFileTxt = "estudiante.txt";
            string nombreFileJson = "estudiante.json";
            string nombreFileXml = "estudiante.xml";

            string pathCompletoT = $@"{path}\{nombreFileTxt}";
            string pathCompletoJ = $@"{path}\{nombreFileJson}";
            string pathCompletoX = $@"{path}\{nombreFileXml}";


            string lectura;

            e1.EscribirTxt(pathCompletoT);

            using (StreamWriter writer = new StreamWriter(pathCompletoX))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Estudiante));
                serializer.Serialize(writer, e1);
            }

            using (StreamReader reader = new StreamReader(pathCompletoX))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Estudiante));
                e2 = serializer.Deserialize(reader) as Estudiante;
            }

            Console.WriteLine(e2);

            Console.WriteLine("-------------------------------------------------------");



            using (StreamWriter writer = new StreamWriter(pathCompletoJ))
            {
                string data = JsonSerializer.Serialize(e1);

                writer.WriteLine(data);
            }

            using (StreamReader reader = new StreamReader(pathCompletoJ))
            {
                string data = reader.ReadToEnd();
                e2 = JsonSerializer.Deserialize<Estudiante>(data);
            }

            Console.WriteLine(e2);

        }
    }
}
