using FileManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class FileInformationModel
    {
        public string SourcePath { get; set; } = string.Empty;
        public string DestinationBase { get; set; } = string.Empty;
        private string FileName { get; set; } = string.Empty;
        private string FilExtension { get; set; } = string.Empty;
        public string EXIFdestpath { get; private set; } = string.Empty;

        public string CreatedDestPath { get; private set; } = string.Empty;
        public string ModifiedDestPath { get; private set; } = string.Empty;
        public string MD5FileHash { get; private set; } = string.Empty;
        public bool IsRAW { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public DateTime ModifiedDate { get; private set; } = DateTime.Now;
        public DateTime ExifOrigDate { get; private set; } = DateTime.Now;

        public FileInformationModel(string SourcePath, string DesitnationBase)
        {
            this.SourcePath = SourcePath;
            DestinationBase = DesitnationBase;
            GetMD5Value();
            DetermineIfRaw();
            ExifOriginalDate();
            GetFSCreationDate();
            GetFSLastWriteDate();
            CalculateDest();

        }
        private void GetMD5Value()
        {
            IGet_MD5 md5 = new Get_MD5(SourcePath);
            MD5FileHash = md5.MD5Value;

        }
        private void DetermineIfRaw()
        {
            IGet_Raw rawStatus = new Get_Raw(SourcePath);
            IsRAW = rawStatus.IsRaw;
        }

        private void ExifOriginalDate()
        {
            IGet_Dates origdate = new Get_EXIFDates(SourcePath);
            ExifOrigDate = origdate.ReturnedDateTime;
        }
        private void GetFSCreationDate()
        {
            IGet_Dates origdate = new Get_FSCreationDate(SourcePath);
            CreatedDate = origdate.ReturnedDateTime;
        }
        private void GetFSLastWriteDate()
        {
            IGet_Dates origdate = new Get_FSLastWriteDate(SourcePath);
            ModifiedDate = origdate.ReturnedDateTime;
        }
        private void CalculateDest()
        {
            ICalculate_Destinations DestinationObject = new Calculate_Destinations(SourcePath, DestinationBase, IsRAW, ExifOrigDate, CreatedDate, ModifiedDate, "01/01/1970");
            CreatedDestPath = DestinationObject.FSCreationDateDestination;
            ModifiedDestPath = DestinationObject.FSLastWriteDateDestination;
            EXIFdestpath = DestinationObject.ExifOriginalDateDestination;
        }

    }
}
