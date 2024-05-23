using System.IO;
using CodingWoche;

namespace ToDoMethods
{
	public class ToDoMethods
	{
        public static void ShowTODOs(string path)
		{
            Console.WriteLine();
            Console.WriteLine("Here are all TODOs:");

            try 
			{
				using (StreamReader reader = new StreamReader(path))
				{
					int index = 1;
					string line;

					while ((line = reader.ReadLine()) != null)
					{
                        Console.WriteLine(index + ". " + line);
                        index++;
                    }
				} 
			}
			catch 
			{
				Console.WriteLine("There are no TODOs yet!");
			}
        }

        public static void ChangeTODO(string path)
		{
            Console.WriteLine();
            Console.WriteLine("Which TODO do you want to change?");

            if (File.Exists(path))
			{
                ToDoMethods.ShowTODOs(path);
                int line = 0;
                try
                {
                    string lineStr = Console.ReadLine();
                    if (lineStr == null || lineStr == "")
                    {
                        Console.WriteLine("Index cannot be empty");
                    }
                    else
                    {
                        line = Convert.ToInt32(lineStr);
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                }

                List<string> lines = File.ReadAllLines(path).ToList();

                if (line != 0 && lines.Count >= line)
                {
                    Console.WriteLine("Change TODO: " + line + ". " + lines[line - 1]);
					string newContent = Console.ReadLine();
					if (String.IsNullOrEmpty(newContent.Trim()))
					{
						Console.WriteLine("TODO cannot be empty!");
					}
					else
					{
						
						lines[line - 1] = newContent;
						File.WriteAllLines(path, lines);
                        Console.WriteLine("Changed TODO: " + line + ". " + newContent);
                    }

                }
                else if (lines.Count < line)
                {
                    Console.WriteLine("TODO does not exist!");
                }
            }
            else
            {
                Console.WriteLine("There are no TODOs yet!");
            }
        }

        public static void AddTODO(string path)
        {
            Console.WriteLine();
            Console.WriteLine("What do you want to add?");

            string content = Console.ReadLine();
            bool isNotUnique = false;

            int counter = 1;

            if (File.Exists(path)) {
				counter = LineCounter(path) + 1;

				using (StreamReader reader = new StreamReader(path))
				{
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						if (line.Equals(content, StringComparison.OrdinalIgnoreCase))
						{
							isNotUnique = true;
						}
                    }
				}
            }

			if (String.IsNullOrEmpty(content.Trim()))
			{
                Console.WriteLine("Invalid input!");
			}
			else if (isNotUnique)
			{	
				Console.WriteLine("TODO already exists!");
            }
			else
			{
                File.AppendAllText(path, content + "\n");
				Console.WriteLine("Added TODO: " + counter + ". " + content);
            }
		}

		public static void RemoveTODO(string path)
		{
            if (File.Exists(path))
			{
                Console.WriteLine("Which TODO do you want to remove? (type 'all' for all)");
                ToDoMethods.ShowTODOs(path);
                int line = 0;
				try
				{	
					string lineStr = Console.ReadLine();
					if (lineStr == null || lineStr == "")
					{
						Console.WriteLine("Index cannot be empty");
					}
					else
					{
                        if (lineStr.ToLower() == "all")
                        {
                            Console.WriteLine("Are you sure you want to delete all TODOs? (yes/no)");
                            string delete = Console.ReadLine();
                            if (delete == "yes")
                            {
                                Console.WriteLine("All TODOs deleted");
                                File.Delete(path);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("No TODOs deleted");
                            }
                        }
                        line = Convert.ToInt32(lineStr);
					}
				}
				catch
				{
					Console.WriteLine("Invalid input!");
				}
				List<string> lines = File.ReadAllLines(path).ToList();

				if (line != 0 && lines.Count >= line)
				{
					Console.WriteLine("Removed TODO: " + line + ". " + lines[line - 1]);
					lines.RemoveAt(line - 1);
					File.WriteAllLines(path, lines);

				}
				else if (lines.Count < line)
				{
                    Console.WriteLine("TODO does not exist!");
				}
			}
			else
			{
				Console.WriteLine("There are no TODOs yet!");
			}
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