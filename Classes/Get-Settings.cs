/*
 * FILE: Get_Settings.cs
 *
 * DESCRIPTION:
 * This class handles loading and providing access to application configuration
 * from the appsettings.json file. It's a central point for all configurable
 * parameters used by the application.
 *
 * PLANNED IMPROVEMENTS:
 *
 * 1. CONFIGURATION VALIDATION
 *    - Add validation of settings values
 *    - Implement default values for missing settings
 *    - Add schema validation for the configuration file
 *
 * 2. STRONGLY TYPED CONFIGURATION
 *    - Use the Options Pattern from Microsoft.Extensions.Options
 *    - Create dedicated configuration section classes
 *    - Implement IOptions<T> for cleaner dependency injection
 *
 * 3. ENVIRONMENT SUPPORT
 *    - Add support for different environments (dev, test, prod)
 *    - Implement environment-specific configuration overrides
 *    - Support environment variables for sensitive settings
 *
 * 4. CONFIGURATION RELOADING
 *    - Implement hot reload of configuration changes
 *    - Add file watching to detect changes to appsettings.json
 *    - Provide notification mechanism for configuration changes
 *
 * 5. SECURITY IMPROVEMENTS
 *    - Add support for encrypted configuration values
 *    - Implement secure storage for sensitive settings
 *    - Add user-specific configuration options
 *
 * 6. ADVANCED CONFIGURATION
 *    - Add support for configuration hierarchies
 *    - Implement conditional configuration based on system properties
 *    - Support for complex configuration scenarios (arrays, nested objects)
 *
 * 7. RUNTIME CONFIGURATION
 *    - Add ability to modify settings at runtime
 *    - Implement persistence of user changes
 *    - Add configuration UI for common settings
 *
 * 8. LOGGING INTEGRATION
 *    - Add proper logging of configuration loading
 *    - Log configuration validation errors
 *    - Implement diagnostic logging for troubleshooting
 */

using Microsoft.Extensions.Configuration;

namespace FileManipulator
{
    internal class Get_Settings
    {
        public string SourcePath { get; private set; } = string.Empty;
        public string DestinationBase { get; private set; } = string.Empty;
        public string DateSource { get; private set; } = string.Empty;
        public string CSVExportPath { get; private set; } = string.Empty;
        public string ConnectionString { get; private set; } = string.Empty;
        public string ProviderName { get; private set; } = string.Empty;

        public Get_Settings()
        {
            GetSettings();
        }

        private void GetSettings()
        {
            try
            {
                var ConfigBuilder = new ConfigurationBuilder().AddJsonFile(
                    $"appsettings.json",
                    false,
                    true
                );
                var config = ConfigBuilder.Build();
                SourcePath = config["SourcePath"];
                DestinationBase = config["DestinationBase"];
                DateSource = config["DateSource"].ToLower();
                CSVExportPath = config["CSVExportPath"];
                ConnectionString = config["ConnectionString"];
                ProviderName = config["ProviderName"];
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was a problem \n{e}");
            }
        }

        public void PrintSettings()
        {
            GetSettings();
            Console.WriteLine(this.SourcePath);
            Console.WriteLine(this.DestinationBase);
            Console.WriteLine(this.DateSource);
            Console.WriteLine(this.CSVExportPath);
            Console.WriteLine(this.ConnectionString);
            Console.WriteLine(this.ProviderName);
        }
    }
}
