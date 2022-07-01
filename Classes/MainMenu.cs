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
            Settings settings = new();
            CheckExists checker = new();
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"*********************\n" +
                    $"This is the Main Menu\n" +
                    $"*********************\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"The JSON Source Path is \"{settings.SourcePath}\"\n" +
                    $"Source Path exists: {checker.CheckDirectory(settings.SourcePath)}\n");
                    Console.WriteLine("\n" +
                    $"The JSON Destination Base is: \"{settings.DestinationBase}\"\n" +
                    $"Destination Path exists: {checker.CheckDirectory(settings.DestinationBase)}\n");
                    Console.WriteLine($"\n" +
                    $"The JSON Date Source is: \"{settings.DateSource}\"\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    $"Type in \"Test\" to run the test object\n" +
                    $"Type in \"Exit\" to exit this menu");

                switch (Console.ReadLine()
                               .ToLower())
                {
                    case "test":
                        Testing _ = new();
                        break;
                    case "exit":
                        showmenu = false;
                        break;
                    default:
                        Console.WriteLine($"You Failed");
                        Console.Write("Press any key to try again");
                        Console.ReadKey();
                        break;
                }
                // Wait for the user to respond before closing.

            } while (showmenu);
        }
    }
}
