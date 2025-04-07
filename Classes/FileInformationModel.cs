/*
 * FILE: FileInformationModel.cs
 * 
 * DESCRIPTION:
 * This file contains the core data model used throughout the application to represent
 * media files and their metadata. It's responsible for gathering and storing all 
 * information about a file that will be used for organization and reporting.
 * 
 * PLANNED IMPROVEMENTS:
 * 
 * 1. ERROR HANDLING
 *    - Replace direct exception throwing with a more robust error handling strategy
 *    - Implement a result pattern that returns success/failure with error details
 *    - Example: 
 *      public class Result<T> {
 *          public bool Success { get; set; }
 *          public string ErrorMessage { get; set; }
 *          public T Data { get; set; }
 *      }
 *    
 * 2. CONSTRUCTOR REFACTORING
 *    - Split the large constructor into smaller, focused methods
 *    - Implement dependency injection to make testing easier
 *    - Remove direct instantiation of services within the constructor
 *    
 * 3. VALIDATION
 *    - Add input validation for paths and other critical parameters
 *    - Implement data annotations or a validation library
 *    - Add property constraints (e.g., required fields, string length limits)
 *    
 * 4. ASYNC SUPPORT
 *    - Refactor file operations to be async for better performance
 *    - Implement Task-based methods for IO-bound operations
 *    - Example: public async Task<bool> GetFileExtensionAsync()
 *    
 * 5. IMPROVED LOGGING
 *    - Replace Console.WriteLine calls with a proper logging framework
 *    - Log at appropriate levels (debug, info, warning, error)
 *    - Include contextual information in log messages
 *    
 * 6. EXTENDED METADATA
 *    - Add support for additional metadata (camera model, GPS, etc.)
 *    - Implement optional metadata fields that don't cause failures if missing
 *    - Add capability to extract and store IPTC and XMP metadata
 *    
 * 7. IMMUTABILITY
 *    - Consider making the model immutable after construction
 *    - Use the builder pattern for complex object creation
 *    - Protect internal state from unexpected modifications
 *    
 * 8. SERIALIZATION IMPROVEMENTS
 *    - Add serialization attributes for better JSON/XML control
 *    - Implement custom serialization for complex types
 *    - Handle circular references properly
 */

// Current code remains unchanged, these notes are for documentation purposes only

using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class FileInformationModel
    {
        public string SourcePath { get; set; } = string.Empty;
        public string FileName { get; private set; } = string.Empty;
        public string FilExtension { get; private set; } = string.Empty;
        public bool IsRAW { get; private set; }
        public string MD5FileHash { get; private set; } = string.Empty;
        public string DateSource { get; private set; } = string.Empty;
        public DateTime FSCreatedDate { get; private set; } = DateTime.Now;
        public DateTime FSModifiedDate { get; private set; } = DateTime.Now;
        public DateTime ExifOrigDate { get; private set; } = DateTime.Now;
        public string DestinationBase { get; set; } = string.Empty;
        public string EXIFdestpath { get; private set; } = string.Empty;
        public string FSCreatedDestPath { get; private set; } = string.Empty;
        public string FSModifiedDestPath { get; private set; } = string.Empty;
        public bool FileMoved { get; set; } = false;

        public FileInformationModel(string SourcePath, string DesitnationBase)
        {
            this.SourcePath = SourcePath;
            DestinationBase = DesitnationBase;
            GetFileExtantion();
            DetermineIfRaw();
            GetMD5Value();
            ExifOriginalDate();
            GetFSCreationDate();
            GetFSLastWriteDate();
            CalculateDest();
            GetDateSource();
            GetFileName();

        }
        private void GetFileName()
        {
            try
            {
                FileName = Path.GetFileName(this.SourcePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetFileName Method");
                FileName = e.ToString();
                throw;
            }
        }
        private void GetFileExtantion()
        {
            try
            {
                FilExtension = Path.GetExtension(this.SourcePath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetExtension Method");
                FilExtension = e.ToString();
                throw;
            }
        }
        private void GetDateSource()
        {
            try
            {
                Get_Settings get_Settings = new();
                DateSource = get_Settings.DateSource;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetDateSource");
                DateSource = e.ToString();
                throw;
            }
        }
        private void GetMD5Value()
        {
            try
            {
                IGet_MD5 md5 = new Get_MD5(SourcePath);
                MD5FileHash = md5.MD5Value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in GetMD5Value");
                MD5FileHash = e.ToString();
                throw;
            }
        }
        private void DetermineIfRaw()
        {
            try
            {
                IGet_Raw rawStatus = new Get_Raw(SourcePath);
                IsRAW = rawStatus.IsRaw;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in DetermineIfRaw");
                IsRAW = false;
                throw;
            }
        }
        private void ExifOriginalDate()
        {
            try
            {
                IGet_Dates origdate = new Get_EXIFDates(SourcePath);
                ExifOrigDate = origdate.ReturnedDateTime;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in EXIFOriginalDAte");
                ExifOrigDate = DateTime.Parse("01-01-1970");
                throw;
            }
        }
        private void GetFSCreationDate()
        {
            try
            {
                IGet_Dates origdate = new Get_FSCreationDate(SourcePath);
                FSCreatedDate = origdate.ReturnedDateTime;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in GetFSCreationDate");
                FSCreatedDate = DateTime.Parse("01-01-1970");
                throw;
            }
        }
        private void GetFSLastWriteDate()
        {
            try
            {
                IGet_Dates origdate = new Get_FSLastWriteDate(SourcePath);
                FSModifiedDate = origdate.ReturnedDateTime;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error in GetFSLastWriteDate");
                FSModifiedDate = DateTime.Parse("01-01-1970");
                throw;
            }
        }
        private void CalculateDest()
        {
            try
            {
                ICalculate_Destinations DestinationObject = new Calculate_Destinations(SourcePath, DestinationBase, IsRAW, ExifOrigDate, FSCreatedDate, FSModifiedDate, "01/01/1970");
                FSCreatedDestPath = DestinationObject.FSCreationDateDestination;
                FSModifiedDestPath = DestinationObject.FSLastWriteDateDestination;
                EXIFdestpath = DestinationObject.ExifOriginalDateDestination;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in CalculateDest");
                FSCreatedDestPath = e.ToString();
                FSModifiedDestPath = e.ToString();
                EXIFdestpath = e.ToString();
                throw;
            }
        }

    }
}
