# FileManipulator

- [FileManipulator](#filemanipulator)
  - [Overview](#overview)
  - [Purpose](#purpose)
  - [Features](#features)
  - [Getting Started](#getting-started)
    - [Requirements](#requirements)
    - [Installation](#installation)
    - [Configuration](#configuration)
  - [Usage](#usage)
  - [How It Works](#how-it-works)
  - [Project Structure](#project-structure)
  - [Development Notes](#development-notes)
  - [Planned Improvements](#planned-improvements)
    - [Code Architecture](#code-architecture)
    - [Feature Additions](#feature-additions)
    - [UI Enhancements](#ui-enhancements)
    - [Performance Optimization](#performance-optimization)
  - [Technical Reference Appendix](#technical-reference-appendix)
    - [.NET Core Method Links](#net-core-method-links)
      - [Directory Class](#directory-class)
      - [File Class](#file-class)
      - [Path Class](#path-class)
      - [DateTime Struct](#datetime-struct)
      - [Cryptography](#cryptography)
      - [JSON Handling](#json-handling)
      - [Configuration builder](#configuration-builder)
  - [Licensing Terms](#licensing-terms)
    - [🔓 Personal Use: GPL v3](#-personal-use-gpl-v3)
    - [💼 Commercial Use: Proprietary License](#-commercial-use-proprietary-license)
  - [Contributing](#contributing)
  - [Acknowledgments](#acknowledgments)

## Overview

**FileManipulator** is a C# application designed to organize and categorize media files (photos, videos, and RAW images) based on their metadata. It is a more robust, user-friendly evolution of a PowerShell script previously used for similar tasks.

## Purpose

This application solves the common problem of organizing large collections of media files by:

- Analyzing file metadata (EXIF data, file system creation/modification dates)
- Creating structured folder hierarchies based on date information
- Generating CSV and JSON reports
- Storing file information in a SQLite database for future reference

## Features

- Multiple date source options: EXIF, file creation, or modification time
- Support for various image and video formats, including RAW
- MD5 hash generation for file integrity and duplicate detection
- CSV export and JSON console output
- SQLite database integration
- Fully configurable via JSON

---

## Getting Started

### Requirements

- .NET 6.0 or higher
- SQLite (bundled or installable)
- Windows OS (tested environment)

### Installation

1. Clone this repository or download the source code.
2. Build the solution using **Visual Studio** or the **.NET CLI**.
3. Ensure that a valid SQLite database file is accessible (or will be created at runtime).

### Configuration

Edit the `appsettings.json` file to set:

```jsonc
{
  "ConnectionString": "Data Source=.\\FileManipulator.db;Version=3",
  "ProviderName": "System.Data.SqlClient",
  "CSVExportPath": "C:\\ExportPath\\",
  "DateSource": "EXIF",
  "DestinationBase": "C:\\DestinationPath",
  "SourcePath": "C:\\SourcePath\\"
}
```

---

## Usage

1. Edit `appsettings.json` with your desired paths and settings.
2. Run the application via terminal or from Visual Studio.
3. Choose from the following options in the main menu:

   - `1`: View file info in JSON format
   - `2`: Export info to CSV
   - `3`: Import data into the database
   - `4`: View database contents
   - `0`: Exit

---

## How It Works

The core processing steps are:

1. **Configuration Parsing** – Reads from `appsettings.json`, validates paths.
2. **File Discovery** – Recursively finds supported files (e.g., `.jpg`, `.raw`, `.mp4`).
3. **Metadata Extraction** – Pulls EXIF and file system dates, and generates MD5 hashes.
4. **Destination Calculation** – Builds folder paths using a structure like: `Year/Month-Year/Day-Month-Year`. RAW images are sorted into a `RAW/` subfolder.
5. **Output Options** – Export to CSV, view data as JSON, or write to SQLite database.
6. _(Planned)_: File movement based on calculated structure.

![App Flow](docs/app-flow-diagram.svg)

---

## Project Structure

For full class, service, and interface documentation, refer to [`docs/PROJECT_FILES.md`](docs/PROJECT_FILES.md).

---

## Development Notes

Each source file contains a structured comment block detailing:

- Purpose and functionality
- Inputs and outputs
- Planned improvements
- Dependencies used

---

## Planned Improvements

### Code Architecture

- Expand interface-driven design
- Introduce dependency injection
- Add structured logging
- Improve error handling

### Feature Additions

- Duplicate detection
- Batch/incremental processing
- File previews
- Enhanced metadata extraction

### UI Enhancements

- Basic GUI frontend
- Progress indicators
- Visual reporting

### Performance Optimization

- Async and parallel file handling
- Stream-based metadata parsing
- Improved memory efficiency

---

## Technical Reference Appendix

### .NET Core Method Links

#### Directory Class

- [Directory.Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.exists)
- [Directory.GetFiles](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles)
- [Directory.CreateDirectory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.createdirectory)

#### File Class

- [File.Exists](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists)
- [File.GetCreationTime](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.getcreationtime)
- [File.GetLastWriteTime](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.getlastwritetime)
- [File.Move](https://docs.microsoft.com/en-us/dotnet/api/system.io.file.move)

#### Path Class

- [Path.GetExtension](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getextension)
- [Path.GetFileName](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.getfilename)
- [Path.Combine](https://docs.microsoft.com/en-us/dotnet/api/system.io.path.combine)

#### DateTime Struct

- [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)
- [DateTime.Parse](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.parse)

#### Cryptography

- [MD5.Create](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5.create)
- [BitConverter.ToString](https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter.tostring)

#### JSON Handling

- [JsonSerializer](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializer)
- [JsonSerializerOptions](https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions)

#### Configuration builder

- [ConfigurationBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationbuilder)
- [AddJsonFile](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.jsonconfigurationextensions.addjsonfile)

---

## Licensing Terms

See [LICENSE.md](LICENSE.md) for full license details.

### 🔓 Personal Use: GPL v3

- Free to use, modify, and distribute
- Requires source disclosure and attribution

### 💼 Commercial Use: Proprietary License

- Contact [joshua@rpdigi.net](mailto:joshua@rpdigi.net)
- Allows closed-source and commercial distribution

---

## Contributing

Pull requests and issues are welcome. Please:

1. Fork the repository
2. Create a feature branch
3. Submit a detailed pull request

---

## Acknowledgments

Created and maintained by **Joshua Porrata**
