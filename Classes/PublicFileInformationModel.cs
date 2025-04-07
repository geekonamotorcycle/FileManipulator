/*
 * FILE: PublicFileInformationModel.cs
 *
 * DESCRIPTION:
 * This class serves as a data transfer object (DTO) for file information
 * that will be exposed to external components or persistence. It mirrors
 * the main FileInformationModel but with public setters for serialization.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. DATA ANNOTATIONS
 *    - Add data annotations for validation
 *    - Implement attributes for controlling serialization
 *    - Create custom conversion attributes for special types
 *
 * 2. MODEL MAPPING
 *    - Implement automated mapping from internal model
 *    - Add selective field mapping capabilities
 *    - Create transformation rules for data conversion
 *
 * 3. VERSIONING SUPPORT
 *    - Add version information for backward compatibility
 *    - Implement graceful handling of missing properties
 *    - Create migration path for different versions
 *
 * 4. SERIALIZATION OPTIMIZATION
 *    - Enhance serialization performance
 *    - Add custom serialization for complex types
 *    - Implement compression for large data
 *
 * 5. SECURITY ENHANCEMENTS
 *    - Add methods for sanitizing sensitive information
 *    - Implement access control markers for properties
 *    - Create validation for potentially dangerous data
 *
 * 6. EXTENSIBILITY
 *    - Add support for dynamic properties
 *    - Implement extension methods for common operations
 *    - Create custom type converters for special formats
 *
 * 7. DOCUMENTATION
 *    - Add comprehensive XML documentation
 *    - Implement usage examples in comments
 *    - Create schema documentation for external systems
 *
 * 8. TYPE CONVERSION
 *    - Improve boolean representation (int to bool)
 *    - Add proper type handling for database interactions
 *    - Implement custom type conversion methods
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class PublicFileInformationModel
    {
        public string SourcePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FilExtension { get; set; } = string.Empty;
        public int IsRAW { get; set; }
        public string MD5FileHash { get; set; } = string.Empty;
        public string DateSource { get; set; } = string.Empty;
        public DateTime FSCreatedDate { get; set; } = DateTime.Now;
        public DateTime FSModifiedDate { get; set; } = DateTime.Now;
        public DateTime ExifOrigDate { get; set; } = DateTime.Now;
        public string DestinationBase { get; set; } = string.Empty;
        public string EXIFdestpath { get; set; } = string.Empty;
        public string FSCreatedDestPath { get; set; } = string.Empty;
        public string FSModifiedDestPath { get; set; } = string.Empty;
        public int FileMoved { get; set; }
    }
}
