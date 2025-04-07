/*
 * FILE: Get_SourcePaths.cs
 *
 * DESCRIPTION:
 * This class is responsible for scanning directories and identifying media files
 * that match the supported formats. It builds a list of absolute file paths that
 * will be processed by the application.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. RECURSION SUPPORT
 *    - Add support for recursive directory scanning
 *    - Implement depth control for recursive operations
 *    - Add filtering options to include/exclude specific subdirectories
 *
 * 2. PERFORMANCE OPTIMIZATION
 *    - Implement parallel directory scanning for large directories
 *    - Add lazy loading or pagination for very large collections
 *    - Consider memory usage optimizations for thousands of files
 *
 * 3. ERROR HANDLING
 *    - Implement more robust error handling for file access issues
 *    - Add recovery mechanisms for partial access scenarios
 *    - Handle network path disconnections and timeouts
 *
 * 4. EXTENSION CONFIGURATION
 *    - Move media format list to configuration file
 *    - Allow runtime configuration of supported formats
 *    - Create a mechanism to add custom formats without code changes
 *
 * 5. FILTERING CAPABILITIES
 *    - Add filtering by file size, date ranges, or other criteria
 *    - Implement an extensible filter system using predicates
 *    - Support compound filters with AND/OR logic
 *
 * 6. CANCELLATION SUPPORT
 *    - Implement CancellationToken support for long-running operations
 *    - Allow users to cancel directory scans in progress
 *    - Add proper cleanup for interrupted operations
 *
 * 7. PROGRESS REPORTING
 *    - Add an event-based progress reporting system
 *    - Report current status for large directory scans
 *    - Include file counts and estimated completion time
 *
 * 8. ASYNC IMPLEMENTATION
 *    - Convert file system operations to async
 *    - Implement IAsyncEnumerable for streaming results
 *    - Example: public async IAsyncEnumerable<string> GetResultsAsync()
 */

namespace FileManipulator.Classes
{
    internal class Get_SourcePaths
    {
        public string sourcebasepath = @"";
        private List<string> imageFormats = new()
        {
            ".jpeg",
            ".png",
            ".webp",
            ".gif",
            ".ico",
            ".bmp",
            ".tiff",
            ".psd",
            ".pcx",
            ".raw",
            ".crw",
            ".cr2",
            ".nef",
            ".orf",
            ".raf",
            ".rw2",
            ".rwl",
            ".srw",
            ".arw",
            ".dng",
            ".x3f",
            ".mov",
            ".mp4",
            ".m4v",
            ".3g2",
            ".3gp",
            ".jpg",
        };
        public List<string> SupportedFilenames = new();

        public Get_SourcePaths(string sourcebasepath)
        {
            this.sourcebasepath = sourcebasepath;
            if (!Directory.Exists(this.sourcebasepath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "The base path of " + this.sourcebasepath + " is not a valid path"
                );
                Console.ResetColor();
                throw new InvalidDataException("Invalid Source Base Path");
            }
        }

        public List<string> Geteresults()
        {
            if (Directory.Exists(sourcebasepath))
            {
                string[] filenames = Directory.GetFiles(sourcebasepath);
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
