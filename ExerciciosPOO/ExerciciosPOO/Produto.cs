using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class Produto
    {
        private double preco;

        public double Preco
        {
            get { return preco; }
            set
            {
                if (value >= 0)
                    preco = value;
                else
                {
                    Console.WriteLine("Produto não pode ter preço negativo");
                }
            }
        }
    }
}
