using FileManipulator.Classes;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    internal class Output_CSV
    {
        public Output_CSV()
        {
            DateTime StartTime = DateTime.Now;
            
            Gather_Files_Create_Models gather_Files_Create_Model = new();
            List<FileInformationModel> models = gather_Files_Create_Model.Files();
            CSV_Export Exporter = new CSV_Export(models);
            
            DateTime EndTime = DateTime.Now;
            TimeSpan TotalTime = EndTime.Subtract(StartTime);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nIt took \"{TotalTime}\" to run on {models.Count} files" +
                $"\nThe CSV was output to: {Exporter.Outputpath}" +
                $"\nPress Any Key to return to the main menu");
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}