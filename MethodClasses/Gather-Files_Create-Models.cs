/*
 * FILE: Gather_Files_Create_Models.cs
 *
 * DESCRIPTION:
 * This class orchestrates the process of gathering files from the source directory
 * and creating data models for each file. It coordinates the path scanning and
 * model creation processes.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. ASYNC IMPLEMENTATION
 *    - Convert to async operation for better UI responsiveness
 *    - Add cancellation support for long-running operations
 *    - Implement parallel processing for better performance
 *
 * 2. PROGRESS REPORTING
 *    - Add detailed progress reporting mechanism
 *    - Implement event-based status updates
 *    - Create time estimation for completion
 *
 * 3. BATCH PROCESSING
 *    - Add support for processing files in batches
 *    - Implement memory usage optimization for large collections
 *    - Create incremental processing capabilities
 *
 * 4. ERROR HANDLING
 *    - Enhance error handling with detailed context
 *    - Add recovery mechanisms for partial failures
 *    - Implement retry logic for transient errors
 *
 * 5. FILTERING OPTIONS
 *    - Add configurable filtering for file selection
 *    - Implement exclusion patterns for unwanted files
 *    - Create advanced filtering based on file attributes
 *
 * 6. CACHING
 *    - Implement caching for previously processed files
 *    - Add change detection to only process modified files
 *    - Create persistent cache for improved performance
 *
 * 7. EXTENSIBILITY
 *    - Create a plugin system for custom file processors
 *    - Implement middleware architecture for processing pipeline
 *    - Add event hooks for custom actions during processing
 *
 * 8. LOGGING AND DIAGNOSTICS
 *    - Add comprehensive logging throughout the process
 *    - Implement performance metrics collection
 *    - Create detailed diagnostics for troubleshooting
 */


using FileManipulator.Classes;

namespace FileManipulator.MethodClasses
{
    internal class Gather_Files_Create_Models
    {
        public Gather_Files_Create_Models() { }

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
