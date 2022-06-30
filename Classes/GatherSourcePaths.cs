namespace FileManipulator.Classes
{
    internal class Get_SourcePaths
    {
        //  Properties
        public string sourcebasepath = @"";
        //  Constructor
        public Get_SourcePaths(string sourcebasepath)
        {
            this.sourcebasepath = sourcebasepath;
            if (Directory.Exists(this.sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(this.sourcebasepath);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + this.sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }

        }
        //  methods
        public string[] Geteresults()
        {
            if (Directory.Exists(sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(sourcebasepath);
                return filenames;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }

        }
        public string[] Writeresults()
        {
            if (Directory.Exists(sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(sourcebasepath);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Path Passed in is: " + sourcebasepath);
                Console.WriteLine("number of files found: " + filenames.Count() + "\n");
                foreach (string filename in filenames)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(filename.ToString());
                }
                Console.ResetColor();
                return filenames;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }

        }
    }
}
