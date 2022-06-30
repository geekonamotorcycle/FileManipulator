using FileManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class Get_FSLastWriteDate : IGet_Dates
    {
        private readonly string SourcePath;

        public DateTime ReturnedDateTime { get; private set; }

        public string sourcepath { get; set; } = string.Empty;
        public Get_FSLastWriteDate(string sourcepath)
        {
            SourcePath = sourcepath;
            GetFSLastWriteDateTime();
        }
        private void GetFSLastWriteDateTime()
        {
            DateTime date = File.GetLastWriteTime(SourcePath);
            ReturnedDateTime = date;
        }
    }

}
