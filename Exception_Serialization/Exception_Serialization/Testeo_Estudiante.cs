using Biblioteca_de_Clases;


namespace Exception_Serialization
{
    internal class Testeo_Estudiante
    {
        static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante(2004, "Sergio", "Aguirre", new List<string>() { "Programación", "Matematicas", "Ingles" });
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreFile = "estudiante.txt";
            string pathCompleto = $@"{path}\{nombreFile}";

            string lectura;

            using(StreamWriter writer = new StreamWriter(pathCompleto)) //Si el append (dentro de las propiedades del StreamWriter) esta en TRUE permite seguir escribiendo (seguido) dentro del mismo archivo.
            {
                writer.WriteLine(e1);
            }

            using(StreamReader reader = new StreamReader(pathCompleto))
            {
                lectura = reader.ReadToEnd();
            }

            Console.WriteLine(lectura);
        }
    }
}
