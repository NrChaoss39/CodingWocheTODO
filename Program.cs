namespace CodingWoche;

using System.Xml.Schema;
using ToDoMethods;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(
            " #####     ####     ###    ######   #######           ########  #####   #####     #####   \r\n" +
            "##   ##   ##  ##   ## ##    ##  ##   ##   #           ## ## ## ### ###   ## ##   ### ###  \r\n" +
            "##       ##       ##   ##   ##  ##   ##                  ##    ##   ##   ##  ##  ##   ##  \r\n" +
            " #####   ##       ##   ##   #####    ####                ##    ##   ##   ##  ##  ##   ##  \r\n" +
            "     ##  ##       #######   ## ##    ##                  ##    ##   ##   ##  ##  ##   ##  \r\n" +
            "##   ##   ##  ##  ##   ##   ## ##    ##   #              ##    ### ###   ## ##   ### ###  \r\n" +
            " #####     ####   ##   ##  #### ##  #######             ####    #####   #####     #####   \r\n");

        string path = "C:\\Users\\M02419\\OneDrive - Nürnberger Baugruppe GmbH + Co KG\\Dokumente\\CodingWoche\\TODOList.txt";
        int i = 0;
        string toDoOptions = "Hello!\n" +
                "What do you want to do?\n" +
                "[S]ee all TODOs\n" +
                "[C]hange a TODO\n" +
                "[A]dd a TODO\n" +
                "[R]emove a TODO\n" +
                "[E]xit";
        while (i == 0)
        {
            Console.WriteLine();
            Console.WriteLine(toDoOptions);
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            char upperInput = char.ToUpper(input);
            switch (upperInput)
            {
                case 'S':
                    ToDoMethods.ShowTODOs(path);
                    break;
                case 'C':
                    ToDoMethods.ChangeTODO(path);
                    break;
                case 'A':
                    ToDoMethods.AddTODO(path);
                    break;
                case 'R':
                    ToDoMethods.RemoveTODO(path);
                    break;
                case 'E':
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    i = 1;
                    break;
                case 'T':
                    ToDoMethods.TODO();
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
