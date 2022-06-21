using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace FileManipulator
{
    public class Fileinfo
    {
        // Accepted public inputs
        public string sourcepath = @"default"; // This should be the fully qualified path to the file including the file name on whichever system you use.
        public string destinationbase = @"default"; // This should be just the base director, the subdirectories will be created based on date created or modified
        // Private String Objects
        private string filename = @"default";   // This is just the filename
        private string filextension = @"default";   //  This is the file extension
        private string createddestpath = @"default";    //  This is the destination path should we judge the file based on its created date set by the native file system
        private string modifieddestpath = @"default";   //  This is the destination path should we judge the file based on its modified date set by the native file system
        private string md5filehash; //  This is the MD5 Hash for the file
        private bool israw = false; // This tells the object if this is a recognized Raw type file
        private string[] rawextensions = { ".png",".3fr", ".ari", ".arw", ".bay", ".braw", ".crw", ".cr2", ".cr3", ".cap", ".data", ".dcs", ".dcr", ".dng", ".drf", ".eip", ".erf", ".fff", ".gpr", ".iiq", ".k25", ".kdc", ".mdc", ".mef", ".mos", ".mrw", ".nef", ".nrw", ".obm", ".orf", ".pef", ".ptx", ".pxn", ".r3d", ".raf", ".raw", ".rwl", ".rw2", ".rwz", ".sr2", ".srf", ".srw", ".tif", ".x3f" };   // Dependent on if the file is recognized as raw
        private string rawcreatetargetpath = @"default";    //  This is the destination path should we judge the file based on its created date set by the native file system (RAW)
        private string rawmodtargetpath = @"default";   //  This is the destination path should we judge the file based on its modified date set by the native file system (RAW)
        
        // Date Time Objects
        private DateTime createdDate;
        private DateTime modifieddate;
        
        //Constructor
        public Fileinfo(string sourcepath, string destinationbase)
        {
            //  Storing the public inputs
            this.sourcepath = sourcepath;
            this.destinationbase = destinationbase; 

            //  The following is dependent on the source file actually existing
            if (File.Exists(this.sourcepath))
            {
                //If the source file exists, gather details on it
                this.filename = Path.GetFileName(this.sourcepath);
                this.filextension = Path.GetExtension(this.sourcepath);
                this.createdDate = File.GetCreationTime(this.sourcepath);
                this.modifieddate = File.GetLastWriteTime(this.sourcepath);

                //  This section is where we generate an md5, this is more complicated than I woudld like
                MD5 md5 = MD5.Create();
                var stream = File.OpenRead(this.sourcepath);
                this.md5filehash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                md5.Clear();
                stream.Close();
                // This is where we release the allocated resources

                if (this.rawextensions.Contains(this.filextension))
                {
                    this.israw = true;
                }
                else
                {
                    this.israw = false;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The path to the source file at" + this.sourcepath + " is invalid");
                Console.ResetColor();
                throw new InvalidDataException("Invalid source file path");
            }
            
            //  The following is dependent on the destination base path actually existing
            if (Directory.Exists(this.destinationbase))
            {
                this.createddestpath = Path.Combine(destinationbase, this.createdDate.ToString("yyyy"), this.createdDate.ToString("MM-yyyy"), this.createdDate.ToString("MM-dd-yyyy"),this.filename);
                this.modifieddestpath = Path.Combine(destinationbase, this.modifieddate.ToString("yyyy"), this.modifieddate.ToString("MM-yyyy"), this.modifieddate.ToString("MM-dd-yyyy"), this.filename);
                if (this.israw)
                {
                    this.rawcreatetargetpath = Path.Combine(destinationbase, this.createdDate.ToString("yyyy"), this.createdDate.ToString("MM-yyyy"), this.createdDate.ToString("MM-dd-yyyy"),"RAW", this.filename);
                    this.rawmodtargetpath = Path.Combine(destinationbase, this.modifieddate.ToString("yyyy"), this.modifieddate.ToString("MM-yyyy"), this.modifieddate.ToString("MM-dd-yyyy"), "RAW", this.filename);
                }
                else
                {
                    this.rawcreatetargetpath = "Not Raw";
                    this.rawmodtargetpath = "Not Raw";
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The base path of " + " is not a valid path");
                Console.ResetColor();
                throw new InvalidDataException("Invalid Base Path");
            }
        }
        //  These are some public methods we will be implimenting
        public bool testfile(string sourcepath)
        {
            if (File.Exists(sourcepath))
            {
                return  true;
            }
            else
            {
                return  false;
            }
        }
        public bool Testdestinationbase(string destinationbase) {
            if (Directory.Exists(destinationbase))
            {
                return  true;
            }
            else
            {
                return false;
            }
        }
        //  This is for checking results
        public string Writeresults() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The file name is: " + this.filename);
            Console.WriteLine("The file extension is: " + this.filextension);
            Console.WriteLine("The file path is: " + this.sourcepath);
            Console.WriteLine("The file was created on: " + this.createdDate);
            Console.WriteLine("The file was last written on: " + this.modifieddate);
            Console.WriteLine("The MD5 Hash for this file is: " + this.md5filehash);
            Console.WriteLine("The file is raw: " + this.israw);
            Console.WriteLine("The output path for the creation date is: " + this.createddestpath);
            Console.WriteLine("The output path for the modified date is: " + this.modifieddestpath);
            Console.WriteLine("The output path for the RAW file creation date is: " + this.rawcreatetargetpath);
            Console.WriteLine("The output path for the RAW file modified date is: " + this.rawmodtargetpath);
            Console.ResetColor();
            return "End of info \n";
        }    
    }
}