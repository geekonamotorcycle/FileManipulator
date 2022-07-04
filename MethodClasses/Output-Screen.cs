using FileManipulator.Classes;
using System.Text.Json;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    public class Output_Screen
    {
        public Output_Screen()
        {
            /*DateTime StartTime = DateTime.Now;
            Get_Settings fileinfosettings = new();
            string destpath = fileinfosettings.DestinationBase;
            Get_SourcePaths filegatherer = new(fileinfosettings.SourcePath);
            CheckExists checker = new();
            bool BaseDestExists = checker.CheckDirectory(destpath);
            List<FileInformationModel> files = new();
            Console.ResetColor();
            */
            Gather_Files_Create_Models files2 = new();
            List<FileInformationModel> files3 = files2.Files();

            foreach (var item in files3)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(item, options);
                Console.WriteLine(jsonString);
            }


/*            foreach (var path in filegatherer.Geteresults())
            {
                bool SourceFileExists = CheckExists.CheckFile(path);
                if (SourceFileExists && BaseDestExists)
                {
                    FileInformationModel FileInfoObject = new(path, destpath);
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(FileInfoObject, options);
                    Console.WriteLine(jsonString);
                    files.Add(FileInfoObject);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("One of the paths failed to check");
                    Console.ResetColor();
                }

            }

            */
            Console.ResetColor();
            Console.WriteLine("Press Any Key to return to the main menu");
            Console.ReadKey();

        }
        /*Console.ForegroundColor = ConsoleColor.Yellow;
        DateTime EndTime = DateTime.Now;
        TimeSpan TotalTime = EndTime.Subtract(StartTime);
        Console.WriteLine($"\n\nThat took \"{TotalTime}\" to run. on {files.Count} files");
        Console.WriteLine("Press Any Key to return to the main menu");
        Console.ReadKey();*/
    }
}
