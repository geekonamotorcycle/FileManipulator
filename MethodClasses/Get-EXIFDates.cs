/*
 * FILE: Get_EXIFDates.cs
 *
 * DESCRIPTION:
 * This class is responsible for extracting the original date/time from image EXIF metadata.
 * It uses the MetadataExtractor library to read EXIF data from various image formats.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. METADATA HANDLING
 *    - Add support for additional EXIF date fields (DateTimeDigitized, etc.)
 *    - Implement fallback strategy when primary date fields are missing
 *    - Add timezone handling for accurate date representation
 *
 * 2. ERROR RESILIENCE
 *    - Add better validation for malformed EXIF data
 *    - Implement recovery strategies for partially corrupted metadata
 *    - Add support for non-standard date formats in EXIF data
 *
 * 3. PERFORMANCE IMPROVEMENTS
 *    - Implement caching for repeatedly accessed files
 *    - Add async support for better performance with large files
 *    - Optimize memory usage when handling large images
 *
 * 4. EXTENDED METADATA
 *    - Extract additional useful EXIF fields (camera model, GPS, etc.)
 *    - Support for XMP and IPTC metadata standards
 *    - Add extraction of image-specific attributes (resolution, color space)
 *
 * 5. FORMAT SUPPORT
 *    - Improve support for RAW file formats from various camera manufacturers
 *    - Add better handling for video file metadata
 *    - Support for emerging file formats and metadata standards
 *
 * 6. LOGGING IMPROVEMENTS
 *    - Add detailed logging of metadata extraction process
 *    - Implement warning system for files with problematic metadata
 *    - Create audit trail for metadata extraction operations
 *
 * 7. INTEGRATION ENHANCEMENTS
 *    - Implement factory pattern for creating appropriate metadata extractors
 *    - Add plugin system for custom metadata extractors
 *    - Create adapters for different metadata library backends
 *
 * 8. TESTING SUPPORT
 *    - Add comprehensive unit tests for various metadata scenarios
 *    - Create test fixtures with various metadata patterns
 *    - Implement integration tests with real image files
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManipulator.Interfaces;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using Directory = MetadataExtractor.Directory;

namespace FileManipulator
{
    internal class Get_EXIFDates : IGet_Dates
    {
        public string sourcepath { get; set; } = string.Empty;
        public DateTime ReturnedDateTime { get; private set; }

        public Get_EXIFDates(string sourcepath)
        {
            GetDateTimeOriginal(sourcepath);
        }

        private DateTime GetDateTimeOriginal(string sourcepath)
        {
            try
            {
                {
                    var directories = ImageMetadataReader.ReadMetadata(sourcepath);

                    foreach (var directory in directories)
                    {
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Date/Time Original")
                            {
                                if (string.IsNullOrEmpty(tag.Description))
                                    continue;
                                string d = tag.Description.Split(" ")[0].Replace(":", "-");
                                string t = tag.Description.Split(" ")[1];
                                //Console.WriteLine(DateTime.Parse($"{d} {t}"));
                                ReturnedDateTime = DateTime.Parse($"{d} {t}");
                                return DateTime.Parse($"{d} {t}");
                            }
                        }
                    }
                    ReturnedDateTime = DateTime.Parse("01/01/1970");
                    return ReturnedDateTime;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error for file {sourcepath}\nError was {e}");
                ReturnedDateTime = DateTime.Parse("01/01/1970");
                throw;
            }
        }
    }
}
