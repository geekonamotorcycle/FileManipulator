/*
 * FILE: Output_CSV.cs
 *
 * DESCRIPTION:
 * This class orchestrates the process of gathering file information and
 * exporting it to a CSV file. It coordinates the data collection and CSV
 * generation process.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. PROCESS SEPARATION
 *    - Separate data gathering from export functionality
 *    - Implement a pipeline architecture for modular processing
 *    - Create extensible hooks for custom processing steps
 *
 * 2. PROGRESS REPORTING
 *    - Add detailed progress reporting for long operations
 *    - Implement time estimation for completion
 *    - Create cancellation capabilities for user control
 *
 * 3. ERROR HANDLING
 *    - Enhance error reporting with detailed context
 *    - Implement partial success capability for large datasets
 *    - Add recovery mechanisms for interrupted operations
 *
 * 4. CONFIGURATION
 *    - Add configurable export options
 *    - Implement templates for different export scenarios
 *    - Create profile system for saved export configurations
 *
 * 5. OPTIMIZATION
 *    - Implement parallel processing for data collection
 *    - Add batched processing for better memory usage
 *    - Create incremental export capabilities for large datasets
 *
 * 6. SCHEDULING
 *    - Add scheduled export capabilities
 *    - Implement automatic export triggers based on events
 *    - Create recurring export job functionality
 *
 * 7. VALIDATION
 *    - Add pre-export validation to identify potential issues
 *    - Implement data quality checks before export
 *    - Create reporting on potential data problems
 *
 * 8. INTEGRATION
 *    - Add integration with external systems
 *    - Implement export to network locations and cloud storage
 *    - Create notification system for completed exports
 */


using FileManipulator.Classes;
using FileManipulator.MethodClasses;

namespace FileManipulator
{
    internal class Output_CSV
    {
        public Output_CSV()
        {
            DateTime StartTime = DateTime.Now;

            Gather_Files_Create_Models gather_Files_Create_Model = new();
            List<FileInformationModel> models = gather_Files_Create_Model.Files();
            CSV_Export Exporter = new CSV_Export(models);

            DateTime EndTime = DateTime.Now;
            TimeSpan TotalTime = EndTime.Subtract(StartTime);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(
                $"\nIt took \"{TotalTime}\" to run on {models.Count} files"
                    + $"\nThe CSV was output to: {Exporter.Outputpath}"
                    + $"\nPress Any Key to return to the main menu"
            );
            Console.ReadKey();
            Console.ResetColor();
            Console.Clear();
        }
    }
}
