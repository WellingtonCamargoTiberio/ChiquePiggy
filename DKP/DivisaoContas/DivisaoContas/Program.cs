using System.Security.Cryptography.X509Certificates;

namespace DivisaoContas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contas contas = new Contas();

            decimal v = contas.DivisaoCompras(1000.00M, 3);

            Console.WriteLine(v);
            
        }
    }
}