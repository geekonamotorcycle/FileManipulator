/*
 * FILE: Program.cs
 *
 * DESCRIPTION:
 * This is the entry point for the application. It initializes the main menu
 * and starts the application flow.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. DEPENDENCY INJECTION
 *    - Implement a proper DI container
 *    - Configure services through DI
 *    - Create a modular application structure
 *
 * 2. COMMAND LINE ARGUMENTS
 *    - Add support for command line arguments
 *    - Implement batch/automation mode via CLI
 *    - Create help documentation for command options
 *
 * 3. APPLICATION LIFECYCLE
 *    - Add proper startup and shutdown sequences
 *    - Implement configuration validation on startup
 *    - Create cleanup routines for application resources
 *
 * 4. LOGGING FRAMEWORK
 *    - Integrate a comprehensive logging framework
 *    - Configure different log levels and outputs
 *    - Add startup diagnostics and system information
 *
 * 5. ERROR HANDLING
 *    - Implement global exception handling
 *    - Add crash recovery mechanisms
 *    - Create detailed error reporting
 *
 * 6. MULTI-MODE SUPPORT
 *    - Add support for different UI modes (console, GUI, service)
 *    - Implement headless operation for servers
 *    - Create API endpoints for remote control
 *
 * 7. PERFORMANCE MONITORING
 *    - Add performance metrics collection
 *    - Implement resource usage tracking
 *    - Create diagnostics for troubleshooting
 *
 * 8. PLUGIN ARCHITECTURE
 *    - Design a plugin system for extensibility
 *    - Implement dynamic module loading
 *    - Create an SDK for third-party extensions
 */


using FileManipulator.Classes;
using FileManipulator.Interfaces;

namespace FileManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new();
        }
    }
}
