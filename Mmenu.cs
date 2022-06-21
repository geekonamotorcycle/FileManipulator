using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace FileManipulator
{
    public class Mmenu 
    {
        public bool showMenu = true;

        public static bool Mainmenu()
        {
            bool showMenu = true;
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, "config.xml");
            string sFilePath = Path.GetFullPath(sFile);
            do while (showMenu == true)
                {
                    Console.WriteLine("I am a banana\n");
                    Console.WriteLine("in order to exit \nthe eternal domain \nof the banana,\nyou must type \nwtf ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            ReadConfigFile menuconfig = new ReadConfigFile(sFile);
                            break;
                        case "wtf":
                            Console.WriteLine("case wtf Triggered");
                            showMenu = false;
                            break;
                        default:
                            Console.WriteLine("Default Triggered");
                            showMenu = true;
                            break;
                    }
                } while (showMenu);
            return true;

        }
    }
}
