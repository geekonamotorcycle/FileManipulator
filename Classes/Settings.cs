using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace FileManipulator
{
    internal class Settings
    {
        public string SourcePath { get; private set; }
        public string DestinationBase { get; private set; }
        public string DateSource { get; private set; }

        public Settings()
        {
            var ConfigBuilder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json");
            var config = ConfigBuilder.Build();
            SourcePath = config["SourcePath"];
            DestinationBase = config["DestinationBase"];
            DateSource = config["DateSource"].ToLower();
        }

    }
}
