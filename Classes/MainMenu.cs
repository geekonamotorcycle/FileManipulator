using FileManipulator.MethodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator.Classes
{
    public class MainMenu
    {
        public MainMenu()
        {
            bool showmenu = true;
            Get_Settings settings = new();
            CheckExists checker = new();
            do
            {
                //Header
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"**************************\n" +
                    $"Media Organizer\n" +
                    $"**************************\n");
                //Status Check
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"The JSON source path is \"{settings.SourcePath}\"\n" +
                    $"Source path exists: {checker.CheckDirectory(settings.SourcePath)}\n");
                Console.WriteLine($"The JSON destination base is: \"{settings.DestinationBase}\"\n" +
                    $"Destination Path exists: {checker.CheckDirectory(settings.DestinationBase)}\n");
                Console.WriteLine($"The JSON date source is: \"{settings.DateSource}\"\n");
                Console.WriteLine($"The SQLite connection string: \"{settings.ConnectionString}\"");
                Console.WriteLine($"The SQLite provider name \"{settings.ProviderName}\"\n");
                //Available Selections
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    $"Enter one of the following options and press enter\n" +
                    $"\"1\" to read the ingest path and output file information to the screen In JSON Format\n" +
                    $"\"2\" to read the ingest path and output a CSV with file information\n" +
                    $"\"3\" to injest failes and output to the DB\n" +
                    $"\"4\" to read the DB and output its contents in JSON Format to the console\n" +
                    $"\"Exit\" to exit this menu application");
                //switch logic
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        Console.ResetColor();
                        Output_Screen _ = new();
                        break;
                    case "2":
                        Console.ResetColor();
                        Output_CSV output_CSV = new();
                        break;
                    case "3":
                        Console.ResetColor();
                        Write_SQLite SQLtesting = new();
                        SQLtesting.TestSQLiteConnection();
                        break;
                    case "4":
                        Console.ResetColor();
                        Output_DBContentsToScreen DBScreenOutput = new();
                        break;
                    case "exit":
                        showmenu = false;
                        break;
                    default:
                        Console.ResetColor();
                        Console.WriteLine($"Your entry was not valid");
                        Console.Write("Press any key to try again");
                        Console.ReadKey();
                        break;
                }
            } while (showmenu);
        }
    }
}
