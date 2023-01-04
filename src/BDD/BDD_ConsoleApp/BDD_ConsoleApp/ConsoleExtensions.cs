using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_ConsoleApp;

public static class ConsoleExtensions
{
    public static void Label(string text)
    {
        Console.WriteLine();
        var len = text.Length + 4;
        Console.Write(" ");
        Print("-", len);
        Console.WriteLine();
        Console.Write ("|| ");
        Console.Write(text);
        Console.WriteLine(" ||");
        Console.Write(" ");
        Print("-", len);
        Console.WriteLine();

    }

    private static void Print(string text, int times = 1)
    {
        for (int x = 0; x < times;x++)
        {
            Console.Write(text);
        }
    }
}
