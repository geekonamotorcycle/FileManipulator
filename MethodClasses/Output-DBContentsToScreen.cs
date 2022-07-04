using FileManipulator.MethodClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class Output_DBContentsToScreen
    {
        public List<PublicFileInformationModel> SQLDump { get; private set; }
        public Output_DBContentsToScreen()
        {
            List<PublicFileInformationModel> SQLDump = new List<PublicFileInformationModel>();
            Write_SQLite write_SQLite = new Write_SQLite();
            SQLDump = write_SQLite.GetDBContents();
            foreach (var item in SQLDump)
            {
                try
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string jsonString = JsonSerializer.Serialize(item, options);
                    Console.WriteLine(jsonString);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.ToString}");
                    throw;
                }
            }
            Console.WriteLine($"Press any Key to continue");
            Console.ReadKey();
        }
    }
}
