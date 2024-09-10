using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_de_Clases
{
    public class Auto
    {
        

        public double Peso { get; set; }
        public String Color { get ; set; }
        public string Marca { get; set ; }

        public Auto()
        {
                
        }

        public Auto(double peso, String color, string marca)
        {
            Peso = peso;
            Color = color;
            Marca = marca;
        }

        public override string ToString()
        {
            return $"Vehiculo de marca: {Marca} - color: {Color} - peso: {Peso}";
        }
    }
}
