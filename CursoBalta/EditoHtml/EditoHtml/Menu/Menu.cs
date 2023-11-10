using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoHtml
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Tela();
            Opcoes();
            short opcao = short.Parse(Console.ReadLine());
            ManipulandoMenu(opcao);
        }

        public static void Tela()
        {
            CabecalhoRodape();
            BarrasLaterais();
            CabecalhoRodape();
        }
        public static void CabecalhoRodape()
        {
            Console.Write("+");

            for (int i = 0; i < 30; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write("\n");
        }
        public static void BarrasLaterais()
        {
            for (int linhas = 0; linhas < 10; linhas++)
            {
                Console.Write("|");
                for (int i = 0; i < 30; i++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write("\n");
            }
        }
        public static void Opcoes()
        {
            Console.SetCursorPosition(3, 2);
            Console.Write("Editor HTML");
            Console.SetCursorPosition(3, 4);
            Console.Write("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.Write("1 - Novo Arquivo");
            Console.SetCursorPosition(3, 7);
            Console.Write("2 - Abrir Arquivo");
            Console.SetCursorPosition(3, 8);
            Console.Write("0 - Para Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Selecione a Opção: ");
        }

        public static void ManipulandoMenu(short opcao)
        {
            switch (opcao)
            {
                case 1: Editor.Inicio(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }
                default: Show(); break;
            }
        }
    }
}
