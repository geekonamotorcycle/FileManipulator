/*
 * FILE: Move_File.cs
 *
 * DESCRIPTION:
 * This class handles the actual file movement operations, copying files from their
 * source locations to their calculated destination paths. It creates directories
 * as needed and tracks the success of operations.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. OPERATION MODES
 *    - Add support for different operation modes (move, copy, link)
 *    - Implement dry-run capability to preview operations
 *    - Add verification after operations to ensure data integrity
 *
 * 2. ERROR HANDLING
 *    - Enhance error handling with detailed error information
 *    - Implement retry logic for failed operations
 *    - Add recovery mechanisms for interrupted transfers
 *
 * 3. COLLISION HANDLING
 *    - Add sophisticated collision resolution strategies
 *    - Implement options for renaming, versioning, or skipping
 *    - Create a duplicate detection system based on content
 *
 * 4. PERFORMANCE
 *    - Implement bulk operations for better performance
 *    - Add streaming copy for large files to reduce memory usage
 *    - Optimize for different storage types (SSD vs. HDD)
 *
 * 5. PROGRESS TRACKING
 *    - Add detailed progress reporting for file operations
 *    - Implement speed calculation and time remaining estimates
 *    - Create event-based notification system for status updates
 *
 * 6. SECURITY
 *    - Add permission preservation during file operations
 *    - Implement secure deletion options for move operations
 *    - Add validation of destination security context
 *
 * 7. METADATA PRESERVATION
 *    - Ensure preservation of important file metadata
 *    - Add options for date preservation strategies
 *    - Implement extended attribute handling
 *
 * 8. TRANSACTION SUPPORT
 *    - Add transaction-like behavior for batch operations
 *    - Implement rollback capability for failed operations
 *    - Create operation journals for recovery scenarios
 */


namespace FileManipulator
{
    internal class Move_File
    {
        public string SourcePath { get; set; } = string.Empty;
        public string DestinationPath { get; set; } = string.Empty;
        private string PathOnly { get; set; } = string.Empty;
        public bool MoveSuccess { get; private set; }

        public Move_File(List<FileInformationModel> paths)
        {
            foreach (var item in paths)
            {
                this.SourcePath = item.SourcePath;
                this.DestinationPath = item.DestinationBase;
                this.PathOnly = item.DestinationBase;

                if (item.DateSource == "exif")
                {
                    this.DestinationPath = item.EXIFdestpath;
                }
                else if (item.DateSource == "created")
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }
                else if (item.DateSource == "modified")
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }
                else
                {
                    this.DestinationPath = item.FSCreatedDestPath;
                }

                try
                {
                    if (Directory.Exists(this.PathOnly) == false)
                    {
                        CreatePath();
                    }
                    else
                    {
                        this.Move_Files();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private void Move_Files()
        {
            if (Directory.Exists(this.PathOnly))
            {
                try
                {
                    File.Move(SourcePath, DestinationPath);
                    if (File.Exists(DestinationPath))
                    {
                        this.MoveSuccess = true;
                    }
                    else
                    {
                        this.MoveSuccess = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                    this.MoveSuccess = false;
                    throw;
                }
            }
            else
            {
                try
                {
                    this.CreatePath();
                    File.Move(SourcePath, DestinationPath);
                    if (File.Exists(DestinationPath))
                    {
                        this.MoveSuccess = true;
                    }
                    else
                    {
                        this.MoveSuccess = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                    this.MoveSuccess = false;
                    throw;
                }
            }
        }

        private void CreatePath()
        {
            Directory.CreateDirectory(this.PathOnly);
            Console.WriteLine($"Created {this.PathOnly}");
        }
    }
}
