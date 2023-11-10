using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("Qual a operação que deseja fazer?");
            Console.WriteLine("Digite 1 para soma");
            Console.WriteLine("Digite 2 para subtração");
            Console.WriteLine("Digite 3 para multplicação");
            Console.WriteLine("Digite 4 para divisão");
            Console.WriteLine("Digite 0 para sair");

            short menu = short.Parse(Console.ReadLine());

            //if (menu == 1)
            //    Soma();
            //if (menu == 2)
            //    Subtracao();
            //if (menu == 3)
            //    Multiplicacao();
            //if (menu == 4)
            //    Divisao();
            //else
            //    Environment.Exit(0);

            switch (menu)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Subtracao(); break;
                case 4: Divisao(); break;
                case 0: Environment.Exit(0); break;
                default: Menu(); break;
            }


        }
        static void Soma()
        {
            Console.Clear();
            Console.WriteLine("Digite o primeiro valor");
            double valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo valor");
            double valor2 = double.Parse(Console.ReadLine());

            double resultado = valor1 + valor2;

            //Console.WriteLine("A soma é = " + resultado);
            Console.WriteLine($"A soma é = {resultado}");
            //Console.WriteLine("A soma é = " + (valor1 + valor2));
            //Console.WriteLine($"A soma é = {valor1 + valor2}");
            Console.ReadKey();
            Menu();
        }
        static void Subtracao()
        {
            Console.Clear();
            Console.WriteLine("Digite o primeiro valor");
            double valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo valor");
            double valor2 = double.Parse(Console.ReadLine());

            double resultado = valor1 - valor2;

            //Console.WriteLine("A subtração é = " + resultado);
            Console.WriteLine($"A subtração é = {resultado}");
            //Console.WriteLine("A subtração é = " + (valor1 - valor2));
            //Console.WriteLine($"A subtração é = {valor1 - valor2}");
            Console.ReadKey();
            Menu();
        }
        static void Multiplicacao()
        {
            Console.Clear();
            Console.WriteLine("Digite o primeiro valor");
            double valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo valor");
            double valor2 = double.Parse(Console.ReadLine());

            double resultado = valor1 * valor2;

            //Console.WriteLine("A multiplicação é = " + resultado);
            Console.WriteLine($"A multiplicação é = {resultado}");
            //Console.WriteLine("A multiplicação é = " + (valor1 * valor2));
            //Console.WriteLine($"A multiplicação é = {valor1 * valor2}");
            Console.ReadKey();
            Menu();
        }
        static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("Digite o primeiro valor");
            double valor1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo valor");
            double valor2 = double.Parse(Console.ReadLine());

            double resultado = valor1 / valor2;

            //Console.WriteLine("A divisão é = " + resultado);
            Console.WriteLine($"A divisão é = {resultado}");
            //Console.WriteLine("A divisão é = " + (valor1 / valor2));
            //Console.WriteLine($"A divisão é = {valor1 / valor2}");
            Console.ReadKey();
            Menu();
        }
    }

}

