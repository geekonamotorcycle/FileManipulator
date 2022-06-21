namespace FileManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string sFile = @"C: \Users\joshp\source\repos\FileManipulator\Config.xml";

            ReadConfigFile configfile = new ReadConfigFile(sFile);
            //Mmenu Menu;
            //Mmenu.Mainmenu();
            /**
            string readpath = @"C:\Users\joshp\OneDrive\Pictures\";
            string destpath = @"J:\desttest";
            GatherSourcePaths filepaths = new(readpath);
            string[] filepathlist = filepaths.Geteresults();


            foreach (string Looppath in filepathlist)
            {
                Fileinfo loopinfo = new(Looppath, destpath);
                Console.WriteLine(loopinfo.Writeresults());
            }
            Console.ReadLine(); 
            **/
        }
        }

    }