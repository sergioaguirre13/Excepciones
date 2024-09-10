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

            Auto v1 = new Auto(3500, "azul", "fiat");
            Auto v2;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreFileTxt = "estudiante.txt";
            string nombreFileJson = "estudiante.json";
            string nombreFileXml = "estudiante.xml";
            string fileAutoJson = "auto.json";
            string fileAutoXml = "auto.xml";
            string fileAutoTxxt = "auto.txt";

            string lectura;
            string lectura2;

            MiClaseSerializadoraGenerica<Auto>.Escribir(path, fileAutoTxxt, v1.ToString());
            lectura2 = MiClaseSerializadoraGenerica<Auto>.LeerTxt(path,fileAutoTxxt);
            Console.WriteLine(lectura2);

            MiClaseSerializadoraGenerica<Auto>.Escribir(path, fileAutoXml, v1);
            v2 = MiClaseSerializadoraGenerica<Auto>.Leer(path, fileAutoXml);
            Console.WriteLine(v2);

            MiClaseSerializadoraGenerica<Auto>.Escribir(path, fileAutoJson, v1);
            v2 = MiClaseSerializadoraGenerica<Auto>.Leer(path, fileAutoJson);
            Console.WriteLine(v2);

            //e1.EscribirTxt(pathCompletoT);

            MiClaseSerializadoraGenerica<Estudiante>.Escribir(path, nombreFileTxt, e1.ToString());
            lectura = MiClaseSerializadoraGenerica<Estudiante>.LeerTxt(path,nombreFileTxt);
            Console.WriteLine(lectura);

            //e1.EscribirJson(pathCompletoJ);
            MiClaseSerializadoraGenerica<Estudiante>.Escribir(path, nombreFileJson, e1);
            e2 = MiClaseSerializadoraGenerica<Estudiante>.Leer(path, nombreFileJson);
            Console.WriteLine(e2);

            //e1.EscribirXml(pathCompletoX);
            MiClaseSerializadoraGenerica<Estudiante>.Escribir(path, nombreFileXml, e1);
            e2 = MiClaseSerializadoraGenerica<Estudiante>.Leer(path, nombreFileXml);
            Console.WriteLine(e2);



        }
    }
}
