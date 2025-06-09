using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class ContaPoupanca : ContaBancaria
    {
        public void CalcularRendimento()
        {
            Console.WriteLine(Saldo + (Saldo *0.6));
        }
    }
}
