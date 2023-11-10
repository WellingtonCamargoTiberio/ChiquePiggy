using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoHtml
{
    public static class Editor
    {
        public static void Inicio()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("Editor Html");
            Console.WriteLine("-----------------------");
            Editar();
        }
        public static void Editar()
        {
            var texto = new StringBuilder();

            do
            {
                texto.AppendLine(Console.ReadLine());
                texto.AppendLine(Environment.NewLine);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("---------------------------");
            Console.WriteLine(" Deseja Salvar o Arquivo?");
            Console.WriteLine("Digite S - Sim ou N - Não");
            var opcao = Console.ReadLine().ToUpper();

            if (opcao == "S")
            {
                Salvar(texto.ToString());
            }
            else
            {
                Menu.Show();
            }
                
        }
        public static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar o arquivo?");
            var caminhoPasta = Console.ReadLine();

            using (var arquivo = new StreamWriter(caminhoPasta))
            {
                arquivo.Write(texto);
            }

            Console.WriteLine($"Arquivo {caminhoPasta} foi salvo com sucesso");
            Console.ReadLine();
            Menu.Show();
        }
    }
}
