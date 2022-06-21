using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace FileManipulator
{
    internal class ReadConfigFile
    {
        public string configPath = "Default";

        public ReadConfigFile(string configPath)
        {
            
            string sFile = @"C:\Users\joshp\source\repos\FileManipulator\Config.xml";
            
            Console.WriteLine(sFile);
            
            XmlDocument configurationfile = new XmlDocument();
            configurationfile.ReadNode();
        }
        
        
    }
}
