using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciciosPOO
{
    public class Funcionario
    {
        public string Nome {  get; set; }
        public int Idade { get; set; }
        public double Salario { get; set; }

        public void funcionario()
        {
            Console.WriteLine(Nome + " " + Idade + " " + Salario);
        }
    }
}
