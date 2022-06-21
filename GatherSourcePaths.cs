using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class GatherSourcePaths
    {
        //  Properties
        public string sourcebasepath = @"";
        //  Constructor
        public GatherSourcePaths(string sourcebasepath) 
        {
            this.sourcebasepath = sourcebasepath;
            if (Directory.Exists(this.sourcebasepath))
            {
                string[] filenames   =  Directory.GetFiles(this.sourcebasepath);
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
            if (Directory.Exists(this.sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(this.sourcebasepath);
                return filenames;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + this.sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }

        }
        public string[] Writeresults()
        {
            if (Directory.Exists(this.sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(this.sourcebasepath);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Path Passed in is: " + this.sourcebasepath);
                Console.WriteLine("number of files found: " + filenames.Count() +"\n");
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
                Console.WriteLine("The base path of " + this.sourcebasepath + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }

        }
    }
}
