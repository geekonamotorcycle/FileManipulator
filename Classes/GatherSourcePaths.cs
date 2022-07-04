using System.Collections.Generic;

namespace FileManipulator.Classes

{
    internal class Get_SourcePaths
    {
        //  Properties
        public string sourcebasepath = @"";
        private List<string> imageFormats = new List<string> { ".jpeg", ".png", ".webp", ".gif", ".ico", ".bmp",
            ".tiff", ".psd", ".pcx", ".raw", ".crw", ".cr2", ".nef", ".orf", ".raf", ".rw2", ".rwl", ".srw", ".arw",
            ".dng", ".x3f", ".mov", ".mp4", ".m4v", ".3g2", ".3gp" , ".jpg" };
        public List<string> SupportedFilenames = new List<string>();
        //  Constructor
        public Get_SourcePaths(string sourcebasepath)
        {
            this.sourcebasepath = sourcebasepath;
            if (!Directory.Exists(this.sourcebasepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + this.sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }
        }

        //  methods
        public List<string> Geteresults()
        {
            if (Directory.Exists(sourcebasepath))
            {
                
                string[] filenames = Directory.GetFiles(this.sourcebasepath);
                foreach (string item in filenames)
                {
                    if (imageFormats.Contains(Path.GetExtension(item).ToLower()))
                    {
                        SupportedFilenames.Add(item);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }
            return SupportedFilenames;

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
