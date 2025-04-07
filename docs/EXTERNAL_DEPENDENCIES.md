# External Dependencies and Documentation

This document provides links to the official documentation for all external libraries, methods, and classes used in the FileManipulator project.

## Table of Contents

- [.NET Core Classes](#net-core-classes)
- [External NuGet Packages](#external-nuget-packages)
- [Interface and Class Patterns](#interface-and-class-patterns)

## .NET Core Classes

### Directory Class

- [Directory.Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.exists "Microsoft Documentation") - Checks if directory exists
- [Directory.GetFiles](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles "Microsoft Documentation") - Retrieves files from directory
- [Directory.CreateDirectory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory "Microsoft Documentation") - Creates directories

### File Class

- [File.Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists "Microsoft Documentation") - Checks if file exists
- [File.GetCreationTime](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.getcreationtime "Microsoft Documentation") - Gets file creation date
- [File.GetLastWriteTime](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.getlastwritetime "Microsoft Documentation") - Gets file modification date
- [File.Move](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.move "Microsoft Documentation") - Moves file to new location

### Path Class

- [Path.GetExtension](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getextension "Microsoft Documentation") - Extracts file extension
- [Path.GetFileName](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfilename "Microsoft Documentation") - Extracts file name
- [Path.Combine](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine "Microsoft Documentation") - Builds path strings

### DateTime Struct

- [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime "Microsoft Documentation") - Represents date and time
- [DateTime.Parse](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse "Microsoft Documentation") - Converts string to DateTime

### Cryptography

- [MD5.Create](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5.create "Microsoft Documentation") - Creates MD5 hasher
- [BitConverter.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter.tostring "Microsoft Documentation") - Converts byte array to string

### JSON Handling

- [JsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer "Microsoft Documentation") - JSON serialization
- [JsonSerializerOptions](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions "Microsoft Documentation") - JSON serialization options

## External NuGet Packages

### Microsoft.Extensions.Configuration

- [ConfigurationBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationbuilder "Microsoft Documentation") - Builds configuration
- [AddJsonFile](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.jsonconfigurationextensions.addjsonfile "Microsoft Documentation") - Adds JSON configuration source
- [Package Documentation](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json "NuGet Package")

### CsvHelper

- [CsvWriter](https://joshclose.github.io/CsvHelper/api/CsvHelper.CsvWriter/ "CsvHelper Documentation") - Writes CSV data
- [WriteHeader](https://joshclose.github.io/CsvHelper/api/CsvHelper.CsvWriter/#writeheader "CsvHelper Documentation") - Writes CSV headers
- [WriteRecord](https://joshclose.github.io/CsvHelper/api/CsvHelper.CsvWriter/#writerecord "CsvHelper Documentation") - Writes CSV records
- [Package Documentation](https://joshclose.github.io/CsvHelper/ "CsvHelper Documentation")

### Dapper

- [Query](https://github.com/DapperLib/Dapper#retrieve-data "Dapper Documentation") - Executes SQL query
- [Execute](https://github.com/DapperLib/Dapper#execute-a-command-that-returns-no-results "Dapper Documentation") - Executes SQL command
- [Package Documentation](https://github.com/DapperLib/Dapper "Dapper Documentation")

### MetadataExtractor

- [ImageMetadataReader.ReadMetadata](https://drewnoakes.github.io/metadata-extractor-dotnet/api/MetadataExtractor.ImageMetadataReader.html#MetadataExtractor_ImageMetadataReader_ReadMetadata_System_String_ "MetadataExtractor Documentation") - Extracts image metadata
- [Package Documentation](https://github.com/drewnoakes/metadata-extractor-dotnet "MetadataExtractor Documentation")

### System.Data.SQLite.Core

- [SQLiteConnection](https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings "Microsoft Documentation") - SQLite connection
- [Package Documentation](https://www.nuget.org/packages/System.Data.SQLite.Core/ "NuGet Package")

## Interface and Class Patterns

### Repository Pattern

- [Documentation](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design "Microsoft Documentation")
- Used in database access classes

### Dependency Injection

- [Documentation](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection "Microsoft Documentation")
- Recommended for future improvements

### Interface Segregation Principle

- [Documentation](https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion "Microsoft Documentation")
- Applied in interface design
