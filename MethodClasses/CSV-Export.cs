using CsvHelper;
using System.Globalization;

namespace FileManipulator
{
    internal class CSV_Export
    {
        readonly Get_Settings OutputPath = new();//Creates an instance of the Settings Object with the property we need to get the destination for the CSV file
        public string Outputpath { get; private set; }  //Createing the variable which can be read publicly, but written to within this class
        private readonly string filename = $"FileInfo_{DateTime.Now:MM-dd-yyyy_HHmm-ss}.csv";    //Created the filename by getting the curreent time and foramtting it
        public CSV_Export(List<FileInformationModel> Data) //Construct the object, the required input is a LIST of FileInformationModel class and any readable property of that class will be written
        {
            Outputpath = Path.Combine(OutputPath.CSVExportPath, filename);  //We are combining the base output path which was read from the Get_Settings object with the Filename peoperty
            try
            {
                using StreamWriter writer = new(Outputpath); //Creating the stream writer using the output path we created
                using CsvWriter csv = new(writer, CultureInfo.InvariantCulture); //This was in the sample code so its in my code, this is probably how 0 day exploits are found
                csv.WriteHeader<FileInformationModel>();    //Reads the Property names from the FileInformationModel Class and writes them on the first line
                csv.NextRecord();   //I tried not having this hear and it didnt work
                foreach (var item in Data)
                {
                    csv.WriteRecord(item);  //Seems obvious
                    csv.NextRecord();   //I tried not having this hear and it didnt work, my 2 minute read of the manual indicated I shouldn't have to have this hear, but whatever
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
