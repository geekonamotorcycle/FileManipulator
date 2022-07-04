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
                var ConfigBuilder = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", false, true);
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

