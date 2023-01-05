using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_ConsoleApp;

public static class ConsoleExt
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

    public static void Line(int length = 20)
    {
        Print ("-", length);
        Console.WriteLine();
        Console.WriteLine();
    }

    private static void Print(string text, int times = 1)
    {
        for (int x = 0; x < times;x++)
        {
            Console.Write(text);
        }
    }

    public static void Write(this ConsoleColor color, string text)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = currentColor;
    }
    public static void WriteLine(this ConsoleColor color, string text)
    {
        color.Write(text);
        Console.WriteLine ();
    }
}
