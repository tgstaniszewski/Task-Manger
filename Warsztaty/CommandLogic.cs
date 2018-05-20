using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Warsztaty
{
    public static class CommandLogic
    {
        private static readonly List<TaskModel> _listTask = new List<TaskModel>();
        
        private static string _path = "data.csv";

        public static void AddTask(ConsoleColor textColor)
        {

            ConsoleEx.WriteLine(textColor, "PODAJ OPIS ZADANIA:");
            var description = Console.ReadLine();

            ConsoleEx.WriteLine(textColor, "CZY JEST TO ZADANIE CAŁODNIOWE? (t/n):");
            var isAllDay = Console.ReadLine();

            ConsoleEx.WriteLine(textColor, "PODAJ DATĘ ROZPOCZECIA [yyyy-MM-dd]:");

            var StartDay = IsCorrectDate(Console.ReadLine());

            DateTime? endTime = null;
            if (isAllDay.ToLower() == "n")
            {
                ConsoleEx.WriteLine(textColor, "PODAJ DATĘ ZAKOŃCZENIA:");
                endTime = IsCorrectDate(Console.ReadLine());
            }


            ConsoleEx.WriteLine(ConsoleColor.Green, "CZY JEST TO WAŻNE ZADANIE? (t/n)");
            var yesNo = Console.ReadLine();
            bool isImportant = yesNo.ToLower() == "t";

            var taskModel = new TaskModel(description, StartDay, endTime, isImportant);

            _listTask.Add(taskModel);

            ConsoleEx.WriteLine(ConsoleColor.Green, $"DODANO ZADANIE ");
            ConsoleEx.WriteLine(textColor, "NACIŚNIJ DOWOLNY PRZYCISK");
            Console.ReadKey();
            Console.Clear();


        }


        public static void RemoveTask(ConsoleColor textColor)
        {

            ShowTask(textColor);

            ConsoleEx.WriteLine(textColor, "Podaj numer zadania do usuniecia?");
            int index = int.Parse(Console.ReadLine());
            _listTask.RemoveAt(index - 1);
            ConsoleEx.WriteLine(textColor, "usunieto zadanie!!!!");
            ConsoleEx.WriteLine(textColor, "NACIŚNIJ DOWOLNY PRZYCISK");
            Console.ReadKey();
            Console.Clear();
        }

        public static DateTime IsCorrectDate(string dateText)
        {

            bool correctDay;
            DateTime Day = DateTime.MinValue;
            do
            {


                correctDay = DateTime.TryParse(dateText, out DateTime date);
                if (!correctDay)
                {
                    Console.WriteLine("błedna data, podaj ponownie date [yyyy-MM-dd]:");
                    dateText = Console.ReadLine();
                }

                Day = date;

            } while (!correctDay);

            return Day;
        }

        public static void ShowTask(ConsoleColor textColor)
        {
            int i = 1;
            ConsoleEx.WriteLine(textColor, "\n\r------------------------------ LISTA ZADAŃ --------------------------------");
            ConsoleEx.WriteLine(textColor, "| {0} | {1} | {2} | {3} | {4} |",
                "#".PadRight(2),
                "Nazwa".PadLeft(30),
                "Data od".PadLeft(10),
                "Data do".PadLeft(10),
                "Ważne");
            ConsoleEx.WriteLine(textColor, "---------------------------------------------------------------------------");

            _listTask.Sort((x, y) => x.StartDate.CompareTo(y.StartDate));
            if (_listTask.Count == 0)
            {
                ConsoleEx.WriteLine(ConsoleColor.Red, "-----------------------BRAK ZADAŃ DO WYŚWIETLENIA!!!!----------------------");
            }
            else
            {
                foreach (var task in _listTask)
                {
                    var desc = task.Description;
                    var taskColor = textColor;

                    if (desc.Length > 29)
                    {
                        desc = $"{desc.Substring(0, 26)}...";
                    }

                    if (task.IsImportant == true)
                    {
                        taskColor = ConsoleColor.Red;
                    }
                    ConsoleEx.WriteLine(taskColor, "| {0} | {1} | {2} | {3} | {4} |",
                        i.ToString().PadRight(2),
                        desc.PadLeft(30),
                        task.StartDate.ToString("yyyy-MM-dd").PadLeft(10),
                        task.EndTime.HasValue ? task.EndTime.Value.ToString("yyyy-MM-dd").PadLeft(10) : "całodniowe".PadLeft(10),
                        task.IsImportant ? "!".PadLeft(5) : "".PadLeft(5));

                    i++;
                }
            }

            ConsoleEx.WriteLine(textColor, "---------------------------------------------------------------------------\n\r");
        }

        public static void SaveTasksToFile(ConsoleColor textColor)
        {

            List<string> listTaskLine = new List<string>();

            if (_listTask.Count == 0)
            {
                ConsoleEx.WriteLine(textColor, "BRAK ZADAŃ DO ZAPISANIA");
            }
            else
            {
                foreach (var task in _listTask)
                {
                    var lineTask =
                        $"{task.Description}," +
                        $"{task.StartDate:yyyy-MM-dd}," +
                        $"{task.EndTime:yyyy-MM-dd}," +
                        $"{task.IsAllDayTask}," +
                        $"{task.IsImportant}";

                    listTaskLine.Add(lineTask);

                }

                File.WriteAllLines(_path, listTaskLine);
                textColor = ConsoleColor.Green;
                ConsoleEx.WriteLine(textColor, $"ZAPISANO DO PLIKU ");
                ConsoleEx.WriteLine(textColor, "NACIŚNIJ DOWOLNY PRZYCISK");
                Console.ReadKey();
                Console.Clear();

            }

        }

        public static void LoadTasks(ConsoleColor textColor)
        {
            if (!File.Exists(_path))
            {
                ConsoleEx.WriteLine(ConsoleColor.DarkRed, "Brak pliku");
            }
            else
            {
                var dateTask = File.ReadAllLines(_path);

                if (_listTask.Count > 0)
                {
                    ConsoleEx.WriteLine(textColor, "OBECNA LISTA ZADAŃ ZOSTANIE NADPISANA");
                    ConsoleEx.WriteLine(textColor, "CZY NAPEWNO CHCESZ WCZYTAĆ ZADANIA Z PLIKU? (t/n)");
                    var yesNo = Console.ReadLine();
                    if (yesNo == "t")
                    {
                        LoadTask(textColor, dateTask);

                    }
                    else
                    {
                        ConsoleEx.WriteLine(ConsoleColor.Green, "PRZERWANO WCZYTYWANIE Z PLIKU");
                    }
                }
                else if (_listTask.Count == 0)
                {
                    LoadTask(textColor, dateTask);
                }


                ConsoleEx.WriteLine(textColor, "NACIŚNIJ DOWOLNY KLAWISZ");
                Console.ReadKey();
                Console.Clear();

            }
        }

        public static void LoadTask(ConsoleColor textColor, string[] dateTask)
        {
            var counterTask = 0;

            _listTask.Clear();
            foreach (var line in dateTask)
            {
                var lineElements = line.Split(',');
                if (lineElements.Length != 5)
                {
                    ConsoleEx.WriteLine(ConsoleColor.DarkRed, "Bład!! : za mało danych w rekordzie , POMIJAM CAŁY REKORD");
                }
                else
                {
                    var desc = lineElements[0];

                    var fromDate = DateTime.TryParse(lineElements[1], out var from);
                    if (!fromDate)
                    {
                        ConsoleEx.WriteLine(ConsoleColor.DarkRed, "Bład! rekordu data rozpoczęcia, POMIJAM REKORD");
                        continue;
                    }

                    DateTime? to = null;
                    if (lineElements[2] != string.Empty)
                    {

                        var toDate = DateTime.TryParse(lineElements[2], out var toDateParse);

                        if (!toDate)
                        {
                            ConsoleEx.WriteLine(ConsoleColor.DarkRed, "Bład! nie wczytano rekordu data zakończenia");
                            continue;
                        }

                        to = toDateParse;

                    }

                    var important = Boolean.TryParse(lineElements[3], out var isImportant);

                    if (!important)
                    {
                        ConsoleEx.WriteLine(ConsoleColor.DarkRed, "Bład! nie wczytano rekordu czy ważny");
                    }

                    var task = new TaskModel(desc, from, to, isImportant);

                    _listTask.Add(task);
                    counterTask++;
                }

            }

            ConsoleEx.WriteLine(ConsoleColor.Green, $"Wczytano {counterTask} zadań");

        }

    }
}
