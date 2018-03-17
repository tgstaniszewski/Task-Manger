using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty
{
    public static class ConsoleEx
    {
        public static void Write(string text, ConsoleColor color, params object[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.ForegroundColor = currentColor;
        }

        public static void WriteLine(string text, ConsoleColor color, params object[] args)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.ForegroundColor = currentColor;
        }
    }
}
