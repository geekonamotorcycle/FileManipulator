using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class PublicFileInformationModel
    {
        public string SourcePath { get; set; } = string.Empty;
        public string FileName { get;  set; } = string.Empty;
        public string FilExtension { get;  set; } = string.Empty;
        public int IsRAW { get;  set; }
        public string MD5FileHash { get;  set; } = string.Empty;
        public string DateSource { get;  set; } = string.Empty;
        public DateTime FSCreatedDate { get;  set; } = DateTime.Now;
        public DateTime FSModifiedDate { get;  set; } = DateTime.Now;
        public DateTime ExifOrigDate { get;  set; } = DateTime.Now;
        public string DestinationBase { get; set; } = string.Empty;
        public string EXIFdestpath { get;  set; } = string.Empty;
        public string FSCreatedDestPath { get;  set; } = string.Empty;
        public string FSModifiedDestPath { get;  set; } = string.Empty;
        public int FileMoved { get; set; }
    }
}
