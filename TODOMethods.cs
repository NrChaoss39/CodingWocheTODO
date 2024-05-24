using System.IO;
using CodingWoche;

namespace ToDoMethods
{
    public class ToDoMethods
    {
        public static void ShowTODOs(string path)
        {

            if (!File.Exists(path))
            {
                Console.WriteLine(" ");
                Console.WriteLine("There are no TODOs yet!");
                return;
            }

            try
            {
                Console.WriteLine("Here are all TODOs:");
                string[] lines = File.ReadAllLines(path);
                if (lines.Length == 0)
                {
                    Console.WriteLine("There are no TODOs yet!");
                    return;
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {lines[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading TODOs: {ex.Message}");
            }
        }

        public static void ChangeTODO(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine(" ");
                Console.WriteLine("There are no TODOs yet!");
                return;
            }
            Console.WriteLine("Which TODO do you want to change?");
            ShowTODOs(path); 
            int lineIndex = ReadValidIndex();

            if (lineIndex == -1) return;

            List<string> lines = File.ReadAllLines(path).ToList();
            if (lineIndex > lines.Count)
            {
                Console.WriteLine("TODO does not exist!");
                return;
            }

            Console.WriteLine("Change TODO: " + lineIndex + ". " + lines[lineIndex - 1]);
            string newContent = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newContent))
            {
                Console.WriteLine("TODO cannot be empty!");
            }
            else
            {
                lines[lineIndex - 1] = newContent.Trim();
                File.WriteAllLines(path, lines);
                Console.WriteLine("Changed TODO: " + lineIndex + ". " + newContent);
            }
        }

        public static void AddTODO(string path)
        {
            Console.WriteLine("");
            Console.WriteLine("What do you want to add?");
            string content = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            List<string> lines = File.Exists(path) ? File.ReadAllLines(path).ToList() : new List<string>();

            if (lines.Any(line => line.Equals(content, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("TODO already exists!");
            }
            else
            {
                lines.Add(content);
                File.WriteAllLines(path, lines);
                Console.WriteLine("Added TODO: " + lines.Count + ". " + content);
            }
        }

        public static void RemoveTODO(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine(" ");
                Console.WriteLine("There are no TODOs yet!");
                return;
            }

            Console.WriteLine("Which TODO do you want to remove? (type 'all' for all)");
            ShowTODOs(path);

            string input = Console.ReadLine()?.Trim();

            if (input?.ToLower() == "all")
            {
                Console.WriteLine("Are you sure you want to delete all TODOs? (yes/no)");
                string delete = Console.ReadLine();
                if (delete?.ToLower() == "yes")
                {
                    File.Delete(path);
                    Console.WriteLine("All TODOs deleted");
                }
                else
                {
                    Console.WriteLine("No TODOs deleted");
                }
                return;
            }

            int lineIndex = ReadValidIndex();

            if (lineIndex == -1) return;

            List<string> lines = File.ReadAllLines(path).ToList();

            if (lineIndex > lines.Count)
            {
                Console.WriteLine("TODO does not exist!");
                return;
            }

            Console.WriteLine("Removed TODO: " + lineIndex + ". " + lines[lineIndex - 1]);
            lines.RemoveAt(lineIndex - 1);
            File.WriteAllLines(path, lines);
        }

        private static int ReadValidIndex()
        {
            int lineIndex = 0;
            try
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Index cannot be empty");
                    return -1;
                }
                lineIndex = Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("Invalid input!");
                return -1;
            }
            return lineIndex;
        }

