using FileManipulator.Classes;


namespace FileManipulator
{
    internal class Output_CSV
    {
        public Output_CSV()
        {
            DateTime StartTime = DateTime.Now;  //This is used to calculate run time
            Get_Settings fileinfosettings = new();  //Creating an object that will read the settings from appsettings.json
            string destpath = fileinfosettings.DestinationBase; //Loading the Base Destination Path
            Get_SourcePaths filegatherer = new(fileinfosettings.SourcePath);    // Running the File name gathering script. This returns a List of strings that are full paths to the individual files in the source path
            CheckExists checker = new();    // Initializing the object which will chack if the Source file and Destination exist at runtime
            bool BaseDestExists = checker.CheckDirectory(destpath); //Checking the destination
            List<FileInformationModel> files = new();   //This is the object that will hold data about each individual file
            foreach (var path in filegatherer.Geteresults())   
            {
                bool SourceFileExists = CheckExists.CheckFile(path);    //Now we are checking to make sure the sourcefile exists
                if (SourceFileExists && BaseDestExists)
                {
                    FileInformationModel FileInfoObject = new(path, destpath);  //Instantiate the object FileInformationModel for this particular files
                    files.Add(FileInfoObject);  // Add the object to the list
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; //This should probably be a catch block
                    Console.WriteLine("One of the paths failed to check");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime EndTime = DateTime.Now;
            TimeSpan TotalTime = EndTime.Subtract(StartTime);
            Console.WriteLine($"\n\nThat took \"{TotalTime}\" to run on {files.Count} files");
            CSV_Export Exporter = new CSV_Export(files);    //Exporting the list as a CSV, there is a try catch block in this class
            Console.WriteLine($"The CSV was output to: {Exporter.Outputpath}");
            Console.WriteLine("Press Any Key to return to the main menu");
            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
