using FileManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class Calculate_Destinations : ICalculate_Destinations
    {
        public DateTime DefaultDate { get; }
        public string SourceFileName { get; set; } = string.Empty;
        public string DesitnationBase { get; set; } = string.Empty;
        public bool IsRaw { get; set; }
        public DateTime EXCreationDate { get; set; }
        public DateTime FSCreationDate { get; set; }
        public DateTime FSLastWriteDate { get; set; }
        public string ExifOriginalDateDestination { get; private set; } = string.Empty;
        public string FSCreationDateDestination { get; private set; } = string.Empty;
        public string FSLastWriteDateDestination { get; private set; } = string.Empty;
        public string RAWExifOriginalDateDestination { get; private set; } = string.Empty;
        public string RAWFSCreationDateDestination { get; private set; } = string.Empty;
        public string RAWFSLastWriteDateDestination { get; private set; } = string.Empty;
        private string FileName { get; set; } = string.Empty;

        public Calculate_Destinations(string SourceFileName, string DesitnationBase, bool IsRaw, DateTime EXCreationDate, DateTime FSCreationDate, DateTime FSLastWriteDate, string DefaultTimeString)
        {

            this.DefaultDate = DateTime.Parse(DefaultTimeString);
            this.IsRaw = IsRaw;
            this.SourceFileName = SourceFileName;
            this.FileName = Path.GetFileName(SourceFileName);
            this.DesitnationBase = DesitnationBase;
            this.EXCreationDate = EXCreationDate;
            this.FSLastWriteDate = FSLastWriteDate;
            this.FSCreationDate = FSCreationDate;
            this.CalculateDEstinations();
        }

        private void CalculateDEstinations()
        {

            if (EXCreationDate != this.DefaultDate)
            {
                if (IsRaw)
                {
                    ExifOriginalDateDestination = Path.Combine(this.DesitnationBase,
                        this.EXCreationDate.ToString("yyyy"),
                        this.EXCreationDate.ToString("MM-yyyy"),
                        this.EXCreationDate.ToString("MM-dd-yyyy"),
                        "Raw",
                        this.FileName);
                }
                else
                {
                    ExifOriginalDateDestination = Path.Combine(this.DesitnationBase,
                        this.EXCreationDate.ToString("yyyy"),
                        this.EXCreationDate.ToString("MM-yyyy"),
                        this.EXCreationDate.ToString("MM-dd-yyyy"),
                        this.FileName);
                }
            }
            else
            {
                if (IsRaw)
                {
                    ExifOriginalDateDestination = Path.Combine(this.DesitnationBase,
                        this.FSCreationDate.ToString("yyyy"),
                        this.FSCreationDate.ToString("MM-yyyy"),
                        this.FSCreationDate.ToString("MM-dd-yyyy"),
                        "RAW",
                        this.FileName);
                }
                else
                {
                    ExifOriginalDateDestination = Path.Combine(this.DesitnationBase,
                        this.FSCreationDate.ToString("yyyy"),
                        this.FSCreationDate.ToString("MM-yyyy"),
                        this.FSCreationDate.ToString("MM-dd-yyyy"),
                        this.FileName);
                }
            }

            if (IsRaw)
            {
                FSCreationDateDestination = Path.Combine(this.DesitnationBase,
                    this.FSCreationDate.ToString("yyyy"),
                    this.FSCreationDate.ToString("MM-yyyy"),
                    this.FSCreationDate.ToString("MM-dd-yyyy"),
                    "RAW",
                    this.FileName);
            }
            else
            {
                FSCreationDateDestination = Path.Combine(this.DesitnationBase,
                    this.FSCreationDate.ToString("yyyy"),
                    this.FSCreationDate.ToString("MM-yyyy"),
                    this.FSCreationDate.ToString("MM-dd-yyyy"),
                    this.FileName);
            }

            if (IsRaw)
            {
                FSLastWriteDateDestination = Path.Combine(this.DesitnationBase,
                    this.FSLastWriteDate.ToString("yyyy"),
                    this.FSLastWriteDate.ToString("MM-yyyy"),
                    this.FSLastWriteDate.ToString("MM-dd-yyyy"),
                    "RAW",
                    this.FileName);
            }
            else
            {
                FSLastWriteDateDestination = Path.Combine(this.DesitnationBase,
                    this.FSLastWriteDate.ToString("yyyy"),
                    this.FSLastWriteDate.ToString("MM-yyyy"),
                    this.FSLastWriteDate.ToString("MM-dd-yyyy"),
                    this.FileName);
            }
        }

    }
}
