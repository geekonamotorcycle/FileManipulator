using FileManipulator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator.MethodClasses
{
    internal class Gather_Files_Create_Models
    {
        public List<FileInformationModel> FileModels { get; private set; }
        public Gather_Files_Create_Models()
        {
            this.FileModels = Files();
        }
        public List<FileInformationModel> Files()
        {
            try
            {
                DateTime StartTime = DateTime.Now;
                Get_Settings fileinfosettings = new();
                string destpath = fileinfosettings.DestinationBase;
                Get_SourcePaths filegatherer = new(fileinfosettings.SourcePath);
                CheckExists checker = new();
                List<FileInformationModel> files = new();
                Console.ResetColor();
                bool BaseDestExists = checker.CheckDirectory(destpath);
                foreach (var path in filegatherer.Geteresults())
                {
                    bool SourceFileExists = CheckExists.CheckFile(path);
                    if (SourceFileExists && BaseDestExists)
                    {
                        FileInformationModel FileInfoObject = new(path, destpath);
                        files.Add(FileInfoObject);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("One of the paths failed to check");
                        Console.ResetColor();
                    }

                }
                return files;
            }

            catch (Exception e)
            {
                Console.WriteLine($"There was a problem \n{e}");
                throw;
            }
        }
    }
}
