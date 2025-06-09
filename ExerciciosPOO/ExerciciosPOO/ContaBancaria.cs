using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class ContaBancaria
    {
        public string Titular;
        protected double Saldo = 50;

        public void Depositar(double saldo)
        {
            Saldo += saldo;
        }
        public void ExibirSaldo()
        {
            Console.WriteLine(Saldo);
        }
    }
}
