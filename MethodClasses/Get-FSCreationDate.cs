using FileManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class Get_FSCreationDate : IGet_Dates
    {
        private string SourcePath;

        public DateTime ReturnedDateTime { get; private set; }

        public string sourcepath { get; set; } = string.Empty;

        public Get_FSCreationDate(string sourcepath)
        {
            SourcePath = sourcepath;
            GetFSCreationDateTime();
        }
        private void GetFSCreationDateTime()
        {
            DateTime date = File.GetCreationTime(SourcePath);
            ReturnedDateTime = date;
        }

    }
}
