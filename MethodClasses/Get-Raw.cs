/*
 * FILE: Get_Raw.cs
 *
 * DESCRIPTION:
 * This class determines whether a file is a RAW image format based on its extension.
 * It supports a wide range of camera-specific RAW formats for proper handling.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. FORMAT DETECTION
 *    - Enhance RAW detection with signature-based identification
 *    - Implement magic number detection for more accurate identification
 *    - Add support for new and emerging RAW formats
 *
 * 2. CONFIGURATION
 *    - Move the list of RAW extensions to configuration
 *    - Add runtime updating of supported formats
 *    - Implement format categories (RAW, HDR, vector, etc.)
 *
 * 3. METADATA INTEGRATION
 *    - Add extraction of RAW-specific metadata
 *    - Implement camera model detection for format variations
 *    - Add support for sidecar files (.XMP, etc.)
 *
 * 4. EXTENSIBILITY
 *    - Create a plugin system for custom format detection
 *    - Implement format detection rules beyond extensions
 *    - Add support for format-specific handling instructions
 *
 * 5. RAW PROCESSING
 *    - Add basic RAW preview generation
 *    - Implement thumbnail extraction from RAW files
 *    - Create utilities for RAW conversion to standard formats
 *
 * 6. PAIRED FILE HANDLING
 *    - Add detection of RAW+JPEG pairs
 *    - Implement relationship tracking between related files
 *    - Create management strategies for file pairs
 *
 * 7. MANUFACTURER SUPPORT
 *    - Add manufacturer-specific format handling
 *    - Implement detailed information about RAW capabilities
 *    - Create vendor-specific metadata extraction
 *
 * 8. TESTING FRAMEWORK
 *    - Build a comprehensive test suite for various formats
 *    - Implement format validation with sample files
 *    - Create detection accuracy metrics
 */


using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Get_Raw : IGet_Raw
    {
        public string SourcePath { get; set; } = String.Empty;
        public bool IsRaw { get; private set; }
        private readonly string[] RawExtensions =
        {
            ".png",
            ".3fr",
            ".ari",
            ".arw",
            ".bay",
            ".braw",
            ".crw",
            ".cr2",
            ".cr3",
            ".cap",
            ".data",
            ".dcs",
            ".dcr",
            ".dng",
            ".drf",
            ".eip",
            ".nef",
            ".erf",
            ".fff",
            ".gpr",
            ".iiq",
            ".k25",
            ".kdc",
            ".mdc",
            ".mef",
            ".mos",
            ".mrw",
            ".nef",
            ".nrw",
            ".obm",
            ".orf",
            ".pef",
            ".ptx",
            ".pxn",
            ".r3d",
            ".raf",
            ".raw",
            ".rwl",
            ".rw2",
            ".rwz",
            ".sr2",
            ".srf",
            ".srw",
            ".tif",
            ".x3f",
        };

        public Get_Raw(string SourcePath)
        {
            this.SourcePath = SourcePath;
            ReturnRaw();
        }

        private void ReturnRaw()
        {
            string FileExtension = Path.GetExtension(SourcePath).ToLower();
            if (RawExtensions.Contains(FileExtension))
            {
                this.IsRaw = true;
            }
            else
            {
                this.IsRaw = false;
            }
        }
    }
}
