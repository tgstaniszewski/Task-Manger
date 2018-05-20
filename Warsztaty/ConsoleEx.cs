using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty
{
    public static class ConsoleEx
    {
        public static void Write(ConsoleColor color, string text, params object[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text, args);
            Console.ForegroundColor = currentColor;
        }

        public static void WriteLine(ConsoleColor color, string text, params object[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text, args);
            Console.ForegroundColor = currentColor;
        }
    }
}
