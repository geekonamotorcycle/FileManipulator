using FileManipulator.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    public class Testing
    {
        public Testing()
        {
            DateTime StartTime = DateTime.Now;
            Settings fileinfosettings = new();
            string destpath = fileinfosettings.DestinationBase;
            Get_SourcePaths filegatherer = new(fileinfosettings.SourcePath);
            CheckExists checker = new();
            bool BaseDestExists = checker.CheckDirectory(destpath);


            foreach (var path in filegatherer.Geteresults())
            {
                bool SourceFileExists = checker.CheckFile(path);
                if (SourceFileExists && BaseDestExists)
                {
                    FileInformationModel FileInfoObject = new(path, destpath);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Source file is \"{FileInfoObject.SourcePath}\"");
                    Console.WriteLine($"Source file is \"{FileInfoObject.DestinationBase}\"");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"MD5 is \"{FileInfoObject.MD5FileHash}\"" +
                        $"\nRaw File: \"{FileInfoObject.IsRAW}\"" +
                        $"\nEXIF Oringinal DATE/TIME: \"{FileInfoObject.ExifOrigDate}\"" +
                        $"\nFile System Creation Date: \"{FileInfoObject.CreatedDate}\"" +
                        $"\nFile System Last Write Date: \"{FileInfoObject.ModifiedDate}\"" +
                        $"\nBasePath is {Path.GetDirectoryName(FileInfoObject.ModifiedDestPath)}" +
                        $"\nEXIF Destination Path \"{FileInfoObject.EXIFdestpath}\"" +
                        $"\nFile System Creation Destination Path \"{FileInfoObject.CreatedDestPath}\"" +
                        $"\nFile System LastWrite Destination Path \"{FileInfoObject.ModifiedDestPath}\"" +
                        $"\n" +
                        $"\n");
                    //Move_File move_File = new Move_File(FileInfoObject.SourcePath, FileInfoObject.EXIFdestpath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("One of the paths failed to check");
                    Console.ResetColor();
                }

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            DateTime EndTime = DateTime.Now;
            TimeSpan TotalTime = EndTime.Subtract(StartTime);
            Console.WriteLine($"\n\nThat took \"{TotalTime}\" to run. on {filegatherer.Geteresults().Count()} files");
        }



    }
}
