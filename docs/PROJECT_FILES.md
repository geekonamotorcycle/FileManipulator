# Project Files and Their Purposes

This document provides detailed information about each file in the FileManipulator project, including their purpose, inputs, outputs, and relationships.

## Table of Contents

- [Core Models (Data Classes)](#core-models-data-classes)
- [Interfaces (Contracts)](#interfaces-contracts)
- [Core Utilities (Service Classes)](#core-utilities-service-classes)
- [Metadata Extraction (Service Implementations)](#metadata-extraction-service-implementations)
- [Data Processing (Service Classes)](#data-processing-service-classes)
- [Output and Reporting (Service Classes)](#output-and-reporting-service-classes)
- [Application Control (Controller Classes)](#application-control-controller-classes)
- [Configuration Files](#configuration-files)

## Core Models (Data Classes)

### FileInformationModel.cs

- **Type**: Data class
- **Purpose**: Primary data model representing a media file and all its metadata
- **Inputs**: Source file path, destination base path
- **Outputs**: Complete file information including dates, paths, hash values
- **Key Properties**: SourcePath, FileName, FilExtension, MD5FileHash, EXIFdestpath, FSCreatedDestPath
- **Uses**: Path.GetFileName, Path.GetExtension, DateTime

### PublicFileInformationModel.cs

- **Type**: Data transfer object (DTO)
- **Purpose**: Version of FileInformationModel with public setters for database operations
- **Inputs**: None directly (populated from FileInformationModel)
- **Outputs**: Serializable representation for database storage
- **Key Properties**: Same as FileInformationModel but with public setters
- **Uses**: DateTime

## Interfaces (Contracts)

### ICalculate_Destinations.cs

- **Type**: Interface
- **Purpose**: Contract for destination path calculation
- **Methods Defined**:
  - Properties for source/destination paths
  - Properties for date information
  - Properties for calculated destination paths
- **Uses**: DateTime

### IGet_Dates.cs

- **Type**: Interface
- **Purpose**: Contract for date retrieval operations
- **Methods Defined**:
  - `ReturnedDateTime` property - DateTime output
  - `sourcepath` property - String input path
- **Uses**: DateTime

### IGet_MD5.cs

- **Type**: Interface
- **Purpose**: Contract for hash calculation
- **Methods Defined**:
  - `FilePath` property - String input path
  - `MD5Value` property - String output hash

### IGet_Raw.cs

- **Type**: Interface
- **Purpose**: Contract for RAW format detection
- **Methods Defined**:
  - `SourcePath` property - String input path
  - `IsRaw` property - Boolean output result

## Core Utilities (Service Classes)

### CheckExists.cs

- **Type**: Utility class
- **Purpose**: Validates existence of files and directories
- **Methods**:
  - `CheckDirectory(string DirectoryPath)` → Returns: bool
  - `CheckFile(string filePath)` → Returns: bool
- **Uses**: Directory.Exists, File.Exists

### Get_Settings.cs

- **Type**: Configuration service
- **Purpose**: Reads and provides access to application settings
- **Methods**:
  - `GetSettings()` → Loads configuration from JSON
  - `PrintSettings()` → Console output of settings
- **Properties**: SourcePath, DestinationBase, DateSource, CSVExportPath, ConnectionString
- **Uses**: ConfigurationBuilder, AddJsonFile

### GatherSourcePaths.cs (Get_SourcePaths)

- **Type**: Service class
- **Purpose**: Scans directories for supported media files
- **Methods**:
  - `Geteresults()` → Input: None, Output: List<string> of file paths
  - `Writeresults()` → Input: None, Output: string[] and console display
- **Uses**: Directory.GetFiles, Path.GetExtension

## Metadata Extraction (Service Implementations)

### Get_EXIFDates.cs

- **Type**: Service implementation (implements IGet_Dates)
- **Purpose**: Extracts dates from image EXIF metadata
- **Methods**:
  - Constructor input: string sourcepath
  - `GetDateTimeOriginal(string sourcepath)` → Returns: DateTime
- **Output**: DateTime via ReturnedDateTime property
- **Uses**: ImageMetadataReader.ReadMetadata, DateTime.Parse

### Get_FSCreationDate.cs

- **Type**: Service implementation (implements IGet_Dates)
- **Purpose**: Retrieves file system creation dates
- **Methods**:
  - Constructor input: string sourcepath
  - `GetFSCreationDateTime()` → Populates ReturnedDateTime property
- **Output**: DateTime via ReturnedDateTime property
- **Uses**: File.GetCreationTime

### Get_FSLastWriteDate.cs

- **Type**: Service implementation (implements IGet_Dates)
- **Purpose**: Retrieves file modification dates
- **Methods**:
  - Constructor input: string sourcepath
  - `GetFSLastWriteDateTime()` → Populates ReturnedDateTime property
- **Output**: DateTime via ReturnedDateTime property
- **Uses**: File.GetLastWriteTime

### Get_MD5.cs

- **Type**: Service implementation (implements IGet_MD5)
- **Purpose**: Calculates file hash values
- **Methods**:
  - Constructor input: string FilePath
  - `ReturnMD5()` → Populates MD5Value property
- **Output**: String hash via MD5Value property
- **Uses**: MD5.Create, BitConverter.ToString

### Get_Raw.cs

- **Type**: Service implementation (implements IGet_Raw)
- **Purpose**: Identifies RAW image formats
- **Methods**:
  - Constructor input: string SourcePath
  - `ReturnRaw()` → Populates IsRaw property
- **Output**: Boolean via IsRaw property
- **Uses**: Path.GetExtension

## Data Processing (Service Classes)

### Calculate_Destinations.cs

- **Type**: Service implementation (implements ICalculate_Destinations)
- **Purpose**: Determines destination file paths
- **Methods**:
  - Constructor inputs: string SourceFileName, string DesitnationBase, bool IsRaw, DateTime dates...
  - `CalculateDEstinations()` → Populates destination path properties
- **Outputs**: Destination paths via properties (ExifOriginalDateDestination, etc.)
- **Uses**: Path.Combine, Path.GetFileName, DateTime

### Gather_Files_Create_Models.cs

- **Type**: Orchestration service
- **Purpose**: Coordinates file discovery and model creation
- **Methods**:
  - `Files()` → Input: None, Output: List<FileInformationModel>
- **Process Flow**: Gets paths → Validates existence → Creates models
- **Uses**: DateTime

### Move_File.cs

- **Type**: Service class
- **Purpose**: Performs file movement operations
- **Methods**:
  - Constructor input: List<FileInformationModel> paths
  - `Move_Files()` → Input: None, Output: Updates MoveSuccess property
  - `CreatePath()` → Creates directory structure
- **Output**: Boolean success via MoveSuccess property
- **Uses**: Directory.Exists, Directory.CreateDirectory, File.Move, File.Exists

## Output and Reporting (Service Classes)

### CSV_Export.cs

- **Type**: Service class
- **Purpose**: Exports data to CSV format
- **Methods**:
  - Constructor input: List<FileInformationModel> Data
- **Output**: CSV file at specified location, path via Outputpath property
- **Uses**: CsvWriter, WriteHeader, WriteRecord, Path.Combine

### Output_CSV.cs

- **Type**: Orchestration service
- **Purpose**: Manages CSV export workflow
- **Methods**:
  - Constructor orchestrates: Data collection → CSV creation → Output
- **Output**: CSV file and console status messages
- **Uses**: DateTime

### Output_Screen.cs

- **Type**: Service class
- **Purpose**: Displays JSON data on console
- **Methods**:
  - Constructor orchestrates: Data collection → JSON conversion → Console output
- **Output**: Console display of file information in JSON format
- **Uses**: JsonSerializer, JsonSerializerOptions

### Output_DBContentsToScreen.cs

- **Type**: Service class
- **Purpose**: Displays database records
- **Methods**:
  - Constructor orchestrates: DB query → JSON conversion → Console output
- **Output**: Console display of database records in JSON format
- **Uses**: JsonSerializer, JsonSerializerOptions

### Write_SQLite.cs

- **Type**: Data access service
- **Purpose**: Manages database operations
- **Methods**:
  - `GetDBContents()` → Input: None, Output: List<PublicFileInformationModel>
  - `WriteToDB(FileInformationModel DataToWrite)` → Input: Model, Output: None
  - `TestSQLiteConnection()` → Validates and tests database connectivity
- **Database Operations**: Select, Insert
- **Uses**: SQLiteConnection, Query, Execute

## Application Control (Controller Classes)

### MainMenu.cs

- **Type**: Controller class
- **Purpose**: User interface and application flow
- **Methods**:
  - Constructor creates menu loop and handles input
- **Process Flow**: Display options → Get input → Execute corresponding function

### Program.cs

- **Type**: Application entry point
- **Purpose**: Initializes application
- **Methods**:
  - `Main(string[] args)` → Application entry point
- **Process Flow**: Creates MainMenu instance which starts the application

## Configuration Files

### appsettings.json

- **Type**: Configuration file (JSON)
- **Purpose**: Stores application settings
- **Key Settings**: Paths, connection strings, preferences
- **Used By**: Get_Settings class

### FileManipulator.csproj

- **Type**: Project file (.NET)
- **Purpose**: Defines project structure and dependencies
- **Key Elements**: NuGet package references, build settings

### FileManipulator.sln

- **Type**: Solution file (Visual Studio)
- **Purpose**: Organizes project for development environment
