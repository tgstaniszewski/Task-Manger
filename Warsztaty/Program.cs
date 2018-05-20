using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Warsztaty
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = "";
            do
            {
                Haeders.MainHeder();

                command = Console.ReadLine();

                if (command == "1")
                {
                    Haeders.AddHeader();
                    CommandLogic.AddTask(ConsoleColor.Green);
                }
                else if (command == "2")
                {
                    Haeders.RemoveTaskHeader();
                    CommandLogic.RemoveTask(ConsoleColor.DarkRed);
                }
                else if (command == "3")
                {
                    Haeders.ShowTaskHeader();
                    CommandLogic.ShowTask(ConsoleColor.Green);
                    ConsoleEx.WriteLine(ConsoleColor.Green, "NACISNIJ DOWOLNY KLAWISZ...");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (command == "4")
                {
                    Haeders.SaveTasksToFileHeader();
                    CommandLogic.SaveTasksToFile(ConsoleColor.DarkGreen);
                }
                else if (command == "5")
                {
                    Haeders.LoadTasksHeader();
                    CommandLogic.LoadTasks(ConsoleColor.DarkCyan);
                }
                else if (command == "6")
                {
                    ConsoleEx.WriteLine(ConsoleColor.Red, "ZAMKNIĘCIE PROGRAMU - NACIŚNIJ DOWOLNY KLAWISZ....");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    ConsoleEx.WriteLine(ConsoleColor.Red, "NIEWŁASCIWA KOMENDA... NACISNIJ DOWOLNY KLAWISZ A NASTEPNIE..." +
                                                          "PODAJ NUMER KOMENDY Z ZAKRESU 1-6...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (command != "6");
        }
    }
}
