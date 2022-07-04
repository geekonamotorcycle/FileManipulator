using FileManipulator.Interfaces;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Directory = MetadataExtractor.Directory;

namespace FileManipulator
{
    internal class Get_EXIFDates : IGet_Dates
    {
        public string sourcepath { get; set; } = string.Empty;
        public DateTime ReturnedDateTime { get; private set; }

        public Get_EXIFDates(string sourcepath)
        {
            GetDateTimeOriginal(sourcepath);
        }
        private DateTime GetDateTimeOriginal(string sourcepath)
        {
            try
            {
                {
                    var directories = ImageMetadataReader.ReadMetadata(sourcepath);

                    foreach (var directory in directories)
                    {
                        foreach (var tag in directory.Tags)
                        {
                            if (tag.Name == "Date/Time Original")
                            {
                                if (string.IsNullOrEmpty(tag.Description))
                                    continue;
                                string d = tag.Description.Split(" ")[0].Replace(":", "-");
                                string t = tag.Description.Split(" ")[1];
                                //Console.WriteLine(DateTime.Parse($"{d} {t}"));
                                ReturnedDateTime = DateTime.Parse($"{d} {t}");
                                return DateTime.Parse($"{d} {t}");
                            }
                        }
                    }

                    ReturnedDateTime = DateTime.Parse("01/01/1970");
                    return ReturnedDateTime;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error for file {sourcepath}\nError was {e}");
                ReturnedDateTime = DateTime.Parse("01/01/1970");
                throw;
            }
        }
    }
}
