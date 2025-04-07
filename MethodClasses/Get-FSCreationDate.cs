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


using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Get_FSCreationDate : IGet_Dates
    {
        private readonly string _sourcePath;
        public DateTime ReturnedDateTime { get; private set; }
        public string sourcepath { get; set; } = string.Empty;

        public Get_FSCreationDate(string sourcepath)
        {
            _sourcePath = sourcepath;
            GetFSCreationDateTime();
        }

        private void GetFSCreationDateTime()
        {
            DateTime date = File.GetCreationTime(_sourcePath);
            ReturnedDateTime = date;
        }
    }
}
