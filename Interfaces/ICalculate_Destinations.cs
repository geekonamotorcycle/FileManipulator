namespace FileManipulator.Interfaces
{
    internal interface ICalculate_Destinations
    {
        DateTime DefaultDate { get; }
        bool IsRaw  { get; set; }
        string DesitnationBase { get; set; }
        DateTime EXCreationDate { get; set; }
        string ExifOriginalDateDestination { get; }
        DateTime FSCreationDate { get; set; }
        string FSCreationDateDestination { get; }
        DateTime FSLastWriteDate { get; set; }
        string FSLastWriteDateDestination { get; }
        string SourceFileName { get; set; }
    }
}