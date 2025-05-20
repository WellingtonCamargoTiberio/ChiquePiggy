using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditoHtml.Editorvc;

public class Visualizador
{
    public static void Show(string text)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("MODO VISUALIZACAO");
        Console.WriteLine("-----------------");
        Console.WriteLine(text);
        Console.WriteLine("-----------------");
        Console.ReadKey();
        Menu.Show();
    }

    public static void Replace(string text)
    {
           
    }
}
