using FileManipulator.Classes;
using System.Text.Json;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    public class Output_Screen
    {
        public Output_Screen()
        {
            Gather_Files_Create_Models gather_Files_Create_Model = new();
            List<FileInformationModel> models = gather_Files_Create_Model.Files();

            foreach (var item in models)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(item, options);
                Console.WriteLine(jsonString);
            }
            Console.ResetColor();
            Console.WriteLine("Press Any Key to return to the main menu");
            Console.ReadKey();
        }

    }
}
