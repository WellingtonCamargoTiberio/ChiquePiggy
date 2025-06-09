using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class Carro
    {
        public string Modelo;
        public string Marca;
        public int Ano;



        public void Ligar( string? marca, string? modelo, int? ano)
        {
            Console.WriteLine("O carro do modelo " + modelo + " esta ligado");
        }
    }
}
