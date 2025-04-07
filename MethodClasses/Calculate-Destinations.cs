/*
 * FILE: Calculate_Destinations.cs
 *
 * DESCRIPTION:
 * This class is responsible for determining the destination file paths for media files
 * based on their dates and other attributes. It constructs the folder hierarchy and
 * final file paths.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. PATH CONSTRUCTION
 *    - Refactor path building logic to be more maintainable
 *    - Implement template-based path construction
 *    - Add support for custom path formats via configuration
 *
 * 2. COLLISION HANDLING
 *    - Implement strategies for handling filename collisions
 *    - Add support for automatic renaming with various patterns
 *    - Create a duplicate detection system based on content hash
 *
 * 3. VALIDATION
 *    - Add path validation for different operating systems
 *    - Implement length checks for path components
 *    - Add checks for reserved characters and filenames
 *
 * 4. EXTENSIBILITY
 *    - Create a plugin system for custom path calculation strategies
 *    - Support for different organization schemes (by event, location, etc.)
 *    - Implement rule-based path determination
 *
 * 5. PATH PREVIEWING
 *    - Add capability to preview destination paths without moving files
 *    - Implement conflict detection in preview mode
 *    - Add reporting for potential path issues
 *
 * 6. CROSS-PLATFORM SUPPORT
 *    - Improve handling of path separators for different operating systems
 *    - Add consistent normalization of paths
 *    - Handle platform-specific path length limitations
 *
 * 7. SPECIAL HANDLING
 *    - Add support for special destination rules for specific file types
 *    - Implement custom handling for panoramas, bursts, and HDR images
 *    - Add support for related file grouping (RAW+JPEG pairs)
 *
 * 8. DATE FALLBACK LOGIC
 *    - Implement more sophisticated date fallback strategies
 *    - Add configurable priority for different date sources
 *    - Create special handling for files with unreliable dates
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Calculate_Destinations : ICalculate_Destinations
    {
        public DateTime DefaultDate { get; }
        public string SourceFileName { get; set; } = string.Empty;
        public string DesitnationBase { get; set; } = string.Empty;
        public bool IsRaw { get; set; }
        public DateTime EXCreationDate { get; set; }
        public DateTime FSCreationDate { get; set; }
        public DateTime FSLastWriteDate { get; set; }
        public string ExifOriginalDateDestination { get; private set; } = string.Empty;
        public string FSCreationDateDestination { get; private set; } = string.Empty;
        public string FSLastWriteDateDestination { get; private set; } = string.Empty;
        public string RAWExifOriginalDateDestination { get; private set; } = string.Empty;
        public string RAWFSCreationDateDestination { get; private set; } = string.Empty;
        public string RAWFSLastWriteDateDestination { get; private set; } = string.Empty;
        private string FileName { get; set; } = string.Empty;

        public Calculate_Destinations(
            string SourceFileName,
            string DesitnationBase,
            bool IsRaw,
            DateTime EXCreationDate,
            DateTime FSCreationDate,
            DateTime FSLastWriteDate,
            string DefaultTimeString
        )
        {
            this.DefaultDate = DateTime.Parse(DefaultTimeString);
            this.IsRaw = IsRaw;
            this.SourceFileName = SourceFileName;
            this.FileName = Path.GetFileName(SourceFileName);
            this.DesitnationBase = DesitnationBase;
            this.EXCreationDate = EXCreationDate;
            this.FSLastWriteDate = FSLastWriteDate;
            this.FSCreationDate = FSCreationDate;
            this.CalculateDEstinations();
        }

        private void CalculateDEstinations()
        {
            if (EXCreationDate != this.DefaultDate)
            {
                if (IsRaw)
                {
                    ExifOriginalDateDestination = Path.Combine(
                        this.DesitnationBase,
                        this.EXCreationDate.ToString("yyyy"),
                        this.EXCreationDate.ToString("MM-yyyy"),
                        this.EXCreationDate.ToString("MM-dd-yyyy"),
                        "Raw",
                        this.FileName
                    );
                }
                else
                {
                    ExifOriginalDateDestination = Path.Combine(
                        this.DesitnationBase,
                        this.EXCreationDate.ToString("yyyy"),
                        this.EXCreationDate.ToString("MM-yyyy"),
                        this.EXCreationDate.ToString("MM-dd-yyyy"),
                        this.FileName
                    );
                }
            }
            else
            {
                if (IsRaw)
                {
                    ExifOriginalDateDestination = Path.Combine(
                        this.DesitnationBase,
                        this.FSCreationDate.ToString("yyyy"),
                        this.FSCreationDate.ToString("MM-yyyy"),
                        this.FSCreationDate.ToString("MM-dd-yyyy"),
                        "RAW",
                        this.FileName
                    );
                }
                else
                {
                    ExifOriginalDateDestination = Path.Combine(
                        this.DesitnationBase,
                        this.FSCreationDate.ToString("yyyy"),
                        this.FSCreationDate.ToString("MM-yyyy"),
                        this.FSCreationDate.ToString("MM-dd-yyyy"),
                        this.FileName
                    );
                }
            }

            if (IsRaw)
            {
                FSCreationDateDestination = Path.Combine(
                    this.DesitnationBase,
                    this.FSCreationDate.ToString("yyyy"),
                    this.FSCreationDate.ToString("MM-yyyy"),
                    this.FSCreationDate.ToString("MM-dd-yyyy"),
                    "RAW",
                    this.FileName
                );
            }
            else
            {
                FSCreationDateDestination = Path.Combine(
                    this.DesitnationBase,
                    this.FSCreationDate.ToString("yyyy"),
                    this.FSCreationDate.ToString("MM-yyyy"),
                    this.FSCreationDate.ToString("MM-dd-yyyy"),
                    this.FileName
                );
            }

            if (IsRaw)
            {
                FSLastWriteDateDestination = Path.Combine(
                    this.DesitnationBase,
                    this.FSLastWriteDate.ToString("yyyy"),
                    this.FSLastWriteDate.ToString("MM-yyyy"),
                    this.FSLastWriteDate.ToString("MM-dd-yyyy"),
                    "RAW",
                    this.FileName
                );
            }
            else
            {
                FSLastWriteDateDestination = Path.Combine(
                    this.DesitnationBase,
                    this.FSLastWriteDate.ToString("yyyy"),
                    this.FSLastWriteDate.ToString("MM-yyyy"),
                    this.FSLastWriteDate.ToString("MM-dd-yyyy"),
                    this.FileName
                );
            }
        }
    }
}
