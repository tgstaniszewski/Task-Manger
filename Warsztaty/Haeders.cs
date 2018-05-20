using System;
using System.Collections.Generic;
using System.Text;

namespace Warsztaty
{
    public static class Haeders
    {
       
        public static void MainHeder()
        {
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "---------------------------------------------------------------------------");
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "---------------------------- MENADŻER ZADAŃ -------------------------------");
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "---------------------------------------------------------------------------");
            CommandLogic.ShowTask(ConsoleColor.Green);
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "--------------------  1-DODAJ ZADANIE -------------------------------------\n\r" +
                                                     "--------------------  2-USUŃ ZADANIE  -------------------------------------\n\r" +
                                                     "--------------------  3-WYŚWIELT AKTUALNE ZADANIA -------------------------\n\r" +
                                                     "--------------------  4-ZAPISZ DO PLIKU -----------------------------------\n\r" +
                                                     "--------------------  5-WCZYTAJ Z PLIKU------------------------------------\n\r" +
                                                     "--------------------  6-EXIT-----------------------------------------------\n\r");
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "---------------------------------------------------------------------------");
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "WPISZ NUMER KOMENDY:");
            ConsoleEx.WriteLine(ConsoleColor.Yellow, "---------------------------------------------------------------------------");
        }

        public static void AddHeader()
        {
            Console.Clear();
            ConsoleEx.WriteLine(ConsoleColor.Green, "---------------------------- DODAWANIE ZADANIA ------------------------------");
        }

        public static void RemoveTaskHeader()
        {
            Console.Clear();
            ConsoleEx.WriteLine(ConsoleColor.Green, "---------------------------- USUWANIE ZADANIA -------------------------------");
        }

        public static void SaveTasksToFileHeader()
        {
            Console.Clear();
            ConsoleEx.WriteLine(ConsoleColor.Green, "----------------------- ZAPISYWANIE ZADAŃ DO PLIKU --------------------------");
        }

        public static void LoadTasksHeader()
        {
            Console.Clear();
            ConsoleEx.WriteLine(ConsoleColor.Green, "------------------------- WCZYTANIE ZADAŃ Z PLIKU ---------------------------");
        }

        public static void ShowTaskHeader()
        {
            Console.Clear();
            ConsoleEx.WriteLine(ConsoleColor.Green, "---------------------------- AKTUALNE ZADANIA -------------------------------");
        }




    }
}