        public static void TODO()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("░▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██▓▓▓▓██████████████████████████████████████████████████████████████▓▓▓▒▒░░░░░░░░░░░\r\n▒▒▒▒▒▒▒▒▒▒▒▒▒▓███▓▓▓▓█████████████████████████████████████████████████████████████████▓▓▓▓▒░░░░░░░░░\r\n░▒▒▒▒▒▒▒▒▒▒▓▓██▓▓▓▓▓▓████████████████████▓▒▒▒▒▒▒▒▒▒▓▓▓▓████████████████████████████████▓▓▓▓▒░░░░░░░░\r\n▒▒▒▒▒▒▒▒▒▒▓█████▓▓█▓▓▓██████████████████▓░░░░░░░░░░░░░░░░▒▒▒▓▓▓█████████████████████████▓▓█▓▒░░░░░░░\r\n▒▒▒▒▒▒▒▒▓▓███████▓▓███▓▓███████████████▓░░░▒░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓███████████████████▓▓█▓▓▒░░░░░░\r\n▒▒▒▒▒▒▒▓██████████▓████████████████████▒░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓██████████████▓▓██▓▓▒░░░░░\r\n▒▒▒▒▒▓▓██▓▓███████████████████████████▓░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓██████████████▓▒▒░░░░\r\n▒▒▒▒▓███▓▒████████████████████████████▒░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓██████████▓▒░░░░\r\n▒▒▓▓██▓▒▒▓███████████████████████████▓░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓██████▓▒▒░░░\r\n▒▓▓██▒▒▒▒███████████████████████████▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▓▓████▓▒░░░\r\n▓██▓▒░▒▒▒████████████████████████▓▒▒░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▓██▓▒░░░\r\n██▓░░░▒▒▓█████████████████████▓▓▒░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▓██▓░░░\r\n▓▒░░░░▒▒▓██▓▓▓▓████████████▓▓▒░░░░░░░░░░░░░░░▒▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▓░░░\r\n░░░░░░▒▒▓▓▒░░░░░▒█████████▒░░░░░░░░░░░░░░░░░░░░▒▓▓▓▒░░░░░░░░░░░░░░░▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓███▓░░░\r\n░░░░░░▒▒▒▒▒▒▒▒░░░▒███████▒░░░░░░░░░░░░░░░░░░░░░░▒▓▓▓█▓▒▒░░░░░░░░░░░▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒████▓░░░\r\n░░░░░░▒░▒▓▓▓▓▓▓▒░░▒▓█████░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓█▓▓▒░░░░░░░░▒▒░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒███▓░░░░\r\n░░░░░▒░░▒▓▓▓▓▓▒▒░░░░▒▓██▒░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒░░░░░▒▒▓▓██▓▓▒░░░░░▒▒░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒░░▒▒███░░░░░\r\n░░░░░▒░░░▒▒▒▒▒▒▒▒░░░▒███░░░░░░░░░░░░░░░░░░░░░░░▒▓▒▒▒▒▒░░░▒▓▓▓███▓▓▓▒▒▒░░░░▒▒░▒▒▒▒▒▒▒▒▒▒░░░░▒██▓░░░░░\r\n░░░░░░░░░▒▒▒▒▓▓▓▓▒░░▒██▓░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░▒▓▒▒▒▓▓▓▓▒▒▒▒▒░░░░░▒░░░▒▒▒▒▒▒▒▒▒░░░░░▒██▒░░░░░\r\n░░░░░▒░░░▒▒▓▓▓▓▓▓▓░░▒██▒░░░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░▒▒▒▒▒░░░░░░░░▒▓█▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒░▒█▒░░░░░░\r\n░░░░░▒░░▒▒▓▓▓▓▓▓▓▓▒░▒▓▒░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒░░░░▒░░░░░░░\r\n░░░░░░▒▒▒▒▓▓▓▓▓▓▓▓▒░▒▒▒░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░\r\n░░░░░░▒▒▒▒▓▓▓▓▓▓▓▒▒░░▒░░░░░░▒▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░▒░░▓▓▒▒▒▒▒▒▒░▒░░░░░░░░░░░░░░░\r\n░░░░░▒▒▓▒▒▓▓▓▓▓▓▒▒░░░░░░░░░░▒▓▓░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░▒▒░▒▓▒░░░░░░░░░░░▒░░░░░░░░░░░░\r\n░░░░░░▒▒▒▒▒▓▓▓▓▓▒▒░░░░░░░░░░░▒▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░▒▒▒▒▒▒▒▒▒▒▒░░░▒░░░░░░░░░░░░░\r\n░░░░░░▒▓▓▒░▒▒▒▓▓▓▓░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒░░░▒░▒░░░░░░░░░░░\r\n░░░░░░▒▒▒▒░░░░▒▒▓▓░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░▒▒▒▒▒▒▒▒▒░░▒▒▒▒░░░░░░░░░░░\r\n░░░░░░▒▒▒▒▒░░░░░░▒░░░░░░░░░░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░▒▒▒▒▒▒▒▒▒░░▒▓▒░░░░░░░░░░░░\r\n░░░░░░▒▒▒▒▒▓▒▒▒▒░▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒░░░░░▒▒▒▒▒▒▒▒░░▓▒░░░░░░░▒▒▒▒░░\r\n░░░░░░▒▒▒▒▒▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░▒░░░░▒▒▒▒▒▒░░░░▒▒▒▒▒░▒░░▒▒▒▒░░░\r\n░░░░░░▒▒▒▒▒▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░▒▒▒▒░░░░░▒▒▒▒▒▒▒▒▒▒▒▒░░░░░\r\n░░░░░░▒▒▒▒▒▓▓▓▓▓▓▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░▒▒▒░░░░▒▓▒▒▒▒▒▒▒▒▒▒▒░░░░░░\r\n░░░░░░▒▒▒░░▒▒▒▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒░\r\n░░░░░░▒▒░░░░░▒▒▓▓▓▒░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒\r\n░░░░░░▒░░░░░░░▒▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░▒░░▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░▒▒▒░▒▒░░░░\r\n░░░░░░░░░░░░░░░▒▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░░░░░░░░░░░░░░░░░░▒▒▒░░░░░░░░░░░░░░░░▒▒▒▒▒\r\n░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░▒░▒▒▒▒░░░░░░░░░░░░░░▒▒▒▒▒\r\n░░░░░░░░░░░░░░░▒▒▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒░░░░░░▒▒░░░░░░░░░░▒▒▓▓▓▒▒▒░░░▒▒░░░░░░▒▒▒▒▒▒\r\n░░░░░░░░░░░░░░░░▒▓▓▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▓▓▒▒░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒░░▒▒▒▒▒▒▒▒▒░▒▒▒▓▓▒\r\n▒░░░░░░░░░░░░░░░▒▓▒▓▓▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░░░░░░░░░░░░░▒▒▒▒▒░░░░░░░░▒▒▒▒▒▒▒▒░▒▒▒▒▒\r\n░░░░░░░░░░░░░░░░▒▓▒▒▓▓▓▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░░▒▒▒▒░░░░░▒▒▒░░░▒▒▒▒▒▒░\r\n░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▓▓▓▓▓▓▓▓▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒▒▒▒\r\n░░░░░░░░░░░░░░░░░▒░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒▒▒\r\n░░░░░░░░░░░░░░░░░▒░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒░░░░░░░░░░░░░░░░░░░░░░░░▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒▒▒▒▒▒▒▒▓▒\r\n░░░░░░░░░░░░░░░░░▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒░░░░░░░░░░░░░░░░░░▒▒▒▓▓▓▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▓▓▓▒▒▒▒▓▓▒▒▒▒▒\r\n░░░░░░░░░░░░░░░░░░▒░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒░░░░░░░░░▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒▒▒▓▓▓▒▒▒▓▓▓▓▓▒▒▒\r\n░░░░░░░░░░░░░░░░░░▒░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒▒░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒\r\n░░░░░░░░░░░░░░░░░░▒░░░░▒▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒░▒▒▒▒▒▒▒▒▒▒▒░░▒▓▓▓▓▓▓▒\r\n░░░░░░░░░░░░░░░░░░▒░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒░▒▒░░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▒\r\n░░░░░░░░░░░░░░░░░░▒░░░░░░▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▓▓▓▒▒▒▒▒▒▒░░░░░▒▒▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▒▒\r\n");
            Console.WriteLine("MY BESTO FRIENDO!!!");
            Thread.Sleep(4000);
            Console.ResetColor();
        }

        private static int LineCounter(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                int i = 0;
                while (r.ReadLine() != null) { i++; }
                return i;
            }
        }
    }
}