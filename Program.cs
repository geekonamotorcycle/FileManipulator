using FileManipulator.Classes;
using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DateTime StartTime = DateTime.Now;
            string destpath = @"J:\desttest";
            Get_SourcePaths filegatherer = new Get_SourcePaths(@"J:\sourcetest");

            foreach (var path in filegatherer.Geteresults())
            {
                CheckExists checker = new();
                bool SourceFileExists = checker.CheckFile(path);
                bool BaseDestExists = checker.CheckDirectory(destpath);

                if (SourceFileExists && BaseDestExists)
                {
                    FileInformationModel FileInfoObject = new FileInformationModel(path, destpath);
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
                        $"\n");
                    Move_File move_File = new Move_File(FileInfoObject.SourcePath, FileInfoObject.EXIFdestpath);
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